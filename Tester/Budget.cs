using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class Budget : Form
    {
        List<Posteringer> udgifter;
        List<Posteringer> indtægter;

        public Budget()
        {
            InitializeComponent();
            udgifter = new List<Posteringer>();
            indtægter = new List<Posteringer>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrepareControls();
        }

        //Opret postering BLIVER KALDT AF DE TO OPRET KNAPPER
        private void OpretPostering(object sender, EventArgs e)
        {
            string beskrivelse;
            string beløb;
            string kategori;
            DateTime date;
            bool erUdgift;

            //Hvis intægtknappen trykkes oprettes en indtægt
            if (sender == btnOpret_i)
            {
                beskrivelse = txtBeskrivelse_i.Text;
                beløb = txtBeløb_i.Text;
                kategori = cBoxKategori_i.SelectedItem.ToString();
                date = datePicker_i.Value;
                erUdgift = false;

                Posteringer postering = new Posteringer(beskrivelse, Mathh.stringToFloat(beløb), kategori, date, erUdgift);
                listPosteringer.Items.Add(postering.ListItem);
                indtægter.Add(postering);
            }

            //Hvis udgiftknappen trykkes oprettes en udgift
            else if (sender == btnOpret_u)
            {
                beskrivelse = txtBeskrivelse_u.Text;
                beløb = txtBeløb_u.Text;
                kategori = cBoxKategori_u.SelectedItem.ToString();
                date = datePicker_u.Value;
                erUdgift = true; 

                Posteringer postering = new Posteringer(beskrivelse, Mathh.stringToFloat(beløb), kategori, date, erUdgift);
                listPosteringer.Items.Add(postering.ListItem);
                udgifter.Add(postering);
            }

            lblBalance.Text = Posteringer.Balance.ToString() + "   " + indtægter.Count.ToString();
        }



        //Sletter de valgte udgifter og opdatterer label (Sender = KNAP)
        private void SletPosteringer(object sender, EventArgs e)
        {
            Posteringer postering;
            foreach (ListViewItem hej in listPosteringer.SelectedItems)
            {
                postering = GetPostering(hej);

                if (udgifter.Contains(postering))
                    udgifter.Remove(postering);

                else if (indtægter.Contains(postering))
                    indtægter.Remove(postering);

                else
                    throw new System.InvalidOperationException("Posteringen var hverken i indtægterlisten eller i udgifter listen");

                postering.Delete();
                listPosteringer.Items.Remove(hej);
            }

            lblBalance.Text = Posteringer.Balance.ToString() +"   "+ indtægter.Count.ToString();
        }

        //Finder og returnere en postering givet et listviewItem
        private Posteringer GetPostering(ListViewItem item)
        {
            foreach (Posteringer ipostering in indtægter)
                if (ipostering.ListItem == item)
                    return ipostering;

            foreach (Posteringer upostering in udgifter)
                if (upostering.ListItem == item)
                    return upostering;

            //Hvis posteringen ikke findes - hvilket ikke burde ske - opstår der er en error
            throw new System.InvalidOperationException("Item was not found, something went wrong");

        }

        //Sætter udgift-tabbens controls' positioner og størrelse til dem i indtægt-tabben
        //Tilføjer items til dropdownlister
        private void PrepareControls()
        {
            foreach (string kategori in Posteringer.iKategorier)
                cBoxKategori_i.Items.Add(kategori);

            cBoxKategori_i.SelectedIndex = 0;

            foreach (string kategori in Posteringer.uKategorier)
                cBoxKategori_u.Items.Add(kategori);

            cBoxKategori_u.SelectedIndex = 0;

            lblBeløb_u.Location = lblBeløb_i.Location;
            lblBeløb_u.Size = lblBeløb_i.Size;

            lblBeskrivelse_u.Location = lblBeskrivelse_i.Location;
            lblBeskrivelse_u.Size = lblBeskrivelse_i.Size;

            lblDato_u.Location = lblDato_i.Location;
            lblDato_u.Size = lblDato_i.Size;

            txtBeløb_u.Location = txtBeløb_i.Location;
            txtBeløb_u.Size = txtBeløb_i.Size;

            txtBeskrivelse_u.Location = txtBeskrivelse_i.Location;
            txtBeskrivelse_u.Location = txtBeskrivelse_i.Location;

            cBoxKategori_u.Location = cBoxKategori_i.Location;
            cBoxKategori_u.Size = cBoxKategori_i.Size;

            datePicker_u.Location = datePicker_i.Location;
            datePicker_u.Size = datePicker_i.Size;

            btnOpret_u.Location = btnOpret_i.Location;
            btnOpret_u.Size = btnOpret_i.Size;
        }


    }
}
