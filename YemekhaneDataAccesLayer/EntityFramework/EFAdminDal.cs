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
    public class EFAdminDal : GenericRepository<Admin>, IAdminDal
    {
    
        public Admin GetByAdSoyad(string ad, string soyad)
        {
            using var context = new YemekhaneContext();
            return context.Adminler.FirstOrDefault(x => x.adminIsim == ad && x.adminSoyad == soyad);
        }

        public Admin GetByUserName(string userName)
        {
            using var context = new YemekhaneContext();
            return context.Adminler.FirstOrDefault(x => x.adminUsername == userName);
        }
    }
}
