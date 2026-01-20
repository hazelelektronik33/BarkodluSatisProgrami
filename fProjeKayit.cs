using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fProjeKayit : Form
    {
        private readonly BarkodDbEntities db = new BarkodDbEntities();
        private readonly CultureInfo tr = CultureInfo.GetCultureInfo("tr-TR");

        // USD kur kullanacaksan (üründe DolarSatisFiyat varsa)
        private decimal _usdKur = 0m;

        public string GelenKullanici { get; set; }
        public int AcilisId { get; set; }

        public fProjeKayit()
        {
            InitializeComponent();
            this.Load += fProjeKayit_Load;
        }

        private void fProjeKayit_Load(object sender, EventArgs e)
        {
            // kullanıcı label
            if (!string.IsNullOrWhiteSpace(GelenKullanici))
                lKullanici.Text = GelenKullanici;

            // combo hazırlık
            HazirlaCombolar();

            // grid hazırlık
            GridHazirla();

            // kur çek (istersen kullan)
            KurYukle();

            // Kayıt açılışı veya yeni kayıt reset
            if (AcilisId > 0)
            {
                ProjeGetir(AcilisId);
            }
            else
            {
                YeniKayitHazirla();
            }

            // event bağla
            bEkle.Click += bEkle_Click;
            bTemizle.Click += bTemizle_Click;
            bKaydet.Click += bKaydet_Click;
            bYazdir.Click += bYazdir_Click;
            bPdf.Click += bPdf_Click;
            bKapat.Click += bKapat_Click;
            bIptal.Click += bIptal_Click;

            tBarkod.KeyDown += tBarkod_KeyDown;
        }

        private void HazirlaCombolar()
        {
            // Tip: 0 Teklif, 1 Proje
            cmbTip.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbTip.Items.Count == 0)
                cmbTip.Items.AddRange(new object[] { "Teklif", "Proje" });
            cmbTip.SelectedIndex = 0;

            // Durum
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbDurum.Items.Count == 0)
                cmbDurum.Items.AddRange(new object[] { "Hazırlanıyor", "Gönderildi", "Onaylandı", "İptal" });
            cmbDurum.SelectedIndex = 0;

            // Evrak no kullanıcı girmesin
            tEvrakNo.ReadOnly = true;

            // tarih
            dtTarih.Value = DateTime.Now;
        }

        private void GridHazirla()
        {
            gridKalemler.AutoGenerateColumns = false;
            gridKalemler.Columns.Clear();

            // düzgün Name (kodda bunları kullanacağız)
            gridKalemler.Columns.Add(MakeTextCol("Barkod", "Barkod", 120, false));
            gridKalemler.Columns.Add(MakeTextCol("UrunAdi", "Ürün Adı", 220, false));
            gridKalemler.Columns.Add(MakeTextCol("Birim", "Birim", 70, false));

            gridKalemler.Columns.Add(MakeNumCol("Miktar", "Miktar", 70));
            gridKalemler.Columns.Add(MakeNumCol("BirimFiyat", "Birim Fiyat", 90));
            gridKalemler.Columns.Add(MakeNumCol("IskontoOran", "İskonto %", 75));
            gridKalemler.Columns.Add(MakeNumCol("KdvOran", "KDV %", 65));

            gridKalemler.Columns.Add(MakeNumCol("AraToplam", "Ara Toplam", 95, readOnly: true));
            gridKalemler.Columns.Add(MakeNumCol("KdvTutar", "KDV Tutar", 95, readOnly: true));
            gridKalemler.Columns.Add(MakeNumCol("GenelToplam", "Genel Toplam", 105, readOnly: true));

            var btnSil = new DataGridViewButtonColumn
            {
                Name = "Sil",
                HeaderText = "Sil",
                Text = "Sil",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            gridKalemler.Columns.Add(btnSil);

            gridKalemler.AllowUserToAddRows = false;
            gridKalemler.RowHeadersVisible = false;
            gridKalemler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridKalemler.MultiSelect = false;

            gridKalemler.CellEndEdit += gridKalemler_CellEndEdit;
            gridKalemler.CellContentClick += gridKalemler_CellContentClick;
        }

        private DataGridViewTextBoxColumn MakeTextCol(string name, string header, int width, bool readOnly)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                Width = width,
                ReadOnly = readOnly
            };
        }

        private DataGridViewTextBoxColumn MakeNumCol(string name, string header, int width, bool readOnly = false)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                Width = width,
                ReadOnly = readOnly
            };
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            return col;
        }

        // -------------------- KUR / FİYAT --------------------
        private void KurYukle()
        {
            try
            {
                _usdKur = db.DovizKur
                    .OrderByDescending(x => x.Id)
                    .Select(x => (decimal?)x.USD)
                    .FirstOrDefault() ?? 0m;
            }
            catch
            {
                _usdKur = 0m;
            }
        }

        private double UrunBirimFiyatTL(Urun urun)
        {
            // Üründe USD fiyat varsa (DolarSatisFiyat), kurla çevir
            if (_usdKur > 0m && urun.DolarSatisFiyat.HasValue && urun.DolarSatisFiyat.Value > 0)
            {
                var tl = (decimal)urun.DolarSatisFiyat.Value * _usdKur;
                return Math.Round((double)tl, 2);
            }

            return Math.Round(Convert.ToDouble(urun.SatisFiyat ?? 0), 2);
        }

        // -------------------- ÜRÜN GETİR / EKLE --------------------
        private void tBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string barkod = (tBarkod.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(barkod)) return;

            var urun = db.Urun.FirstOrDefault(x => x.Barkod == barkod);
            if (urun == null)
            {
                MessageBox.Show("Bu barkoda ait ürün bulunamadı.");
                return;
            }

            tUrunAdi.Text = urun.UrunAd;
            tBirim.Text = urun.Birim;
            tMiktar.Text = "1";
            tBirimFiyat.Text = UrunBirimFiyatTL(urun).ToString("0.00", tr);
            tIskonto.Text = "0";
            tKdv.Text = (urun.KdvOrani ?? 0).ToString();

            // hızlı eklemek istersen:
            // bEkle.PerformClick();
        }

        private void bEkle_Click(object sender, EventArgs e)
        {
            string barkod = (tBarkod.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(barkod))
            {
                MessageBox.Show("Barkod boş olamaz.");
                return;
            }

            // aynı barkod varsa miktarı artır
            foreach (DataGridViewRow r in gridKalemler.Rows)
            {
                var b = r.Cells["Barkod"].Value?.ToString();
                if (b == barkod)
                {
                    double eskiM = ToDouble(r.Cells["Miktar"].Value);
                    double ek = ToDouble(tMiktar.Text);
                    r.Cells["Miktar"].Value = (eskiM + ek).ToString("0.###", tr);

                    // satırı yeniden hesapla
                    SatirHesapla(r);
                    ToplamlariYaz();
                    TemizKalemGirisi();
                    return;
                }
            }

            int idx = gridKalemler.Rows.Add();
            var row = gridKalemler.Rows[idx];

            row.Cells["Barkod"].Value = barkod;
            row.Cells["UrunAdi"].Value = tUrunAdi.Text;
            row.Cells["Birim"].Value = tBirim.Text;

            row.Cells["Miktar"].Value = ToDouble(tMiktar.Text).ToString("0.###", tr);
            row.Cells["BirimFiyat"].Value = ToDouble(tBirimFiyat.Text).ToString("0.00", tr);
            row.Cells["IskontoOran"].Value = ToDouble(tIskonto.Text).ToString("0.##", tr);
            row.Cells["KdvOran"].Value = ToDouble(tKdv.Text).ToString("0.##", tr);

            SatirHesapla(row);
            ToplamlariYaz();
            TemizKalemGirisi();
        }

        private void TemizKalemGirisi()
        {
            tBarkod.Clear();
            tUrunAdi.Clear();
            tBirim.Clear();
            tMiktar.Text = "1";
            tBirimFiyat.Clear();
            tIskonto.Text = "0";
            tKdv.Text = "0";
            tBarkod.Focus();
        }

        // -------------------- HESAPLAMALAR --------------------
        private void gridKalemler_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = gridKalemler.Rows[e.RowIndex];
            SatirHesapla(row);
            ToplamlariYaz();
        }

        private void gridKalemler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (gridKalemler.Columns[e.ColumnIndex].Name == "Sil")
            {
                gridKalemler.Rows.RemoveAt(e.RowIndex);
                ToplamlariYaz();
            }
        }

        private void SatirHesapla(DataGridViewRow row)
        {
            if (row == null) return;

            double miktar = ToDouble(row.Cells["Miktar"].Value);
            double fiyat = ToDouble(row.Cells["BirimFiyat"].Value);
            double iskOr = ToDouble(row.Cells["IskontoOran"].Value);
            double kdvOr = ToDouble(row.Cells["KdvOran"].Value);

            double brut = miktar * fiyat;
            double iskTutar = brut * iskOr / 100.0;
            double ara = brut - iskTutar;
            double kdv = ara * kdvOr / 100.0;
            double genel = ara + kdv;

            row.Cells["AraToplam"].Value = Math.Round(ara, 2).ToString("0.00", tr);
            row.Cells["KdvTutar"].Value = Math.Round(kdv, 2).ToString("0.00", tr);
            row.Cells["GenelToplam"].Value = Math.Round(genel, 2).ToString("0.00", tr);
        }

        private void ToplamlariYaz()
        {
            double ara = 0, kdv = 0, genel = 0, iskonto = 0;

            foreach (DataGridViewRow r in gridKalemler.Rows)
            {
                double miktar = ToDouble(r.Cells["Miktar"].Value);
                double fiyat = ToDouble(r.Cells["BirimFiyat"].Value);
                double brut = miktar * fiyat;

                double araSatir = ToDouble(r.Cells["AraToplam"].Value);
                double kdvSatir = ToDouble(r.Cells["KdvTutar"].Value);
                double genSatir = ToDouble(r.Cells["GenelToplam"].Value);

                ara += araSatir;
                kdv += kdvSatir;
                genel += genSatir;
                iskonto += (brut - araSatir);
            }

            tAraToplam.Text = ara.ToString("c2", tr);
            tKDVToplam.Text = kdv.ToString("c2", tr);
            tGenelToplam.Text = genel.ToString("c2", tr);
            tIskontoToplam.Text = iskonto.ToString("c2", tr);
        }

        private void ProjeGetir(int id)
        {
            var baslik = db.Teklifler.FirstOrDefault(x => x.Id == id);
            if (baslik == null)
            {
                MessageBox.Show("Kayıt bulunamadı!");
                return;
            }

            // Başlık verileri
            lTeklifId.Text = baslik.Id.ToString();
            cmbTip.SelectedIndex = (int)baslik.Tip;
            tEvrakNo.Text = baslik.EvrakNo;
            dtTarih.Value = baslik.Tarih ?? DateTime.Now;
            cmbDurum.Text = baslik.Durum;
            tCariAdi.Text = baslik.CariAdi;
            tYetkili.Text = baslik.Yetkili;
            // tTelefon.Text = baslik.Telefon; // Entity'de varsa
            // tMail.Text = baslik.Mail;       // Entity'de varsa
            // tNot.Text = baslik.Not;         // Entity'de varsa
            
            // Eğer varsa entity fieldlarını aç:
            // if(baslik.Telefon != null) tTelefon.Text = baslik.Telefon;
            
            // Kalemler
            gridKalemler.Rows.Clear();
            var kalemler = db.TeklifKalemler.Where(x => x.TeklifId == id).ToList();

            foreach (var k in kalemler)
            {
                int idx = gridKalemler.Rows.Add();
                var row = gridKalemler.Rows[idx];

                row.Cells["Barkod"].Value = k.Barkod;
                row.Cells["UrunAdi"].Value = k.UrunAdi;
                // row.Cells["Birim"].Value = k.Birim; // Entity'de varsa
                
                row.Cells["Miktar"].Value = k.Miktar.HasValue ? k.Miktar.Value.ToString("0.###", tr) : "0";
                row.Cells["BirimFiyat"].Value = k.BirimFiyat.HasValue ? k.BirimFiyat.Value.ToString("0.00", tr) : "0";
                
                // Entity'de bu alanlar varsa:
                // row.Cells["IskontoOran"].Value = ...
                // row.Cells["KdvOran"].Value = ...
                
                // Satır hesapla (Otomatik hesaplansın)
                SatirHesapla(row);
            }
            
            ToplamlariYaz();
        }

        private double ToDouble(object val)
        {
            if (val == null) return 0;

            // currency gelirse temizle
            var s = val.ToString().Trim();
            if (string.IsNullOrWhiteSpace(s)) return 0;

            // kullanıcı ,/. karışık giriyorsa
            s = s.Replace(".", ",");

            if (double.TryParse(s, NumberStyles.Any, tr, out double d))
                return d;

            // son çare
            return 0;
        }

        // -------------------- EVRAK NO --------------------
        private string YeniEvrakNo(byte tip)
        {
            // prefix: Teklif=TEK, Proje=PRJ
            string prefix = (tip == 0) ? "TEK" : "PRJ";

            // EvrakNo tablosu: Tip (byte) + SonNo (int)
            var sayac = db.EvrakNo.SingleOrDefault(x => x.Tip == tip);
            if (sayac == null)
            {
                sayac = new EvrakNo { Tip = tip, SonNo = 0 };
                db.EvrakNo.Add(sayac);
                db.SaveChanges();
            }

            sayac.SonNo += 1;
            db.SaveChanges();

            return prefix + sayac.SonNo.ToString("D6");
        }

        // -------------------- KAYDET / TEMİZLE --------------------
        private void YeniKayitHazirla()
        {
            lTeklifId.Text = "0";
            tEvrakNo.Text = "";
            dtTarih.Value = DateTime.Now;

            gridKalemler.Rows.Clear();

            tAraToplam.Text = 0.ToString("c2", tr);
            tIskontoToplam.Text = 0.ToString("c2", tr);
            tKDVToplam.Text = 0.ToString("c2", tr);
            tGenelToplam.Text = 0.ToString("c2", tr);

            // başlık alanları
            tCariAdi.Clear();
            tTelefon.Clear();
            tYetkili.Clear();
            tMail.Clear();
            tNot.Clear();
        }

        private void bTemizle_Click(object sender, EventArgs e)
        {
            YeniKayitHazirla();
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (gridKalemler.Rows.Count <= 0)
            {
                MessageBox.Show("Kalem yok. Önce ürün ekle.");
                return;
            }

            byte tip = (byte)cmbTip.SelectedIndex;
            int teklifId = 0;
            int.TryParse(lTeklifId.Text, out teklifId);

            using (var trn = db.Database.BeginTransaction())
            {
                try
                {
                    Teklifler baslik;

                    if (teklifId == 0)
                    {
                        baslik = new Teklifler
                        {
                            Tip = tip,
                            EvrakNo = YeniEvrakNo(tip),
                            Tarih = dtTarih.Value,
                            Kullanici = lKullanici.Text
                        };
                        db.Teklifler.Add(baslik);
                        db.SaveChanges();

                        lTeklifId.Text = baslik.Id.ToString();
                        tEvrakNo.Text = baslik.EvrakNo;
                    }
                    else
                    {
                        baslik = db.Teklifler.Single(x => x.Id == teklifId);

                        // eski kalemleri sil
                        var eskiKalemler = db.TeklifKalemler.Where(x => x.TeklifId == baslik.Id).ToList();
                        db.TeklifKalemler.RemoveRange(eskiKalemler);
                        db.SaveChanges();
                    }

                    // Başlık alanları (senin entity’de bu alanlar var diye daha önce kullanmıştık)
                    baslik.CariAdi = tCariAdi.Text;
                    baslik.Yetkili = tYetkili.Text;
                    baslik.Durum = cmbDurum.Text;

                    // GenelToplam decimal bekliyorsa:
                    baslik.GenelToplam = (decimal)ToDouble(tGenelToplam.Text);

                    // İstersen entity’de varsa bunları da aç:
                    // baslik.Telefon = tTelefon.Text;
                    // baslik.Mail = tMail.Text;
                    // baslik.Not = tNot.Text;

                    // Kalemleri ekle
                    foreach (DataGridViewRow r in gridKalemler.Rows)
                    {
                        var kalem = new TeklifKalemler
                        {
                            TeklifId = baslik.Id,
                            Barkod = r.Cells["Barkod"].Value?.ToString(),
                            UrunAdi = r.Cells["UrunAdi"].Value?.ToString(),
                            Miktar = (decimal)ToDouble(r.Cells["Miktar"].Value),
                            BirimFiyat = (decimal)ToDouble(r.Cells["BirimFiyat"].Value),
                        };

                        // entity’de varsa bunları da saklayabilirsin:
                        // kalem.Birim = r.Cells["Birim"].Value?.ToString();
                        // kalem.IskontoOran = (decimal)ToDouble(r.Cells["IskontoOran"].Value);
                        // kalem.KdvOran = (decimal)ToDouble(r.Cells["KdvOran"].Value);
                        // kalem.AraToplam = (decimal)ToDouble(r.Cells["AraToplam"].Value);
                        // kalem.KdvTutar = (decimal)ToDouble(r.Cells["KdvTutar"].Value);
                        // kalem.GenelToplam = (decimal)ToDouble(r.Cells["GenelToplam"].Value);

                        db.TeklifKalemler.Add(kalem);
                    }

                    db.SaveChanges();
                    trn.Commit();

                    MessageBox.Show("Kaydedildi ✅");
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    trn.Rollback();
                    string hataMesaji = "Doğrulama Hatası:\n";
                    foreach (var entityErr in ex.EntityValidationErrors)
                    {
                        foreach (var err in entityErr.ValidationErrors)
                        {
                            hataMesaji += "- " + err.PropertyName + ": " + err.ErrorMessage + "\n";
                        }
                    }
                    MessageBox.Show(hataMesaji);
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    MessageBox.Show("Kayıt hatası: " + ex.Message);
                }
            }
        }
        private void bYazdir_Click(object sender, EventArgs e)
        {
             MessageBox.Show("Yazdırma işlemi sonraki aşamada eklenecektir.");
        }

        private void bPdf_Click(object sender, EventArgs e)
        {
             MessageBox.Show("PDF kaydetme işlemi sonraki aşamada eklenecektir.");
        }

        private void bKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bIptal_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("İşlemi iptal edip kapatmak istiyor musunuz?", "İptal", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
