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
using BudgetCore;

namespace BudgetProgram
{
    public partial class Indstillinger : Form
    {
        #region Declaration og instantiation
        List<string> i_kategorier;
        List<string> u_kategorier;

        PosteringManager Manager;

        public Indstillinger()
        {
            
            InitializeComponent();
            FetchKategorier();
            btnSlet_i.Enabled = false;
            btnSlet_u.Enabled = false;
            Manager = PosteringManager.instance;
        }

        private void Indstillinger_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Fetching og pushing af indstillinger til manager ved start og slut
        //Henter i- og u-kategorier fra PosteringManagers lister. 
        //Indsætter kategorierne i listevisningerne 
        private void FetchKategorier()
        {
            i_kategorier = new List<string>();
            foreach (string kat in PosteringManager.iKategorier)
            {
                listBoxKategorier_i.Items.Add(kat);
                i_kategorier.Add(kat);
            }

            u_kategorier = new List<string>();
            foreach (string kat in PosteringManager.uKategorier)
            {
                listBoxKategorier_u.Items.Add(kat);
                u_kategorier.Add(kat);
            }

        }

        //Sender indstillinger til manager, som gemmer disse og opdaterer lokale variabble
        //Resetter controls på Budget.cs så de har de nye indstillinger (fx. kategorier)
        private void btnGem_Click(object sender, EventArgs e)
        {
            Manager.WriteKategorier(i_kategorier, u_kategorier);
            Budget.instance.ControlValuesToDefault();
        }

        //Det samme som btnGem, lukker indstillinger-vinduet.
        private void btnOK_Click(object sender, EventArgs e)
        {
            Manager.WriteKategorier(i_kategorier, u_kategorier);
            Budget.instance.ControlValuesToDefault();
            this.Close();

        }

        #endregion

        #region Kategori-lister front og back end

        //Ny i-kategori. 
        private void btnNy_Click(object sender, EventArgs e)
        {
            StringBox box = new StringBox("Navn på ny indtægtskategori", "Ny indtægtskategori");
            box.ShowDialog();

            if (box.finished)
            {
                if (i_kategorier.Contains(box.output))
                {
                    MessageBox.Show("Kategorien: '" + box.output + "' eksisterer allerede");
                    return;
                }
                listBoxKategorier_i.Items.Add(box.output);
                i_kategorier.Add(box.output);
            }

        }

        //Ny u-kategori
        private void btnNy_u_Click(object sender, EventArgs e)
        {
            StringBox box = new StringBox("Navn på ny udgiftskategori", "Ny udgiftskategori");
            box.ShowDialog();

            if (box.finished)
            {
                if (u_kategorier.Contains(box.output))
                {
                    MessageBox.Show("Kategorien: '" + box.output + "' eksisterer allerede");
                    return;
                }
                listBoxKategorier_u.Items.Add(box.output);
                u_kategorier.Add(box.output);
            }

        }

        //Slet i-kategori
        private void btnSlet_Click(object sender, EventArgs e)
        {
            string CategoryToDelete = listBoxKategorier_i.SelectedItem.ToString();
            if (HasPostsWithCategory(CategoryToDelete, false))
                return;

            else
            {
                if (DialogResult.OK == MessageBox.Show("Er du sikker på at du vil slette kategorien '" + CategoryToDelete + "'?", "Sletning af kategori", MessageBoxButtons.OKCancel))
                {
                    i_kategorier.Remove(CategoryToDelete);
                    listBoxKategorier_i.Items.Remove(CategoryToDelete);
                }
            }
        }

        //Slet u-kategori
        private void btnSlet_u_Click(object sender, EventArgs e)
        {
            string CategoryToDelete = listBoxKategorier_u.SelectedItem.ToString();
            if (HasPostsWithCategory(CategoryToDelete,true))
                return;
            else
            {
                if (DialogResult.OK == MessageBox.Show("Er du sikker på at du vil slette kategorien '" + CategoryToDelete + "'?","Sletning af kategori",MessageBoxButtons.OKCancel))
                {
                    u_kategorier.Remove(CategoryToDelete);
                    listBoxKategorier_u.Items.Remove(listBoxKategorier_u.SelectedItem);
                }
            }
        }

        //Tjekker om der er nogen poster med en given kategori. Bliver brugt ved sletning af kategori

        private bool HasPostsWithCategory(string kategori, bool erUdgift)
        {
            //Laver søgning hvor kun poster med kategorien vises.
            List<string> Cat = new List<string>();
            Cat.Add(kategori);
            List<string> Type = new List<string>();
            if (erUdgift)
                Type.Add("Udgift");
            else
                Type.Add("Indtægt");

            bool hasPostsWithCat = false;
            string message = "";
            List<ListViewItem> resultat = new List<ListViewItem>();
            foreach (Postering post in Manager.SøgPosteringer(Cat, Cat, Type, "", "", 1, DateTime.Today, DateTime.Today))
            {
                message += post.Beskrivelse + "\n";
                hasPostsWithCat = true;
            }

            if (hasPostsWithCat)
            {
                MessageBox.Show("Der er poster som har kategorien '" + kategori + "' og kategorien kan derfor ikke slettes. Følgende poster har kategorien: \n\n" + message);
                return true;
            }
            else
                return false;
        }
        
        //Sørger for at slet-knappen for i-kategorier kun virker når en kategori er valgt
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

        //Sørger for at slet-knappen for u-kategorier kun virker når en kategori er valgt
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
        #endregion
    }
}
