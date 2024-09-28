using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerDev.Models
{
    [Table("tags")]
    public class Tag : BaseEntity
    {
        [MaxLength(32)]
        [JsonProperty("name")]
        [Column("name")]
        public required string Name { get; set; }
    }
}