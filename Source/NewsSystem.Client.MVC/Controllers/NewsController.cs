using Microsoft.AspNet.Identity;
using NewsSystem.Client.MVC.Models.NewsViewModels;
using NewsSystem.Common;
using NewsSystem.Data.Models;
using NewsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem.Client.MVC.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var allNewsFromDb = this.newsService
                                                .GetAllNews();
            var viewModel = new List<AllNewsViewModel>();

            foreach (var news in allNewsFromDb)
            {
                var currentNews = new AllNewsViewModel()
                {
                    Id = news.Id,
                    Title = news.Title
                };

                viewModel.Add(currentNews);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNews(CreateNewsViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var file = model.ImageFile;
            var imagePath = ApplicationConstants.ImagePath + file.FileName;
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                     || Path.GetExtension(file.FileName).ToLower() == ".jpeg"
                     || Path.GetExtension(file.FileName).ToLower() == ".png"
                     || Path.GetExtension(file.FileName).ToLower() == ".gif")
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath(ApplicationConstants.ImagePath), fileName);
                        file.SaveAs(path);
                    }
                }
            }

            var newsToAdd = new Article()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Resume = model.Resume,
                Content = model.Content,
                AddedOn = DateTime.UtcNow,
                ImagePath = imagePath,
                UserId = userId,
            };

            this.newsService.AddNews(newsToAdd);

            return RedirectToAction("Index", "Success");
        }
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            var newsModel = this.newsService
                                            .GetNewsByTitle(search);

            var viewModel = new List<AllNewsViewModel>();

            foreach (var news in newsModel)
            {
                var currentNews = new AllNewsViewModel()
                {
                    Id = news.Id,
                    Title = news.Title
                };

                viewModel.Add(currentNews);
            }

            if (viewModel.Count < 1)
            {
                return PartialView("_NoResults", viewModel);
            }

            return PartialView("_AllNews", viewModel);
        }
    }
}