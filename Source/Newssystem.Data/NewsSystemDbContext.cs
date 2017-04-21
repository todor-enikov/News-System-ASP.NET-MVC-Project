using Microsoft.AspNet.Identity.EntityFramework;
using NewsSystem.Data.Models;
using System.Data.Entity;

namespace Newssystem.Data
{
    public class NewsSystemDbContext : IdentityDbContext<User>, INewsSystemDbContext
    {
        public NewsSystemDbContext()
            : base("NewsSystem")
        {

        }

        public virtual IDbSet<Article> Articles { get; set; }

        public static NewsSystemDbContext Create()
        {
            return new NewsSystemDbContext();
        }
    }
}
