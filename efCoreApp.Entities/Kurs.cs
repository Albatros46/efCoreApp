using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efCoreApp.Entities
{
    public class Kurs
    {
        [Key]
        [Display(Name = "Id")]
       
        public int KursId { get; set; }

        [MinLength(20)]
        public string? Title { get; set; }
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}
