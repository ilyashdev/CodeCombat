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

        services.AddScoped<DailyService>();
        services.AddScoped<UserService>();

        services.AddScoped<DailyRepository>();
        services.AddScoped<PostRepository>();
        services.AddScoped<QuizRepository>();
        services.AddScoped<SolutionsRepository>();
        services.AddScoped<UserRepository>();


    }
}
