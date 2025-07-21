using Microsoft.EntityFrameworkCore;
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
    public class EFOkutmaDal : GenericRepository<Okutmalar>, IOkutmaDal
    {

        public bool BugunOkuttuMu(int calisanID)
        {
            using var context = new YemekhaneContext();
            return context.Okutmalar.Any(x => x.calisan.calisanID == calisanID && x.OkutmaTarihi == DateTime.Today && !x.jokerGecis);
        }

        public int GetByCalisanCount(DateTime tarih)
        {
            using var context = new YemekhaneContext();
            return context.Okutmalar
                          .Where(x => x.OkutmaTarihi == tarih && !x.jokerGecis)
                          .Select(x => x.calisanID)
                          .Count();
        }

        public List<Okutmalar> GetByDate(DateTime tarih)
        {
            using var context = new YemekhaneContext();
            return context.Okutmalar
                          .Include(x => x.OkutmaTarihi)
                          .Where(x => x.OkutmaTarihi.Date == tarih.Date)
                          .ToList();
        }

        public List<Okutmalar> GetByDateRange(DateTime baslangic, DateTime bitis)
        {
            using var context = new YemekhaneContext();
            return context.Okutmalar
                          .Include(x => x.calisan)
                          .Where(x => x.OkutmaTarihi >= baslangic && x.OkutmaTarihi <= bitis)
                          .ToList();
        }

        public int GetByUniqueCalisanCount(DateTime tarih)
        {
            using var context = new YemekhaneContext();
            return context.Okutmalar
                          .Where(x => x.OkutmaTarihi == tarih && !x.jokerGecis)
                          .Select(x => x.calisanID)
                          .Distinct()
                          .Count();
        }
    }
}
