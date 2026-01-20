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
    public partial class fCariHareketler : Form
    {
        public fCariHareketler()
        {
            InitializeComponent();
        }

        BarkodDbEntities db = new BarkodDbEntities();

        private void fCariHareketler_Load(object sender, EventArgs e)
        {
             // Grid stilini ayarla
            Islemler.GridDuzenle(gridListe);
        }

        private void bCariSec_Click(object sender, EventArgs e)
        {
            fCariListe f = new fCariListe();
            f.SecimModu = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                int cariId = f.SecilenCariId;
                CariHareketleriGetir(cariId);
            }
        }

        private void CariHareketleriGetir(int cariId)
        {
            var cari = db.Cariler.Find(cariId);
            if (cari != null)
            {
                lCariAdi.Text = cari.CariAdi;
                lTelefon.Text = cari.Telefon;
            }

            var hareketler = db.IslemOzet
                .Where(x => x.CariId == cariId)
                .OrderByDescending(x => x.Tarih)
                .Select(x => new
                {
                    x.Id,
                    x.IslemNo,
                    x.Tarih,
                    x.Aciklama,
                    x.Iade,
                    x.OdemeSekli,
                    Tutar = (x.Nakit ?? 0) + (x.Kart ?? 0)
                })
                .ToList();

            gridListe.DataSource = hareketler;
            Islemler.GridDuzenle(gridListe);

            // Hesaplamalar
            double toplamGelir = hareketler.Where(x => x.Iade == false || x.Iade == null).Sum(x => x.Tutar);
            double toplamGider = hareketler.Where(x => x.Iade == true).Sum(x => x.Tutar);

            lToplamGelir.Text = toplamGelir.ToString("C2");
            lToplamGider.Text = toplamGider.ToString("C2");
            lBakiye.Text = (toplamGelir - toplamGider).ToString("C2");

            gridListe.Columns["Id"].Visible = false;
            gridListe.Columns["Tutar"].DefaultCellStyle.Format = "C2";
            gridListe.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
    }
}
