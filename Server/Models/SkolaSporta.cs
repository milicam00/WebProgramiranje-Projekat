using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("SkolaSporta")]
    public class SkolaSporta
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Naziv { get; set; }

        [MaxLength(200)]
        public string Adresa { get; set; }
        [MaxLength(40)]
        public string  Broj { get; set; }

        [MaxLength(100)]
        public string Email{get; set;}
        public List<Sport> sportovi{get; set;}
    }
}

