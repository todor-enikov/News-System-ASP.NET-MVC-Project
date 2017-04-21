using Newssystem.Data;
using NewsSystem.Services.Contracts;
using System.Data;
using System.Linq;

namespace NewsSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly NewsSystemDbContext dbContext;

        public RoleService()
        {
            this.dbContext = new NewsSystemDbContext();
        }

        public string GetCurrentRoleOfUser(string id)
        {
            return dbContext.Roles
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault()
                                  .Name;
        }
    }
}
