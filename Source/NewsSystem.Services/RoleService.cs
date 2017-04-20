using Newssystem.Data.Repository;
using NewsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NewsSystem.Data.Models;
using Newssystem.Data;
using System.Web.Security;

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
