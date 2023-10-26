using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efCoreApp.Entities
{
    public class Ogrenci
    {
        [Key]
        
        public int OgrenciId { get; set; }
       // [Validation(ErrorMessage ="Maximum 20 Karakter giriniz!")]
        [MaxLength(20)]
        [Display(Name ="First Name")]
        public string? FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string? LastName { get; set; }
        public string AdSoyad { 
            get 
            {
                return this.FirstName + " " + this.LastName;
            } 
        }
        [Display(Name ="E-Posta")]
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();//= new List<KursKayit>() -> null olma durumunu önler
        //Her ögrenci birden fazla kursa katilacagi icin 
    }
}
