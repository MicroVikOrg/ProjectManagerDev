using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using JsonIgnore = Newtonsoft.Json.JsonIgnoreAttribute;


namespace ProjectManagerDev.Models
{
    [Table("projects")]
    public class Project
    {
        [Column("id"),DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [MaxLength(64)]
        [Column("name")]
        [JsonProperty("name")]
        public required string Name { get; set; }

        [Column("summary")]
        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [Column("created_at")]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("company_id")]
        [JsonProperty("company_id")]
        public int CompanyId { get; set; }

       
        public List<Board> Boards { get; set; } = new List<Board>();

        [JsonIgnore]
        public Company Company { get; set; }
    }
}