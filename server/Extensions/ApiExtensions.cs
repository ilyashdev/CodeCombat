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
        
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IContentRepository, ContentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<ITagsRepository, TagsRepository>();

        services.AddScoped<ModuleFactoryRegister>();

        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IContentService, ContentService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IModuleService, ModuleService>();
        services.AddScoped<IValidateService, TelegramValidate>();
    }
}