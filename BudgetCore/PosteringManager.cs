using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace BudgetCore
{
    class PosteringManager
    {
        //Singleton
        public static PosteringManager instance;

        //Filer
        public string dataDirectory { get; private set; }
        public string programData { get; private set; }
        public string currentBudget { get; private set; }
        public string i_kategori_fil { get; private set; }
        public string u_kategori_fil { get; private set; }
        public string posteringPath { get; private set; }
        public List<string> budgetFiles { get; private set; }

        public FileStream fs;

        //Postering liste
        List<Postering> posteringer;

        //Andre variable
        public int AntalPosteringer
        {
            get
            {
                return posteringer.Count;
            }
        }

        public string budgetName { get; private set; }

        //Liste med udgift og indtægt kategorier
        public  List<string> iKategorier { get; private set; }
        public  List<string> uKategorier { get; private set; }


        public PosteringManager()
        {
            instance = this;

            posteringer = new List<Postering>();
            budgetFiles = new List<string>();

            //Paths
            dataDirectory = AppDomain.CurrentDomain.BaseDirectory;
            dataDirectory = Path.GetFullPath(Path.Combine(dataDirectory, @"Data\"));
            programData = dataDirectory + "//ProgramData.txt";

            //Loader budget filerne ind i en liste og returnere den første. Denne benyttes når programmet åbnes.
            currentBudget = Path.Combine(dataDirectory, LoadBudgetFiles());
            posteringPath =  currentBudget + "//posteringFil.txt";
            i_kategori_fil = currentBudget + "//iKategoriFil.txt";
            u_kategori_fil = currentBudget + "//uKategoriFil.txt";


            //Kategorier
            //iKategorier = new List<string> { "Andet", "Arbejde", "Gaver I", "SU" };
            //uKategorier = new List<string> { "Abonnementer", "Andet / Store Køb", "Gaver", "Hverdag", "Mad", "Sjov", "Skole", "Telefon", "Tøj" };
            LoadKategorier();

            //Slet ubrugte budget-mapper
            DeleteUnreferencedBudgets();

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

        #region Saving And Loading

        public void Gem()
        {
            CheckProgramExistence();
            StreamWriter sw = new StreamWriter(posteringPath);

            foreach (Postering postering in posteringer)
            {
                sw.WriteLine(postering.GetSaveString());
            }
            sw.Close();
        }

        private void Load()
        {
            CheckProgramExistence();
            StreamReader sr = new StreamReader(posteringPath);
            string line = sr.ReadLine();

            while (line != null)
            {
                posteringer.Add(Unwrap(line));
                line = sr.ReadLine();
            }
            sr.Close();

        }
        public void LoadCVS()
        {
            StreamReader sr = new StreamReader(Path.Combine(dataDirectory, "ScriptPosteringer.txt"));
            string line = sr.ReadLine();

            while (line != null)
            {
                posteringer.Add(Unwrap(line));
                line = sr.ReadLine();
            }
            sr.Close();
            StreamWriter sw = new StreamWriter(Path.Combine(dataDirectory, "ScriptPosteringer.txt"));
            sw.Close();
        }

        public void RunScript()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = Path.Combine(dataDirectory, "StartScript.bat");
            proc.StartInfo.WorkingDirectory = dataDirectory;
            proc.Start();
        }
        private void DeleteUnreferencedBudgets()
        {
            foreach (string dir in Directory.GetDirectories(dataDirectory))
            {
                if (!(budgetFiles.Contains((dir.Split('\\')[dir.Split('\\').Length - 1]))))
                    Directory.Delete(dir,true);

            }
        }

        public void SkiftBudget(string budget)
        {
            StreamWriter sw = new StreamWriter(programData);
            sw.WriteLine(budget);
            foreach (string line in budgetFiles)
            {
                if (line == budget)
                    continue;
                sw.WriteLine(line);
            }
            sw.Close();
        }

        private string LoadBudgetFiles()
        {
            CheckProgramExistence();
            budgetFiles = new List<string>();
            StreamReader sr = new StreamReader(programData);
            budgetName = sr.ReadLine();
            budgetFiles.Add(budgetName);
            string line = sr.ReadLine();
            while (line != null)
            {
                budgetFiles.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
            return @budgetName;
        }

        public void WriteBudgets(List<string> budgets)
        {
            budgetFiles = new List<string>();
            StreamWriter sw = new StreamWriter(programData);
            foreach (string budget in budgets)
            {
                budgetFiles.Add(budget);
                sw.WriteLine(budget);
            }

            sw.Close();
            SkiftBudget(LoadBudgetFiles());

        }

        //Omdanner en gemt string til et Posteringsobjekt
        private Postering Unwrap(string input)
        {
            string[] args = input.Split(';');
            return (new Postering(args[0], Mathh.stringToFloat(args[1]), args[2], Convert.ToDateTime(args[3]), Convert.ToBoolean(args[4])));

        }

        public void WriteKategorier(List<string> nye_iKategorier, List<string> nye_uKategorier)
        {
            StreamWriter sw = new StreamWriter(i_kategori_fil);
            foreach (string kat in nye_iKategorier)
                sw.WriteLine(kat);
            sw.Close();

            sw = new StreamWriter(u_kategori_fil);
            foreach (string kat in nye_uKategorier)
                sw.WriteLine(kat);
            sw.Close();
            LoadKategorier();
        }


        public void LoadKategorier()
        {
            CheckProgramExistence();

            iKategorier = new List<string>();
            StreamReader sr = new StreamReader(i_kategori_fil);
            string line = sr.ReadLine();

            while (line != null)
            {
                iKategorier.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            uKategorier = new List<string>();
            sr = new StreamReader(u_kategori_fil);
            line = sr.ReadLine();

            while (line != null)
            {
                uKategorier.Add(line);
                line = sr.ReadLine();
            }


            sr.Close();
        }

        private void CheckProgramExistence()
        {
            if (!Directory.Exists(dataDirectory))
                Directory.CreateDirectory(dataDirectory);

            if (!Directory.Exists(currentBudget))
                Directory.CreateDirectory(currentBudget);

            if (!File.Exists(posteringPath))
            {
                fs = File.Create(posteringPath);
                fs.Close();
            }

            if (!File.Exists(programData))
            {
                fs = File.Create(programData);
                fs.Close();
            }

            if (!File.Exists(i_kategori_fil))
            {
                fs = File.Create(i_kategori_fil);
                fs.Close();

                StreamWriter sw = new StreamWriter(i_kategori_fil);
                sw.WriteLine("Løn");
                sw.WriteLine("SU");
                sw.WriteLine("Gaver");
                sw.WriteLine("Andet");
                sw.WriteLine("Hussling");
                sw.Close();
            }

            if (!File.Exists(u_kategori_fil))
            {
                fs = File.Create(u_kategori_fil);
                fs.Close();
                StreamWriter sw = new StreamWriter(u_kategori_fil);
                sw.WriteLine("Mad");
                sw.WriteLine("Gaver");
                sw.WriteLine("Tøj");
                sw.WriteLine("Hverdag");
                sw.WriteLine("Skole");
                sw.WriteLine("Coke");
                sw.Close();
            }
            if (!Directory.Exists(currentBudget))
                Directory.CreateDirectory(currentBudget);

        }


         

        #endregion

        #region Liste Manipulation
        //Finder og returnere en postering givet et listviewItem
        public Postering GetPostering(ListViewItem item)
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
        }

        public List<Postering> GetAllePosteringer()
        {
            return posteringer;
        }


        public List<Postering> SøgPosteringer(List<string> tilladte_u_kat, List<string> tilladte_i_kat, List<string> tilladte_typer, string min, string max, int datoSearch, DateTime minDato, DateTime maxDato)
        {
            List<Postering> søgResultat = new List<Postering>();

            float i_min = Mathh.stringToFloat(min);
            float i_max = Mathh.stringToFloat(max);

            DateTime UgeStart = DateTime.Today;
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    UgeStart = UgeStart.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    UgeStart = UgeStart.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    UgeStart = UgeStart.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    UgeStart = UgeStart.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    UgeStart = UgeStart.AddDays(-5);
                    break;
                case DayOfWeek.Sunday:
                    UgeStart = UgeStart.AddDays(-6);
                    break;
            }



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
                if (postering.Pris < i_min && i_min != 0)
                    continue;

                if (postering.Pris > i_max && i_max != 0)
                    continue;
                switch (datoSearch)
                {
                    //År
                    case 1:
                        if (postering.dato.Year != DateTime.Now.Year)
                            continue;
                        break;
                    //Måned
                    case 2:
                        if (postering.dato.Month != DateTime.Now.Month || postering.dato.Year != DateTime.Now.Year)
                            continue;
                        break;
                    //Uge
                    case 3:
                        if (DateTime.Compare(postering.dato, UgeStart) < 0)
                            continue;
                        else if (DateTime.Compare(postering.dato, DateTime.Now) > 0)
                            continue;
                        break;

                    //Dag
                    case 4:
                        if (postering.dato.Day != DateTime.Now.Day ||
                            postering.dato.Month != DateTime.Now.Month ||
                            postering.dato.Year != DateTime.Now.Year)
                            continue;
                        break;
                    
                    //Specifikt
                    case 5:
                        if (DateTime.Compare(postering.dato, maxDato) > 0)
                            continue;
                        else if (DateTime.Compare(postering.dato, minDato) < 0)
                            continue;
                        break;
                }

                søgResultat.Add(postering);
            }

            return søgResultat;

        }
        public List<Postering> SøgPosteringerTekst(string text)
        {
            List<Postering> resultat_list = new List<Postering>();
            text = text.ToLower();
            foreach (Postering post in posteringer)
            {
                if (post.Beskrivelse.ToLower().Contains(text))
                    resultat_list.Add(post);
            }
            return resultat_list;
        }
        #endregion

        #region Testing
        //TESTING PURPOSES

        public void OpretSamplePosteringer()
        {

            for (int i = 0; i < 200; i++)
            {
                posteringer.Add(new Postering("Tilfældig postering nr. " + i.ToString()));
            }

        }

        #endregion


      
    }
}
