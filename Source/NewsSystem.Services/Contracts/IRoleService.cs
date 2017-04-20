using NewsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Services.Contracts
{
    public interface IRoleService
    {
        string GetCurrentRoleOfUser(string id);
    }
}
