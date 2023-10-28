using efCoreApp.Entities;
using System.ComponentModel.DataAnnotations;

namespace efCoreApp.ViewModels
{
    public class KursViewModel
    {//Form alanina tasimak istedigimiz verileri ViewModel ile tasiyacagiz. Klasorler genelde ViewModels veya ModelsDTO diye adlandirilir.
        [Key]
        [Display(Name = "Id")]
        public int KursId { get; set; }

        [MinLength(20,ErrorMessage ="Baslik En az 20 karakterden olusmalidir.")]
        [Required]
        public string? Title { get; set; }


        public int OgretmenId { get; set; }

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();

    }
}
