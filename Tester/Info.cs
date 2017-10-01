using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetProgram
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
        }

        private void Info_Load(object sender, EventArgs e)
        {
            linkLabelKode.Links.Add(0, 41, "https://github.com/ChristianHinge/Budget/");
            linkLabelWiki.Links.Add(0, 45, "https://github.com/ChristianHinge/Budget/wiki");
        }

        private void OpenLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabelEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:christianhingepedersen@gmail.com");
        }
    }
}
