using System;
using System.ComponentModel.DataAnnotations;

namespace NewsSystem.Data.Models
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(300)]
        public string Resume { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(10000)]
        public string Content { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AddedOn { get; set; }

        public bool IsEditing { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}