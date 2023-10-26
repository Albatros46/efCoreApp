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
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Kurs> Kurslar => Set<Kurs>();//{ get; set; } // nullable olmasini sagliyoruz
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();//{ get; set; } // => Set<Ogrenci>();//nullable olmasini sagliyoruz
        public DbSet<KursKayit> KursKayits => Set<KursKayit>();//{ get; set; } // => Set<KursKayit>();//nullable olmasini sagliyoruz
        public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();//{ get; set; } // => Set<KursKayit>();//nullable olmasini sagliyoruz

    }
}
