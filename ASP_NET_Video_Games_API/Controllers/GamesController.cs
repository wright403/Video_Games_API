using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    //api/Games
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetPublishers()
        {
            var videoGamePublishers = _context.VideoGames.Select(vg => vg.Publisher).Distinct();

            return Ok(videoGamePublishers);
        }

        [HttpGet("{id}")]
        public IActionResult GetGamesByID(int id)
        {
            
                var videoGames = _context.VideoGames.Where(vg => vg.Id == id);
                return Ok(videoGames);
            
        }

        [HttpGet]
        public IActionResult GetGames()
        {
            var videoGames = _context.VideoGames;
            return Ok(videoGames);
        }

    }
}
