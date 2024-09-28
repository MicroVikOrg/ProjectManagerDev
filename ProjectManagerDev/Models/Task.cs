using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using JsonIgnore = Newtonsoft.Json.JsonIgnoreAttribute;
namespace ProjectManagerDev.Models
{
    [Table("tasks")]
    public class Task : BaseEntity
    {
        [JsonProperty("id")]
        [Column("id"), Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(64)]
        [JsonProperty("name")]
        [Column("name")]
        public required string Name { get; set; }
        [JsonProperty("description")]
        [Column("description")]
        public string? Description { get; set; }
        [JsonProperty("created_at")]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public Column Column { get; set; }


        [JsonPropertyName("column_id")]
        [Column("column_id")]
        public Guid ColumnId { get; set; }

        
    }
}
