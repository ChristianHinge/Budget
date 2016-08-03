namespace Tester
{
    partial class Budget
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBeskrivelse_i = new System.Windows.Forms.TextBox();
            this.txtBeløb_i = new System.Windows.Forms.TextBox();
            this.lblBeløb_i = new System.Windows.Forms.Label();
            this.lblBeskrivelse_i = new System.Windows.Forms.Label();
            this.btnOpret_i = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.datePicker_i = new System.Windows.Forms.DateTimePicker();
            this.cBoxKategori_i = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listPosteringer = new System.Windows.Forms.ListView();
            this.cHeaderBeskrivelse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHeaderDato = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHeaderBeløb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHeaderKategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.btnIndstillinger = new System.Windows.Forms.Button();
            this.lblDato_i = new System.Windows.Forms.Label();
            this.lblDato_u = new System.Windows.Forms.Label();
            this.datePicker_u = new System.Windows.Forms.DateTimePicker();
            this.cBoxKategorier_u = new System.Windows.Forms.ComboBox();
            this.txtBeløb_u = new System.Windows.Forms.TextBox();
            this.btnOpret_u = new System.Windows.Forms.Button();
            this.lblBeskrivelse_u = new System.Windows.Forms.Label();
            this.lblBeløb_u = new System.Windows.Forms.Label();
            this.txtBeskrivelse_u = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBeskrivelse_i
            // 
            this.txtBeskrivelse_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeskrivelse_i.Location = new System.Drawing.Point(79, 43);
            this.txtBeskrivelse_i.Name = "txtBeskrivelse_i";
            this.txtBeskrivelse_i.Size = new System.Drawing.Size(200, 26);
            this.txtBeskrivelse_i.TabIndex = 2;
            // 
            // txtBeløb_i
            // 
            this.txtBeløb_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeløb_i.Location = new System.Drawing.Point(79, 11);
            this.txtBeløb_i.Name = "txtBeløb_i";
            this.txtBeløb_i.Size = new System.Drawing.Size(100, 26);
            this.txtBeløb_i.TabIndex = 0;
            // 
            // lblBeløb_i
            // 
            this.lblBeløb_i.AutoSize = true;
            this.lblBeløb_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeløb_i.Location = new System.Drawing.Point(7, 17);
            this.lblBeløb_i.Name = "lblBeløb_i";
            this.lblBeløb_i.Size = new System.Drawing.Size(50, 20);
            this.lblBeløb_i.TabIndex = 2;
            this.lblBeløb_i.Text = "Beløb";
            // 
            // lblBeskrivelse_i
            // 
            this.lblBeskrivelse_i.AutoSize = true;
            this.lblBeskrivelse_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeskrivelse_i.Location = new System.Drawing.Point(7, 46);
            this.lblBeskrivelse_i.Name = "lblBeskrivelse_i";
            this.lblBeskrivelse_i.Size = new System.Drawing.Size(64, 20);
            this.lblBeskrivelse_i.TabIndex = 3;
            this.lblBeskrivelse_i.Text = "Beskriv.";
            // 
            // btnOpret_i
            // 
            this.btnOpret_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpret_i.Location = new System.Drawing.Point(79, 107);
            this.btnOpret_i.Name = "btnOpret_i";
            this.btnOpret_i.Size = new System.Drawing.Size(200, 39);
            this.btnOpret_i.TabIndex = 4;
            this.btnOpret_i.Text = "Opret";
            this.btnOpret_i.UseVisualStyleBackColor = true;
            this.btnOpret_i.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(293, 182);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.ForestGreen;
            this.tabPage1.Controls.Add(this.lblDato_i);
            this.tabPage1.Controls.Add(this.datePicker_i);
            this.tabPage1.Controls.Add(this.cBoxKategori_i);
            this.tabPage1.Controls.Add(this.txtBeløb_i);
            this.tabPage1.Controls.Add(this.btnOpret_i);
            this.tabPage1.Controls.Add(this.lblBeskrivelse_i);
            this.tabPage1.Controls.Add(this.lblBeløb_i);
            this.tabPage1.Controls.Add(this.txtBeskrivelse_i);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(285, 156);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Indtægt";
            // 
            // datePicker_i
            // 
            this.datePicker_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker_i.Location = new System.Drawing.Point(79, 75);
            this.datePicker_i.Name = "datePicker_i";
            this.datePicker_i.Size = new System.Drawing.Size(200, 26);
            this.datePicker_i.TabIndex = 3;
            // 
            // cBoxKategori_i
            // 
            this.cBoxKategori_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxKategori_i.FormattingEnabled = true;
            this.cBoxKategori_i.Location = new System.Drawing.Point(185, 11);
            this.cBoxKategori_i.Name = "cBoxKategori_i";
            this.cBoxKategori_i.Size = new System.Drawing.Size(94, 26);
            this.cBoxKategori_i.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Red;
            this.tabPage2.Controls.Add(this.lblDato_u);
            this.tabPage2.Controls.Add(this.datePicker_u);
            this.tabPage2.Controls.Add(this.cBoxKategorier_u);
            this.tabPage2.Controls.Add(this.txtBeløb_u);
            this.tabPage2.Controls.Add(this.btnOpret_u);
            this.tabPage2.Controls.Add(this.lblBeskrivelse_u);
            this.tabPage2.Controls.Add(this.lblBeløb_u);
            this.tabPage2.Controls.Add(this.txtBeskrivelse_u);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(285, 156);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Udgift";
            // 
            // listPosteringer
            // 
            this.listPosteringer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHeaderBeskrivelse,
            this.cHeaderDato,
            this.cHeaderBeløb,
            this.cHeaderKategori,
            this.cHeaderType});
            this.listPosteringer.FullRowSelect = true;
            this.listPosteringer.Location = new System.Drawing.Point(297, 21);
            this.listPosteringer.Name = "listPosteringer";
            this.listPosteringer.Size = new System.Drawing.Size(395, 286);
            this.listPosteringer.TabIndex = 7;
            this.listPosteringer.UseCompatibleStateImageBehavior = false;
            this.listPosteringer.View = System.Windows.Forms.View.Details;
            // 
            // cHeaderBeskrivelse
            // 
            this.cHeaderBeskrivelse.Text = "Beskrivelse";
            this.cHeaderBeskrivelse.Width = 129;
            // 
            // cHeaderDato
            // 
            this.cHeaderDato.Text = "Dato";
            this.cHeaderDato.Width = 64;
            // 
            // cHeaderBeløb
            // 
            this.cHeaderBeløb.Text = "Beløb";
            this.cHeaderBeløb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cHeaderBeløb.Width = 69;
            // 
            // cHeaderKategori
            // 
            this.cHeaderKategori.Text = "Kategori";
            this.cHeaderKategori.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cHeaderKategori.Width = 80;
            // 
            // cHeaderType
            // 
            this.cHeaderType.Text = "Type";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(188, 215);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Slet Postering";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(9, 215);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(35, 13);
            this.lblBalance.TabIndex = 9;
            this.lblBalance.Text = "label5";
            // 
            // btnIndstillinger
            // 
            this.btnIndstillinger.Location = new System.Drawing.Point(188, 284);
            this.btnIndstillinger.Name = "btnIndstillinger";
            this.btnIndstillinger.Size = new System.Drawing.Size(96, 23);
            this.btnIndstillinger.TabIndex = 10;
            this.btnIndstillinger.Text = "Indstillinger";
            this.btnIndstillinger.UseVisualStyleBackColor = true;
            this.btnIndstillinger.Click += new System.EventHandler(this.btnIndstillinger_Click);
            // 
            // lblDato_i
            // 
            this.lblDato_i.AutoSize = true;
            this.lblDato_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDato_i.Location = new System.Drawing.Point(7, 80);
            this.lblDato_i.Name = "lblDato_i";
            this.lblDato_i.Size = new System.Drawing.Size(44, 20);
            this.lblDato_i.TabIndex = 8;
            this.lblDato_i.Text = "Dato";
            // 
            // lblDato_u
            // 
            this.lblDato_u.AutoSize = true;
            this.lblDato_u.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDato_u.Location = new System.Drawing.Point(6, 80);
            this.lblDato_u.Name = "lblDato_u";
            this.lblDato_u.Size = new System.Drawing.Size(44, 20);
            this.lblDato_u.TabIndex = 16;
            this.lblDato_u.Text = "Dato";
            // 
            // datePicker_u
            // 
            this.datePicker_u.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker_u.Location = new System.Drawing.Point(78, 75);
            this.datePicker_u.Name = "datePicker_u";
            this.datePicker_u.Size = new System.Drawing.Size(200, 26);
            this.datePicker_u.TabIndex = 13;
            // 
            // cBoxKategorier_u
            // 
            this.cBoxKategorier_u.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxKategorier_u.FormattingEnabled = true;
            this.cBoxKategorier_u.Location = new System.Drawing.Point(184, 11);
            this.cBoxKategorier_u.Name = "cBoxKategorier_u";
            this.cBoxKategorier_u.Size = new System.Drawing.Size(94, 26);
            this.cBoxKategorier_u.TabIndex = 10;
            // 
            // txtBeløb_u
            // 
            this.txtBeløb_u.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeløb_u.Location = new System.Drawing.Point(78, 11);
            this.txtBeløb_u.Name = "txtBeløb_u";
            this.txtBeløb_u.Size = new System.Drawing.Size(100, 26);
            this.txtBeløb_u.TabIndex = 9;
            // 
            // btnOpret_u
            // 
            this.btnOpret_u.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpret_u.Location = new System.Drawing.Point(78, 107);
            this.btnOpret_u.Name = "btnOpret_u";
            this.btnOpret_u.Size = new System.Drawing.Size(200, 39);
            this.btnOpret_u.TabIndex = 15;
            this.btnOpret_u.Text = "Opret";
            this.btnOpret_u.UseVisualStyleBackColor = true;
            // 
            // lblBeskrivelse_u
            // 
            this.lblBeskrivelse_u.AutoSize = true;
            this.lblBeskrivelse_u.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeskrivelse_u.Location = new System.Drawing.Point(6, 46);
            this.lblBeskrivelse_u.Name = "lblBeskrivelse_u";
            this.lblBeskrivelse_u.Size = new System.Drawing.Size(64, 20);
            this.lblBeskrivelse_u.TabIndex = 14;
            this.lblBeskrivelse_u.Text = "Beskriv.";
            // 
            // lblBeløb_u
            // 
            this.lblBeløb_u.AutoSize = true;
            this.lblBeløb_u.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeløb_u.Location = new System.Drawing.Point(6, 17);
            this.lblBeløb_u.Name = "lblBeløb_u";
            this.lblBeløb_u.Size = new System.Drawing.Size(50, 20);
            this.lblBeløb_u.TabIndex = 11;
            this.lblBeløb_u.Text = "Beløb";
            // 
            // txtBeskrivelse_u
            // 
            this.txtBeskrivelse_u.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeskrivelse_u.Location = new System.Drawing.Point(78, 43);
            this.txtBeskrivelse_u.Name = "txtBeskrivelse_u";
            this.txtBeskrivelse_u.Size = new System.Drawing.Size(200, 26);
            this.txtBeskrivelse_u.TabIndex = 12;
            // 
            // Budget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(697, 319);
            this.Controls.Add(this.btnIndstillinger);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listPosteringer);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Budget";
            this.Text = "Christian Hinge Budget";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBeskrivelse_i;
        private System.Windows.Forms.TextBox txtBeløb_i;
        private System.Windows.Forms.Label lblBeløb_i;
        private System.Windows.Forms.Label lblBeskrivelse_i;
        private System.Windows.Forms.Button btnOpret_i;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cBoxKategori_i;
        private System.Windows.Forms.ListView listPosteringer;
        private System.Windows.Forms.ColumnHeader cHeaderBeskrivelse;
        private System.Windows.Forms.ColumnHeader cHeaderBeløb;
        private System.Windows.Forms.ColumnHeader cHeaderKategori;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Button btnIndstillinger;
        private System.Windows.Forms.DateTimePicker datePicker_i;
        private System.Windows.Forms.ColumnHeader cHeaderDato;
        private System.Windows.Forms.ColumnHeader cHeaderType;
        private System.Windows.Forms.Label lblDato_i;
        private System.Windows.Forms.Label lblDato_u;
        private System.Windows.Forms.DateTimePicker datePicker_u;
        private System.Windows.Forms.ComboBox cBoxKategorier_u;
        private System.Windows.Forms.TextBox txtBeløb_u;
        private System.Windows.Forms.Button btnOpret_u;
        private System.Windows.Forms.Label lblBeskrivelse_u;
        private System.Windows.Forms.Label lblBeløb_u;
        private System.Windows.Forms.TextBox txtBeskrivelse_u;
    }
}

