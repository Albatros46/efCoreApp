using efCoreApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efCoreApp.Repositories.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Kurs> Kurslar => Set<Kurs>();//nullable olmasini sagliyoruz
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();//nullable olmasini sagliyoruz
        public DbSet<KursKayit> KursKayits => Set<KursKayit>();//nullable olmasini sagliyoruz

    }
}
