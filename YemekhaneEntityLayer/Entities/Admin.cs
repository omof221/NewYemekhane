using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekhaneEntityLayer.Entities
{
    public class Admin
    {
        public int adminID { get; set; }
        public string adminIsim { get; set; }
        public string adminSoyad { get; set; }
        public string adminEmail { get; set; }

        public string  adminUsername { get; set; }
        public string adminSifre { get; set; }
    }
}
