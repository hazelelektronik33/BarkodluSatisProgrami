using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lisans;
namespace BarkodluSatis
{
   public class Kontrol
    {
        BarkodDbEntities db = new BarkodDbEntities();
       
        public void LisansFormuAc()
        {
            

            fLisans f = new fLisans();

            f.Show();
        }


    }
}
