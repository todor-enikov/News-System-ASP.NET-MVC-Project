using NewsSystem.Client.MVC.Models.ArticleViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem.Client.MVC.Models.UserViewModels
{
    public class UserDetailsViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public List<UserArticleViewModel> UserArticles { get; set; }
    }
}