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
    public DbSet<UserEntity> Users {get;set;} = null!;    
    public DbSet<ContentEntity> Contents {get;set;} = null!;
    public DbSet<CommentEntity> Comments {get;set;} = null!;
    public DbSet<CourseEntity> Courses {get;set;} = null!;
    public DbSet<ModuleEntity> Modules {get;set;} = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_configuration.GetConnectionString("DataBase"));
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.MyContent)
            .WithOne(c => c.Creator);
        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.FavoriteContent)
            .WithMany(c => c.InFavoriteUser);
        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.MyUps)
            .WithMany(c => c.UpUsers);
        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.MyDowns)
            .WithMany(c => c.DownUsers);
        modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.MyComments)
            .WithOne(c => c.Creator);

        modelBuilder.Entity<ContentEntity>()
            .HasMany(c => c.Comments)
            .WithOne(c => c.Content);

        modelBuilder.Entity<CourseEntity>()
            .HasMany(c => c.Modules)
            .WithOne(m => m.Course);

        modelBuilder.Entity<ModuleEntity>()
            .UseTphMappingStrategy(); 
    }

}

}


