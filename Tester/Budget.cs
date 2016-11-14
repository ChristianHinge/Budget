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
        PosteringManager manager = new PosteringManager();
        public static Budget instance = null;
        Indstillinger formIndstillinger;
        private ListViewColumnSorter lvwColumnSorter;
        private bool searchingAllowed;

        public Budget()
        {
            InitializeComponent();
            instance = this;
            searchingAllowed = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VisAllePosteringer();
            PrepareControls();

            //Sorter til listview
            lvwColumnSorter = new ListViewColumnSorter();
            listPosteringer.ListViewItemSorter = lvwColumnSorter;
            searchingAllowed = true;
            
        }

        //Opret postering BLIVER KALDT AF DE TO OPRET KNAPPER
        private void OpretPostering(object sender, EventArgs e)
        {
            int status;
            //Hvis intægtknappen trykkes oprettes en indtægt
            if (sender == btnOpret_i)
            {
                status = manager.OpretPostering(txtBeskrivelse_i.Text, txtBeløb_i.Text, cBoxKategori_i.Text, datePicker_i.Value, false);

                if (status == 0)
                    VisAllePosteringer();

                else
                    MessageBox.Show(GetStatusMessage(status));
            }

            //Hvis udgiftknappen trykkes oprettes en udgift
            else 
            {
                status = manager.OpretPostering(txtBeskrivelse_u.Text, txtBeløb_u.Text, cBoxKategori_u.Text, datePicker_u.Value, true);

                if (status == 0)
                    VisAllePosteringer();

                else
                    MessageBox.Show(GetStatusMessage(status));
            }


            UpdatePoseringsLabel();
        }

        string GetStatusMessage(int status)
        {
            switch (status)
            {
                case 1:
                    return ("Udfyld venligst beløb-feltet. Tilladte tegn: 0-9 , .");
                case 2:
                    return ("Udfyld venligt beskrivelse-feltet");
                case 3:
                    return ("Semikolon (;) må ikke benyttes i beskrivelses-feltet");
                default:
                    throw new Exception("Status unknown. Status: " + status.ToString());
            }

        }

        //Sletter de valgte udgifter og opdatterer label (Sender = KNAP)
        private void SletPosteringer(object sender, EventArgs e)
        {
            string prompt = "Er du sikker på at du ønsker at slette nedenstående postering(er)?\n";
            //Finder navnene på de valgte list items
            foreach (ListViewItem hej in listPosteringer.SelectedItems)
                prompt += "\n" + hej.SubItems[0].Text;

            if (MessageBox.Show(prompt, "Sletning af posteringer", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (ListViewItem post in listPosteringer.SelectedItems)
                    manager.SletPostering(post);


                UpdatePoseringsLabel();
                VisAllePosteringer();
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
            bool HasCategories = false;
            foreach (string kategori in PosteringManager.iKategorier)
            {
                cBoxKategori_i.Items.Add(kategori);
                cListKategorier_i.Items.Add(kategori, true);
                HasCategories = true;
            }
            if (HasCategories)
                cBoxKategori_i.SelectedIndex = 0;

            //Lists udgifter
            HasCategories = false;
            foreach (string kategori in PosteringManager.uKategorier)
            {
                cBoxKategori_u.Items.Add(kategori);
                cListKategorier_u.Items.Add(kategori, true);
                HasCategories = true;
            }
            if (HasCategories)
                cBoxKategori_u.SelectedIndex = 0;

            cListType.Items.Clear();
            cListType.Items.Add("Indtægt", true);
            cListType.Items.Add("Udgift", true);

            UpdatePoseringsLabel();

            dateTimeStart.Value = DateTime.Now.Date.AddMonths(-1);
            dateTimeStart.MaxDate = DateTime.Now.Date.AddDays(1);
            dateTimeSlut.Value = DateTime.Now.Date.AddDays(1);

            checkedListBox1.SelectedIndex = 0;

            txtBoxMax.Text = "";
            txtBoxMin.Text = "";
        }
        #endregion


        #region Saving And Loading

        private void btnGem_Click(object sender, EventArgs e)
        {
            manager.Gem();
        }


        #endregion

        #region Liste Manipulation
        //Finder og returnere en postering givet et listviewItem

        private void btnSøg_Click(object sender, EventArgs e)
        {
            SøgPosteringer();
        }

        private void SletAllePosteringer()
        {
            listPosteringer.Items.Clear();
            UpdatePoseringsLabel();
        }
        private void VisAllePosteringer()
        {
            listPosteringer.BeginUpdate();
            listPosteringer.ListViewItemSorter = null;
            SletAllePosteringer();

            foreach (Postering postering in manager.GetAllePosteringer())
                listPosteringer.Items.Add(postering.ListItem);

            listPosteringer.ListViewItemSorter = lvwColumnSorter;
            listPosteringer.EndUpdate();
            UpdatePoseringsLabel();
 

        }

        private void SøgPosteringer()
        {
            if (searchingAllowed == false)
                return;

            SletAllePosteringer();

            //Parametrer decleration
            List<string> uallowedKategorier = new List<string>();
            List<string> iallowedKategorier = new List<string>();
            List<string> allowedTyper = new List<string>();
            string min = txtBoxMin.Text.Trim();
            string max = txtBoxMax.Text.Trim();
            DateTime maxDato;
            DateTime minDato;
            int datoSearchType = 1;

            //Parameter Assignment
            foreach (var item in cListType.CheckedItems)
                allowedTyper.Add(item.ToString());

            foreach (var item in cListKategorier_u.CheckedItems)
                uallowedKategorier.Add(item.ToString());

            foreach (var item in cListKategorier_i.CheckedItems)
                iallowedKategorier.Add(item.ToString());

            datoSearchType = checkedListBox1.SelectedIndex;
            minDato = dateTimeStart.Value;
            maxDato = dateTimeSlut.Value;

            //Listview Update
            listPosteringer.BeginUpdate();
            listPosteringer.ListViewItemSorter = null;

            foreach (Postering postering in manager.SøgPosteringer(uallowedKategorier, iallowedKategorier, allowedTyper, min, max, datoSearchType,minDato,maxDato))
                listPosteringer.Items.Add(postering.ListItem);

            listPosteringer.ListViewItemSorter = lvwColumnSorter;
            listPosteringer.EndUpdate();
            UpdatePoseringsLabel();

        }
            
        

        #endregion

        #region Controls til sortering
        
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
            lblPosteringer.Text = "Antal posteringer vist: " + listPosteringer.Items.Count.ToString() + " ud af " + PosteringManager.AntalPosteringer;
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
            SøgPosteringer();
        }

        private void cListKategorier_i_SelectedIndexChanged(object sender, EventArgs e)
        {
            cListKategorier_i.ClearSelected();
            SøgPosteringer();
        }

        private void cListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cListType.ClearSelected();
            SøgPosteringer();
        }
        #endregion

        #region Testing
        //TESTING PURPOSES

        private void OpretSamplePosteringer(object sender, EventArgs e)
        {
            manager.OpretSamplePosteringer();
            VisAllePosteringer();
        }
        
        #endregion

        private void btnIndstillinger_Click(object sender, EventArgs e)
        {
            formIndstillinger = new Indstillinger();
            formIndstillinger.ShowDialog();
        }

        private void listPosteringer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ColumnClick_Event(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            listPosteringer.Sort();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            btnGem_Click(sender, EventArgs.Empty);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            btnIndstillinger_Click(sender, EventArgs.Empty);
        }

        private void SearchTextChange(object sender, EventArgs e)
        {
            listPosteringer.BeginUpdate();
            listPosteringer.ListViewItemSorter = null;
            SletAllePosteringer();

            foreach (Postering postering in manager.SøgPosteringerTekst(txtBoxSearch.Text))
                listPosteringer.Items.Add(postering.ListItem);

            listPosteringer.ListViewItemSorter = lvwColumnSorter;
            listPosteringer.EndUpdate();
            UpdatePoseringsLabel();
        }

        private void ControlValueChange(object sender, EventArgs e)
        {
            SøgPosteringer();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dato controls
            if (checkedListBox1.SelectedIndex == 5)
            {
                dateTimeStart.Enabled = true;
                dateTimeSlut.Enabled = true;
            }
            else
            {
                dateTimeStart.Enabled = false;
                dateTimeSlut.Enabled = false;
            }

            //Sørger for at kun én checkbox er checked

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.SelectedIndex == i)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                    continue;
                }
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }

            SøgPosteringer();

        }
    }
}


