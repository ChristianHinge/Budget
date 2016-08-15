using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using BudgetCore;

namespace BudgetProgram
{
    public partial class Budget : Form
    {

        List<Posteringer> posteringer;
        public static Budget instance = null;
        Indstillinger formIndstillinger;

        //Excel
        Excel.Application excelApp;
        Excel._Workbook excelWorkbook;
        
        public Budget()
        {
            InitializeComponent();
            //dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


            instance = this;
            Posteringer.UpdateKategorier();
            posteringer = new List<Posteringer>();
            Load_Posteringer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrepareControls();
            SøgPosteringer();
        }

        //Opret postering BLIVER KALDT AF DE TO OPRET KNAPPER
        private void OpretPostering(object sender, EventArgs e)
        {
            string beskrivelse;
            float beløb;
            string kategori;
            DateTime date;
            bool erUdgift;

            //Hvis intægtknappen trykkes oprettes en indtægt
            if (sender == btnOpret_i)
            {
                beskrivelse = txtBeskrivelse_i.Text;
                beskrivelse = beskrivelse.Trim(' ');
                beløb = Mathh.Round(Mathh.stringToFloat(txtBeløb_i.Text),2);
                kategori = cBoxKategori_i.SelectedItem.ToString();
                date = datePicker_i.Value;
                erUdgift = false;
                if (beløb <= 0)
                {
                    lblError_i.Text = "*Kun positive beløb accepteres";
                    return;
                }
                if (beskrivelse == "")
                {
                    lblError_i.Text = "*Mangler beskrivelse";
                    txtBeskrivelse_i.Text = "";
                    return;
                }
                if (beskrivelse.Contains(";"))
                {
                    lblError_i.Text = "*Ulovligt bogstav: ';'";
                    return;
                }
                lblError_i.Text = "";
            }

            //Hvis udgiftknappen trykkes oprettes en udgift
            else 
            {
                beskrivelse = txtBeskrivelse_u.Text;
                beskrivelse = beskrivelse.Trim(' ');
                beløb = Mathh.Round(Mathh.stringToFloat(txtBeløb_u.Text), 2);
                kategori = cBoxKategori_u.SelectedItem.ToString();
                date = datePicker_u.Value;
                erUdgift = true;
                if (beløb <= 0)
                {

                    lblError_u.Text = "*Kun positive beløb accepteres";
                    return;
                }
                if (beskrivelse == "")
                {
                    lblError_u.Text = "*Mangler beskrivelse";
                    txtBeskrivelse_u.Text = "";
                    return;
                }
                if (beskrivelse.Contains(";"))
                {
                    lblError_u.Text = "*Ulovligt bogstav: ';'";
                    return;
                }
                lblError_u.Text = "";
            }

            Posteringer postering = new Posteringer(beskrivelse, beløb, kategori, date, erUdgift);
            posteringer.Add(postering);
            UpdatePoseringsLabel();
        }



        //Sletter de valgte udgifter og opdatterer label (Sender = KNAP)
        private void SletPosteringer(object sender, EventArgs e)
        {
            string prompt = "Er du sikker på at du ønsker at slette nedenstående postering(er)?\n";
            //Finder navnene på de valgte list items
            foreach (ListViewItem hej in listPosteringer.SelectedItems)
                prompt += "\n" + hej.SubItems[0].Text;

            if (!(MessageBox.Show(prompt, "Sletning af posteringer", MessageBoxButtons.OKCancel) == DialogResult.OK))
                return;

            Posteringer postering;
            foreach (ListViewItem hej in listPosteringer.SelectedItems)
            {
                postering = GetPostering(hej);

                if (posteringer.Contains(postering))
                    posteringer.Remove(postering);
                else
                    throw new System.InvalidOperationException("Posteringen var hverken i indtægterlisten eller i udgifter listen");

                UpdatePoseringsLabel();
                postering.Delete();
                listPosteringer.Items.Remove(hej);
            }
        }
        
