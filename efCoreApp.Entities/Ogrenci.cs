using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name ="E-Posta")]
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
    }
}
