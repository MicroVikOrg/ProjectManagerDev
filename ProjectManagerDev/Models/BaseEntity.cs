using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerDev.Models
{
    public abstract class BaseEntity
    {
        [Column("id"), Key]
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
