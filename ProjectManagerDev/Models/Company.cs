﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerDev.Models
{
    [Table("companies")]
    public class Company : BaseEntity
    {
        [Column("created_at")]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("company_name")]
        [JsonProperty("company_name")]
        public required string CompanyName { get; set; } 
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}