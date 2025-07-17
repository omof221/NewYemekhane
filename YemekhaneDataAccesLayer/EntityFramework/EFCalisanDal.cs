using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneDataAccesLayer.Abstract;
using YemekhaneDataAccesLayer.Context;
using YemekhaneDataAccesLayer.Repositories;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneDataAccesLayer.EntityFramework
{
    public class EFCalisanDal : GenericRepository<Calisan>, ICalisanDal
    {
        public Calisan GetByAdSoyad(string ad, string soyad)
        {
            using var context = new YemekhaneContext();
            return context.Calisanlar.FirstOrDefault(x => x.calisanIsmi == ad && x.calisanSoyad == soyad);
        }

        public Calisan GetByGörev(string görev)
        {
            using var context = new YemekhaneContext();
            return context.Calisanlar.FirstOrDefault(x => x.calisanGorevi == görev);    

        }

        public Calisan GetByKartNo(int kartNo)
        {
            using var context = new YemekhaneContext();
            return context.Calisanlar.FirstOrDefault(x => x.calisanKartNo == kartNo);
        }
    }
}
