namespace Tester
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
            this.listBoxKategorier = new System.Windows.Forms.ListBox();
            this.btnNy = new System.Windows.Forms.Button();
            this.btnSlet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxKategorier
            // 
            this.listBoxKategorier.FormattingEnabled = true;
            this.listBoxKategorier.Items.AddRange(new object[] {
            "hej",
            "hej",
            "ny"});
            this.listBoxKategorier.Location = new System.Drawing.Point(12, 21);
            this.listBoxKategorier.Name = "listBoxKategorier";
            this.listBoxKategorier.Size = new System.Drawing.Size(120, 95);
            this.listBoxKategorier.TabIndex = 0;
            // 
            // btnNy
            // 
            this.btnNy.Location = new System.Drawing.Point(12, 122);
            this.btnNy.Name = "btnNy";
            this.btnNy.Size = new System.Drawing.Size(51, 23);
            this.btnNy.TabIndex = 1;
            this.btnNy.Text = "Ny";
            this.btnNy.UseVisualStyleBackColor = true;
            // 
            // btnSlet
            // 
            this.btnSlet.Location = new System.Drawing.Point(69, 122);
            this.btnSlet.Name = "btnSlet";
            this.btnSlet.Size = new System.Drawing.Size(63, 23);
            this.btnSlet.TabIndex = 2;
            this.btnSlet.Text = "Slet";
            this.btnSlet.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Indtægtskategorier";
            // 
            // Indstillinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSlet);
            this.Controls.Add(this.btnNy);
            this.Controls.Add(this.listBoxKategorier);
            this.Name = "Indstillinger";
            this.Text = "Indstillinger";
            this.Load += new System.EventHandler(this.Indstillinger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxKategorier;
        private System.Windows.Forms.Button btnNy;
        private System.Windows.Forms.Button btnSlet;
        private System.Windows.Forms.Label label1;
    }
}