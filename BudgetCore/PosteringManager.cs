using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace BudgetCore
{
    class PosteringManager
    {
        //IO Paths

        public static string dirPath;
        public static string i_path;
        public static string u_path;
        public static string posteringPath;

        //Postering liste

        List<Postering> posteringer;

        //Liste med udgift og indtægt kategorier

        public static List<string> iKategorier { get; private set; }
        public static List<string> uKategorier { get; private set; }
        public static int AntalPosteringer
        {
            get
            {
                return Postering.Antal;
            }
        }


        public PosteringManager()
        {
            posteringer = new List<Postering>();

            //Paths
            dirPath = AppDomain.CurrentDomain.BaseDirectory;
            dirPath = Path.GetFullPath(Path.Combine(dirPath, @"..\..\..\Data\"));
            posteringPath = dirPath + "//posteringFil.txt";
            i_path = dirPath + "//iKategoriFil.txt";
            u_path = dirPath + "//uKategoriFil.txt";



            //Kategorier
            iKategorier = new List<string> { "Andet", "Arbejde", "Gaver I", "SU" };
            uKategorier = new List<string> { "Abonnementer", "Andet / Store Køb", "Gaver", "Hverdag", "Mad", "Sjov", "Skole", "Telefon", "Tøj" };
            UpdateKategorier();



            //Load posteringer
            Load();
        }

        //Opret postering
        public int OpretPostering(string beskrivelse, string beløb, string kategori, DateTime dato, bool erUdgift)
        {
            float int_beløb;
            beskrivelse = beskrivelse.Trim(' ');
            int_beløb = Mathh.Round(Mathh.stringToFloat(beløb), 2);

            if (int_beløb <= 0)
                return 1;   //Invalid beløb

            else if (beskrivelse == "")
                return 2;   //Invalid beskrivelse

            else if (beskrivelse.Contains(";"))
                return 3;   //brug af semicolon i beskrivelse

            else
            {
                Postering postering = new Postering(beskrivelse, int_beløb, kategori, dato, erUdgift);
                posteringer.Add(postering);

                return 0;   //Intet galt
            }

        }



        /*
        private void SletPosteringer(List<Postering> sletListe)
        {
            foreach (Postering post in sletListe)
            {
                if (posteringer.Contains(post))
                    posteringer.Remove(post);
                else
                    throw new System.InvalidOperationException("Posteringen var hverken i indtægterlisten eller i udgifter listen");

                post.Delete();
            }
        }
        */
        #region Saving And Loading

        public void Gem()
        {

            StreamWriter sw = new StreamWriter(posteringPath);

            foreach (Postering postering in posteringer)
            {
                sw.WriteLine(postering.GetSaveString());
            }
            sw.Close();
        }

        private void Load()
        {
            StreamReader sr = new StreamReader(posteringPath);
            string line = sr.ReadLine();

            while (line != null)
            {
                posteringer.Add(Unwrap(line));
                line = sr.ReadLine();
            }
            sr.Close();

        }

        //Omdanner en gemt string til et Posteringsobjekt
        private Postering Unwrap(string input)
        {
            char semicolon = ';';
            string[] args = input.Split(semicolon);
            return (new Postering(args[0], Mathh.stringToFloat(args[1]), args[2], Convert.ToDateTime(args[3]), Convert.ToBoolean(args[4])));

        }
        #endregion

        #region Liste Manipulation
        //Finder og returnere en postering givet et listviewItem
        private Postering GetPostering(ListViewItem item)
        {
            foreach (Postering postering in posteringer)
                if (postering.ListItem == item)
                    return postering;


            //Hvis posteringen ikke findes - hvilket ikke burde ske - opstår der er en error
            throw new System.InvalidOperationException("Item was not found, something went wrong");

        }

        public void SletPostering(ListViewItem postItem)
        {
            Postering postering = GetPostering(postItem);
            posteringer.Remove(postering);
            postering.Delete();
        }

        public List<ListViewItem> GetAllePosteringer()
        {
            List<ListViewItem> listViewAllePosteringer = new List<ListViewItem>();

            foreach (Postering postering in posteringer)
                listViewAllePosteringer.Add(postering.ListItem);

            return listViewAllePosteringer;
        }


        public List<ListViewItem> SøgPosteringer(List<string> tilladte_u_kat, List<string> tilladte_i_kat, List<string> tilladte_typer, string min, string max, int datoSearch, DateTime minDato, DateTime maxDato)
        {
            List<ListViewItem> søgResultat = new List<ListViewItem>();

            float i_min = Mathh.stringToFloat(min);
            float i_max = Mathh.stringToFloat(max);


            //Cycle through all posteringer
            foreach (Postering postering in posteringer)
            {
                if (tilladte_typer.Contains("Udgift") && postering.erUdgift == true)
                {
                    if (!(tilladte_u_kat.Contains(postering.kategori)))
                        continue;
                }
                else if (tilladte_typer.Contains("Indtægt") && postering.erUdgift == false)
                {
                    if (!(tilladte_i_kat.Contains(postering.kategori)))
                        continue;
                }
                else
                    continue;

                if (postering.Pris < i_min)
                    continue;

                if (postering.Pris > i_max)
                    continue;

                if (datoSearch == 3)    //Specifikt
                {
                    if (DateTime.Compare(postering.dato, maxDato) > 0)
                        continue;
                    else if (DateTime.Compare(postering.dato, minDato) < 0)
                        continue;
                }

                else if (datoSearch == 2)   //Måned
                    if (postering.dato.Month != DateTime.Now.Month || postering.dato.Year != DateTime.Now.Year)
                        continue;

                søgResultat.Add(postering.ListItem);
            }

            return søgResultat;

        }
        #endregion

        #region Testing
        //TESTING PURPOSES

        public void OpretSamplePosteringer()
        {

            for (int i = 0; i < 50; i++)
            {
                posteringer.Add(new Postering("Tilfældig postering nr. " + i.ToString()));
            }

        }

        #endregion


        public static void UpdateKategorier()
        {
            iKategorier = new List<string>();
            StreamReader sr = new StreamReader(i_path);
            string line = sr.ReadLine();

            while (line != null)
            {
                iKategorier.Add(line);
                line = sr.ReadLine();
            }


            sr.Close();

            uKategorier = new List<string>();
            sr = new StreamReader(u_path);
            line = sr.ReadLine();

            while (line != null)
            {
                uKategorier.Add(line);
                line = sr.ReadLine();
            }


            sr.Close();
        }
    }
}
