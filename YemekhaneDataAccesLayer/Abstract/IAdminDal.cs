using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneDataAccesLayer.Abstract
{
    public interface IAdminDal :IGenericDal<Admin>
    {
        Admin GetByAdSoyad(string ad, string soyad);
        Admin GetByUserName(string userName);   
    }
}
