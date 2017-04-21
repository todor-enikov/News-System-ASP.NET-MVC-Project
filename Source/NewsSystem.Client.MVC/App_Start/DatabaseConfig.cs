using Newssystem.Data;
using Newssystem.Data.Migrations;
using System.Data.Entity;

namespace NewsSystem.Client.MVC.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsSystemDbContext, Configuration>());
            NewsSystemDbContext.Create().Database.Initialize(true);
        }
    }
}