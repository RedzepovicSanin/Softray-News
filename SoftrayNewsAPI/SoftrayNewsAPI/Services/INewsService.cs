using SoftrayNewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftrayNewsAPI.Services
{
    public interface INewsService
    {
        List<News> GetAllNews();
        News GetNewsById(int id);
        News InsertNews(News news);
        News UpdateNews(News news);
        News DeleteNews(int id);
    }
}
