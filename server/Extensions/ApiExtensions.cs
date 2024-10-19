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
                policy.WithOrigins("https://1737-109-126-175-155.ngrok-free.app");
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
        services.AddTransient<UserRepository>();
        services.AddTransient<DataService>();
        services.AddTransient<UserService>();

    }
}
