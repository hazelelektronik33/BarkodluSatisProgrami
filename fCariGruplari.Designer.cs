
using System;

namespace BarkodluSatis
{
    partial class fCariGruplari
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lKullanici = new BarkodluSatis.lStandart();
            this.bKapat = new BarkodluSatis.bStandart();
            this.tGrupAdi = new BarkodluSatis.tStandart();
            this.lStandart5 = new BarkodluSatis.lStandart();
            this.tGrupKodu = new BarkodluSatis.tStandart();
            this.bSil = new BarkodluSatis.bStandart();
            this.bKaydet = new BarkodluSatis.bStandart();
            this.lStandart4 = new BarkodluSatis.lStandart();
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lKullanici);
            this.splitContainer1.Panel1.Controls.Add(this.bKapat);
            this.splitContainer1.Panel1.Controls.Add(this.tGrupAdi);
            this.splitContainer1.Panel1.Controls.Add(this.lStandart5);
            this.splitContainer1.Panel1.Controls.Add(this.tGrupKodu);
            this.splitContainer1.Panel1.Controls.Add(this.bSil);
            this.splitContainer1.Panel1.Controls.Add(this.bKaydet);
            this.splitContainer1.Panel1.Controls.Add(this.lStandart4);
            this.splitContainer1.Panel1.Controls.Add(this.lStandart2);
            this.splitContainer1.Panel1.Controls.Add(this.lStandart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridListe);
            this.splitContainer1.Size = new System.Drawing.Size(372, 413);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 0;
            // 
            // lKullanici
            // 
            this.lKullanici.AutoSize = true;
            this.lKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lKullanici.ForeColor = System.Drawing.Color.DimGray;
            this.lKullanici.Location = new System.Drawing.Point(279, 22);
            this.lKullanici.Name = "lKullanici";
            this.lKullanici.Size = new System.Drawing.Size(83, 20);
            this.lKullanici.TabIndex = 20;
            this.lKullanici.Text = "lStandart3";
            // 
            // bKapat
            // 
            this.bKapat.BackColor = System.Drawing.Color.DarkMagenta;
            this.bKapat.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bKapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bKapat.ForeColor = System.Drawing.Color.White;
            this.bKapat.Image = global::BarkodluSatis.Properties.Resources.Kapat24x24;
            this.bKapat.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bKapat.Location = new System.Drawing.Point(247, 176);
            this.bKapat.Margin = new System.Windows.Forms.Padding(1);
            this.bKapat.Name = "bKapat";
            this.bKapat.Size = new System.Drawing.Size(115, 66);
            this.bKapat.TabIndex = 19;
            this.bKapat.Text = "Kapat";
            this.bKapat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bKapat.UseVisualStyleBackColor = false;
            // 
            // tGrupAdi
            // 
            this.tGrupAdi.BackColor = System.Drawing.Color.White;
            this.tGrupAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tGrupAdi.Location = new System.Drawing.Point(129, 114);
            this.tGrupAdi.Name = "tGrupAdi";
            this.tGrupAdi.Size = new System.Drawing.Size(233, 26);
            this.tGrupAdi.TabIndex = 18;
            // 
            // lStandart5
            // 
            this.lStandart5.AutoSize = true;
            this.lStandart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart5.ForeColor = System.Drawing.Color.DimGray;
            this.lStandart5.Location = new System.Drawing.Point(12, 120);
            this.lStandart5.Name = "lStandart5";
            this.lStandart5.Size = new System.Drawing.Size(72, 20);
            this.lStandart5.TabIndex = 17;
            this.lStandart5.Text = "Grup Adı";
            // 
            // tGrupKodu
            // 
            this.tGrupKodu.BackColor = System.Drawing.Color.White;
            this.tGrupKodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tGrupKodu.Location = new System.Drawing.Point(129, 66);
            this.tGrupKodu.Name = "tGrupKodu";
            this.tGrupKodu.Size = new System.Drawing.Size(233, 26);
            this.tGrupKodu.TabIndex = 16;
            // 
            // bSil
            // 
            this.bSil.BackColor = System.Drawing.Color.DarkMagenta;
            this.bSil.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bSil.ForeColor = System.Drawing.Color.White;
            this.bSil.Image = global::BarkodluSatis.Properties.Resources.Sil24x24;
            this.bSil.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bSil.Location = new System.Drawing.Point(129, 176);
            this.bSil.Margin = new System.Windows.Forms.Padding(1);
            this.bSil.Name = "bSil";
            this.bSil.Size = new System.Drawing.Size(115, 66);
            this.bSil.TabIndex = 9;
            this.bSil.Text = "Sil";
            this.bSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bSil.UseVisualStyleBackColor = false;
            // 
            // bKaydet
            // 
            this.bKaydet.BackColor = System.Drawing.Color.DarkOrange;
            this.bKaydet.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bKaydet.ForeColor = System.Drawing.Color.White;
            this.bKaydet.Image = global::BarkodluSatis.Properties.Resources.Kaydet24x24;
            this.bKaydet.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bKaydet.Location = new System.Drawing.Point(10, 176);
            this.bKaydet.Margin = new System.Windows.Forms.Padding(1);
            this.bKaydet.Name = "bKaydet";
            this.bKaydet.Size = new System.Drawing.Size(115, 66);
            this.bKaydet.TabIndex = 10;
            this.bKaydet.Text = "Kaydet";
            this.bKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bKaydet.UseVisualStyleBackColor = false;
            this.bKaydet.Click += new System.EventHandler(this.bKaydet_Click);
            // 
            // lStandart4
            // 
            this.lStandart4.AutoSize = true;
            this.lStandart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lStandart4.ForeColor = System.Drawing.Color.Maroon;
            this.lStandart4.Location = new System.Drawing.Point(273, -49);
            this.lStandart4.Name = "lStandart4";
            this.lStandart4.Size = new System.Drawing.Size(75, 25);
            this.lStandart4.TabIndex = 14;
            this.lStandart4.Text = "Arama";
            // 
            // lStandart2
            // 
            this.lStandart2.AutoSize = true;
            this.lStandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart2.ForeColor = System.Drawing.Color.DimGray;
            this.lStandart2.Location = new System.Drawing.Point(12, 69);
            this.lStandart2.Name = "lStandart2";
            this.lStandart2.Size = new System.Drawing.Size(86, 20);
            this.lStandart2.TabIndex = 12;
            this.lStandart2.Text = "Grup Kodu";
            // 
            // lStandart1
            // 
            this.lStandart1.AutoSize = true;
            this.lStandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lStandart1.ForeColor = System.Drawing.Color.DimGray;
            this.lStandart1.Location = new System.Drawing.Point(12, 22);
            this.lStandart1.Name = "lStandart1";
            this.lStandart1.Size = new System.Drawing.Size(89, 20);
            this.lStandart1.TabIndex = 11;
            this.lStandart1.Text = "Grup Bilgisi";
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
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
            this.gridListe.Size = new System.Drawing.Size(372, 156);
            this.gridListe.TabIndex = 2;
            this.gridListe.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridListe_CellDoubleClick);
            // 
            // fCariGruplari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 413);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fCariGruplari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Grup";
            this.Load += new System.EventHandler(this.fCariGruplari_Load);
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
        private bStandart bKapat;
        private tStandart tGrupAdi;
        private lStandart lStandart5;
        private tStandart tGrupKodu;
        private bStandart bSil;
        private bStandart bKaydet;
        private lStandart lStandart4;
        private lStandart lStandart2;
        private lStandart lStandart1;
        private gridOzel gridListe;
        internal lStandart lKullanici;
    }
}