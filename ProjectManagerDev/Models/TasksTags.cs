using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagerDev.Models
{
    [Table("task_tags")]
    [PrimaryKey("TaskId","TagId")]
    public class TasksTags 
    {
        [Column("task_id")]
        [JsonProperty("task_id")]
        public Guid TaskId { get; set; }

        public required Task Task { get; set; }
        public required Tag Tag { get; set; }

        [JsonProperty("tag_id")]
        [Column("tag_id")]
        public Guid TagId { get; set; }
    }
}