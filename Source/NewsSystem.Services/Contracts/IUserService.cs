using NewsSystem.Data.Models;
using System.Linq;

namespace NewsSystem.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();

        User GetUserById(string id);

        IQueryable<User> GetUserByUserName(string username);

        void Update(User userToUpdate);

        void UpdateUserRole(User userToUpdate);
    }
}
