namespace Newssystem.Data.Migrations
{
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NewsSystem.Common;
    using NewsSystem.Data.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Newssystem.Data.NewsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsSystemDbContext context)
        {
            this.SeedRoles(context);
            this.SeedAdmin(context);
        }

        private void SeedRoles(NewsSystemDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var adminRole = new IdentityRole { Name = ApplicationConstants.AdminRole };
                roleManager.Create(adminRole);

                var userRole = new IdentityRole { Name = ApplicationConstants.UserRole };
                roleManager.Create(userRole);

                context.SaveChanges();
            }
        }

        private void SeedAdmin(NewsSystemDbContext context)
        {
            if (!context.Users.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                var defaultAdmin = new User()
                {
                    FirstName = "Administrator",
                    LastName = "Administrator",
                    UserName = "Administrator",
                    Email = "Admin@istrator.bg"
                };

                userManager.Create(defaultAdmin, "123456");
                userManager.AddToRole(defaultAdmin.Id, ApplicationConstants.AdminRole);
                context.SaveChanges();
            }
        }
    }
}
