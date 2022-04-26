using ASP_NET_Video_Games_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Video_Games_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
