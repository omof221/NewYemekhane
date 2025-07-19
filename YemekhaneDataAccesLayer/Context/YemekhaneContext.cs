using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneDataAccesLayer.Context
{
    public class YemekhaneContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial Catalog=yemekhanePProjesiDB;Integrated Security=true;Encrypt=True;TrustServerCertificate=True;");
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Okutmalar> Okutmalar { get; set; }
        public DbSet<Admin> Adminler { get; set; }

    }
}
