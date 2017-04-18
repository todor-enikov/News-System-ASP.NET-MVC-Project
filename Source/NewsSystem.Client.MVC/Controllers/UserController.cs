﻿using NewsSystem.Client.MVC.Models.ArticleViewModels;
using NewsSystem.Client.MVC.Models.UserViewModels;
using NewsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem.Client.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var allUsersFromDb = this.userService.GetAllUsers();
            var viewModel = new List<AllUsersViewModel>();

            foreach (var user in allUsersFromDb)
            {
                var userToAdd = new AllUsersViewModel()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                viewModel.Add(userToAdd);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var userFromDB = this.userService
                                             .GetUserById(id);
            var userFromDbArticles = userFromDB.Articles;
            var articles = new List<UserArticleViewModel>();

            foreach (var userArticle in userFromDbArticles)
            {
                var articleToAdd = new UserArticleViewModel()
                {
                    Id = userArticle.Id,
                    Title = userArticle.Title
                };

                articles.Add(articleToAdd);
            }

            var viewModel = new UserDetailsViewModel()
            {
                Id = id,
                FirstName = userFromDB.FirstName,
                LastName = userFromDB.LastName,
                UserName = userFromDB.UserName,
                Email = userFromDB.Email,
                UserArticles = articles
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var userFromDb = this.userService
                                             .GetUserById(id);
            var viewModel = new UserDetailsViewModel()
            {
                Email = userFromDb.Email,
                FirstName = userFromDb.FirstName,
                LastName = userFromDb.LastName,
                UserName = userFromDb.UserName
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDetailsViewModel model, string id)
        {
            var userToUpdate = this.userService
                                               .GetUserById(id);
            userToUpdate.Email = model.Email;
            userToUpdate.FirstName = model.FirstName;
            userToUpdate.LastName = model.LastName;
            userToUpdate.UserName = model.UserName;
            this.userService.Update(userToUpdate);

            return RedirectToAction("Details", "User", new { id = model.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {

            var userModel = this.userService
                                .GetUserByUserName(search);

            var viewModel = new List<AllUsersViewModel>();

            foreach (var user in userModel)
            {
                var currentUser = new AllUsersViewModel()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                viewModel.Add(currentUser);
            }

            if (viewModel.Count < 1)
            {
                return PartialView("_NoResults", viewModel);
            }

            return PartialView("_AllUsers", viewModel);
        }
    }
}