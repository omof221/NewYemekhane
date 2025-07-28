using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekhaneEntityLayer.Entities
{
    public class YemekhaneCalisan
    {
        public int yemekhaneCalisanId { get; set; }
        public string tc { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }

        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public bool durum { get; set; }
        
    }
}
