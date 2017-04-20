using NewsSystem.Client.MVC.Models.ArticleViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem.Client.MVC.Models.UserViewModels
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "{0} should be between {2} and {1} symbols long!", MinimumLength = 5)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<UserArticleViewModel> UserArticles { get; set; }

        public string Role { get; set; }
    }
}