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
        public int TaskId { get; set; }

        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<Tag> Tags { get; set; } = new List<Tag>();

        [JsonProperty("tag_id")]
        [Column("tag_id")]
        public int TagId { get; set; }
    }
}