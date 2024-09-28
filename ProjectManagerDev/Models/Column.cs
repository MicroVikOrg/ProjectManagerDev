using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerDev.Models
{
    [Table("columns")]
    public class Column : BaseEntity
    {
        [JsonProperty("name")]
        [Column("name")]
        public required string Name { get; set; }
        [JsonIgnore]
        public Board Board { get; set; }
        [JsonProperty("board_id")]
        [Column("board_id")]
        public Guid BoardId { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}