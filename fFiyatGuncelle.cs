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
    public partial class fFiyatGuncelle : Form
    {
        public fFiyatGuncelle()
        {
            InitializeComponent();
        }

        private void tBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var db = new BarkodDbEntities())
                {

                    if (db.Urun.Any(x=> x.Barkod == tBarkod.Text))
                    {
                        var getir = db.Urun.Where(x => x.Barkod == tBarkod.Text).SingleOrDefault();
                        lBarkod.Text = getir.Barkod;
                        lUrunAdi.Text = getir.UrunAd;
                        double alisfiyat = Convert.ToDouble(getir.AlisFiyati);
                        lAlisFiyat.Text = alisfiyat.ToString("c2");                       
                        double mevcutfiyat = Convert.ToDouble(getir.SatisFiyat);
                        lMevcutFiyat.Text = mevcutfiyat.ToString("c2");
                        double dolaralisfiyat = Convert.ToDouble(getir.DolarAlisFiyat);
                        lDolarAlisFiyat.Text = dolaralisfiyat.ToString("#,##0.00");
                        double dolarsatisfiyat = Convert.ToDouble(getir.DolarSatisFiyat);
                        lDolarFiyat.Text = dolarsatisfiyat.ToString("#,##0.00");
                    }
                    else
                    {
                        MessageBox.Show("Ürün Kayıtlı Değil");
                    }
                    
                }
            }
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (tYeniFiyat.Text!="" && lBarkod.Text!="")
            {
                using (var db=new BarkodDbEntities())
                {
                    var guncellenecek = db.Urun.Where(x => x.Barkod == lBarkod.Text).SingleOrDefault();
                    guncellenecek.SatisFiyat = Islemler.DoubleYap(tYeniFiyat.Text);
                    guncellenecek.AlisFiyati = Islemler.DoubleYap(tYeniAlisFiyat.Text);
                    guncellenecek.DolarSatisFiyat = Islemler.DoubleYap(tDolarSatis.Text);
                    guncellenecek.DolarAlisFiyat = Islemler.DoubleYap(tDolarAlis.Text);
                    int kdvorani = Convert.ToInt16(guncellenecek.KdvOrani);
                    Math.Round(Islemler.DoubleYap(tYeniFiyat.Text) * kdvorani / 100, 2);
                    Math.Round(Islemler.DoubleYap(tDolarSatis.Text) * kdvorani / 100, 2);
                    db.SaveChanges();
                    MessageBox.Show("Yeni Fiyat Kaydedilmiştir.");
                    lBarkod.Text = "";
                    lUrunAdi.Text = "";
                    lMevcutFiyat.Text = "";
                    lAlisFiyat.Text = "";
                    lDolarAlisFiyat.Text = "";
                    lDolarFiyat.Text = "";
                    tBarkod.Clear();
                    tYeniFiyat.Clear();
                    tYeniAlisFiyat.Clear();
                    tDolarAlis.Clear();
                    tDolarSatis.Clear();
                    tBarkod.Focus();
                }
            }
            else
            {
                MessageBox.Show("Ürün Okutunuz");
                tBarkod.Focus();
            }
        }

        private void fFiyatGuncelle_Load(object sender, EventArgs e)
        {
            lBarkod.Text = "";
            lUrunAdi.Text = "";
            lAlisFiyat.Text = "";
            lMevcutFiyat.Text = "";
            lDolarAlisFiyat.Text = "";
            lDolarFiyat.Text = "";
        }

        private void tBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08)
            {
                e.Handled = true;
            }
        }

     
    }
}
