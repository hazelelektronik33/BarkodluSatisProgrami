
namespace BarkodluSatis
{
    partial class fProjeler
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lKullanici = new System.Windows.Forms.Label();
            this.bYenile = new System.Windows.Forms.Button();
            this.bSil = new System.Windows.Forms.Button();
            this.bDuzenle = new System.Windows.Forms.Button();
            this.bYeniEkle = new System.Windows.Forms.Button();
            this.gridListe = new System.Windows.Forms.DataGridView();
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
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.lKullanici);
            this.splitContainer1.Panel1.Controls.Add(this.bYenile);
            this.splitContainer1.Panel1.Controls.Add(this.bSil);
            this.splitContainer1.Panel1.Controls.Add(this.bDuzenle);
            this.splitContainer1.Panel1.Controls.Add(this.bYeniEkle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridListe);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 0;
            // 
            // lKullanici
            // 
            this.lKullanici.AutoSize = true;
            this.lKullanici.Location = new System.Drawing.Point(850, 23);
            this.lKullanici.Name = "lKullanici";
            this.lKullanici.Size = new System.Drawing.Size(46, 13);
            this.lKullanici.TabIndex = 4;
            this.lKullanici.Text = "Kullanıcı";
            this.lKullanici.Visible = false;
            // 
            // bYenile
            // 
            this.bYenile.BackColor = System.Drawing.Color.Thistle;
            this.bYenile.Location = new System.Drawing.Point(276, 12);
            this.bYenile.Name = "bYenile";
            this.bYenile.Size = new System.Drawing.Size(82, 35);
            this.bYenile.TabIndex = 3;
            this.bYenile.Text = "Yenile";
            this.bYenile.UseVisualStyleBackColor = false;
            this.bYenile.Click += new System.EventHandler(this.bYenile_Click);
            // 
            // bSil
            // 
            this.bSil.BackColor = System.Drawing.Color.Crimson;
            this.bSil.Location = new System.Drawing.Point(188, 12);
            this.bSil.Name = "bSil";
            this.bSil.Size = new System.Drawing.Size(82, 35);
            this.bSil.TabIndex = 2;
            this.bSil.Text = "Sil";
            this.bSil.UseVisualStyleBackColor = false;
            this.bSil.Click += new System.EventHandler(this.bSil_Click);
            // 
            // bDuzenle
            // 
            this.bDuzenle.BackColor = System.Drawing.Color.SlateBlue;
            this.bDuzenle.Location = new System.Drawing.Point(100, 12);
            this.bDuzenle.Name = "bDuzenle";
            this.bDuzenle.Size = new System.Drawing.Size(82, 35);
            this.bDuzenle.TabIndex = 1;
            this.bDuzenle.Text = "Detay/Düzenle";
            this.bDuzenle.UseVisualStyleBackColor = false;
            this.bDuzenle.Click += new System.EventHandler(this.bDuzenle_Click);
            // 
            // bYeniEkle
            // 
            this.bYeniEkle.BackColor = System.Drawing.Color.Olive;
            this.bYeniEkle.Location = new System.Drawing.Point(12, 12);
            this.bYeniEkle.Name = "bYeniEkle";
            this.bYeniEkle.Size = new System.Drawing.Size(82, 35);
            this.bYeniEkle.TabIndex = 0;
            this.bYeniEkle.Text = "+ Yeni Ekle";
            this.bYeniEkle.UseVisualStyleBackColor = false;
            this.bYeniEkle.Click += new System.EventHandler(this.bYeniEkle_Click);
            // 
            // gridListe
            // 
            this.gridListe.AllowUserToAddRows = false;
            this.gridListe.AllowUserToDeleteRows = false;
            this.gridListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridListe.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gridListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridListe.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridListe.Location = new System.Drawing.Point(0, 0);
            this.gridListe.MultiSelect = false;
            this.gridListe.Name = "gridListe";
            this.gridListe.ReadOnly = true;
            this.gridListe.RowHeadersVisible = false;
            this.gridListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListe.Size = new System.Drawing.Size(984, 497);
            this.gridListe.TabIndex = 0;
            // 
            // fProjeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fProjeler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje ve Teklif Listesi";
            this.Load += new System.EventHandler(this.fProjeler_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridListe)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bYeniEkle;
        private System.Windows.Forms.Button bDuzenle;
        private System.Windows.Forms.Button bSil;
        private System.Windows.Forms.Button bYenile;
        private System.Windows.Forms.DataGridView gridListe;
        public System.Windows.Forms.Label lKullanici; // internal access
    }
}