using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;


namespace BudgetCore
{
    class Postering
    {

        public static string valuta = " kr.";
        private Random rnd = new Random();



        //Private posteringsvariabler
        public string kategori { get; private set; }
        public DateTime dato { get; private set; }
        public bool erUdgift { get; private set; }

        //Static properties
        private static int antal = 0;
        public static int Antal
        {
            get
            {
                return antal;
            }
        }

        private static float sumUdgift = 0;
        public static float SamledeUdgift
        {
            get
            {
                return sumUdgift;
            }
        }

        private static float sumIndtægt = 0;
        public static float SamledeIndtægt
        {
            get
            {
                return sumIndtægt;
            }
        }

        public static float Balance
        {
            get
            {
                return sumIndtægt - sumUdgift;
            }
        }

        //Properties
        private ListViewItem listItem;
        public ListViewItem ListItem
        {
            get
            {
                return listItem;
            }
        }

        private float pris;
        public float Pris
        {
            get
            {
                return pris;
            }
        }

        private string beskrivelse;
        public string Beskrivelse
        {
            get
            {
                return beskrivelse;
            }
        }


        //DECLARATION giver værdier til alle fields =======================================================================================================================
        public Postering(string navn, float beløb, string kat, DateTime date, bool udgift)
        {
            pris = beløb;
            beskrivelse = navn;
            kategori = kat;
            dato = date;

            if (udgift == true)
            {
                sumUdgift += pris;
                erUdgift = true;
            }
            else
            {
                sumIndtægt += pris;
                erUdgift = false;
            }
            antal++;
            MakeListItem();
        }

        //Opret tilfældig postering
        public Postering(string navn)
        {
            Thread.Sleep(2);
            int Seed = (int)DateTime.Now.Ticks;
            rnd = new Random(Seed);

            beskrivelse = navn;
            pris = rnd.Next(1, 2000);
            int i = rnd.Next(0, 2);
            int n;
            if (i == 0)
            {
                erUdgift = true;
                sumUdgift += pris;
                n = rnd.Next(0, PosteringManager.uKategorier.Count);
                kategori = PosteringManager.uKategorier[n];
            }
            else
            {
                erUdgift = false;
                sumIndtægt += pris;
                n = rnd.Next(0, PosteringManager.iKategorier.Count);
                kategori = PosteringManager.iKategorier[n];
            }

            dato = RandomDay();


            antal++;
            MakeListItem();
        }

        public static void UpdateKategorier()
        {
            iKategorier = new List<string>();
            StreamReader sr = new StreamReader(PosteringManager.i_path);
            string line = sr.ReadLine();

            while (line != null)
            {
                iKategorier.Add(line);
                line = sr.ReadLine();
            }


            sr.Close();

            uKategorier = new List<string>();
            sr = new StreamReader(PosteringManager.u_path);
            line = sr.ReadLine();

            while (line != null)
            {
                uKategorier.Add(line);
                line = sr.ReadLine();
            }


            sr.Close();
        }

        //Laver et list item som har alle værdier til tabellen. Gemmes i en public readonly property
        private void MakeListItem()
        {
            string s = string.Format("{0:N2}" + valuta, pris);
            listItem = new ListViewItem(Beskrivelse);
            listItem.SubItems.Add(dato.ToString());
            listItem.SubItems.Add(s);
            listItem.SubItems.Add(kategori);

            if (erUdgift)
                listItem.SubItems.Add("Udgift");
            else
                listItem.SubItems.Add("Indtægt");

        }
        //Ændrer sum indtægter eller udgifter når slettet
        public void Delete()
        {
            if (erUdgift)
                sumUdgift -= pris;
            else
                sumIndtægt -= pris;
            antal--;
        }
        public string GetSaveString()
        {
            return (Beskrivelse + ";" + pris.ToString() + ";" + kategori + ";" + dato.ToString() + ";" + erUdgift.ToString());
        }

        private Random gen = new Random();
        private DateTime RandomDay()
        {
            DateTime start = new DateTime(2016, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
