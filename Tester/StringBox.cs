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
    public partial class StringBox : Form
    {
        public string output;
        public bool finished = false;
        public StringBox(string message, string header)
        {
            InitializeComponent();
            Text = header;
            lblTekst.Text = message;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Trim() != "")
            {
                output = txtInput.Text.Trim();
                finished = true;
                this.Close();
            }
        }
    }
}
