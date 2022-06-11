using Microsoft.EntityFrameworkCore;

namespace TaskOne
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PersonData> Persons { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Data/PeoplesDb.db");
        }
    }
}
