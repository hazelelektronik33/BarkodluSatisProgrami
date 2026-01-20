
namespace BarkodluSatis
{
    partial class fLisans
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
            this.tStandart1 = new BarkodluSatis.tStandart();
            this.lStandart1 = new BarkodluSatis.lStandart();

            this.SuspendLayout();
            // 
            // tStandart1
            // 
            this.tStandart1.BackColor = System.Drawing.Color.White;
            this.tStandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tStandart1.Location = new System.Drawing.Point(115, 235);
            this.tStandart1.Name = "tStandart1";
            this.tStandart1.Size = new System.Drawing.Size(250, 26);
            this.tStandart1.TabIndex = 0;
            // 
            // lStandart1
            // 
            this.lStandart1.AutoSize = true;
            this.lStandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart1.ForeColor = System.Drawing.Color.DimGray;
            this.lStandart1.Location = new System.Drawing.Point(45, 44);
            this.lStandart1.Name = "lStandart1";
            this.lStandart1.Size = new System.Drawing.Size(83, 20);
            this.lStandart1.TabIndex = 1;
            this.lStandart1.Text = "Kontrol No";
            // 
        
            // 
            // fLisans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);

            this.Controls.Add(this.lStandart1);
            this.Controls.Add(this.tStandart1);
            this.Name = "fLisans";
            this.Text = "fLisans";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private tStandart tStandart1;
        private lStandart lStandart1;
        
    }
}