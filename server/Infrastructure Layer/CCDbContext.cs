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

    public DbSet<UserEntity> Users { get; set; } = null!; 
    public DbSet<SolutionsEntity> Solutions { get; set; } = null!; 
    public DbSet<CommentEntity> Comments { get; set; } = null!; 
    public DbSet<DailyEntity> Dailys { get; set; } = null!; 
    public DbSet<BaseContentEntity> AllContent { get; set; } = null!; 
    public DbSet<BaseModuleEntity> AllModules {get; set;}= null!; 
    public DbSet<CodeEntity> CodeModules {get; set;}= null!; 
    public DbSet<TextEntity> TextModules {get; set;}= null!; 
    public DbSet<FlashCardEntity> FlashCardModules {get; set;}= null!; 
    public DbSet<CourseEntity> Courses {get; set;}= null!; 
    public DbSet<TestEntity> Tests { get; set; }= null!; 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DataBase"));
    }

}

}


