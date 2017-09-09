namespace BudgetProgram
{
    partial class Indstillinger
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
            this.listBoxKategorier_i = new System.Windows.Forms.ListBox();
            this.btnNy_i = new System.Windows.Forms.Button();
            this.btnSlet_i = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnvend = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBudgetter = new System.Windows.Forms.TabPage();
            this.btnSletBudget = new System.Windows.Forms.Button();
            this.btnOpretBudget = new System.Windows.Forms.Button();
            this.listBoxBudgetter = new System.Windows.Forms.ListBox();
            this.tabKategorier = new System.Windows.Forms.TabPage();
            this.listBoxKategorier_u = new System.Windows.Forms.ListBox();
            this.btnSlet_u = new System.Windows.Forms.Button();
            this.btnNy_u = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabProfil = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lavl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabBudgetter.SuspendLayout();
            this.tabKategorier.SuspendLayout();
            this.tabProfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxKategorier_i
            // 
            this.listBoxKategorier_i.FormattingEnabled = true;
            this.listBoxKategorier_i.Location = new System.Drawing.Point(6, 22);
            this.listBoxKategorier_i.Name = "listBoxKategorier_i";
            this.listBoxKategorier_i.Size = new System.Drawing.Size(145, 186);
            this.listBoxKategorier_i.TabIndex = 0;
            this.listBoxKategorier_i.SelectedValueChanged += new System.EventHandler(this.listBoxKategorier_i_SelectedValueChanged);
            // 
            // btnNy_i
            // 
            this.btnNy_i.Location = new System.Drawing.Point(6, 213);
            this.btnNy_i.Name = "btnNy_i";
            this.btnNy_i.Size = new System.Drawing.Size(71, 23);
            this.btnNy_i.TabIndex = 1;
            this.btnNy_i.Text = "Ny";
            this.btnNy_i.UseVisualStyleBackColor = true;
            this.btnNy_i.Click += new System.EventHandler(this.btnNy_Click);
            // 
            // btnSlet_i
            // 
            this.btnSlet_i.Location = new System.Drawing.Point(83, 213);
            this.btnSlet_i.Name = "btnSlet_i";
            this.btnSlet_i.Size = new System.Drawing.Size(68, 23);
            this.btnSlet_i.TabIndex = 2;
            this.btnSlet_i.Text = "Slet";
            this.btnSlet_i.UseVisualStyleBackColor = true;
            this.btnSlet_i.Click += new System.EventHandler(this.btnSlet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Indtægtskategorier";
            // 
            // btnAnvend
            // 
            this.btnAnvend.Location = new System.Drawing.Point(150, 270);
            this.btnAnvend.Name = "btnAnvend";
            this.btnAnvend.Size = new System.Drawing.Size(75, 23);
            this.btnAnvend.TabIndex = 5;
            this.btnAnvend.Text = "Anvend";
            this.btnAnvend.UseVisualStyleBackColor = true;
            this.btnAnvend.Click += new System.EventHandler(this.btnGem_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(231, 270);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBudgetter);
            this.tabControl1.Controls.Add(this.tabKategorier);
            this.tabControl1.Controls.Add(this.tabProfil);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(317, 268);
            this.tabControl1.TabIndex = 7;
            // 
            // tabBudgetter
            // 
            this.tabBudgetter.Controls.Add(this.btnSletBudget);
            this.tabBudgetter.Controls.Add(this.btnOpretBudget);
            this.tabBudgetter.Controls.Add(this.listBoxBudgetter);
            this.tabBudgetter.Location = new System.Drawing.Point(4, 22);
            this.tabBudgetter.Name = "tabBudgetter";
            this.tabBudgetter.Size = new System.Drawing.Size(309, 242);
            this.tabBudgetter.TabIndex = 2;
            this.tabBudgetter.Text = "Budgetter";
            this.tabBudgetter.UseVisualStyleBackColor = true;
            // 
            // btnSletBudget
            // 
            this.btnSletBudget.Location = new System.Drawing.Point(177, 57);
            this.btnSletBudget.Name = "btnSletBudget";
            this.btnSletBudget.Size = new System.Drawing.Size(129, 48);
            this.btnSletBudget.TabIndex = 3;
            this.btnSletBudget.Text = "Slet Budget";
            this.btnSletBudget.UseVisualStyleBackColor = true;
            this.btnSletBudget.Click += new System.EventHandler(this.btnSletBudget_Click);
            // 
            // btnOpretBudget
            // 
            this.btnOpretBudget.Location = new System.Drawing.Point(177, 3);
            this.btnOpretBudget.Name = "btnOpretBudget";
            this.btnOpretBudget.Size = new System.Drawing.Size(129, 48);
            this.btnOpretBudget.TabIndex = 2;
            this.btnOpretBudget.Text = "Nyt Budget";
            this.btnOpretBudget.UseVisualStyleBackColor = true;
            this.btnOpretBudget.Click += new System.EventHandler(this.btnOpretBudget_Click);
            // 
            // listBoxBudgetter
            // 
            this.listBoxBudgetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxBudgetter.FormattingEnabled = true;
            this.listBoxBudgetter.ItemHeight = 25;
            this.listBoxBudgetter.Location = new System.Drawing.Point(3, 3);
            this.listBoxBudgetter.Name = "listBoxBudgetter";
            this.listBoxBudgetter.Size = new System.Drawing.Size(171, 229);
            this.listBoxBudgetter.TabIndex = 1;
            this.listBoxBudgetter.SelectedIndexChanged += new System.EventHandler(this.listBoxBudgetter_SelectedIndexChanged);
            // 
            // tabKategorier
            // 
            this.tabKategorier.Controls.Add(this.listBoxKategorier_u);
            this.tabKategorier.Controls.Add(this.btnSlet_u);
            this.tabKategorier.Controls.Add(this.btnNy_u);
            this.tabKategorier.Controls.Add(this.label2);
            this.tabKategorier.Controls.Add(this.listBoxKategorier_i);
            this.tabKategorier.Controls.Add(this.btnNy_i);
            this.tabKategorier.Controls.Add(this.btnSlet_i);
            this.tabKategorier.Controls.Add(this.label1);
            this.tabKategorier.Location = new System.Drawing.Point(4, 22);
            this.tabKategorier.Name = "tabKategorier";
            this.tabKategorier.Padding = new System.Windows.Forms.Padding(3);
            this.tabKategorier.Size = new System.Drawing.Size(309, 242);
            this.tabKategorier.TabIndex = 0;
            this.tabKategorier.Text = "Kategorier";
            this.tabKategorier.UseVisualStyleBackColor = true;
            // 
            // listBoxKategorier_u
            // 
            this.listBoxKategorier_u.FormattingEnabled = true;
            this.listBoxKategorier_u.Location = new System.Drawing.Point(157, 22);
            this.listBoxKategorier_u.Name = "listBoxKategorier_u";
            this.listBoxKategorier_u.Size = new System.Drawing.Size(145, 186);
            this.listBoxKategorier_u.TabIndex = 9;
            this.listBoxKategorier_u.SelectedValueChanged += new System.EventHandler(this.listBoxKategorier_u_SelectedValueChanged);
            // 
            // btnSlet_u
            // 
            this.btnSlet_u.Location = new System.Drawing.Point(234, 213);
            this.btnSlet_u.Name = "btnSlet_u";
            this.btnSlet_u.Size = new System.Drawing.Size(68, 23);
            this.btnSlet_u.TabIndex = 8;
            this.btnSlet_u.Text = "Slet";
            this.btnSlet_u.UseVisualStyleBackColor = true;
            this.btnSlet_u.Click += new System.EventHandler(this.btnSlet_u_Click);
            // 
            // btnNy_u
            // 
            this.btnNy_u.Location = new System.Drawing.Point(157, 213);
            this.btnNy_u.Name = "btnNy_u";
            this.btnNy_u.Size = new System.Drawing.Size(71, 23);
            this.btnNy_u.TabIndex = 7;
            this.btnNy_u.Text = "Ny";
            this.btnNy_u.UseVisualStyleBackColor = true;
            this.btnNy_u.Click += new System.EventHandler(this.btnNy_u_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Udgiftskategorier";
            // 
            // tabProfil
            // 
            this.tabProfil.Controls.Add(this.comboBox2);
            this.tabProfil.Controls.Add(this.lavl);
            this.tabProfil.Controls.Add(this.label4);
            this.tabProfil.Controls.Add(this.label3);
            this.tabProfil.Controls.Add(this.comboBox1);
            this.tabProfil.Controls.Add(this.textBox1);
            this.tabProfil.Location = new System.Drawing.Point(4, 22);
            this.tabProfil.Name = "tabProfil";
            this.tabProfil.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfil.Size = new System.Drawing.Size(309, 242);
            this.tabProfil.TabIndex = 1;
            this.tabProfil.Text = "Profil";
            this.tabProfil.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Månede",
            "År",
            "Uge"});
            this.comboBox2.Location = new System.Drawing.Point(8, 80);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // lavl
            // 
            this.lavl.AutoSize = true;
            this.lavl.Location = new System.Drawing.Point(6, 64);
            this.lavl.Name = "lavl";
            this.lavl.Size = new System.Drawing.Size(215, 13);
            this.lavl.TabIndex = 4;
            this.lavl.Text = "Som standard, vis posteringer for gældende:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valuta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Navn";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(49, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 20);
            this.textBox1.TabIndex = 0;
            // 
            // Indstillinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 296);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAnvend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Indstillinger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Indstillinger";
            this.Load += new System.EventHandler(this.Indstillinger_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabBudgetter.ResumeLayout(false);
            this.tabKategorier.ResumeLayout(false);
            this.tabKategorier.PerformLayout();
            this.tabProfil.ResumeLayout(false);
            this.tabProfil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxKategorier_i;
        private System.Windows.Forms.Button btnNy_i;
        private System.Windows.Forms.Button btnSlet_i;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnvend;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKategorier;
        private System.Windows.Forms.TabPage tabProfil;
        private System.Windows.Forms.ListBox listBoxKategorier_u;
        private System.Windows.Forms.Button btnSlet_u;
        private System.Windows.Forms.Button btnNy_u;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lavl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabBudgetter;
        private System.Windows.Forms.Button btnSletBudget;
        private System.Windows.Forms.Button btnOpretBudget;
        private System.Windows.Forms.ListBox listBoxBudgetter;
    }
}