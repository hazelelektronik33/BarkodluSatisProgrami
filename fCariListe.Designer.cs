
namespace BarkodluSatis
{
    partial class fCariListe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCariListe));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lKullanici = new BarkodluSatis.lStandart();
            this.tCariGrup = new BarkodluSatis.tStandart();
            this.tVergiNo = new BarkodluSatis.tStandart();
            this.lStandart5 = new BarkodluSatis.lStandart();
            this.tCariAdi = new BarkodluSatis.tStandart();
            this.tCariKodu = new BarkodluSatis.tStandart();
            this.bTemizle = new BarkodluSatis.bStandart();
            this.bAra = new BarkodluSatis.bStandart();
            this.lStandart4 = new BarkodluSatis.lStandart();
            this.lCariGrup = new BarkodluSatis.lStandart();
            this.lStandart2 = new BarkodluSatis.lStandart();
            this.lStandart1 = new BarkodluSatis.lStandart();
            this.gridListe = new BarkodluSatis.gridOzel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListe)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lKullanici);
            this.splitContainer1.Panel1.Controls.Add(this.tCariGrup);
            this.splitContainer1.Panel1.Controls.Add(this.tVergiNo);
            this.splitContainer1.Panel1.Controls.Add(this.lStandart5);
            this.splitContainer1.Panel1.Controls.Add(this.tCariAdi);
            this.splitContainer1.Panel1.Controls.Add(this.tCariKodu);
            this.splitContainer1.Panel1.Controls.Add(this.bTemizle);
            this.splitContainer1.Panel1.Controls.Add(this.bAra);
            this.splitContainer1.Panel1.Controls.Add(this.lStandart4);
            this.splitContainer1.Panel1.Controls.Add(this.lCariGrup);
            this.splitContainer1.Panel1.Controls.Add(this.lStandart2);
            this.splitContainer1.Panel1.Controls.Add(this.lStandart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridListe);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 554);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 0;
            // 
            // lKullanici
            // 
            this.lKullanici.AutoSize = true;
            this.lKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lKullanici.ForeColor = System.Drawing.Color.DimGray;
            this.lKullanici.Location = new System.Drawing.Point(17, 393);
            this.lKullanici.Name = "lKullanici";
            this.lKullanici.Size = new System.Drawing.Size(83, 20);
            this.lKullanici.TabIndex = 9;
            this.lKullanici.Text = "lStandart3";
            // 
            // tCariGrup
            // 
            this.tCariGrup.BackColor = System.Drawing.Color.White;
            this.tCariGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tCariGrup.Location = new System.Drawing.Point(15, 265);
            this.tCariGrup.Name = "tCariGrup";
            this.tCariGrup.Size = new System.Drawing.Size(250, 26);
            this.tCariGrup.TabIndex = 3;
            // 
            // tVergiNo
            // 
            this.tVergiNo.BackColor = System.Drawing.Color.White;
            this.tVergiNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tVergiNo.Location = new System.Drawing.Point(15, 204);
            this.tVergiNo.Name = "tVergiNo";
            this.tVergiNo.Size = new System.Drawing.Size(250, 26);
            this.tVergiNo.TabIndex = 2;
            // 
            // lStandart5
            // 
            this.lStandart5.AutoSize = true;
            this.lStandart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart5.ForeColor = System.Drawing.Color.DimGray;
            this.lStandart5.Location = new System.Drawing.Point(13, 181);
            this.lStandart5.Name = "lStandart5";
            this.lStandart5.Size = new System.Drawing.Size(70, 20);
            this.lStandart5.TabIndex = 6;
            this.lStandart5.Text = "Vergi No";
            // 
            // tCariAdi
            // 
            this.tCariAdi.BackColor = System.Drawing.Color.White;
            this.tCariAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tCariAdi.Location = new System.Drawing.Point(17, 143);
            this.tCariAdi.Name = "tCariAdi";
            this.tCariAdi.Size = new System.Drawing.Size(250, 26);
            this.tCariAdi.TabIndex = 1;
            this.tCariAdi.TextChanged += new System.EventHandler(this.tCariAdi_TextChanged);
            // 
            // tCariKodu
            // 
            this.tCariKodu.BackColor = System.Drawing.Color.White;
            this.tCariKodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tCariKodu.Location = new System.Drawing.Point(17, 80);
            this.tCariKodu.Name = "tCariKodu";
            this.tCariKodu.Size = new System.Drawing.Size(250, 26);
            this.tCariKodu.TabIndex = 0;
            // 
            // bTemizle
            // 
            this.bTemizle.BackColor = System.Drawing.Color.DarkMagenta;
            this.bTemizle.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bTemizle.ForeColor = System.Drawing.Color.White;
            this.bTemizle.Image = global::BarkodluSatis.Properties.Resources.Sil32x32;
            this.bTemizle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bTemizle.Location = new System.Drawing.Point(152, 308);
            this.bTemizle.Margin = new System.Windows.Forms.Padding(1);
            this.bTemizle.Name = "bTemizle";
            this.bTemizle.Size = new System.Drawing.Size(115, 66);
            this.bTemizle.TabIndex = 7;
            this.bTemizle.Text = "Temizle";
            this.bTemizle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bTemizle.UseVisualStyleBackColor = false;
            // 
            // bAra
            // 
            this.bAra.BackColor = System.Drawing.Color.DarkOrange;
            this.bAra.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bAra.ForeColor = System.Drawing.Color.White;
            this.bAra.Image = global::BarkodluSatis.Properties.Resources.Ara32x32;
            this.bAra.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bAra.Location = new System.Drawing.Point(15, 308);
            this.bAra.Margin = new System.Windows.Forms.Padding(1);
            this.bAra.Name = "bAra";
            this.bAra.Size = new System.Drawing.Size(115, 66);
            this.bAra.TabIndex = 6;
            this.bAra.Text = "Ara";
            this.bAra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bAra.UseVisualStyleBackColor = false;
            // 
            // lStandart4
            // 
            this.lStandart4.AutoSize = true;
            this.lStandart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lStandart4.ForeColor = System.Drawing.Color.Maroon;
            this.lStandart4.Location = new System.Drawing.Point(12, 9);
            this.lStandart4.Name = "lStandart4";
            this.lStandart4.Size = new System.Drawing.Size(75, 25);
            this.lStandart4.TabIndex = 3;
            this.lStandart4.Text = "Arama";
            // 
            // lCariGrup
            // 
            this.lCariGrup.AutoSize = true;
            this.lCariGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lCariGrup.ForeColor = System.Drawing.Color.DimGray;
            this.lCariGrup.Location = new System.Drawing.Point(13, 242);
            this.lCariGrup.Name = "lCariGrup";
            this.lCariGrup.Size = new System.Drawing.Size(77, 20);
            this.lCariGrup.TabIndex = 2;
            this.lCariGrup.Text = "Cari Grup";
            // 
            // lStandart2
            // 
            this.lStandart2.AutoSize = true;
            this.lStandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart2.ForeColor = System.Drawing.Color.DimGray;
            this.lStandart2.Location = new System.Drawing.Point(13, 120);
            this.lStandart2.Name = "lStandart2";
            this.lStandart2.Size = new System.Drawing.Size(64, 20);
            this.lStandart2.TabIndex = 1;
            this.lStandart2.Text = "Cari Adı";
            // 
            // lStandart1
            // 
            this.lStandart1.AutoSize = true;
            this.lStandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart1.ForeColor = System.Drawing.Color.DimGray;
            this.lStandart1.Location = new System.Drawing.Point(11, 57);
            this.lStandart1.Name = "lStandart1";
            this.lStandart1.Size = new System.Drawing.Size(78, 20);
            this.lStandart1.TabIndex = 0;
            this.lStandart1.Text = "Cari Kodu";
            // 
            // gridListe
            // 
            this.gridListe.AllowUserToAddRows = false;
            this.gridListe.AllowUserToDeleteRows = false;
            this.gridListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridListe.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gridListe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListe.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridListe.EnableHeadersVisualStyles = false;
            this.gridListe.Location = new System.Drawing.Point(0, 0);
            this.gridListe.Name = "gridListe";
            this.gridListe.ReadOnly = true;
            this.gridListe.RowHeadersVisible = false;
            this.gridListe.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gridListe.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gridListe.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.gridListe.RowTemplate.Height = 32;
            this.gridListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListe.Size = new System.Drawing.Size(770, 554);
            this.gridListe.TabIndex = 2;
            // 
            // fCariListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fCariListe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Listesi";
            this.Load += new System.EventHandler(this.fCariListe_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridListe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private lStandart lStandart4;
        private lStandart lCariGrup;
        private lStandart lStandart2;
        private lStandart lStandart1;
        private tStandart tCariGrup;
        private tStandart tVergiNo;
        private lStandart lStandart5;
        private tStandart tCariAdi;
        private tStandart tCariKodu;
        private bStandart bTemizle;
        private bStandart bAra;
        internal lStandart lKullanici;
        private gridOzel gridListe;
    }
}