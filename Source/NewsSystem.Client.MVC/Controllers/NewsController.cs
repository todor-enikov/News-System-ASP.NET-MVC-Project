using Microsoft.AspNet.Identity;
using NewsSystem.Client.MVC.Models.NewsViewModels;
using NewsSystem.Common;
using NewsSystem.Data.Models;
using NewsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
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
        [AllowAnonymous]
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
        [Authorize(Roles = ApplicationConstants.AdminRole)]
        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ApplicationConstants.AdminRole)]
        public ActionResult AddNews(CreateNewsViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var file = model.ImageFile;
            var imagePath = ApplicationConstants.ImagePath + file.FileName;
            this.UploadFile(file);

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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(Guid id)
        {
            var newsFromDb = this.newsService
                                             .GetNewsById(id);

            var viewModel = new NewsDetailsViewModel()
            {
                Id = newsFromDb.Id,
                Title = newsFromDb.Title,
                Resume = newsFromDb.Resume,
                Content = newsFromDb.Content,
                AddedOn = newsFromDb.AddedOn,
                ImagePath = newsFromDb.ImagePath,
                AuthorId = newsFromDb.UserId,
                Author = newsFromDb.User.UserName
            };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
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

        [HttpGet]
        [Authorize(Roles = ApplicationConstants.AdminRole)]
        public ActionResult Edit(Guid id)
        {
            var newsFromDb = this.newsService
                                             .GetNewsById(id);
            if (!newsFromDb.IsEditing)
            {
                var viewModel = new EditNewsViewModel()
                {
                    Title = newsFromDb.Title,
                    Resume = newsFromDb.Resume,
                    Content = newsFromDb.Content,
                    Id = newsFromDb.Id
                };

                newsFromDb.IsEditing = true;
                this.newsService.UpdateNews(newsFromDb);

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("CannotEdit", "Success");
            }
        }

        [HttpPost]
        [Authorize(Roles = ApplicationConstants.AdminRole)]
        public ActionResult Edit(EditNewsViewModel model, Guid id)
        {
            var newsToUpdate = newsService
                                        .GetNewsById(id);

            var userId = User.Identity.GetUserId();
            var file = model.ImageFile;
            this.UploadFile(file);
            if (file != null)
            {
                var imagePath = ApplicationConstants.ImagePath + file.FileName;
                newsToUpdate.ImagePath = imagePath;
            }

            newsToUpdate.Title = model.Title;
            newsToUpdate.Resume = model.Resume;
            newsToUpdate.Content = model.Content;
            newsToUpdate.AddedOn = DateTime.UtcNow;
            newsToUpdate.UserId = userId;
            newsToUpdate.IsEditing = false;
            this.newsService.UpdateNews(newsToUpdate);

            return RedirectToAction("Details", "News", new { id = model.Id }); ;
        }

        public void UploadFile(HttpPostedFileBase file)
        {
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
        }
    }
}