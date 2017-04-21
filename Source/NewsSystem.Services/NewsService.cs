﻿using Newssystem.Data.Repository;
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
                throw new ArgumentException("The news repo should not be null!");
            }

            this.newsRepo = newsRepo;
        }

        public IQueryable<Article> GetAllNews()
        {
            return this.newsRepo.All();
        }

        public Article GetNewsById(Guid id)
        {
            return this.newsRepo.GetById(id);
        }

        public void AddNews(Article newsToAdd)
        {
            this.newsRepo.Add(newsToAdd);
            this.newsRepo.SaveChanges();
        }

        public IQueryable<Article> GetNewsByTitle(string title)
        {
            return this.newsRepo.All()
                                .Where(a => a.Title.Contains(title));
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
