using System.Windows.Forms;
using BudgetCore;
using System;

namespace BudgetProgram
{
    public partial class EditPosteringForm : Form
    {
        public bool posteringRedigeret = false;
        private PosteringManager posteringManager = PosteringManager.instance;
        public EditPosteringForm(ListViewItem listPostering)
        {
            Console.WriteLine("Clicked");
            InitializeComponent();
            Postering postering = posteringManager.GetPostering(listPostering);
            txtBeløb.Text = postering.Pris.ToString();
            txtBeskrivelse.Text = postering.Beskrivelse;
            datePicker.Value = postering.dato;
            cboxType.SelectedIndex = boolToInt(postering.erUdgift);
            UpdateKategoriListe();
            if (cBoxKategori.Items.Contains(postering.kategori))
                cBoxKategori.SelectedIndex = cBoxKategori.Items.IndexOf(postering.kategori);

        }
        private int boolToInt(bool boolean)
        {
            if (boolean == true) { return 1; }
            else return 0;
        }

        private bool intToBool(int integer)
        {
            if (integer != 0) { return true; }
            else return (false);
        }

        private void EditPosteringForm_Load(object sender, EventArgs e)
        {
            
        }


        private void btnOpret_Click(object sender, EventArgs e)
        {
            int status = posteringManager.OpretPostering(txtBeskrivelse.Text, txtBeløb.Text, cBoxKategori.SelectedItem.ToString(), datePicker.Value, intToBool(cboxType.SelectedIndex));
            if (status == 0) {
                posteringRedigeret = true;
                this.Close();
            }
            else { lblError.Text = Budget.instance.GetStatusMessage(status); }
        }

        private void UpdateKategoriListe()
        {
            cBoxKategori.Items.Clear();
            if (cboxType.SelectedIndex == 1)
            {
                foreach (string kat in posteringManager.uKategorier)
                {
                    cBoxKategori.Items.Add(kat);
                }
            }
            else
            {
                foreach (string kat in posteringManager.iKategorier)
                {
                    cBoxKategori.Items.Add(kat);
                }
            }
            cBoxKategori.SelectedIndex = 0;
        }

        private void cboxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateKategoriListe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
