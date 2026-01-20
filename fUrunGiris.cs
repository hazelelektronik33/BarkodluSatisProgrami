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
    public partial class fUrunGiris : Form
    {
        public fUrunGiris()
        {
            InitializeComponent();
        }

       

        
        BarkodDbEntities db = new BarkodDbEntities();
        private void tBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = tBarkod.Text.Trim();
           

                if (db.Urun.Any(a => a.Barkod == barkod))
                {
                    var urun = db.Urun.Where(a => a.Barkod == barkod).SingleOrDefault();
                    tUrunAdi.Text = urun.UrunAd;
                    tAciklama.Text = urun.Aciklama;
                    cmbUrunGrubu.Text = urun.UrunGrup;
                    tAlisFiyati.Text = urun.AlisFiyati.ToString();
                    tSatisFiyati.Text = urun.SatisFiyat.ToString();

                    tDolarAlis.Text = urun.DolarAlisFiyat.ToString();
                    tDolarSatis.Text = urun.DolarSatisFiyat.ToString();
                    tOzelKod.Text = urun.OzelKod.ToString();
                    tTedarikci.Text = urun.Tedarikci;

                    tMiktar.Text = urun.Miktar.ToString();
                    tKdvOrani.Text = urun.KdvOrani.ToString();
                    if (urun.Birim == "Kg")
                    {
                        chUrunTipi.Checked = true;
                        bBarkodOlustur.Enabled = false;
                    }
                    else
                    {
                        chUrunTipi.Checked = false;
                        bBarkodOlustur.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ürün Kayıtlı Değil Kaydedebilirsiniz...");
                }
            }
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (tBarkod.Text != "" && tUrunAdi.Text != "" && cmbUrunGrubu.Text != "" && tAlisFiyati.Text != "" && tSatisFiyati.Text != "" && tKdvOrani.Text != "" && tMiktar.Text != "" && tDolarAlis.Text != "" && tDolarSatis.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == tBarkod.Text))
                {
                    var guncelle = db.Urun.Where(a => a.Barkod == tBarkod.Text).SingleOrDefault();                  
                    guncelle.UrunAd = tUrunAdi.Text;
                    guncelle.Aciklama = tAciklama.Text;
                    guncelle.UrunGrup = cmbUrunGrubu.Text;
                    guncelle.AlisFiyati = Islemler.DoubleYap(tAlisFiyati.Text);
                    guncelle.SatisFiyat = Islemler.DoubleYap(tSatisFiyati.Text);
                    guncelle.DolarAlisFiyat = Islemler.DoubleYap(tDolarAlis.Text);
                    guncelle.DolarSatisFiyat = Islemler.DoubleYap(tDolarSatis.Text);
                    guncelle.OzelKod = tOzelKod.Text;
                    guncelle.Tedarikci = tTedarikci.Text;
                    guncelle.KdvOrani = Convert.ToInt32(tKdvOrani.Text);
                    guncelle.KdvTutari = Math.Round(Islemler.DoubleYap(tSatisFiyati.Text) * Convert.ToInt32(tKdvOrani.Text) / 100, 2);
                    guncelle.Miktar = Convert.ToDouble(tMiktar.Text);
                    if (chUrunTipi.Checked)
                    {
                        guncelle.Birim = "Kg";
                    }
                    else
                    {
                        guncelle.Birim = "Adet";
                    }
                    
                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = lKullanici.Text;
                    db.SaveChanges();
                    MessageBox.Show("Ürün Başarı İle Güncellendi.");
                    gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();                  
                }
                else
                {
                    Urun urun = new Urun();
                    urun.Barkod = tBarkod.Text;
                    urun.UrunAd = tUrunAdi.Text;
                    urun.Aciklama = tAciklama.Text;
                    urun.UrunGrup = cmbUrunGrubu.Text;
                    urun.AlisFiyati = Islemler.DoubleYap(tAlisFiyati.Text);
                    urun.SatisFiyat = Islemler.DoubleYap(tSatisFiyati.Text);
                    urun.DolarAlisFiyat = Islemler.DoubleYap(tDolarAlis.Text);
                    urun.DolarSatisFiyat = Islemler.DoubleYap(tDolarSatis.Text);
                    urun.OzelKod = tOzelKod.Text;
                    urun.Tedarikci = tTedarikci.Text;
                    urun.KdvOrani = Convert.ToInt32(tKdvOrani.Text);
                    urun.KdvTutari = Math.Round(Islemler.DoubleYap(tSatisFiyati.Text) * Convert.ToInt32(tKdvOrani.Text) / 100, 2);
                    urun.Miktar = Convert.ToDouble(tMiktar.Text);
                    if (chUrunTipi.Checked)
                    {
                        urun.Birim = "Kg";
                    }
                    else
                    {
                        urun.Birim = "Adet";
                    }

                    urun.Tarih = DateTime.Now;
                    urun.Kullanici = lKullanici.Text;
                    db.Urun.Add(urun);
                    db.SaveChanges();
                    if (tBarkod.Text.Length == 8)
                    {
                        var ozelbarkod = db.Barkod.First();
                        ozelbarkod.BarkodNo += 1;
                        db.SaveChanges();
                    }
                   
                    gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                    Islemler.GridDuzenle(gridUrunler);
                }
                Islemler.StokHareket(tBarkod.Text, tUrunAdi.Text, "Adet", Convert.ToDouble(tMiktar.Text), cmbUrunGrubu.Text, lKullanici.Text);
                Temizle();
            }
            else
            {
                MessageBox.Show("Bilgi Girişlerini Kontrol Ediniz!");
                tBarkod.Focus();
            }
        }

        private void tUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (tUrunAra.Text.Length >= 2)
            {
                string urunad = tUrunAra.Text;
                gridUrunler.DataSource = db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();
                Islemler.GridDuzenle(gridUrunler);
            }
        }

        private void bIptal_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void Temizle()
            {
            tBarkod.Clear();
            tUrunAdi.Clear();
            tAciklama.Clear();
            tTedarikci.Clear();
            tAlisFiyati.Text = "0";
            tSatisFiyati.Text = "0";
            tDolarAlis.Text = "0";
            tDolarSatis.Text = "0";
            tOzelKod.Text = "0";
            tMiktar.Text = "0";
            tKdvOrani.Text = "18";
            tBarkod.Focus();
            chUrunTipi.Checked = false;
        }

        private void fUrunGiris_Load(object sender, EventArgs e)
        {
            tUrunSayisi.Text = db.Urun.Count().ToString();
            gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
            Islemler.GridDuzenle(gridUrunler);
            GrupDoldur();
            KurYukle();

        }
        private decimal _usdKur = 0m;

        private void KurYukle()
        {
            _usdKur = db.DovizKur
                .OrderByDescending(x => x.Tarih)
                .Select(x => (decimal?)x.USD)
                .FirstOrDefault() ?? 0m;

            // İstersen ekranda göster diye bir label eklersin:
            // lUsdKur.Text = _usdKur > 0 ? $"USD Kur: {_usdKur:0.######}" : "USD Kur girilmemiş!";
        }

        private void bUrunGrubuEkle_Click(object sender, EventArgs e)
        {
            fUrunGrubuEkle f = new fUrunGrubuEkle();
            f.ShowDialog();
        }
        public void GrupDoldur()
        {
            cmbUrunGrubu.DisplayMember = "UrunGrupAd";
            cmbUrunGrubu.ValueMember = "Id";
            cmbUrunGrubu.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).ToList();

        }

        private void bBarkodOlustur_Click(object sender, EventArgs e)
        {
            var barkodno = db.Barkod.First();
            int karakter = barkodno.BarkodNo.ToString().Length;
            string sifirlar = string.Empty;
            for (int i = 0; i < 8 - karakter; i++)
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.BarkodNo.ToString();
            tBarkod.Text = olusanbarkod;
            tUrunAdi.Focus();
        }

        private void tAlisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void tSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count>0)
            {
                int urunid = Convert.ToInt32(gridUrunler.CurrentRow.Cells["UrunId"].Value.ToString());
                string urunad = gridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                string barkod = gridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunad + "Ürünü Silmek İstiyormusunuz?", "Ürün Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.Urun.Find(urunid);
                    db.Urun.Remove(urun);

                    db.SaveChanges();
                    var hizliurun = db.HizliUrun.Where(x => x.Barkod == barkod).SingleOrDefault();
                    hizliurun.Barkod = "-";
                    hizliurun.UrunAd = "-";
                    hizliurun.Fiyat = 0;
                    db.SaveChanges();
                    MessageBox.Show("Ürün Silinmiştir.");
                
                    gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                    Islemler.GridDuzenle(gridUrunler);
                    
                    tBarkod.Focus();
                }
            }
            
        }

        private void tBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void chUrunTipi_CheckedChanged(object sender, EventArgs e)
        {
            if (chUrunTipi.Checked)
            {
                chUrunTipi.Text = "Gramajlı Ürün Tipi";
                bBarkodOlustur.Enabled = false;
            }
            else
            {
                chUrunTipi.Text = "Barkodlu Ürün Tipi";
                bBarkodOlustur.Enabled = true;
            }
        }
        private void tDolarSatis_TextChanged(object sender, EventArgs e)
        {
            decimal kur = KurGetirUSD();
            if (kur <= 0) return;

            if (decimal.TryParse(tDolarSatis.Text.Replace(".", ","), out decimal usd))
            {
                tSatisFiyati.Text = (usd * kur).ToString("0.00");
            }
        }

        private void tDolarAlis_TextChanged(object sender, EventArgs e)
        {
            decimal kur = KurGetirUSD();
            if (kur <= 0) return;

            if (decimal.TryParse(tDolarAlis.Text.Replace(".", ","), out decimal usd))
            {
                tAlisFiyati.Text = (usd * kur).ToString("0.00");
            }
        }

        private decimal KurGetirUSD()
        {
            // En son kaydı al
            var kur = db.DovizKur.OrderByDescending(x => x.Tarih)
                                 .Select(x => (decimal?)x.USD)
                                 .FirstOrDefault();

            return kur ?? 0m;
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count>0)
            {
                tBarkod.Text = gridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                tUrunAdi.Text = gridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                tAciklama.Text = gridUrunler.CurrentRow.Cells["Aciklama"].Value.ToString();
                cmbUrunGrubu.Text = gridUrunler.CurrentRow.Cells["UrunGrup"].Value.ToString();
                tAlisFiyati.Text = gridUrunler.CurrentRow.Cells["AlisFiyati"].Value.ToString();
                tDolarAlis.Text = gridUrunler.CurrentRow.Cells["DolarAlisFiyat"].Value.ToString();
                tDolarSatis.Text = gridUrunler.CurrentRow.Cells["DolarSatisFiyat"].Value.ToString();
                tOzelKod.Text = gridUrunler.CurrentRow.Cells["OzelKod"].Value.ToString();
                tTedarikci.Text = gridUrunler.CurrentRow.Cells["Tedarikci"].Value.ToString();
                tSatisFiyati.Text = gridUrunler.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                tKdvOrani.Text = gridUrunler.CurrentRow.Cells["KdvOrani"].Value.ToString();
                tMiktar.Text = gridUrunler.CurrentRow.Cells["Miktar"].Value.ToString();
                string birim = gridUrunler.CurrentRow.Cells["Birim"].Value.ToString();
                if (birim=="Kg")
                {
                    chUrunTipi.Checked = true;
                }
                else
                {
                    chUrunTipi.Checked = false;
                }


            }
        }

        private void tMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void tKdvOrani_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

        private void bKurGir_Click(object sender, EventArgs e)
        {
            using (var f = new fKurAyarlari())
                f.ShowDialog();

            KurYukle(); // kapanınca güncel kuru tekrar çek
        }

    }
}