using Microsoft.EntityFrameworkCore;
using CodeCombat.Models;
using CodeCombat.DataAccess.Entity;

namespace CodeCombat.DataAccess
{
    public class CCDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public CCDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<User> Users => Set<User>();
    public DbSet<SolutionsEntity> Solutions => Set<SolutionsEntity>();
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DataBase"));
    }

}

}


