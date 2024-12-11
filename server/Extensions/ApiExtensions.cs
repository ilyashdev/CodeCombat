using CodeCombat.Application_Layer.Service;
using CodeCombat.Infrastructure_Layer.Repository;

namespace CodeCombat.Extensions;

public static class ApiExtensions
{
    public static void AddApiCors(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://eduardkrustein.uk");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });
    }

    public static void AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddTransient<ICourseService, CourseService>();
        services.AddTransient<ICourseRepository, CourseRepository>();
        services.AddTransient<IContentService, ContentService>();
        services.AddTransient<IContentRepository, ContentRepository>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ITagsRepository, TagsRepository>();
    }
}