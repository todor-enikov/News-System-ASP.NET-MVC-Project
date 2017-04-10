using System;
using System.ComponentModel.DataAnnotations;

namespace NewsSystem.Data.Models
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}