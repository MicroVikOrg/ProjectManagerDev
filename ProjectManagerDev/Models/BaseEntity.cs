using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagerDev.Models
{
    public abstract class BaseEntity
    {
        [Column("id"), Key]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
