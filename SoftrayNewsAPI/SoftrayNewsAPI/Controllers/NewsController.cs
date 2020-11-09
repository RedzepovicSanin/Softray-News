using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftrayNewsAPI.DL.Models;
using SoftrayNewsAPI.Services;

namespace SoftrayNewsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {

        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("GetAllNews")]
        public async Task<ActionResult<List<News>>> GetAll()
        {
            try
            {
                List<News> newsList = await _newsService.GetAllNews();

                return newsList;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Get")]
        public async Task<ActionResult<News>> Get(int id)
        {
            try
            {
                News news = await _newsService.GetNewsById(id);

                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<News>> Insert([FromBody] News news)
        {
            try
            {
                if (news != null)
                {
                    News newNews = await _newsService.InsertNews(news);
                    return Ok(newNews);
                }
                else
                {
                    return BadRequest("Desila se greska!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<News>> Update([FromBody] News newsForEdit)
        {
            try
            {
                if (newsForEdit != null)
                {
                    News updatedNews = await _newsService.UpdateNews(newsForEdit);
                    return Ok(updatedNews);
                }
                else
                {
                    return BadRequest("Desila se greska!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<News>> Delete(int id)
        {
            try
            {
                News news = await _newsService.DeleteNews(id);
                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
