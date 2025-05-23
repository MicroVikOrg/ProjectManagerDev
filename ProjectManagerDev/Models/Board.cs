﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerDev.Models
{
    [Table("board")]
    public class Board : BaseEntity
    {
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
        public Guid ProjectId { get; set; }

        public List<Column> Columns { get; set; } = new List<Column>();

        [JsonIgnore]
        public Project Project { get; set; }
    }
}