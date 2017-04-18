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
        public ActionResult Details()
        {
            return View();
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