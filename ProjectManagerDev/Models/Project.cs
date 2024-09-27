using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using JsonIgnore = Newtonsoft.Json.JsonIgnoreAttribute;


namespace ProjectManagerDev.Models
{
    [Table("projects")]
    public class Project : BaseEntity
    {
        [Column("id"), Key]
        [JsonProperty("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(64)]
        [Column("name")]
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Column("summary")]
        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [Column("created_at")]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("company_id")]
        [JsonProperty("company_id")]
        public Guid CompanyId { get; set; }

       
        public List<Board> Boards { get; set; } = new List<Board>();

        [JsonIgnore]
        public required Company Company { get; set; }
        public Project(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Summary = project.Summary;
            CreatedAt = project.CreatedAt;
            CompanyId = project.CompanyId;
        }
    }
}