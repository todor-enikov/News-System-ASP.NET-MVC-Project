using NewsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Services.Contracts
{
    public interface INewsService
    {
        IQueryable<Article> GetAllNews();

        Article GetNewsById(string id);

        void AddNews(Article newsToAdd);

        IQueryable<Article> GetNewsByTitle(string title);

        void UpdateNews(Article newsToUpdate);

        void DeleteNews(Article newsToDelete);
    }
}
