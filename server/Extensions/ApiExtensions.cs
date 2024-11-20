using CodeCombat.DataAccess.Repositories;
using CodeCombat.Services;
public static class ApiExtensions
{
    public static void AddApiCors(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddCors(
            options =>{
                options.AddDefaultPolicy(policy=>{
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
        services.AddTransient<CourseService>();
        services.AddTransient<DailyService>();
        services.AddTransient<UserService>();
        services.AddTransient<DataService>();

        services.AddTransient<CourseRepository>();
        services.AddTransient<DailyRepository>();
        services.AddTransient<SolutionsRepository>();
        services.AddTransient<UserRepository>();


    }
}
