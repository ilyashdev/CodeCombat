using CodeCombat.Application_Layer.Service;
using CodeCombat.Domain_Layer.Factory.ModuleFactory;
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
        
        services.AddTransient<ICourseRepository, CourseRepository>();
        services.AddTransient<IContentRepository, ContentRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IModuleRepository, ModuleRepository>();
        services.AddTransient<ITagsRepository, TagsRepository>();

        services.AddTransient<ModuleFactoryRegister>();

        services.AddTransient<ICourseService, CourseService>();
        services.AddTransient<IContentService, ContentService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IModuleService, ModuleService>();
    }
}