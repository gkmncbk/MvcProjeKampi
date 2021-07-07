using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete.ViewModels
{
   public class AllHeadingListPagition
    {
        public List<Heading> baslikListesi { get; set; }
        public decimal aktifSayfaNo { get; set; }
        public decimal sayfadaBulunacakKayitAdedi { get; set; }
        public decimal toplamKayitSayisi { get; set; }
        public decimal toplamSayfaSayisi { get; set; }
    }
}
