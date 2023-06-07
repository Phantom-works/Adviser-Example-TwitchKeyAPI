using Microsoft.EntityFrameworkCore;
using TwitchKeyAPI.Models;

namespace TwitchKeyAPI.Data
{
    public class TwitchKeyAPIDbContext : DbContext
    {
        public TwitchKeyAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TwitchKey> TwitchKey { get; set; }
    }
}
