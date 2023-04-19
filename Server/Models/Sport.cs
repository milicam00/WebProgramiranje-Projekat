using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Sport")]
    public class Sport
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Vrsta { get; set; }
        public int MaxBrojDece { get; set; }
        public int TrenBrojDece { get; set; }
        public int Cena { get; set; }
       
        public List<Spoj> DeteSport{get; set;}
        [JsonIgnore]
        public SkolaSporta SkolaSporta{get; set;}


    }
}