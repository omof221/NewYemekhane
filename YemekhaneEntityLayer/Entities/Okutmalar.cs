using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekhaneEntityLayer.Entities
{
    public class Okutmalar
    {
        public int OkutmaID { get; set; }

        public int calisanID { get; set; }
        public Calisan calisan { get; set; }
        public DateTime OkutmaTarihi { get; set; }
        public bool jokerGecis { get; set; }
        public int gecisCount { get; set; }
        public int jokerGecisCount { get; set; }
    }
}
