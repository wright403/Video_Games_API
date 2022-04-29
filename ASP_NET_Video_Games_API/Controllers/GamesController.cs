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

        //[HttpGet("Publisher/{Publisher}")]

        //public IActionResult GetPublishers()
        //{
        //    var videoGamePublishers = _context.VideoGames.Select(vg => vg.Publisher).Distinct();

        //    return Ok(videoGamePublishers);
        //}

        [HttpGet("{id}")]
        public IActionResult GetGamesByID(int id)
        {

            var videoGames = _context.VideoGames.Where(vg => vg.Id == id);
            return Ok(videoGames);

        }
        [HttpGet("Name/{Name}")]
        public IActionResult GetGames(string Name)
        {
            var nameofgame = _context.VideoGames.Where(g => g.Name.Contains(Name));

            return Ok(nameofgame);
        }
        [HttpGet("Platform/")]
        
        public IActionResult GetSalesByPlatform()
        {
            
            var consoles = _context.VideoGames.Select(c => c.Platform).Distinct();
            
            Dictionary<string, double> returnValue = new();
            foreach (string Platform in consoles.ToList())
            {
                var salesbyPlatform = _context.VideoGames.Where(i => i.Platform == Platform).Where(vg => vg.Year > 2013).Where(vg => vg.GlobalSales > 0).Select(i => i.GlobalSales).Sum();
                if (salesbyPlatform > 0)
                {
                    returnValue.Add(Platform, salesbyPlatform);
                }
            }
            return Ok(returnValue);
        }
        [HttpGet]
        public IActionResult GetAllGames()
        {
            var videoGames = _context.VideoGames;

            return Ok(videoGames);
        }
        [HttpGet("ActionGamesByYear")]
        public IActionResult GetActionGamesByYear()
        {
            var years = _context.VideoGames.Where(c => c.Year > 1995).Select(c => c.Year).Distinct();

            Dictionary<int, double> returnValue = new();
            foreach (int year in years.ToList())
            {

                var AllSales = _context.VideoGames.Where(s => s.Genre == "Action").Where(s => s.Year == year).Select(s => s.GlobalSales).Sum();
                returnValue.Add(year, AllSales);
            }
            return Ok(returnValue);
        }
    }
}
