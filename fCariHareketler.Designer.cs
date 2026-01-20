
namespace BarkodluSatis
{
    partial class fCariHareketler
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lKullanici = new BarkodluSatis.lStandart();
            this.label5 = new System.Windows.Forms.Label();
            this.lBakiye = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lToplamGider = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lToplamGelir = new System.Windows.Forms.Label();
            this.lTelefon = new System.Windows.Forms.Label();
            this.lCariAdi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bCariSec = new System.Windows.Forms.Button();
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
            this.splitContainer1.Panel1.Controls.Add(this.lKullanici);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.lBakiye);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lToplamGider);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lToplamGelir);
            this.splitContainer1.Panel1.Controls.Add(this.lTelefon);
            this.splitContainer1.Panel1.Controls.Add(this.lCariAdi);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.bCariSec);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridListe);
            this.splitContainer1.Size = new System.Drawing.Size(984, 561);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 0;
            // 
            // lKullanici
            // 
            this.lKullanici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lKullanici.AutoSize = true;
            this.lKullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lKullanici.ForeColor = System.Drawing.Color.DimGray;
            this.lKullanici.Location = new System.Drawing.Point(889, 9);
            this.lKullanici.Name = "lKullanici";
            this.lKullanici.Size = new System.Drawing.Size(83, 20);
            this.lKullanici.TabIndex = 0;
            this.lKullanici.Text = "lStandart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(623, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Bakiye";
            // 
            // lBakiye
            // 
            this.lBakiye.AutoSize = true;
            this.lBakiye.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lBakiye.ForeColor = System.Drawing.Color.Tomato;
            this.lBakiye.Location = new System.Drawing.Point(687, 75);
            this.lBakiye.Name = "lBakiye";
            this.lBakiye.Size = new System.Drawing.Size(64, 20);
            this.lBakiye.TabIndex = 8;
            this.lBakiye.Text = "0.00TL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(407, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Toplam Gider";
            // 
            // lToplamGider
            // 
            this.lToplamGider.AutoSize = true;
            this.lToplamGider.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lToplamGider.ForeColor = System.Drawing.Color.Tomato;
            this.lToplamGider.Location = new System.Drawing.Point(521, 75);
            this.lToplamGider.Name = "lToplamGider";
            this.lToplamGider.Size = new System.Drawing.Size(64, 20);
            this.lToplamGider.TabIndex = 6;
            this.lToplamGider.Text = "0.00TL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(202, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Toplam Gelir";
            // 
            // lToplamGelir
            // 
            this.lToplamGelir.AutoSize = true;
            this.lToplamGelir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lToplamGelir.ForeColor = System.Drawing.Color.Tomato;
            this.lToplamGelir.Location = new System.Drawing.Point(313, 75);
            this.lToplamGelir.Name = "lToplamGelir";
            this.lToplamGelir.Size = new System.Drawing.Size(64, 20);
            this.lToplamGelir.TabIndex = 4;
            this.lToplamGelir.Text = "0.00TL";
            // 
            // lTelefon
            // 
            this.lTelefon.AutoSize = true;
            this.lTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lTelefon.ForeColor = System.Drawing.Color.DimGray;
            this.lTelefon.Location = new System.Drawing.Point(123, 41);
            this.lTelefon.Name = "lTelefon";
            this.lTelefon.Size = new System.Drawing.Size(0, 20);
            this.lTelefon.TabIndex = 3;
            // 
            // lCariAdi
            // 
            this.lCariAdi.AutoSize = true;
            this.lCariAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lCariAdi.ForeColor = System.Drawing.Color.DimGray;
            this.lCariAdi.Location = new System.Drawing.Point(123, 12);
            this.lCariAdi.Name = "lCariAdi";
            this.lCariAdi.Size = new System.Drawing.Size(0, 20);
            this.lCariAdi.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cari Bilgisi";
            // 
            // bCariSec
            // 
            this.bCariSec.BackColor = System.Drawing.Color.Tomato;
            this.bCariSec.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.bCariSec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCariSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bCariSec.ForeColor = System.Drawing.Color.White;
            this.bCariSec.Location = new System.Drawing.Point(12, 59);
            this.bCariSec.Name = "bCariSec";
            this.bCariSec.Size = new System.Drawing.Size(128, 40);
            this.bCariSec.TabIndex = 14;
            this.bCariSec.Text = "Cari Seç";
            this.bCariSec.UseVisualStyleBackColor = false;
            this.bCariSec.Click += new System.EventHandler(this.bCariSec_Click);
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
            this.gridListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridListe.EnableHeadersVisualStyles = false;
            this.gridListe.Location = new System.Drawing.Point(0, 0);
            this.gridListe.Name = "gridListe";
            this.gridListe.ReadOnly = true;
            this.gridListe.RowHeadersVisible = false;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            this.gridListe.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridListe.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.gridListe.RowTemplate.Height = 32;
            this.gridListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListe.Size = new System.Drawing.Size(984, 447);
            this.gridListe.TabIndex = 9;
            // 
            // fCariHareketler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "fCariHareketler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Hareketler";
            this.Load += new System.EventHandler(this.fCariHareketler_Load);
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
        internal lStandart lKullanici;
        private System.Windows.Forms.Button bCariSec;
        private System.Windows.Forms.Label lCariAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lTelefon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lBakiye;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lToplamGider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lToplamGelir;
        private System.Windows.Forms.DataGridView gridListe;
    }
}