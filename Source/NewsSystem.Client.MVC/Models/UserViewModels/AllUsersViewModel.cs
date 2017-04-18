using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystem.Client.MVC.Models.UserViewModels
{
    public class AllUsersViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }
            
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}