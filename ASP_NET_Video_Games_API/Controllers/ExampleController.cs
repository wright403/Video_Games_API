using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    // api/examples
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamplesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            var videoGamePublishers = _context.VideoGames.Select(vg => vg.Publisher).Distinct();

            return Ok(videoGamePublishers);
        }

        [HttpGet("{pubName}")]
        public IActionResult GetGamesByPublisher(string pubName)
        {
            var videoGames = _context.VideoGames.Where(vg => vg.Publisher == pubName);
            return Ok(videoGames);
        }

    }
}
