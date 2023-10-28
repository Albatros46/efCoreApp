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
       
       
        public int OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; } = null!; // "public int OgretmenId { get; set; }" her iki kullanimda ayni.
                                                        //  public int? Ogretmen2 { get; set; } //Eger kurs acildiktan sonra ogretmen atansin istersek bu sekil kullanilabilir.

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}
