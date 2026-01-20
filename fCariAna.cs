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
    public partial class fCariAna : Form
    {
        public fCariAna()
        {
            InitializeComponent();
        }

        private void bCariAcilisKarti_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fCariAcilisKarti f = new fCariAcilisKarti();
            f.lKullanici.Text = lKullanici.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void bCariGruplari_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fCariGruplari f = new fCariGruplari();
            f.lKullanici.Text = lKullanici.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void bCariListesi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fCariListe f = new fCariListe();
            f.lKullanici.Text = lKullanici.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void bCariHaraketleri_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fCariHareketler f = new fCariHareketler();
            f.lKullanici.Text = lKullanici.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
