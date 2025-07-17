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
        Calisan GetByKartNo(string kartNo);
        Calisan GetByAdSoyad(string ad, string soyad);
        Calisan GetByGörev(string görev);
    }
}