        #region Control Handeling
        //Sætter udgift-tabbens controls' positioner og størrelse til dem i indtægt-tabben
        //Tilføjer items til dropdownlister
        private void PrepareControls()
        {
            ControlValuesToDefault();

            lblBeløb_u.Location = lblBeløb_i.Location;
            lblBeløb_u.Size = lblBeløb_i.Size;

            lblBeskrivelse_u.Location = lblBeskrivelse_i.Location;
            lblBeskrivelse_u.Size = lblBeskrivelse_i.Size;

            lblDato_u.Location = lblDato_i.Location;
            lblDato_u.Size = lblDato_i.Size;

            txtBeløb_u.Location = txtBeløb_i.Location;
            txtBeløb_u.Size = txtBeløb_i.Size;

            txtBeskrivelse_u.Location = txtBeskrivelse_i.Location;
            txtBeskrivelse_u.Size = txtBeskrivelse_i.Size;

            cBoxKategori_u.Location = cBoxKategori_i.Location;
            cBoxKategori_u.Size = cBoxKategori_i.Size;

            datePicker_u.Location = datePicker_i.Location;
            datePicker_u.Size = datePicker_i.Size;

            btnOpret_u.Location = btnOpret_i.Location;
            btnOpret_u.Size = btnOpret_i.Size;

            lblError_i.Text = "";
            lblError_u.Text = "";
            lblError_u.Location = lblError_i.Location;
            lblError_u.Size = lblError_i.Size;

            cListKategorier_u.Size = cListKategorier_i.Size;
            cboxBegræns.Checked = false;
            gboxSøg.Hide();
        }

        public void ControlValuesToDefault()
        {
            cBoxKategori_i.Items.Clear();
            cBoxKategori_u.Items.Clear();
            cListKategorier_i.Items.Clear();
            cListKategorier_u.Items.Clear();

            //Lists indtægter
            foreach (string kategori in Posteringer.iKategorier)
            {
                cBoxKategori_i.Items.Add(kategori);
                cListKategorier_i.Items.Add(kategori, true);
            }
            cBoxKategori_i.SelectedIndex = 0;

            //Lists udgifter
            foreach (string kategori in Posteringer.uKategorier)
            {
                cBoxKategori_u.Items.Add(kategori);
                cListKategorier_u.Items.Add(kategori, true);
            }
            cBoxKategori_u.SelectedIndex = 0;

            cListType.Items.Clear();
            cListType.Items.Add("Indtægt", true);
            cListType.Items.Add("Udgift", true);

            UpdatePoseringsLabel();

            dateTimeStart.Value = DateTime.Now.Date.AddMonths(-1);
            dateTimeStart.MaxDate = DateTime.Now.Date.AddDays(1);
            dateTimeSlut.Value = DateTime.Now.Date.AddDays(1);

            cboxAlleDatoer.Checked = true;

            txtBoxMax.Text = "";
            txtBoxMin.Text = "";
        }
        #endregion

        #region Saving And Loading

        private void btnGem_Click(object sender, EventArgs e)
        {
            PosteringMangager.Gem();
        }

        //Omdanner en gemt string til et Posteringsobjekt
        private Posteringer Unwrap(string input)
        {
            char semicolon = ';';
            string[] args = input.Split(semicolon);
            return (new Posteringer(args[0], Mathh.stringToFloat(args[1]), args[2], Convert.ToDateTime(args[3]), Convert.ToBoolean(args[4])));

        }
        #endregion

        #region Liste Manipulation
        //Finder og returnere en postering givet et listviewItem
        private Posteringer GetPostering(ListViewItem item)
        {
            foreach (Posteringer postering in posteringer)
                if (postering.ListItem == item)
                    return postering;


            //Hvis posteringen ikke findes - hvilket ikke burde ske - opstår der er en error
            throw new System.InvalidOperationException("Item was not found, something went wrong");

        }
        public static void AddToList(ListViewItem posteringItem)
        {
            instance.listPosteringer.Items.Add(posteringItem);

        }

        private void btnSøg_Click(object sender, EventArgs e)
        {
            SøgPosteringer();
        }

        private void SletAllePosteringer()
        {
            foreach (ListViewItem item in listPosteringer.Items)
                item.Remove();
        }
        private void VisAllePosteringer()
        {
            SletAllePosteringer();
            foreach (Posteringer postering in posteringer)
            {
                listPosteringer.Items.Add(postering.ListItem);
            }
            UpdatePoseringsLabel();

        }

