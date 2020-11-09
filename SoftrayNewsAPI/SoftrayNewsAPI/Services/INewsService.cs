using SoftrayNewsAPI.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftrayNewsAPI.Services
{
    public interface INewsService
    {
        Task<List<News>> GetAllNews();
        Task<News> GetNewsById(int id);
        Task<News> InsertNews(News news);
        Task<News> UpdateNews(News news);
        Task<News> DeleteNews(int id);
    }
}
