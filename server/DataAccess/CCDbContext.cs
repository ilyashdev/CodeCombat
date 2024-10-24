using Microsoft.EntityFrameworkCore;
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
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<SolutionsEntity> Solutions { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<DailyEntity> Dailys { get; set; }
    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<QuizEntity> Quizs { get; set; }
    public DbSet<TestEntity> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DataBase"));
    }

}

}


