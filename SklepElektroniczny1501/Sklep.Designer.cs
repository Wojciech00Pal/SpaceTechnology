namespace SklepElektroniczny1501
{
    partial class Sklep
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
            this.prod = new System.Windows.Forms.Button();
            this.zam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // prod
            // 
            this.prod.Location = new System.Drawing.Point(16, 30);
            this.prod.Margin = new System.Windows.Forms.Padding(4);
            this.prod.Name = "prod";
            this.prod.Size = new System.Drawing.Size(155, 82);
            this.prod.TabIndex = 0;
            this.prod.Text = "Produkty";
            this.prod.UseMnemonic = false;
            this.prod.UseVisualStyleBackColor = true;
            this.prod.Click += new System.EventHandler(this.prod_Click);
            // 
            // zam
            // 
            this.zam.Location = new System.Drawing.Point(192, 30);
            this.zam.Margin = new System.Windows.Forms.Padding(4);
            this.zam.Name = "zam";
            this.zam.Size = new System.Drawing.Size(159, 82);
            this.zam.TabIndex = 1;
            this.zam.Text = "Zamówienia";
            this.zam.UseVisualStyleBackColor = true;
            this.zam.Click += new System.EventHandler(this.zam_Click);
            // 
            // Sklep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 187);
            this.Controls.Add(this.zam);
            this.Controls.Add(this.prod);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Sklep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sklep";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button prod;
        private System.Windows.Forms.Button zam;
    }
}