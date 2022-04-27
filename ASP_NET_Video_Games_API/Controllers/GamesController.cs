using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP_NET_Video_Games_API.Models;
using System.Collections.Generic;

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
        [HttpGet("Name/{Name}")]
        public IActionResult GetGames(string Name)
        {
            var nameofgame = _context.VideoGames.Where(g => g.Name.Contains(Name));

            return Ok(nameofgame);
        }
       

    }
}
