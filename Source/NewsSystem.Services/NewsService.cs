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
    public class NewsService : INewsService
    {
        private readonly IEfGenericRepository<Article> newsRepo;

        public NewsService(IEfGenericRepository<Article> newsRepo)
        {
            if (newsRepo == null)
            {
                throw new ArgumentException("The car repo should not be null!");
            }

            this.newsRepo = newsRepo;
        }

        public IQueryable<Article> GetAllNews()
        {
            return this.newsRepo.All();
        }

        public Article GetNewsById(string id)
        {
            return this.newsRepo.GetById(id);
        }

        public void AddNews(Article newsToAdd)
        {
            this.newsRepo.Add(newsToAdd);
            this.newsRepo.SaveChanges();
        }

        public void UpdateNews(Article newsToUpdate)
        {
            this.newsRepo.Update(newsToUpdate);
            this.newsRepo.SaveChanges();
        }

        public void DeleteNews(Article newsToDelete)
        {
            this.newsRepo.Delete(newsToDelete);
        }
    }
}
