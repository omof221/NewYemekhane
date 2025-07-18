using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneDataAccesLayer.Abstract;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneBussssinesLayer_.Concretes
{
    public class OkutmaManager
    {
        public readonly IOkutmaDal _okutmaDal;

        public OkutmaManager(IOkutmaDal okutmaDal)
        {
            _okutmaDal = okutmaDal;
        }

        // Constructor - dependency injection ile ICalisanDal dışarıdan alınır

        public void Ekle(Okutmalar okutma) 
        { _okutmaDal.Insert(okutma); }

        public bool BugunOkuttuMu(int calisanId) 
        { return _okutmaDal.BugunOkuttuMu(calisanId); }

        public List<Okutmalar> GetByDate(DateTime tarih)
        { return _okutmaDal.GetByDate(tarih); }

        public List<Okutmalar> GetByDateRange(DateTime baslangic, DateTime bitis)

        { return _okutmaDal.GetByDateRange(baslangic, bitis); }

        public int GetUniqueCalisanCount(DateTime tarih)

        { return _okutmaDal.GetByUniqueCalisanCount(tarih); }

    }
}
