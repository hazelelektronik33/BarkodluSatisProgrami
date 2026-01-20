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
    public partial class fCariGruplari : Form
    {
        private readonly BarkodDbEntities db = new BarkodDbEntities();

        public fCariGruplari()
        {
            InitializeComponent();
        }

        private void fCariGruplari_Load(object sender, EventArgs e)
        {
            Listele();
            Islemler.GridDuzenle(gridListe);
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            string kod = tGrupKodu.Text.Trim().ToUpperInvariant();
            string ad = tGrupAdi.Text.Trim();

            if (string.IsNullOrWhiteSpace(kod) || string.IsNullOrWhiteSpace(ad))
            {
                MessageBox.Show("Grup Kodu ve Grup Adı zorunludur.");
                return;
            }

            // Tek sorgu ile bul
            var grup = db.CariGrup.SingleOrDefault(x => x.GrupKodu == kod);

            if (grup == null)
            {
                // Yeni kayıt
                grup = new CariGrup
                {
                    GrupKodu = kod,
                    GrupAdi = ad,
                    KullaniciKayit = lKullanici.Text,
                    TarihKaydet = DateTime.Now
                };

                db.CariGrup.Add(grup);
                db.SaveChanges();

                MessageBox.Show("Grup başarı ile eklendi.");
            }
            else
            {
                // Güncelle
                grup.GrupAdi = ad;
                grup.GrupKodu = kod;

                // DB'de varsa daha doğru alan: KullaniciDuzenle / TarihDuzenle
                grup.KullaniciKayit = lKullanici.Text;   // sende böyle alan var diye bırakıyorum
                grup.TarihDuzenle = DateTime.Now;

                db.SaveChanges();

                MessageBox.Show("Grup başarı ile güncellendi.");
            }

            Listele();
            Temizle();
        }

        private void Listele()
        {
            gridListe.DataSource = db.CariGrup
                .OrderByDescending(x => x.Id)
                .Take(50)
                .ToList();
        }

        private void Temizle()
        {
            tGrupKodu.Clear();
            tGrupAdi.Clear();
            tGrupKodu.Focus();
        }
        private void gridListe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = gridListe.Rows[e.RowIndex];
            tGrupKodu.Text = row.Cells["GrupKodu"].Value?.ToString();
            tGrupAdi.Text = row.Cells["GrupAdi"].Value?.ToString();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            db.Dispose();
            base.OnFormClosed(e);
        }
    }
}
