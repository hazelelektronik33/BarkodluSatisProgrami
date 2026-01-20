
namespace BarkodluSatis
{
    partial class fCariAna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCariAna));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bCariHaraketleri = new BarkodluSatis.bStandart();
            this.bCariListesi = new BarkodluSatis.bStandart();
            this.bCariGruplari = new BarkodluSatis.bStandart();
            this.bCariAcilisKarti = new BarkodluSatis.bStandart();
            this.lKullanici = new BarkodluSatis.lStandart();
            this.gridListe = new BarkodluSatis.gridOzel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListe)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.lKullanici);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridListe);
            this.splitContainer1.Size = new System.Drawing.Size(459, 383);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.bCariHaraketleri, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.bCariListesi, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.bCariGruplari, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bCariAcilisKarti, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 116);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // bCariHaraketleri
            // 
            this.bCariHaraketleri.BackColor = System.Drawing.Color.Tomato;
            this.bCariHaraketleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCariHaraketleri.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bCariHaraketleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCariHaraketleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bCariHaraketleri.ForeColor = System.Drawing.Color.White;
            this.bCariHaraketleri.Image = global::BarkodluSatis.Properties.Resources.Cari_Liste32x32;
            this.bCariHaraketleri.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bCariHaraketleri.Location = new System.Drawing.Point(337, 1);
            this.bCariHaraketleri.Margin = new System.Windows.Forms.Padding(1);
            this.bCariHaraketleri.Name = "bCariHaraketleri";
            this.bCariHaraketleri.Size = new System.Drawing.Size(111, 114);
            this.bCariHaraketleri.TabIndex = 3;
            this.bCariHaraketleri.Text = "Cari Hareketleri";
            this.bCariHaraketleri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCariHaraketleri.UseVisualStyleBackColor = false;
            this.bCariHaraketleri.Click += new System.EventHandler(this.bCariHaraketleri_Click);
            // 
            // bCariListesi
            // 
            this.bCariListesi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(92)))), ((int)(((byte)(168)))));
            this.bCariListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCariListesi.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bCariListesi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCariListesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bCariListesi.ForeColor = System.Drawing.Color.White;
            this.bCariListesi.Image = global::BarkodluSatis.Properties.Resources.Cari_Hareket32x32;
            this.bCariListesi.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bCariListesi.Location = new System.Drawing.Point(225, 1);
            this.bCariListesi.Margin = new System.Windows.Forms.Padding(1);
            this.bCariListesi.Name = "bCariListesi";
            this.bCariListesi.Size = new System.Drawing.Size(110, 114);
            this.bCariListesi.TabIndex = 2;
            this.bCariListesi.Text = "Cari Listesi";
            this.bCariListesi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCariListesi.UseVisualStyleBackColor = false;
            this.bCariListesi.Click += new System.EventHandler(this.bCariListesi_Click);
            // 
            // bCariGruplari
            // 
            this.bCariGruplari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(153)))), ((int)(((byte)(112)))));
            this.bCariGruplari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCariGruplari.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bCariGruplari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCariGruplari.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bCariGruplari.ForeColor = System.Drawing.Color.White;
            this.bCariGruplari.Image = global::BarkodluSatis.Properties.Resources.Cari_Grup32x32;
            this.bCariGruplari.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bCariGruplari.Location = new System.Drawing.Point(113, 1);
            this.bCariGruplari.Margin = new System.Windows.Forms.Padding(1);
            this.bCariGruplari.Name = "bCariGruplari";
            this.bCariGruplari.Size = new System.Drawing.Size(110, 114);
            this.bCariGruplari.TabIndex = 1;
            this.bCariGruplari.Text = "Cari Grupları";
            this.bCariGruplari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCariGruplari.UseVisualStyleBackColor = false;
            this.bCariGruplari.Click += new System.EventHandler(this.bCariGruplari_Click);
            // 
            // bCariAcilisKarti
            // 
            this.bCariAcilisKarti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(133)))), ((int)(((byte)(27)))));
            this.bCariAcilisKarti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCariAcilisKarti.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bCariAcilisKarti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCariAcilisKarti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bCariAcilisKarti.ForeColor = System.Drawing.Color.White;
            this.bCariAcilisKarti.Image = global::BarkodluSatis.Properties.Resources.Cari_Kart32x32;
            this.bCariAcilisKarti.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bCariAcilisKarti.Location = new System.Drawing.Point(1, 1);
            this.bCariAcilisKarti.Margin = new System.Windows.Forms.Padding(1);
            this.bCariAcilisKarti.Name = "bCariAcilisKarti";
            this.bCariAcilisKarti.Size = new System.Drawing.Size(110, 114);
            this.bCariAcilisKarti.TabIndex = 0;
            this.bCariAcilisKarti.Text = "Cari Açılış Kartı";
            this.bCariAcilisKarti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bCariAcilisKarti.UseVisualStyleBackColor = false;
            this.bCariAcilisKarti.Click += new System.EventHandler(this.bCariAcilisKarti_Click);
            // 
            // lKullanici
            // 
            this.lKullanici.AutoSize = true;
            this.lKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lKullanici.ForeColor = System.Drawing.Color.DimGray;
            this.lKullanici.Location = new System.Drawing.Point(1307, 9);
            this.lKullanici.Name = "lKullanici";
            this.lKullanici.Size = new System.Drawing.Size(83, 20);
            this.lKullanici.TabIndex = 0;
            this.lKullanici.Text = "lStandart1";
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
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
            this.gridListe.Size = new System.Drawing.Size(459, 119);
            this.gridListe.TabIndex = 2;
            // 
            // fCariAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(459, 383);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fCariAna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fCariAna";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridListe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        internal lStandart lKullanici;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private bStandart bCariHaraketleri;
        private bStandart bCariListesi;
        private bStandart bCariGruplari;
        private bStandart bCariAcilisKarti;
        private gridOzel gridListe;
    }
}