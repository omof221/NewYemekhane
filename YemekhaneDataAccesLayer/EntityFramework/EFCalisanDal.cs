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

        public Calisan GetByGorev(string gorev)
        {
            using var context = new YemekhaneContext();
            return context.Calisanlar.FirstOrDefault(x => x.calisanGorevi == gorev);    

        }

        public Calisan GetByKartNo(int kartNo)
        {
            using var context = new YemekhaneContext();
            return context.Calisanlar.FirstOrDefault();
        }
    }
}
