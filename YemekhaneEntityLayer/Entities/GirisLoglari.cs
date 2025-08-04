using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekhaneEntityLayer.Entities
{
    public class GirisLoglari
    {
        public int GirisLoglariId { get; set; }

        // Foreign Key
        public int CalisanId { get; set; }

        // Navigation Property
        public YemekhaneCalisan Calisan { get; set; }

        public DateTime GirisZamani { get; set; }
        public bool Basarili { get; set; }
    }
}
