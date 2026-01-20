using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodluSatis
{
    public static class SabitDegerler
    {
        // Ödeme Şekilleri
        public const string OdemeNakit = "Nakit";
        public const string OdemeKart = "Kart";

        // Özel Barkodlar
        public const string BarkodsuzUrun = "11111111111116";
        public const string HizliUrunBos = "-";

        // İşlem Açıklamaları
        public const string SatisYapiliyor = "Satış Yapılıyor";
        public const string IadeIslemi = "İade İşlemi";
        public const string IadeYapiliyor = "İade Yapılıyor";

        // Varsayılan Değerler
        public const string VarsayilanBirim = "Adet";
        public const string VarsayilanUrunAdi = "Barkodsuz Ürün";
        public const string VarsayilanUrunGrup = "Barkodsuz Ürün";
    }
}
