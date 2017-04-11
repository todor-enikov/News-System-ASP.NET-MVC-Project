using Newssystem.Data.Repository;
using NewsSystem.Data.Models;
using NewsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IEfGenericRepository<User> userRepo;

        public UserService(IEfGenericRepository<User> userRepo)
        {
            if (userRepo == null)
            {
                throw new ArgumentException("The car repo should not be null!");
            }

            this.userRepo = userRepo;
        }

        public IQueryable<User> GetAllUsers()
        {
            return this.userRepo.All();
        }

        public User GetUserById(string id)
        {
            return this.userRepo.GetById(id);
        }

        public void UpdateUserRole(User userToUpdate)
        {
            this.userRepo.Update(userToUpdate);
            this.userRepo.SaveChanges();
        }
    }
}
