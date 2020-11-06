using SoftrayNewsAPI.Models;
using SoftrayNewsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SoftrayNewsAPI.Services
{

    public class NewsService : INewsService
    {
        private List<News> allNews = new List<News>();
        public NewsService()
        {
            News initialNews = new News(1, "Nova vijest", "Najnovija vijest za cuti", NewsStatus.Active, DateTime.Now, new User(1, "Sanin", DateTime.Now));
            News initialNews2 = new News(2, "Nova vijest 2", "Najnovija vijest za cuti 2", NewsStatus.Active, DateTime.Now, new User(1, "Sanin", DateTime.Now));
            News initialNews3 = new News(3, "Nova vijest 3", "Najnovija vijest za cuti 3", NewsStatus.Deleted, DateTime.Now, new User(1, "Sanin", DateTime.Now));
            News initialNews4 = new News(4, "Nova vijest 4", "Najnovija vijest za cuti 4", NewsStatus.Achived, DateTime.Now, new User(2, "Lamija", DateTime.Now));
            allNews.Add(initialNews);
            allNews.Add(initialNews2);
            allNews.Add(initialNews3);
            allNews.Add(initialNews4);
        }

        public List<News> GetAllNews()
        {
            try
            {
                List<News> news = allNews.OrderByDescending(x => x.DateInserted).ToList();
                
                return news;
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public News GetNewsById(int id)
        {
            try
            {
                News foundNews = allNews.Where(x => x.Id == id).FirstOrDefault();
                return foundNews;
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public News InsertNews(News newsForInsert)
        {
            try
            {
                News newNews = new News(newsForInsert.Id, newsForInsert.Title, newsForInsert.Description, NewsStatus.Active, newsForInsert.DateInserted, newsForInsert.UserCreated);

                // dbContext.News.Add(newNews);
                // await p2pContext.SaveChangesAsync();
                return newNews;
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public News UpdateNews(News newsForUpdate) {

            try
            {
                News updatedNews = allNews.Where(x => x.Id == newsForUpdate.Id).FirstOrDefault();
                updatedNews.Title = newsForUpdate.Title;
                updatedNews.Description = newsForUpdate.Description;
                updatedNews.DateInserted = newsForUpdate.DateInserted;
                updatedNews.UserCreated = newsForUpdate.UserCreated;

                //p2pContext.Update(updatedNews);
                //await p2pContext.SaveChangesAsync();
                return updatedNews;
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }
        public News DeleteNews(int id)
        {
            News foundNews = allNews.Where(x => x.Id == id).FirstOrDefault();
            foundNews.Status = NewsStatus.Deleted;
            return foundNews;
        }
    }
}