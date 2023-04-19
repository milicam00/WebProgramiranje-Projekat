using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Spoj")]
    public class Spoj
    {
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public Dete Dete { get; set; }
        [JsonIgnore]
        public Sport Sport { get; set; }

    [Required]
        public System.DateTime DatumUpisa { get; set; }

    }
    
}
