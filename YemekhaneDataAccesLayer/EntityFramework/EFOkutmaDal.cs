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
        public bool BugunOkuttuMu(int calisanId)
        {
            throw new NotImplementedException();
        }

        public int GetByCalisanCount(DateTime tarih)
        {
            throw new NotImplementedException();
        }

        public List<Okutmalar> GetByDate(DateTime tarih)
        {
            throw new NotImplementedException();
        }

        public List<Okutmalar> GetByDateRange(DateTime baslangic, DateTime bitis)
        {
            throw new NotImplementedException();
        }

        public int GetByUniqueCalisanCount(DateTime tarih)
        {
            throw new NotImplementedException();
        }
    }
}
