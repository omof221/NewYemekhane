using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneBussssinesLayer_.Interfacess
{
    public interface ICalisanService
    {
        Calisan TGetByAdSoyad(string ad, string soyad);
        Calisan TGetById(int id);
        List<Calisan> TGetAll();
        Calisan TGetByGorev(string gorev);

        Calisan TGetByKartNo(int kartNo);
    }
}
