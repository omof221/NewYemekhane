using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneBussssinesLayer_.Interfacess
{
    internal interface IOkutmaService
    {
        void TEkle(Okutmalar okutma);
        bool TBugunOkuttuMu(int calisanId);
        List<Okutmalar> TGetByDate(DateTime tarih);
        List<Okutmalar> TGetByDateRange(DateTime baslangic, DateTime bitis);
        int TGetByUniqueCalisanCount(DateTime tarih);
        int TGetByCalisanCount(DateTime tarih);

    }
}
