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
        
    }
}
