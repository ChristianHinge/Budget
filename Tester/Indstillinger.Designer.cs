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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNy_u = new System.Windows.Forms.Button();
            this.btnSlet_u = new System.Windows.Forms.Button();
            this.listBoxKategorier_u = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.btnAnvend.Location = new System.Drawing.Point(279, 270);
            this.btnAnvend.Name = "btnAnvend";
            this.btnAnvend.Size = new System.Drawing.Size(75, 23);
            this.btnAnvend.TabIndex = 5;
            this.btnAnvend.Text = "Anvend";
            this.btnAnvend.UseVisualStyleBackColor = true;
            this.btnAnvend.Click += new System.EventHandler(this.btnGem_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(360, 270);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(442, 268);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxKategorier_u);
            this.tabPage1.Controls.Add(this.btnSlet_u);
            this.tabPage1.Controls.Add(this.btnNy_u);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.listBoxKategorier_i);
            this.tabPage1.Controls.Add(this.btnNy_i);
            this.tabPage1.Controls.Add(this.btnSlet_i);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(434, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // listBoxKategorier_u
            // 
            this.listBoxKategorier_u.FormattingEnabled = true;
            this.listBoxKategorier_u.Location = new System.Drawing.Point(157, 22);
            this.listBoxKategorier_u.Name = "listBoxKategorier_u";
            this.listBoxKategorier_u.Size = new System.Drawing.Size(145, 186);
            this.listBoxKategorier_u.TabIndex = 9;
            this.listBoxKategorier_u.SelectedValueChanged += new System.EventHandler(this.listBoxKategorier_u_SelectedValueChanged);
            // 
            // Indstillinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 296);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAnvend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Indstillinger";
            this.Text = "Indstillinger";
            this.Load += new System.EventHandler(this.Indstillinger_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxKategorier_u;
        private System.Windows.Forms.Button btnSlet_u;
        private System.Windows.Forms.Button btnNy_u;
        private System.Windows.Forms.Label label2;
    }
}