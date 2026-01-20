using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BarkodluSatis
{
    public partial class fSatis : Form
    {
        private SatisServisi satisServisi = new SatisServisi();

        public fSatis()
        {
            InitializeComponent();
        }

        private void bNakit_Click(object sender, EventArgs e)
        {
            SatisYap(SabitDegerler.OdemeNakit);
        }
        private decimal _usdKur = 0m;
        private int _cariId = 0;

        private void KurYukle()
        {
            // DovizKur tablosundan en güncel USD kur
            _usdKur = db.DovizKur
                .OrderByDescending(x => x.Id)
                .Select(x => (decimal?)x.USD)
                .FirstOrDefault() ?? 0m;
        }



        private void fSatis_Load(object sender, EventArgs e)
        {
            HizliButonDoldur();
            b5.Text = 5.ToString("c2");
            b10.Text = 10.ToString("c2");
            b20.Text = 20.ToString("c2");
            b50.Text = 50.ToString("c2");
            b100.Text = 100.ToString("c2");
            b200.Text = 200.ToString("c2");
            using (var db2 = new BarkodDbEntities())
            {
                var sabit = db2.Sabit.FirstOrDefault();
                chYazdirmaDurumu.Checked = Convert.ToBoolean(sabit?.Yazici ?? false);
            }


            KurYukle();
            KurEtiketGuncelle();
            // istersen debug:
            // MessageBox.Show("USD Kur: " + _usdKur);


        }



        private void HizliButonDoldur()
        {
            var hizliurun = db.HizliUrun.ToList();

            foreach (var item in hizliurun)
            {

                Button bh = this.Controls.Find("bH" + item.Id, true).FirstOrDefault() as Button;
                if (bh != null)
                {
                    double fiyat = Islemler.DoubleYap(item.Fiyat.ToString());
                    bh.Text = item.UrunAd + "\n" + fiyat.ToString("c2");
                }
            }


        }
        private void HizliButtonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int butonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
            if (b.Text.ToString().StartsWith("-"))
            {
                fHizliButonUrunEkle f = new fHizliButonUrunEkle();
                f.lButonId.Text = butonid.ToString();
                f.ShowDialog();
            }

            else
            {

                var urunbarkod = db.HizliUrun.Where(a => a.Id == butonid).Select(a => a.Barkod).FirstOrDefault();
                var urun = db.Urun.Where(a => a.Barkod == urunbarkod).FirstOrDefault();
                UrunGetirlisteye(urun, urunbarkod, Convert.ToDouble(tMiktar.Text));
                GenelToplam();
            }

        }

        BarkodDbEntities db = new BarkodDbEntities();
        private void tBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = tBarkod.Text.Trim();
                if (barkod.Length <= 2)
                {
                    tMiktar.Text = barkod;
                    tBarkod.Clear();
                    tBarkod.Focus();

                }
                else
                {
                    if (db.Urun.Any(a => a.Barkod == barkod))
                    {
                        var urun = db.Urun.Where(a => a.Barkod == barkod).FirstOrDefault();
                        UrunGetirlisteye(urun, barkod, Convert.ToDouble(tMiktar.Text));
                    }

                    else
                    {
                        int onek = Convert.ToInt32(barkod.Substring(0, 2));
                        if (db.Terazi.Any(a => a.TeraziOnEk == onek))
                        {
                            string teraziurunno = barkod.Substring(2, 5);
                            if (db.Urun.Any(a => a.Barkod == teraziurunno))
                            {
                                var urunterazi = db.Urun.Where(a => a.Barkod == teraziurunno).FirstOrDefault();
                                double miktarkg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                UrunGetirlisteye(urunterazi, teraziurunno, miktarkg);
                            }
                            else
                            {
                                Console.Beep(900, 2000);
                                MessageBox.Show("KG Ürün Ekleme Sayfası");
                            }
                        }
                        else
                        {
                            Console.Beep(900, 2000);
                            fUrunGiris f = new fUrunGiris();
                            f.tBarkod.Text = barkod;
                            f.ShowDialog();
                        }
                    }




                }
                gridSatisListesi.ClearSelection();
                GenelToplam();

            }
        }

        private void UrunGetirlisteye(Urun urun, string barkod, double miktar)
        {
            // 1. GÜVENLİK KONTROLÜ (Early Return)
            if (urun == null)
            {
                MessageBox.Show("Sistemde bu barkoda ait ürün tanımlı değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Metodun geri kalanını çalıştırma, burada dur.
            }
            int satirsayisi = gridSatisListesi.Rows.Count;
            double fiyatTl = satisServisi.UrunSatisFiyatiHesapla(urun, _usdKur);
            double kdvBirim = satisServisi.KdvBirimTutarHesapla(fiyatTl, urun.KdvOrani);
            bool eklenmismi = false;

            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)
                {
                    var b = gridSatisListesi.Rows[i].Cells["Barkod"].Value?.ToString();
                    if (b == barkod)
                    {
                        // Mevcut miktarı bir kez alıp üzerine ekliyoruz
                        double eskiMiktar = Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Miktar"].Value);
                        double yeniMiktar = eskiMiktar + miktar;

                        gridSatisListesi.Rows[i].Cells["Miktar"].Value = yeniMiktar;
                        gridSatisListesi.Rows[i].Cells["Fiyat"].Value = fiyatTl;
                        gridSatisListesi.Rows[i].Cells["Toplam"].Value = Math.Round(yeniMiktar * fiyatTl, 2);
                        gridSatisListesi.Rows[i].Cells["KdvTutari"].Value = kdvBirim;

                        eklenmismi = true;
                        break; // Ürün bulundu, döngüden çıkabiliriz.
                    }
                }
            }

            if (!eklenmismi)
            {
                // Yeni satır ekleme işlemi
                int yeniSatirIndex = gridSatisListesi.Rows.Add();
                gridSatisListesi.Rows[yeniSatirIndex].Cells["Barkod"].Value = barkod;
                gridSatisListesi.Rows[yeniSatirIndex].Cells["UrunAdi"].Value = urun.UrunAd;
                gridSatisListesi.Rows[yeniSatirIndex].Cells["UrunGrup"].Value = urun.UrunGrup;
                gridSatisListesi.Rows[yeniSatirIndex].Cells["Birim"].Value = urun.Birim;
                gridSatisListesi.Rows[yeniSatirIndex].Cells["Fiyat"].Value = fiyatTl;
                gridSatisListesi.Rows[yeniSatirIndex].Cells["Miktar"].Value = miktar;
                gridSatisListesi.Rows[yeniSatirIndex].Cells["Toplam"].Value = Math.Round(miktar * fiyatTl, 2);
                gridSatisListesi.Rows[yeniSatirIndex].Cells["AlisFiyat"].Value = urun.AlisFiyati;
                gridSatisListesi.Rows[yeniSatirIndex].Cells["KdvTutari"].Value = kdvBirim;
            }
        }
        private void GenelToplam()
        {

            double toplam = 0;
            for (int i = 0; i < gridSatisListesi.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Toplam"].Value);
            }
            tGenelToplam.Text = toplam.ToString("c2");
            tMiktar.Text = "1";
            tBarkod.Clear();
            tBarkod.Focus();

        }

        private void gridSatisListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 9)
            {
                gridSatisListesi.Rows.Remove(gridSatisListesi.CurrentRow);
                gridSatisListesi.ClearSelection();
                GenelToplam();
                tBarkod.Focus();



            }





        }
        private void bh_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button b = (Button)sender;
                if (!b.Text.StartsWith("-"))
                {
                    int butonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
                    ContextMenuStrip s = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No:" + butonid.ToString();
                    sil.Click += Sil_Click;
                    s.Items.Add(sil);
                    this.ContextMenuStrip = s;
                }
            }

        }

        private void Sil_Click(object sender, EventArgs e)
        {
            int butonid = Convert.ToInt16(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncelle = db.HizliUrun.Find(butonid);
            guncelle.Barkod = "-";
            guncelle.UrunAd = "-";
            guncelle.Fiyat = 0;
            db.SaveChanges();
            double fiyat = 0;
            Button b = this.Controls.Find("bH" + butonid, true).FirstOrDefault() as Button;
            b.Text = "-" + "\n" + fiyat.ToString("c2");

        }

        private void bNx_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            if (b.Text == ",")
            {
                int virgul = tNumarator.Text.Count(x => x == ',');

                if (virgul < 1)
                {
                    tNumarator.Text += b.Text;
                }

            }
            else if (b.Text == "<")
            {

                if (tNumarator.Text.Length > 0)
                {
                    tNumarator.Text = tNumarator.Text.Substring(0, tNumarator.Text.Length - 1);

                }

            }
            else
            {
                tNumarator.Text += b.Text;
            }
        }

        private void bAdet_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                tMiktar.Text = tNumarator.Text;
                tNumarator.Clear();
                tBarkod.Clear();
                tBarkod.Focus();
            }
        }

        private void bOdenen_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                double sonuc = Islemler.DoubleYap(tNumarator.Text) - Islemler.DoubleYap(tGenelToplam.Text);
                tParaUstu.Text = sonuc.ToString("c2");
                tOdenen.Text = Islemler.DoubleYap(tNumarator.Text).ToString("c2");
                tNumarator.Clear();
                tBarkod.Focus();
            }
        }

        private void bBarkod_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == tNumarator.Text))
                {
                    var urun = db.Urun.Where(a => a.Barkod == tNumarator.Text).FirstOrDefault();
                    UrunGetirlisteye(urun, tNumarator.Text, Convert.ToDouble(tMiktar.Text));
                    tNumarator.Clear();
                    tBarkod.Focus();
                }
                else
                {
                    MessageBox.Show("Urun Ekleme Sayfasını Aç");
                }
            }
        }

        private void ParaUstuHesapla_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            double sonuc = Islemler.DoubleYap(b.Text) - Islemler.DoubleYap(tGenelToplam.Text);
            tOdenen.Text = Islemler.DoubleYap(b.Text).ToString("c2");
            tParaUstu.Text = sonuc.ToString("c2");
        }

        private void bDigerUrun_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                int satirsayisi = gridSatisListesi.Rows.Count;
                gridSatisListesi.Rows.Add();
                gridSatisListesi.Rows[satirsayisi].Cells["Barkod"].Value = SabitDegerler.BarkodsuzUrun;
                gridSatisListesi.Rows[satirsayisi].Cells["UrunAdi"].Value = SabitDegerler.VarsayilanUrunAdi;
                gridSatisListesi.Rows[satirsayisi].Cells["UrunGrup"].Value = SabitDegerler.VarsayilanUrunGrup;
                gridSatisListesi.Rows[satirsayisi].Cells["Birim"].Value = SabitDegerler.VarsayilanBirim;
                gridSatisListesi.Rows[satirsayisi].Cells["Miktar"].Value = 1;
                gridSatisListesi.Rows[satirsayisi].Cells["AlisFiyat"].Value = 0;
                gridSatisListesi.Rows[satirsayisi].Cells["Fiyat"].Value = Convert.ToDouble(tNumarator.Text);
                gridSatisListesi.Rows[satirsayisi].Cells["KdvTutari"].Value = 0;
                gridSatisListesi.Rows[satirsayisi].Cells["Toplam"].Value = Convert.ToDouble(tNumarator.Text);
                tNumarator.Text = "";
                GenelToplam();
                tBarkod.Focus();
            }
        }

        private void bIade_Click(object sender, EventArgs e)
        {
            if (chSatisİadeİslemi.Checked)
            {
                chSatisİadeİslemi.Checked = false;
                chSatisİadeİslemi.Text = SabitDegerler.SatisYapiliyor;
            }
            else
            {
                chSatisİadeİslemi.Checked = true;
                chSatisİadeİslemi.Text = SabitDegerler.IadeIslemi;
            }
        }

        private void bTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            tMiktar.Text = "1";
            tBarkod.Clear();
            tOdenen.Clear();
            tParaUstu.Clear();
            tGenelToplam.Text = 0.ToString("c2");
            chSatisİadeİslemi.Checked = false;
            tNumarator.Clear();
            gridSatisListesi.Rows.Clear();
            tBarkod.Clear();
            tBarkod.Focus();
            _cariId = 0;
            lCari.Text = "";

        }

        public void SatisYap(string odemesekli)
        {
            // Grid boşsa çık
            var satirlar = gridSatisListesi.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .ToList();

            if (satirlar.Count == 0) return;

            bool satisiade = chSatisİadeİslemi.Checked;

            // Islem tablosu
            var islemTablosu = db.Islem.FirstOrDefault();
            if (islemTablosu == null)
            {
                MessageBox.Show("Islem tablosunda kayıt yok! (IslemNo başlatılmalı)");
                return;
            }

            // ✅ IslemNo nullable ise garantiye al
            int islemno = (islemTablosu.IslemNo ?? 1);
            if (islemTablosu.IslemNo == null)
                islemTablosu.IslemNo = islemno; // db'de de dolsun

            using (var trn = db.Database.BeginTransaction())
            {
                try
                {
                    double alisfiyattoplam = 0;

                    foreach (var row in satirlar)
                    {
                        string barkod = row.Cells["Barkod"].Value?.ToString();

                        // Güvenlik
                        if (string.IsNullOrWhiteSpace(barkod))
                            continue;

                        double alisFiyat = Islemler.DoubleYap(row.Cells["AlisFiyat"].Value?.ToString());
                        double fiyat = Islemler.DoubleYap(row.Cells["Fiyat"].Value?.ToString());
                        double miktar = Islemler.DoubleYap(row.Cells["Miktar"].Value?.ToString());
                        double toplam = Islemler.DoubleYap(row.Cells["Toplam"].Value?.ToString());

                        // Grid’de KdvTutari = birim kdv ise:
                        double kdvBirim = Islemler.DoubleYap(row.Cells["KdvTutari"].Value?.ToString());
                        double kdvToplam = kdvBirim * miktar;

                        var satis = new Satis
                        {
                            IslemNo = islemno,
                            UrunAd = row.Cells["UrunAdi"].Value?.ToString(),
                            UrunGrup = row.Cells["UrunGrup"].Value?.ToString(),
                            Barkod = barkod,
                            Birim = row.Cells["Birim"].Value?.ToString(),
                            AlisFiyat = alisFiyat,
                            SatisFiyat = fiyat,
                            Miktar = miktar,
                            Toplam = toplam,
                            KdvTutari = kdvToplam,
                            OdemeSekli = odemesekli,
                            Iade = satisiade,
                            Tarih = DateTime.Now,
                            Kullanici = lKullanici.Text
                        };

                        db.Satis.Add(satis);

                        // ✅ Stok işlemi aynı db içinde (transaction’a dahil)
                        var urun = db.Urun.FirstOrDefault(x => x.Barkod == barkod);
                        if (urun != null)
                        {
                            double mevcut = Convert.ToDouble(urun.Miktar ?? 0);

                            if (!satisiade)
                            {
                                // satış -> stok azalt
                                double yeni = mevcut - miktar;
                                if (yeni < 0) yeni = 0; // istersen burada hata verdirirsin
                                urun.Miktar = yeni;
                            }
                            else
                            {
                                // iade -> stok artır
                                urun.Miktar = mevcut + miktar;
                            }
                        }

                        alisfiyattoplam += alisFiyat * miktar;
                    }

                    // IslemOzet
                    double genelToplam = Islemler.DoubleYap(tGenelToplam.Text);

                    var io = new IslemOzet
                    {
                        IslemNo = islemno,
                        Iade = satisiade,
                        AlisFiyatToplam = alisfiyattoplam,
                        Gelir = false,
                        Gider = false,
                        Aciklama = satisiade ? SabitDegerler.IadeIslemi + " (" + odemesekli + ")" : odemesekli + " Satış",
                        OdemeSekli = odemesekli,
                        Kullanici = lKullanici.Text,
                        Tarih = DateTime.Now,
                        Nakit = 0,
                        Kart = 0,
                        CariId = _cariId != 0 ? (int?)_cariId : null
                    };

                    if (odemesekli == SabitDegerler.OdemeNakit) { io.Nakit = genelToplam; io.Kart = 0; }
                    else if (odemesekli == SabitDegerler.OdemeKart) { io.Nakit = 0; io.Kart = genelToplam; }
                    else { io.Nakit = Islemler.DoubleYap(lNakit.Text); io.Kart = Islemler.DoubleYap(lKart.Text); }

                    db.IslemOzet.Add(io);

                    // ✅ IslemNo artır
                    islemTablosu.IslemNo = islemno + 1;

                    db.SaveChanges();
                    trn.Commit();

                    if (chYazdirmaDurumu.Checked)
                        new Yazdir(islemno).YazdirmayaBasla();

                    Temizle();
                    MessageBox.Show("İşlem başarıyla tamamlandı.");
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    MessageBox.Show("Satış hatası: " + ex.Message);
                }
            }
        }

        private void KurEtiketGuncelle()
        {
            var tr = System.Globalization.CultureInfo.GetCultureInfo("tr-TR");

            if (_usdKur <= 0m)
                lblUsdKur.Text = "USD: (kur yok)";
            else
                lblUsdKur.Text = "USD: " + _usdKur.ToString("0.####", tr);
        }



        private void bKartNakit_Click(object sender, EventArgs e)
        {
            fNakitKart f = new fNakitKart();
            f.ShowDialog();
        }

        private void tMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
                e.Handled = true;

        }

        private void tBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void tNumarator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }



        private void fSatis_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
                SatisYap(SabitDegerler.OdemeNakit);
            if (e.KeyCode == Keys.F2)
                SatisYap(SabitDegerler.OdemeKart);
            if (e.KeyCode == Keys.F3)
            {
                fNakitKart f = new fNakitKart();
                f.ShowDialog();
            }

        }

        private void bCariSec_Click(object sender, EventArgs e)
        {
            fCariListe f = new fCariListe();
            f.SecimModu = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                _cariId = f.SecilenCariId;
                lCari.Text = f.SecilenCariAdi;
            }
        }

        private void bIslemBeklet_Click(object sender, EventArgs e)
        {
            if (bIslemBeklet.Text == "İşlem Beklet")
            {
                Bekle();
                bIslemBeklet.BackColor = System.Drawing.Color.OrangeRed;
                bIslemBeklet.Text = "İşlem Bekliyor";
                gridSatisListesi.Rows.Clear();
            }
            else
            {
                Beklemedencik();
                bIslemBeklet.BackColor = System.Drawing.Color.DimGray;
                bIslemBeklet.Text = "İşlem Beklet";
                gridBekle.Rows.Clear();
            }
        }
        private void Bekle()
        {
            int satir = gridSatisListesi.Rows.Count;
            int sutun = gridSatisListesi.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    gridBekle.Rows.Add();
                    for (int j = 0; j < sutun - 1; j++)
                    {
                        gridBekle.Rows[i].Cells[j].Value = gridSatisListesi.Rows[i].Cells[j].Value;

                    }
                }
            }
        }
        private void Beklemedencik()
        {
            int satir = gridBekle.Rows.Count;
            int sutun = gridBekle.Columns.Count;
            if (satir > 0)
            {
                for (int i = 0; i < satir; i++)
                {
                    gridSatisListesi.Rows.Add();
                    for (int j = 0; j < sutun - 1; j++)
                    {
                        gridSatisListesi.Rows[i].Cells[j].Value = gridBekle.Rows[i].Cells[j].Value;
                    }
                }
            }

        }

        private void bKart_Click(object sender, EventArgs e)
        {
            SatisYap(SabitDegerler.OdemeKart);
        }

        private void chSatisİadeİslemi_CheckedChanged(object sender, EventArgs e)
        {
            if (chSatisİadeİslemi.Checked)
            {
                chSatisİadeİslemi.Text = SabitDegerler.IadeYapiliyor;
            }
            else
            {
                chSatisİadeİslemi.Text = SabitDegerler.SatisYapiliyor;
            }
        }


    }
}
