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
    public DbSet<SolutionEntity> Solutions { get; set; } = null!; 
    public DbSet<CommentEntity> Comments { get; set; } = null!; 
    public DbSet<DailyEntity> Dailys { get; set; } = null!; 
    public DbSet<ModuleEntity> AllModules {get; set;}= null!; 
    public DbSet<CourseEntity> Courses {get; set;}= null!; 
    public DbSet<TestEntity> Tests { get; set; }= null!; 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseNpgsql(_configuration.GetConnectionString("DataBase"));
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
                .HasMany(c => c.Courses)
                .WithOne(p => p.User);
        modelBuilder.Entity<CourseEntity>()
                .HasMany(c => c.Modules)
                .WithOne(m => m.Course);

    }

}

}


