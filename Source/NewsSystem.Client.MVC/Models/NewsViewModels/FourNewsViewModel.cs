using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem.Client.MVC.Models.NewsViewModels
{
    public class FourNewsViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }
    }
}