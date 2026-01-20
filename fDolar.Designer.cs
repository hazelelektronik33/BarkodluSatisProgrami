
namespace BarkodluSatis
{
    partial class fDolar
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
            this.lDolar = new BarkodluSatis.lStandart();
            this.SuspendLayout();
            // 
            // lDolar
            // 
            this.lDolar.AutoSize = true;
            this.lDolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lDolar.ForeColor = System.Drawing.Color.DimGray;
            this.lDolar.Location = new System.Drawing.Point(46, 68);
            this.lDolar.Name = "lDolar";
            this.lDolar.Size = new System.Drawing.Size(83, 20);
            this.lDolar.TabIndex = 0;
            this.lDolar.Text = "lStandart1";
            // 
            // fDolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lDolar);
            this.Name = "fDolar";
            this.Text = "fDolar";
            this.Load += new System.EventHandler(this.fDolar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal lStandart lDolar;
    }
}