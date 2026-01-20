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
    public partial class fCariAcilisKarti : Form
    {
        private readonly BarkodDbEntities db = new BarkodDbEntities();
        public int AcilisId { get; set; }

        public fCariAcilisKarti()
        {
            InitializeComponent();
            this.Load += fCariAcilisKarti_Load;
        }

        private void fCariAcilisKarti_Load(object sender, EventArgs e)
        {
            // Combo doldur
            cmbCariGrup.DataSource = db.CariGrup.OrderBy(x => x.GrupAdi).ToList();
            cmbCariGrup.DisplayMember = "GrupAdi";
            cmbCariGrup.ValueMember = "Id";
            cmbCariGrup.SelectedIndex = -1;

            // Event bağla
            cmbCariGrup.SelectedIndexChanged += cmbCariGrup_SelectedIndexChanged;
            bKaydet.Click += bKaydet_Click;
            bSil.Click += bSil_Click;
            bKapat.Click += bKapat_Click;

            // Edit modu mu Yeni kayıt mı?
            if (AcilisId > 0)
            {
                CariGetir(AcilisId);
            }
            else
            {
                Temizle();
            }
        }

        private void CariGetir(int id)
        {
            var cari = db.Cariler.FirstOrDefault(x => x.Id == id);
            if (cari == null)
            {
                MessageBox.Show("Cari bulunamadı!");
                return;
            }

            tCariKodu.Text = cari.CariKodu;
            tCariAdi.Text = cari.CariAdi;
            tVergiDairesi.Text = cari.VergiDairesi;
            tVergiNo.Text = cari.VergiNo;
            tUlke.Text = cari.Ulke;
            tSehir.Text = cari.Sehir;
            tIlce.Text = cari.Ilce;
            tAdres.Text = cari.Adres;
            tTelefon.Text = cari.Telefon;
            tCepTelefon.Text = cari.CepTelefon;
            tFax.Text = cari.Fax;
            tMail.Text = cari.Mail;
            tWebAdres.Text = cari.WebAdres;
            tYetkili.Text = cari.Yetkili;
            tYetkiliMail.Text = cari.YetkiliMail;

            // Grup seçimi
            if (cari.GrupId != null && cari.GrupId > 0)
            {
                cmbCariGrup.SelectedValue = cari.GrupId;
            }
        }

        private void cmbCariGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCariGrup.SelectedItem is CariGrup g)
            {
                tCariGrupKodu.Text = g.GrupKodu;
                tCariGrupAdi.Text = g.GrupAdi;
                tGrupId.Text = g.Id.ToString();
            }
            else
            {
                tCariGrupKodu.Clear();
                tCariGrupAdi.Text = "";
                tGrupId.Clear();
            }
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            // Doğrulama
            if (string.IsNullOrWhiteSpace(tCariAdi.Text)) { MessageBox.Show("Cari Adı zorunludur."); return; }
            if (string.IsNullOrWhiteSpace(tVergiDairesi.Text)) { MessageBox.Show("Vergi Dairesi zorunludur."); return; }
            if (string.IsNullOrWhiteSpace(tVergiNo.Text)) { MessageBox.Show("Vergi No zorunludur."); return; }
            
            // Grup zorunlu mu? Genelde evet
            if (cmbCariGrup.SelectedIndex == -1) { MessageBox.Show("Cari Grup seçiniz."); cmbCariGrup.Focus(); return; }

            try
            {
                Cariler cari;
                bool yeni = false;

                if (AcilisId > 0)
                {
                    cari = db.Cariler.FirstOrDefault(x => x.Id == AcilisId);
                    if (cari == null) { MessageBox.Show("Düzenlenecek kayıt bulunamadı."); return; }
                }
                else
                {
                    cari = new Cariler();
                    cari.TarihKaydet = DateTime.Now;
                    cari.Kullanici = lKullanici.Text;
                    
                    // Geçici ID verelim, sonra update ederiz veya doğrudan ID üretelim
                    // CariKodu unique constraint varsa dikkat
                    cari.CariKodu = "TMP"; 
                    
                    db.Cariler.Add(cari);
                    yeni = true;
                }

                // Alanları set et
                cari.CariAdi = tCariAdi.Text.Trim();
                cari.VergiDairesi = tVergiDairesi.Text.Trim();
                cari.VergiNo = tVergiNo.Text.Trim();
                cari.CepTelefon = tCepTelefon.Text.Trim();
                cari.Telefon = tTelefon.Text.Trim();
                cari.Adres = tAdres.Text.Trim();
                cari.Ilce = tIlce.Text.Trim();
                cari.Sehir = tSehir.Text.Trim();
                cari.Ulke = tUlke.Text.Trim();
                cari.Mail = tMail.Text.Trim();
                cari.Fax = tFax.Text.Trim();
                cari.WebAdres = tWebAdres.Text.Trim();
                cari.Yetkili = tYetkili.Text.Trim();
                cari.YetkiliMail = tYetkiliMail.Text.Trim();

                if (cmbCariGrup.SelectedItem is CariGrup g)
                {
                    cari.GrupId = g.Id;
                    cari.CariGrupAdi = g.GrupAdi;
                    cari.CariGrupKodu = g.GrupKodu;
                }

                // Edit bilgileri
                cari.DuzenlemeTarihi = DateTime.Now;
                cari.KullaniciDuzenle = lKullanici.Text;

                db.SaveChanges(); // ID oluştu

                if (yeni)
                {
                    // CariKodu oluştur: GrupKodu + 00001 (Basit yöntem: ID kullan)
                    // Veya sadece ID:
                    cari.CariKodu = cari.Id.ToString("D5");
                    db.SaveChanges();
                    tCariKodu.Text = cari.CariKodu;
                    AcilisId = cari.Id; // Artık edit modundayız
                }

                MessageBox.Show("Kaydedildi ✅");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string msg = "Doğrulama Hatası:\n";
                foreach (var err in ex.EntityValidationErrors)
                {
                    foreach (var e2 in err.ValidationErrors)
                    {
                        msg += "- " + e2.PropertyName + ": " + e2.ErrorMessage + "\n";
                    }
                }
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void bSil_Click(object sender, EventArgs e)
        {
            if (AcilisId > 0)
            {
                 if (MessageBox.Show("Bu cariyi silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     var c = db.Cariler.Find(AcilisId);
                     if (c != null)
                     {
                         db.Cariler.Remove(c);
                         db.SaveChanges();
                         MessageBox.Show("Silindi.");
                         Close();
                     }
                 }
            }
            else
            {
                Temizle();
            }
        }

        private void bKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Temizle()
        {
            AcilisId = 0;
            tCariKodu.Clear();
            tCariAdi.Clear();
            tVergiDairesi.Clear();
            tVergiNo.Clear();
            tCepTelefon.Clear();
            tTelefon.Clear();
            tAdres.Clear();
            tIlce.Clear();
            tSehir.Clear();
            tUlke.Clear();
            tFax.Clear();
            tMail.Clear();
            tWebAdres.Clear();
            tYetkili.Clear();
            tYetkiliMail.Clear();
            
            cmbCariGrup.SelectedIndex = -1;
            tCariGrupKodu.Clear();
            tCariGrupAdi.Text = "";
            tGrupId.Clear();
        }

        private void tTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }
    }
}
