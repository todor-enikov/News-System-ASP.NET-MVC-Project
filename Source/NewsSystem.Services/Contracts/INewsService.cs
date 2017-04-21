using NewsSystem.Data.Models;
using System;
using System.Linq;

namespace NewsSystem.Services.Contracts
{
    public interface INewsService
    {
        IQueryable<Article> GetAllNews();

        Article GetNewsById(Guid id);

        void AddNews(Article newsToAdd);

        IQueryable<Article> GetNewsByTitle(string title);

        IQueryable<Article> GetLastFourAddedNews();

        void UpdateNews(Article newsToUpdate);

        void DeleteNews(Article newsToDelete);
    }
}
