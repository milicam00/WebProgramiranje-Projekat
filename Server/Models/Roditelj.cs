using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Roditelj")]
    public class Roditelj
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }


        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }


        [Required]
        [MaxLength(50)]
        public string BrTel{get; set;}

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [JsonIgnore]
        
        public List<Dete> Dete { get; set; }
    }
}