using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem.Client.MVC.Models.ArticleViewModels
{
    public class UserArticleViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}