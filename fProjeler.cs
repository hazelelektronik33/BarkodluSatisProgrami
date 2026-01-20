using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fProjeler : Form
    {
        private readonly BarkodDbEntities db = new BarkodDbEntities();

        public fProjeler()
        {
            InitializeComponent();
        }

        private void fProjeler_Load(object sender, EventArgs e)
        {
            ProjeleriListele();
        }

        private void ProjeleriListele()
        {
            var liste = db.Teklifler.Select(x => new
            {
                x.Id,
                x.EvrakNo,
                Tip = (x.Tip == 0 ? "Teklif" : "Proje"),
                x.CariAdi,
                x.GenelToplam,
                x.Durum,
                x.Tarih,
                x.Kullanici
            }).OrderByDescending(x => x.Id).ToList();

            gridListe.DataSource = liste;

            // Kolon başlıkları ve format
            gridListe.Columns["Id"].Visible = false;
            gridListe.Columns["GenelToplam"].DefaultCellStyle.Format = "C2";
            gridListe.Columns["Tarih"].DefaultCellStyle.Format = "d";

            gridListe.Columns["EvrakNo"].HeaderText = "Evrak No";
            gridListe.Columns["CariAdi"].HeaderText = "Cari Adı";
            gridListe.Columns["GenelToplam"].HeaderText = "Tutar";
            gridListe.Columns["Durum"].HeaderText = "Durum";
            gridListe.Columns["Kullanici"].HeaderText = "Kullanıcı";
        }

        private void bYeniEkle_Click(object sender, EventArgs e)
        {
            fProjeKayit f = new fProjeKayit();
            f.GelenKullanici = lKullanici.Text;
            f.ShowDialog();
            
            // Dönüşte listeyi yenile
            ProjeleriListele();
        }

        private void bDuzenle_Click(object sender, EventArgs e)
        {
            if (gridListe.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(gridListe.SelectedRows[0].Cells["Id"].Value);
                
                fProjeKayit f = new fProjeKayit();
                f.GelenKullanici = lKullanici.Text;
                f.AcilisId = id;
                f.ShowDialog();
                
                ProjeleriListele();
            }
        }


        private void bSil_Click(object sender, EventArgs e)
        {
             if (gridListe.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(gridListe.SelectedRows[0].Cells["Id"].Value);
                if (MessageBox.Show("Seçili kaydı silmek istiyor musunuz?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        var silinecek = db.Teklifler.Find(id);
                        if (silinecek != null)
                        {
                            db.Teklifler.Remove(silinecek);
                            // Kalemleri de sil (Cascade yoksa) - EntityFramework genelde halleder ama manual silebiliriz
                            var kalemler = db.TeklifKalemler.Where(x => x.TeklifId == id).ToList();
                            db.TeklifKalemler.RemoveRange(kalemler);
                            
                            db.SaveChanges();
                            ProjeleriListele();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme hatası: " + ex.Message);
                    }
                }
            }
        }

        private void bYenile_Click(object sender, EventArgs e)
        {
            ProjeleriListele();
        }
    }
}
