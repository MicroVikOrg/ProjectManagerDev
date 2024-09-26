using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerDev.Models
{
    [Table("tasks")]
    public class Task
    {
        [JsonProperty("id")]
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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


        [JsonProperty("column_id")]
        [Column("column_id")]
        public int ColumnId { get; set; }

        
    }
}
