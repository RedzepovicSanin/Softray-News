using SoftrayNewsAPI.DL.DBContext;
using SoftrayNewsAPI.DL.Enums;
using SoftrayNewsAPI.DL.Models;
using SoftrayNewsAPI.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SoftrayNewsAPI.Services
{

    public class NewsService : INewsService
    {
        private readonly dbContext dbContext;

        public NewsService(dbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<News>> GetAllNews()
        {
            try
            {
                List<News> news = await dbContext.News.OrderByDescending(x => x.DateInserted).Take(100).ToListAsync();
                
                return news;
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public async Task<News> GetNewsById(int id)
        {
            try
            {
                News foundNews = await dbContext.News.Where(x => x.Id == id).FirstOrDefaultAsync();
                return foundNews;
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public async Task<News> InsertNews(News newsForInsert)
        {
            try
            {
                if (newsForInsert.UserCreated != null)
                {
                    News newNews = new News();
                    newNews.Text = newsForInsert.Text;
                    newNews.Title = newsForInsert.Title;
                    newNews.Status = NewsStatus.Active;
                    newNews.DateInserted = DateTime.Now;
                    dbContext.News.Add(newNews);
                    await dbContext.SaveChangesAsync();
                    return newNews;
                } 
                else
                {
                    throw new Exception("User doesnt exist");
                }
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public async Task<News> UpdateNews(News newsForUpdate) {

            try
            {
                News updatedNews = dbContext.News.Where(x => x.Id == newsForUpdate.Id).FirstOrDefault();
                updatedNews.Title = newsForUpdate.Title;
                updatedNews.Text = newsForUpdate.Text;
                updatedNews.DateInserted = newsForUpdate.DateInserted;
                updatedNews.UserCreated = newsForUpdate.UserCreated;

                dbContext.Update(updatedNews);
                await dbContext.SaveChangesAsync();
                return updatedNews;
            }
            catch (Exception ex)
            {
                // moze se dodati logger koji upisuje exceptione u neku bazu
                throw new Exception(ex.Message);
            }
        }

        public async Task<News> DeleteNews(int id)
        {
            News foundNews = await dbContext.News.Where(x => x.Id == id).FirstOrDefaultAsync();
            foundNews.Status = NewsStatus.Deleted;

            dbContext.Update(foundNews);
            await dbContext.SaveChangesAsync();
            return foundNews;
        }
    }
}