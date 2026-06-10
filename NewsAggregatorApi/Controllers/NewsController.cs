using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAggregatorApi.Data;
using NewsAggregatorApi.Models;

namespace NewsAggregatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/news
        [HttpGet]
        public IActionResult GetAllNews()
        {
            var newsItems = _context.NewsItems.ToList();
            return Ok(newsItems);
        }

        // C#
        [HttpPost]
        public IActionResult SubmitNews([FromBody] NewsItem newsItem)
        {
            if (newsItem == null) return BadRequest();

            // If client provides UserId (FK)
            if (newsItem.UserId != 0)
            {
                var user = _context.Users.Find(newsItem.UserId);
                if (user == null) return BadRequest($"User {newsItem.UserId} not found.");
                newsItem.User = user; // attach existing user
            }

            _context.NewsItems.Add(newsItem);
            _context.SaveChanges();
            return Ok(newsItem);
        }
            