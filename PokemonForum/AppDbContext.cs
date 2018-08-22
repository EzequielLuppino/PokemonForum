using Microsoft.EntityFrameworkCore;

namespace PokemonForum
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Publication> Publications { get; set; }
    }
}