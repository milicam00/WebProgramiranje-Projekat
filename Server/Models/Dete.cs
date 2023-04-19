using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Dete")]
    public class Dete
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prezime{ get; set; }

        [Required]
        [Range(3,14)]
        public int Godine { get; set; }

        [Required]
        [MaxLength(13)]
        public string JMBG { get; set; }

        
        public List<Spoj> SportDete{get; set;}
        public virtual  Roditelj Roditelj{get;set;}


    }
}