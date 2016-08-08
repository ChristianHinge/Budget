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
using System.Threading;

namespace BudgetProgram
{
    public partial class Budget : Form
    {
        List<Posteringer> posteringer;
        public static Budget instance = null;

        //Excel
        Excel.Application excelApp;
        Excel._Workbook excelWorkbook;

        public Budget()
        {
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            instance = this;
            InitializeComponent();
            posteringer = new List<Posteringer>();
            Load_Posteringer();


            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrepareControls();

            //Excel
            while (IsOpened("Budget.xlsm"))
            {
                DialogResult result = MessageBox.Show("Please close Budget.xlsm before continuing.", "Hinge Budget", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                    continue;
                else if (result == DialogResult.Cancel)
                    LukLortet();
            }

            excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelWorkbook = excelApp.Workbooks.Open(@"C:\Users\User\Documents\Visual Studio 2015\Projects\Budget\Budget.xlsm", 2, false);
            excelApp.Run("Opdater");
            
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
                posteringer.Add(postering);
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
                posteringer.Add(postering);
            }

            lblBalance.Text = Posteringer.Balance.ToString() + "   " + posteringer.Count.ToString();
        }



        //Sletter de valgte udgifter og opdatterer label (Sender = KNAP)
        private void SletPosteringer(object sender, EventArgs e)
        {
            Posteringer postering;
            foreach (ListViewItem hej in listPosteringer.SelectedItems)
            {
                postering = GetPostering(hej);

                if (posteringer.Contains(postering))
                    posteringer.Remove(postering);
                else
                    throw new System.InvalidOperationException("Posteringen var hverken i indtægterlisten eller i udgifter listen");

                postering.Delete();
                listPosteringer.Items.Remove(hej);
            }

            lblBalance.Text = Posteringer.Balance.ToString() + "   " + posteringer.Count.ToString();
        }

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

        private void OnApplicationExit(object sender, EventArgs e)
        {
            Gem();
            Thread.Sleep(100);
            excelApp.Run("Opdater");
            Thread.Sleep(2000);
            excelWorkbook.Save();
            Thread.Sleep(1000);
            excelWorkbook.Close();
            excelApp.Quit();

            Marshal.FinalReleaseComObject(excelWorkbook);
            Marshal.FinalReleaseComObject(excelApp);

            excelApp = null;
            excelWorkbook = null;

            GC.Collect();
        }
        
        #region Control Handeling
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
            txtBeskrivelse_u.Size = txtBeskrivelse_i.Size;

            cBoxKategori_u.Location = cBoxKategori_i.Location;
            cBoxKategori_u.Size = cBoxKategori_i.Size;

            datePicker_u.Location = datePicker_i.Location;
            datePicker_u.Size = datePicker_i.Size;

            btnOpret_u.Location = btnOpret_i.Location;
            btnOpret_u.Size = btnOpret_i.Size;
        }
        #endregion

        #region Saving And Loading
        private void btnGem_Click(object sender, EventArgs e)
        {
            Gem();
        }
        private void Gem()
        {
            string path = "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\Budget\\posteringFil.txt";
        
            StreamWriter sw = new StreamWriter(path);
            foreach (Posteringer postering in posteringer)
            {
                sw.WriteLine(postering.GetInfo());
            }
            sw.Close();
            excelApp.Run("Opdater");
        }
        private void Load_Posteringer()
        {
            StreamReader sr = new StreamReader("C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\Budget\\posteringFil.txt");
            string line = sr.ReadLine();
            while (line != null)
            {
                posteringer.Add(Unwrap(line));
                line = sr.ReadLine();
            }
            sr.Close();

        }

        //Omdanner en gemt string til et Posteringsobjekt
        private Posteringer Unwrap(string input)
        {
            char semicolon = ';';
            string[] args = input.Split(semicolon);
            return (new Posteringer(args[0], Mathh.stringToFloat(args[1]), args[2], Convert.ToDateTime(args[3]), Convert.ToBoolean(args[4])));

        }
        #endregion

        #region Testing
        //TESTING PURPOSES

        private void OpretSamplePosteringer(object sender, EventArgs e)
        {
            posteringer.Add(new Posteringer("Burger", 65.7f, "Mad", DateTime.Today, true));
            posteringer.Add(new Posteringer("Løn Juli", 1450, "Løn", DateTime.Today, false));
            posteringer.Add(new Posteringer("Computer", 5099, "Andet", DateTime.Now, true));
            posteringer.Add(new Posteringer("post1", 100, "SU", DateTime.UtcNow, false));
            posteringer.Add(new Posteringer("post2", 0.50f, "Mad", DateTime.Today, true));
            posteringer.Add(new Posteringer("post3", 54, "Andet", DateTime.Today, false));
            posteringer.Add(new Posteringer("Burger", 65.7f, "Mad", DateTime.Today, true));
            posteringer.Add(new Posteringer("Løn Juli", 1450, "Løn", DateTime.Today, false));
            posteringer.Add(new Posteringer("Computer", 5099, "Andet", DateTime.Now, true));
            posteringer.Add(new Posteringer("post1", 100, "SU", DateTime.UtcNow, false));
            posteringer.Add(new Posteringer("post2", 0.50f, "Mad", DateTime.Today, true));
            posteringer.Add(new Posteringer("post3", 54, "Andet", DateTime.Today, false));
        }
        #endregion

        static bool IsOpened(string wbook)
        {
            bool isOpened = true;
            Excel.Application exApp;
            exApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            try
            {
                exApp.Workbooks.get_Item(wbook);
            }
            catch (Exception)
            {
                isOpened = false;
            }
            return isOpened;
        }
        private void LukLortet()
        {
            System.Environment.Exit(1);
        }
    }
}

