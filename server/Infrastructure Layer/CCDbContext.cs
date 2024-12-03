using CodeCombat.Domain_Layer.Models;
using CodeCombat.Domain_Layer.Models.Course;
using CodeCombat.Domain_Layer.Models.Course.Modules;
using Microsoft.EntityFrameworkCore;

namespace CodeCombat.Infrastructure_Layer;

public class CcDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public CcDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Content> Contents { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Module> Modules { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_configuration.GetConnectionString("DataBase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);
        modelBuilder.Entity<User>()
            .HasMany(u => u.MyContent)
            .WithOne(c => c.Creator);
        modelBuilder.Entity<User>()
            .HasMany(u => u.FavoriteContent)
            .WithMany(c => c.InFavoriteUser);
        modelBuilder.Entity<User>()
            .HasMany(u => u.MyUps)
            .WithMany(c => c.UpUsers);
        modelBuilder.Entity<User>()
            .HasMany(u => u.MyDowns)
            .WithMany(c => c.DownUsers);
        modelBuilder.Entity<User>()
            .HasMany(u => u.MyComments)
            .WithOne(c => c.Creator);

        modelBuilder.Entity<Content>()
            .HasMany(c => c.Comments)
            .WithOne(c => c.Content);
        modelBuilder.Entity<Content>()
            .UseTphMappingStrategy()
            .HasDiscriminator(c => c.ContentType);


        modelBuilder.Entity<Course>()
            .HasMany(c => c.Modules)
            .WithOne(m => m.InCourse);

        modelBuilder.Entity<Module>()
            .UseTphMappingStrategy()
            .HasDiscriminator(m => m.ModuleType)
            .HasValue<TextModule>("Text");
    }
}