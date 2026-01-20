using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fCariListe : Form
    {
      

        public fCariListe()
        {
            InitializeComponent();
        }
        BarkodDbEntities db = new BarkodDbEntities();
        private void fCariListe_Load(object sender, EventArgs e)
        {
            gridListe.DataSource = db.Cariler.OrderByDescending(a => a.Id).Take(20).ToList();
            // 1) Kolonlar sıkışmasın
            gridListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridListe.ScrollBars = ScrollBars.Both;

            // 2) Header ayrı, hücre ayrı stil
            gridListe.EnableHeadersVisualStyles = false;

            var header = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(0, 174, 219),
                ForeColor = Color.White,
                Padding = new Padding(3),
                WrapMode = DataGridViewTriState.False
            };
            gridListe.ColumnHeadersDefaultCellStyle = header;

            var cell = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Black,
                Padding = new Padding(3),
                WrapMode = DataGridViewTriState.False
            };
            gridListe.DefaultCellStyle = cell;

            // 3) İstersen önemli kolonları dondur (solda sabit)
            if (gridListe.Columns.Contains("CariKodu")) gridListe.Columns["CariKodu"].Frozen = true;
            if (gridListe.Columns.Contains("CariAdi")) gridListe.Columns["CariAdi"].Frozen = true;

            Islemler.GridDuzenle(gridListe);

            // Context Menu Ekleme (Kod ile)
            ContextMenuStrip ctx = new ContextMenuStrip();
            ToolStripMenuItem menuEkle = new ToolStripMenuItem("Yeni Cari Ekle");
            ToolStripMenuItem menuDuzenle = new ToolStripMenuItem("Düzenle");
            ToolStripMenuItem menuSil = new ToolStripMenuItem("Sil");

            menuEkle.Click += MenuEkle_Click;
            menuDuzenle.Click += MenuDuzenle_Click;
            menuSil.Click += MenuSil_Click;

            ctx.Items.Add(menuEkle);
            ctx.Items.Add(menuDuzenle);
            ctx.Items.Add(menuSil);

            gridListe.ContextMenuStrip = ctx;
            gridListe.DoubleClick += GridListe_DoubleClick;
        }


        public bool SecimModu = false;
        public int SecilenCariId = 0;
        public string SecilenCariAdi = "";

        private void GridListe_DoubleClick(object sender, EventArgs e)
        {
            if (SecimModu)
            {
                 if (gridListe.SelectedRows.Count > 0)
                 {
                    SecilenCariId = Convert.ToInt32(gridListe.SelectedRows[0].Cells["Id"].Value);
                    SecilenCariAdi = gridListe.SelectedRows[0].Cells["CariAdi"].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                 }
            }
            else
            {
                MenuDuzenle_Click(sender, e);
            }
        }

        private void MenuEkle_Click(object sender, EventArgs e)
        {
            fCariAcilisKarti f = new fCariAcilisKarti();
            f.ShowDialog();
            // Dönüşte listeyi yenile (bAra_Click tetiklenebilir veya Load tekrar)
            bAra_Click(null, null);
        }

        private void MenuDuzenle_Click(object sender, EventArgs e)
        {
            if (gridListe.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(gridListe.SelectedRows[0].Cells["Id"].Value);
                fCariAcilisKarti f = new fCariAcilisKarti();
                f.AcilisId = id;
                f.ShowDialog();
                bAra_Click(null, null);
            }
        }

        private void MenuSil_Click(object sender, EventArgs e)
        {
            if (gridListe.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(gridListe.SelectedRows[0].Cells["Id"].Value);
                if (MessageBox.Show("Seçili cariyi silmek istiyor musunuz?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        var silinecek = db.Cariler.Find(id);
                        if (silinecek != null)
                        {
                            db.Cariler.Remove(silinecek);
                            db.SaveChanges();
                            bAra_Click(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                         MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
        }

        private void bAra_Click(object sender, EventArgs e)
        {
            TumunuListele();
        }

        private void TumunuListele()
        {
             gridListe.DataSource = db.Cariler.OrderByDescending(a => a.Id).ToList();
             Islemler.GridDuzenle(gridListe);
        }

        private void tCariAdi_TextChanged(object sender, EventArgs e)
        {
            string cariadi = tCariAdi.Text;
            if (tCariAdi.Text.Length >= 2) // 3'tü 2 yaptım daha seri olsun
            {
                 var aranan = db.Cariler.Where(x => x.CariAdi.Contains(cariadi)).ToList();
                 gridListe.DataSource = aranan;
                 Islemler.GridDuzenle(gridListe);
            }
            else if (tCariAdi.Text.Length == 0)
            {
                TumunuListele();
            }
        }
    }
}
