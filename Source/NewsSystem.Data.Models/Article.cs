using System;
using System.ComponentModel.DataAnnotations;

namespace NewsSystem.Data.Models
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Resume { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}