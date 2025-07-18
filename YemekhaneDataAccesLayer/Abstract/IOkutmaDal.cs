using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneDataAccesLayer.Abstract
{
    public interface IOkutmaDal:IGenericDal<Okutmalar>
    {
        bool BugunOkuttuMu(int calisanId);
        List<Okutmalar> GetByDate(DateTime tarih);
        List<Okutmalar> GetByDateRange(DateTime baslangic, DateTime bitis);
        int GetByUniqueCalisanCount(DateTime tarih);
        int GetByCalisanCount(DateTime tarih);
    }
}
