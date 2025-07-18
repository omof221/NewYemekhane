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
    public class CalisanManager : ICalisanService
    {
        private readonly ICalisanDal _calisanDal;

        // Constructor - dependency injection ile ICalisanDal dışarıdan alınır
        public CalisanManager(ICalisanDal calisanDal)
        {
            _calisanDal = calisanDal;
        }
            
        // Kart numarasına göre çalışanı getir
        public Calisan GetByKartNo(int kartNo)
            => _calisanDal.GetByKartNo(kartNo);

        // Ad ve soyad'a göre çalışanı getir
        public Calisan GetByAdSoyad(string ad, string soyad)
            => _calisanDal.GetByAdSoyad(ad, soyad);

        // ID'ye göre çalışanı getir
        public Calisan GetById(int id)
            => _calisanDal.GetById(id);

        //Göreve göre çalışanı getir
        public Calisan GetByGorev(string gorev)
            => _calisanDal.GetByGorev(gorev);
        // Tüm çalışanları getir
        public List<Calisan> GetAll()
            => _calisanDal.GetAll();


    }
}
