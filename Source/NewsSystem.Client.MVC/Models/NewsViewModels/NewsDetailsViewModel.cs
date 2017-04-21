using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem.Client.MVC.Models.NewsViewModels
{
    public class NewsDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Resume { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }

        public DateTime AddedOn { get; set; }

        public string AuthorId { get; set; }

        public string Author { get; set; }
    }
}