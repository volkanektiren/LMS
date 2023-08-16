﻿using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    [Table("Books", Schema = "LMS")]
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
