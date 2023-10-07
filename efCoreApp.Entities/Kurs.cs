using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efCoreApp.Entities
{
    public class Kurs
    {
        [Key]
        public int KursId { get; set; }
        public string? Title { get; set; }
    }
}
