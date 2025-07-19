using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneBussssinesLayer_.Interfacess;
using YemekhaneDataAccesLayer.Abstract;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneBussssinesLayer_.Concretes
{
    public class OkutmaManager : IOkutmaService
    {
        private readonly IOkutmaDal _okutmaDal;

        public OkutmaManager(IOkutmaDal okutmaDal)
        {
            _okutmaDal = okutmaDal;
        }

        public bool TBugunOkuttuMu(int calisanId)
        {
            return _okutmaDal.BugunOkuttuMu(calisanId); 
        }

        public void TEkle(Okutmalar okutma)
        {
            throw new NotImplementedException();
        }

        public int TGetByCalisanCount(DateTime tarih)
        {
            throw new NotImplementedException();
        }

        public List<Okutmalar> TGetByDate(DateTime tarih)
        {
            throw new NotImplementedException();
        }

        public List<Okutmalar> TGetByDateRange(DateTime baslangic, DateTime bitis)
        {
            throw new NotImplementedException();
        }

        public int TGetByUniqueCalisanCount(DateTime tarih)
        {
            throw new NotImplementedException();
        }
    }
}
