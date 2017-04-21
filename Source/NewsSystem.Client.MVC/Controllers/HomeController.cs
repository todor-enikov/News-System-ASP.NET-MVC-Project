using NewsSystem.Client.MVC.Models.NewsViewModels;
using NewsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem.Client.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService newsService;

        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public ActionResult Index()
        {
            var newsFromDb = this.newsService
                                       .GetLastFourAddedNews();
            var viewModel = new List<FourNewsViewModel>();

            foreach (var news in newsFromDb)
            {
                var currentNews = new FourNewsViewModel()
                {
                    Id = news.Id,
                    Title = news.Title,
                    ImagePath = news.ImagePath
                };

                viewModel.Add(currentNews);
            }

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}