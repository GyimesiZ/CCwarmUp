using CCapi.Models.CodingChallenge;
using Microsoft.EntityFrameworkCore;

namespace DevopsApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CC_Bet> Bets { get; set; }
        public DbSet<CC_User> Players { get; set; }
        public DbSet<CC_Match> Matches { get; set; }
        public DbSet<CC_Team> Teams { get; set; }
        public DbSet<CC_Message> Messages { get; set; }
    }
}
