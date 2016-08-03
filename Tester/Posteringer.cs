using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    
    class Posteringer
    {


        //Liste med udgift og indtægt kategorier
        public static List<string> iKategorier = new List<string> { "Løn", "SU", "Gaver","Andet"};
        public static List<string> uKategorier = new List<string> { "Mad", "Gaver", "Tøj", "Abonnementer", "Andet" };
        
        //Private posteringsvariabler
        private string kategori;
        private DateTime dato;
        private bool erUdgift;

        //Static properties
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
        public Posteringer(string navn, float beløb, string kat, DateTime date, bool udgift)
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
 
            MakeListItem();
        }

        //Laver et list item som har alle værdier til tabellen. Gemmes i en public readonly property
        private void MakeListItem()
        {
            listItem = new ListViewItem(Beskrivelse);
            listItem.SubItems.Add(dato.ToString());
            listItem.SubItems.Add(Pris.ToString()+" Kr.");
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
        }
    }
}

