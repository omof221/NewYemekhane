﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneBussssinesLayer_.Interfacess
{
    public interface IAdminService
    {
        Admin TGetByAdSoyad(string ad, string soyad);
        Admin TGetByUserName(string username);
    }
}
