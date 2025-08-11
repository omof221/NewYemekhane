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
        public int? CalisanId { get; set; }
        public YemekhaneCalisan Calisan { get; set; }
        public DateTime GirisZamani { get; set; }
        public bool Basarili { get; set; }
    }
}
