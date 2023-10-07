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
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
    }
}
