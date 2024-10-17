using Microsoft.EntityFrameworkCore;
using CodeCombat.Models;

namespace CodeCombat.DataAccess
{
    public class UserDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public UserDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DataBase"));
    }
}
}