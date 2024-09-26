using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerDev.Models
{
    [Table("tags")]
    public class Tag
    {
        [JsonProperty("id")]
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(32)]
        [JsonProperty("name")]
        [Column("name")]
        public required string Name { get; set; }
    }
}