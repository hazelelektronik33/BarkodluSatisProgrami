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
    public partial class fKurAyarlari : Form
    {
        private readonly BarkodDbEntities db = new BarkodDbEntities();

        public fKurAyarlari()
        {
            InitializeComponent();
        }

        private void fKurAyarlari_Load(object sender, EventArgs e)
        {
            var son = db.DovizKur.OrderByDescending(x => x.Tarih).FirstOrDefault();
            if (son != null)
            {
                tUsdKur.Text = son.USD.ToString("0.######");
                lSonKur.Text = string.Format("Son USD: {0:0.######}  ({1:dd.MM.yyyy HH:mm})", son.USD, son.Tarih);
            }
            else
            {
                lSonKur.Text = "Henüz kur girilmemiş.";
            }
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(tUsdKur.Text.Replace(".", ","), out decimal kur) || kur <= 0)
            {
                MessageBox.Show("Geçerli bir USD kuru gir (ör: 33,50).");
                tUsdKur.Focus();
                return;
            }

            db.DovizKur.Add(new DovizKur
            {
                USD = kur,
                Tarih = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Kur kaydedildi.");
            this.Close();
        }
    }
}
