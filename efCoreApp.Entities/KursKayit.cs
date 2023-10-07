using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efCoreApp.Entities
{
    public class KursKayit
    {
        
        public int Id { get; set; }
        public int ogrenciId { get; set; }
        public int kursId { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
