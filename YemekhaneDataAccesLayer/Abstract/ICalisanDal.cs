using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneDataAccesLayer.Abstract
{
    public interface ICalisanDal : IGenericDal<Calisan>
    {
        Calisan GetByKartNo(int kartNo);
        Calisan GetByAdSoyad(string ad, string soyad);
        Calisan GetByGorev(string gorev);
    }
}
