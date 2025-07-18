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
    public class AdminManager
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;

        }

        public Admin GetByAdSoyad(string ad, string soyad)
            => _adminDal.GetByAdSoyad(ad, soyad);

        public Admin GetByUserName(string username)
            => _adminDal.GetByUserName(username);


    }
}
