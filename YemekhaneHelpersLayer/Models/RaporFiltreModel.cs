using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekhaneHelpersLayer.Models
{
    public class RaporFiltreModel
    {
        public DateTime? BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime? TekTarih { get; set; }
        public int? calisanID { get; set; }
    }
}
