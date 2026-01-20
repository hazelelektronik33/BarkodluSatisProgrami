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
    public partial class fTeknikServis : Form
    {
        public fTeknikServis()
        {
            InitializeComponent();
        }
        private void Temizle()
        {
            tBarkod.Clear();
            tUrunAdi.Clear();
            tAciklama.Clear();
            tSeriNo.Clear();
            tMusteriBeyani.Clear();
            tUzerindeGelenler.Clear();
            tSeriNo.Clear();
            chYazdir.Checked = false;
        }
        BarkodDbEntities db = new BarkodDbEntities();
        private void fTeknikServis_Load(object sender, EventArgs e)
        {
            gridTeknikListe.DataSource = db.TeknikServis.OrderByDescending(a => a.Id).Take(20).ToList();
            Islemler.GridDuzenle(gridTeknikListe);
        }

       

            private void bKaydet_Click(object sender, EventArgs e)
            {
                if (tBarkod.Text != "" && tUrunAdi.Text != ""  && tSeriNo.Text != "" && tTeslimAlan.Text != "" && tAciklama.Text != "" && tMusteriBeyani.Text != "" && tUzerindeGelenler.Text != "" && tGirisTarihi.Text != "")
                {
                    if (db.TeknikServis.Any(a => a.Barkod == tBarkod.Text))
                    {
                        var guncelle = db.TeknikServis.Where(a => a.Barkod == tBarkod.Text).SingleOrDefault();
                        guncelle.UrunAdi = tUrunAdi.Text;
                        guncelle.Aciklama = tAciklama.Text;
                        guncelle.UrunGrubu = cmbUrunGrubu.Text;
                        guncelle.SeriNo = tSeriNo.Text;
                        guncelle.TeslimAlan = tTeslimAlan.Text;
                        guncelle.MusteriBeyani = tMusteriBeyani.Text;
                        guncelle.UzerindeGelenler = tUzerindeGelenler.Text;
                        guncelle.GirisTarihi = DateTime.Now;   
                        guncelle.TeslimAlan = lKullanici.Text;
                        db.SaveChanges();
                    if (chYazdir.Checked)
                    {
                        // Yazdır...
                        Yazdir yazdir = new Yazdir(1);
                        yazdir.YazdirmayaBasla();
                    }
                    MessageBox.Show("Teknik Servis Formu Başarı İle Güncellendi.");
                        //gridTeknikListe.DataSource = db.TeknikServis.OrderByDescending(a => a.Id).Take(20).ToList();
                    }
                    else
                    {

                    TeknikServis teknikservis = new TeknikServis();
                    teknikservis.Barkod = tBarkod.Text;
                    teknikservis.UrunAdi = tUrunAdi.Text;
                    teknikservis.Aciklama = tAciklama.Text;
                    teknikservis.UrunGrubu = cmbUrunGrubu.Text;
                    teknikservis.SeriNo = tSeriNo.Text;
                    teknikservis.TeslimAlan = tTeslimAlan.Text;
                    teknikservis.MusteriBeyani = tMusteriBeyani.Text;
                    teknikservis.UzerindeGelenler = tUzerindeGelenler.Text;
                    teknikservis.GirisTarihi = DateTime.Now;
                    teknikservis.TeslimAlan = lKullanici.Text;
 
                        db.TeknikServis.Add(teknikservis);
                        db.SaveChanges();
                        if (tBarkod.Text.Length == 8)
                        {
                            var ozelbarkod = db.Barkod.First();
                            ozelbarkod.BarkodNo += 1;
                            db.SaveChanges();
                        }

                        
                    }
                 
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Bilgi Girişlerini Kontrol Ediniz!");
                    tBarkod.Focus();
                }
            }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTeknikListe.Rows.Count > 0)
            {
                int id = Convert.ToInt32(gridTeknikListe.CurrentRow.Cells["Id"].Value.ToString());
                lKullaniciId.Text = id.ToString();
                using (var db = new BarkodDbEntities())
                {
                    var getir = db.TeknikServis.Where(x => x.Id == id).FirstOrDefault();
                    tSeriNo.Text = getir.SeriNo;
                    tBarkod.Text = getir.Barkod;
                    tUrunAdi.Text = getir.UrunAdi;
                    tAciklama.Text = getir.Aciklama;
                    tMusteriBeyani.Text = getir.MusteriBeyani;
                    tUzerindeGelenler.Text = getir.UzerindeGelenler;
                   
                    bKaydet.Text = "Düzenle/Kaydet";
                    Doldur();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Seçiniz");
            }
        }
        private void Doldur()
        {
            using (var db = new BarkodDbEntities())
            {
                if (db.TeknikServis.Any())
                {
                    gridTeknikListe.DataSource = db.TeknikServis.Select(x => new { x.Id, x.SeriNo, x.Barkod, x.UrunAdi, x.Aciklama, x.MusteriBeyani, x.UzerindeGelenler }).ToList();
                    Islemler.GridDuzenle(gridTeknikListe);

                }
                


            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTeknikListe.Rows.Count > 0)
            {
                int urunid = Convert.ToInt32(gridTeknikListe.CurrentRow.Cells["Id"].Value.ToString());
                string urunadi = gridTeknikListe.CurrentRow.Cells["UrunAdi"].Value.ToString();
                string barkod = gridTeknikListe.CurrentRow.Cells["Barkod"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunadi + " Kayıtı Silmek İstiyormusunuz?", "Kayıt Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var teknikservis = db.TeknikServis.Find(urunid);
                    db.TeknikServis.Remove(teknikservis);

                    db.SaveChanges();
                    
                    MessageBox.Show("Kayıt Silinmiştir.");

                    gridTeknikListe.DataSource = db.TeknikServis.OrderByDescending(a => a.Id).Take(20).ToList();
                    Islemler.GridDuzenle(gridTeknikListe);

                    tBarkod.Focus();
                }
            }
        }
    }
}
