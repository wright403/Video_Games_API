using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Video_Games_API.Models
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public int? Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NorthAmericaSales { get; set; }
        public double EuropeSales { get; set; }
        public double JapanSales { get; set; }
        public double OtherSales { get; set; }
        public double GlobalSales { get; set; }
    }
}
