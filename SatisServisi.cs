using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodluSatis
{
    public class SatisServisi
    {
        public double UrunSatisFiyatiHesapla(Urun urun, decimal usdKur)
        {
            // Üründe USD satış fiyatı varsa kurla çevir
            if (usdKur > 0m && urun.DolarSatisFiyat.HasValue && urun.DolarSatisFiyat.Value > 0)
            {
                var tl = (decimal)urun.DolarSatisFiyat.Value * usdKur;
                return Math.Round((double)tl, 2);
            }

            // Yoksa TL satış fiyatı
            return Math.Round(Convert.ToDouble(urun.SatisFiyat ?? 0), 2);
        }

        public double KdvBirimTutarHesapla(double birimFiyatTl, int? kdvOrani)
        {
            int oran = kdvOrani ?? 0;
            return Math.Round(birimFiyatTl * oran / 100.0, 2);
        }
    }
}
