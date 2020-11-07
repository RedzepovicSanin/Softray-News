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
            News initialNews = new News(1, "Long concerned about climate change, VC Steve Westly is feeling electrified", "A former CFO of the state of California, Steve Westly is passionate about government. The onetime eBay exec and early Tesla  board member has also been a proponent of clean energy for roughly 30 years, so he’s feeling optimistic right now, with former U.S. VP Joe Biden amassing a growing number of electoral votes and widening his lead over Donald Trump as he inches toward an election win.", NewsStatus.Active, DateTime.Now, new User(1, "Sanin", DateTime.Now));
            News initialNews2 = new News(2, "Extra Crunch roundup: B2B marketplaces, edtech M&A, breaking into the $1M ARR club", "Like many people, I’ve been distracted in recent days. As I write this, I have one eye on my keyboard and another on a TV that sporadically broadcasts election results from battleground states. Despite the background noise, I’m completely impressed with the TechCrunch staff; it takes a great deal of focus and energy to set aside the world’s top news story and concentrate on the work at hand.", NewsStatus.Active, DateTime.Now, new User(1, "Sanin", DateTime.Now));
            News initialNews3 = new News(3, "Daily Crunch: Netflix tests a linear video channel", "Netflix previously tested a Shuffle button, so apparently it’s very interested in exploring a viewer experience where you just turn the TV on and veg out. The service says it’s testing this in France because “many viewers like the idea of programming that doesn’t require them to choose what they are going to watch.”", NewsStatus.Deleted, DateTime.Now, new User(1, "Sanin", DateTime.Now));
            News initialNews4 = new News(4, "Startups making meat alternatives are gaining traction worldwide", "New partnerships with global chains like McDonald’s in Hong Kong, the launch of test kitchens in Israel and new financing rounds for startups in Sydney and Singapore point to abounding opportunities in international markets for meat alternatives.", NewsStatus.Achived, DateTime.Now, new User(2, "Lamija", DateTime.Now));
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
                News newNews = new News(newsForInsert.Id, newsForInsert.Title, newsForInsert.Text, NewsStatus.Active, newsForInsert.DateInserted, newsForInsert.UserCreated);

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
                updatedNews.Text = newsForUpdate.Text;
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