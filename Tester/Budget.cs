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
            foreach (string kategori in Posteringer.Kategorier)
            {
                cBoxKategori_i.Items.Add(kategori);
            }
            cBoxKategori_i.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetControlPositions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string beskrivelse = txtBeskrivelse_i.Text;
            string beløb = txtBeløb_i.Text;
            DateTime date = datePicker_i.Value;
            Posteringer ny = new Posteringer(beskrivelse, Mathh.stringToFloat(beløb), cBoxKategori_i.SelectedItem.ToString(), date, false);
            listPosteringer.Items.Add(ny.ListItem);
            ny.ListItemIndex = listPosteringer.Items.IndexOf(ny.ListItem);
            indtægter.Add(ny);

            lblBalance.Text = Posteringer.Balance.ToString() + "   " + indtægter.Count.ToString();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            Posteringer postering;
            foreach (ListViewItem hej in listPosteringer.SelectedItems)
            {
                postering = GetPostering(hej);
                indtægter.Remove(postering);
                postering.Delete();
                listPosteringer.Items.Remove(hej);
            }

            lblBalance.Text = Posteringer.Balance.ToString() +"   "+ indtægter.Count.ToString();
        }
        // void DeleteListItem(int index)


        private Posteringer GetPostering(ListViewItem item)
        {
            foreach (Posteringer postering in indtægter)
            {
                if (postering.ListItem == item)
                    return postering;
            }
            return new Posteringer("lol",666,"xd", new DateTime() ,false);

        }

        private void btnIndstillinger_Click(object sender, EventArgs e)
        {
            
        }


        //Sætter udgift-tabbens controls' positioner og størrelse til dem i indtægt-tabben
        private void SetControlPositions()
        {
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

            cBoxKategorier_u.Location = cBoxKategori_i.Location;
            cBoxKategorier_u.Size = cBoxKategori_i.Size;

            datePicker_u.Location = datePicker_i.Location;
            datePicker_u.Size = datePicker_i.Size;
        }
    }
}
