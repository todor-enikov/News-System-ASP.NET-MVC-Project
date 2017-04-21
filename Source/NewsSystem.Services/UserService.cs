using Newssystem.Data.Repository;
using NewsSystem.Data.Models;
using NewsSystem.Services.Contracts;
using System;
using System.Linq;

namespace NewsSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IEfGenericRepository<User> userRepo;

        public UserService(IEfGenericRepository<User> userRepo)
        {
            if (userRepo == null)
            {
                throw new ArgumentException("The user repo should not be null!");
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

        public IQueryable<User> GetUserByUserName(string username)
        {
            return this.userRepo.All()
                                .Where(u => u.UserName.Contains(username));
        }

        public void Update(User userToUpdate)
        {
            this.userRepo.Update(userToUpdate);
            this.userRepo.SaveChanges();
        }

        public void UpdateUserRole(User userToUpdate)
        {
            this.userRepo.Update(userToUpdate);
            this.userRepo.SaveChanges();
        }
    }
}
