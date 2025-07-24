using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekhaneEntityLayer.Entities
{
    public class Calisan
    {
        public  int calisanID { get; set; }
        public bool aktiflik { get; set; }
        public string calisanIsmi { get; set; }
        public string calisanSoyad { get; set; }

        public string calisanGorevi { get; set; }

        public string calisanKartNo { get; set; }

        public List<Okutmalar> Okutmalar { get; set; }




    }
}
