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
        private bool erUdgift;
        public static List<String> Kategorier = new List<string> { "Løn", "SU", "Gaver","Andet"};
        private string kategori;
        private DateTime dato;
        public int ListItemIndex;
        private ListViewItem listItem;
        public ListViewItem ListItem
        {
            get
            {
                return listItem;
            }
        }
        public static float SamledeUdgift
        {
            get
            {
                return sumUdgift;
            }
        }

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


        private static float sumUdgift = 0;
        private static float sumIndtægt = 0;
        public float Pris
        {
            get
            {
                return pris;
            }
        }
        public string Beskrivelse
        {
            get
            {
                return beskrivelse;
            } 
        }
        private float pris;
        private string beskrivelse;

        //DECLARATION
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

        public string GetInfo()
        {
            return (Beskrivelse + Pris.ToString());
        }

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
        public void Delete()
        {
            sumIndtægt -= pris;
        }
    }
}

