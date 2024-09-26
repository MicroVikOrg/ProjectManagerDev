using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerDev.Models
{
    [Table("board")]
    public class Board
    {
        [Column("id"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [MaxLength(64)]
        [Column("name")]
        [JsonProperty("name")]
        public required string Name { get; set; }

        [MaxLength(20)]
        [Column("type")]
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("project_id)")]
        [Column("project_id")]
        public int ProjectId { get; set; }

        List<Column> Columns { get; set; }

        [JsonIgnore]
        public Project Project { get; set; }
    }
}