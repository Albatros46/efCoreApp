using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efCoreApp.Entities
{
    public class KursKayit
    {
        [Key]
        [Display(Name = "Id")]
        
        public int KayitId { get; set; }

        [Display(Name = "Ogrenci Id")]
        [ForeignKey("OgrenciId")]
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; } = null!; //Iki tablonun ilgili alanlarini kesitrip SQL ile Join yaparak NAvigation Property ile yapilabilir.

        [Display(Name ="Kurs Id")]
        [ForeignKey("KursId")]
        public int KursId { get; set; }
        public Kurs Kurs { get; set; } = null!;

        //[Display(Name ="Kayit Tarihi")]
        //public DateTime KayitTarihi { get; set; }

        /*
         Many To Many table Relatiship ( Coka Cok tablo iliskisi olacak )
         bir ogrenci birden fazla kursa kayit olabileck ve bir kursta birden fazla ogrenci olacak.

        Iki tablonun ilgili alanlarini kesitrip SQL ile Join yaparak NAvigation Property ile yapilabilir.
         */
    }
}
