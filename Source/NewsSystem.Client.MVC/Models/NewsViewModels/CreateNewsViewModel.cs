using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsSystem.Client.MVC.Models.NewsViewModels
{
    public class CreateNewsViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 20)]
        public string Resume { get; set; }

        [Required]
        [StringLength(10000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 100)]
        public string Content { get; set; }

        [Required]
        [FileExtensions(Extensions = "jpg|jpeg|png|gif", ErrorMessage = "Please select a .jpg, .jpeg, .png or .gif file.")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}