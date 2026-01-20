namespace BarkodluSatis
{
    partial class fKurAyarlari
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
            this.tUsdKur = new System.Windows.Forms.TextBox();
            this.bKaydet = new System.Windows.Forms.Button();
            this.lSonKur = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tUsdKur
            // 
            this.tUsdKur.Location = new System.Drawing.Point(243, 108);
            this.tUsdKur.Name = "tUsdKur";
            this.tUsdKur.Size = new System.Drawing.Size(135, 20);
            this.tUsdKur.TabIndex = 0;
            this.tUsdKur.Text = "0";
            this.tUsdKur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bKaydet
            // 
            this.bKaydet.BackColor = System.Drawing.Color.DeepPink;
            this.bKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bKaydet.ForeColor = System.Drawing.Color.White;
            this.bKaydet.Location = new System.Drawing.Point(243, 161);
            this.bKaydet.Name = "bKaydet";
            this.bKaydet.Size = new System.Drawing.Size(135, 69);
            this.bKaydet.TabIndex = 1;
            this.bKaydet.Text = "Kaydet";
            this.bKaydet.UseVisualStyleBackColor = false;
            this.bKaydet.Click += new System.EventHandler(this.bKaydet_Click);
            // 
            // lSonKur
            // 
            this.lSonKur.AutoSize = true;
            this.lSonKur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lSonKur.Location = new System.Drawing.Point(243, 56);
            this.lSonKur.Name = "lSonKur";
            this.lSonKur.Size = new System.Drawing.Size(66, 24);
            this.lSonKur.TabIndex = 2;
            this.lSonKur.Text = "label1";
            // 
            // fKurAyarlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lSonKur);
            this.Controls.Add(this.bKaydet);
            this.Controls.Add(this.tUsdKur);
            this.Name = "fKurAyarlari";
            this.Text = "fKurAyarlari";
            this.Load += new System.EventHandler(this.fKurAyarlari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tUsdKur;
        private System.Windows.Forms.Button bKaydet;
        private System.Windows.Forms.Label lSonKur;
    }
}