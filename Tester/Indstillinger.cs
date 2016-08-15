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

namespace BudgetProgram
{
    public partial class Indstillinger : Form
    {
        List<string> i_kategorier;
        List<string> u_kategorier;

        public Indstillinger()
        {
            InitializeComponent();
            ReadKategorier();
            btnSlet_i.Enabled = false;
            btnSlet_u.Enabled = false;
        }

        private void Indstillinger_Load(object sender, EventArgs e)
        {
            
        }

        private void ReadKategorier()
        {
            i_kategorier = new List<string>();
            StreamReader sr = new StreamReader(Budget.i_path);
            string line = sr.ReadLine();

            while (line != null)
            {
                i_kategorier.Add(line);
                listBoxKategorier_i.Items.Add(line);
                line = sr.ReadLine();
            }


            sr.Close();

            u_kategorier = new List<string>();
            sr = new StreamReader(Budget.u_path);
            line = sr.ReadLine();

            while (line != null)
            {
                u_kategorier.Add(line);
                listBoxKategorier_u.Items.Add(line);
                line = sr.ReadLine();
            }

            sr.Close();

        }

        private void WriteKategorier()
        {
            StreamWriter sw = new StreamWriter(Budget.i_path);
            foreach (string kat in i_kategorier)
                sw.WriteLine(kat);
            sw.Close();

            sw = new StreamWriter(Budget.u_path);
            foreach (string kat in u_kategorier)
                sw.WriteLine(kat);
            sw.Close();

            Posteringer.UpdateKategorier();
        }

        private void btnNy_Click(object sender, EventArgs e)
        {
            StringBox box = new StringBox("Navn på ny indtægtskategori", "Ny indtægtskategori");
            box.ShowDialog();

            if (box.finished)
            {
                listBoxKategorier_i.Items.Add(box.output);
                i_kategorier.Add(box.output);
            }

        }

        private void btnNy_u_Click(object sender, EventArgs e)
        {
            StringBox box = new StringBox("Navn på ny udgiftskategori", "Ny udgiftskategori");
            box.ShowDialog();

            if (box.finished)
            {
                listBoxKategorier_u.Items.Add(box.output);
                u_kategorier.Add(box.output);
            }

        }

        private void btnSlet_Click(object sender, EventArgs e)
        {
            i_kategorier.Remove(listBoxKategorier_i.SelectedItem.ToString());
            listBoxKategorier_i.Items.Remove(listBoxKategorier_i.SelectedItem);

        }


        private void btnSlet_u_Click(object sender, EventArgs e)
        {
            u_kategorier.Remove(listBoxKategorier_u.SelectedItem.ToString());
            listBoxKategorier_u.Items.Remove(listBoxKategorier_u.SelectedItem);
        }


        private void btnGem_Click(object sender, EventArgs e)
        {
            WriteKategorier();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            WriteKategorier();
            this.Close();

        }

        private void listBoxKategorier_i_SelectedValueChanged(object sender, EventArgs e)
        {
            bool anySelected = false;
            for (int i = 0; i < listBoxKategorier_i.Items.Count; i++)
                if (listBoxKategorier_i.GetSelected(i))
                {
                    anySelected = true;
                    break;
                }

            if (anySelected)
                btnSlet_i.Enabled = true;
            else
                btnSlet_i.Enabled = false;
        }

        private void listBoxKategorier_u_SelectedValueChanged(object sender, EventArgs e)
        {
            bool anySelected = false;
            for (int i = 0; i < listBoxKategorier_u.Items.Count; i++)
                if (listBoxKategorier_u.GetSelected(i))
                {
                    anySelected = true;
                    break;
                }

            if (anySelected)
                btnSlet_u.Enabled = true;
            else
                btnSlet_u.Enabled = false;
        }
    }
}