        private void SøgPosteringer()
        {
            SletAllePosteringer();

            List<string> uallowedKategorier = new List<string>();
            List<string> iallowedKategorier = new List<string>();
            List<string> allowedTyper = new List<string>();
            string min = txtBoxMin.Text.Trim();
            string max = txtBoxMax.Text.Trim();

            int antalPosteringer = 0;

            //gather settings
            foreach (var item in cListType.CheckedItems)
                allowedTyper.Add(item.ToString());
            string s = "";

            foreach (var item in cListKategorier_i.CheckedItems)
            {
                iallowedKategorier.Add(item.ToString());
            }


            foreach (var item in cListKategorier_u.CheckedItems)
            {
                uallowedKategorier.Add(item.ToString());
            }

            //Cycle through all posteringer
            foreach (Posteringer postering in posteringer)
            {
                if (allowedTyper.Contains("Udgift") && postering.erUdgift == true)
                {
                    if (!(uallowedKategorier.Contains(postering.kategori)))
                        continue;
                }
                else if (allowedTyper.Contains("Indtægt") && postering.erUdgift == false)
                {
                    if (!(iallowedKategorier.Contains(postering.kategori)))
                        continue;
                }
                else
                    continue;

                if (min != "")
                    if (postering.Pris < Mathh.stringToFloat(min))
                        continue;
                if (max != "")
                    if (postering.Pris > Mathh.stringToFloat(max))
                        continue;
                if ((!cboxAlleDatoer.Checked) && (!cBoxMåned.Checked))
                {
                    if (DateTime.Compare(postering.dato, dateTimeSlut.Value) > 0)
                        continue;
                    else if (DateTime.Compare(postering.dato, dateTimeStart.Value) < 0)
                        continue;
                }

                else if (cBoxMåned.Checked)
                    if (postering.dato.Month != DateTime.Now.Month || postering.dato.Year != DateTime.Now.Year)
                        continue;
                antalPosteringer++;
                AddToList(postering.ListItem);
            }
            UpdatePoseringsLabel();
        }

        #endregion

        #region Controls til sortering
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxAlleDatoer.Checked)
            {
                dateTimeStart.Enabled = false;
                dateTimeSlut.Enabled = false;
                cBoxMåned.Checked = false;
            }
            else if (!cBoxMåned.Checked)
            {
                dateTimeStart.Enabled = true;
                dateTimeSlut.Enabled = true;
            }
        }

        private void cBoxMåned_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxMåned.Checked)
            {
                dateTimeStart.Enabled = false;
                dateTimeSlut.Enabled = false;
                cboxAlleDatoer.Checked = false;
            }
            else if (!cboxAlleDatoer.Checked)
            {
                dateTimeStart.Enabled = true;
                dateTimeSlut.Enabled = true;
            }

        }

        private void btnVisAlle_Click(object sender, EventArgs e)
        {
            VisAllePosteringer();
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            ControlValuesToDefault();
        }

        private void UpdatePoseringsLabel()
        {
            lblPosteringer.Text = "Antal posteringer vist: " + listPosteringer.Items.Count.ToString() + " ud af " + Posteringer.Antal;
        }


        private void cboxBegræns_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxBegræns.Checked)
                gboxSøg.Show();
            else
                gboxSøg.Hide();

        }

        private void cListKategorier_u_SelectedIndexChanged(object sender, EventArgs e)
        {
            cListKategorier_u.ClearSelected();
        }

        private void cListKategorier_i_SelectedIndexChanged(object sender, EventArgs e)
        {
            cListKategorier_i.ClearSelected();
        }

        private void cListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cListType.ClearSelected();
        }
        #endregion

        #region Testing
        //TESTING PURPOSES

        private void OpretSamplePosteringer(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
                posteringer.Add(new Posteringer("Tilfældig postering nr. " + i.ToString()));
            UpdatePoseringsLabel();
        }
        
        #endregion

        private void btnIndstillinger_Click(object sender, EventArgs e)
        {
            formIndstillinger = new Indstillinger();
            formIndstillinger.ShowDialog();
        }
    }
}

