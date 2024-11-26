using Microsoft.EntityFrameworkCore;

namespace CodeCombat.DataAccess
{
    public class CCDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public CCDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_configuration.GetConnectionString("DataBase"));
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}

}


