using CodeCombat.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.UseDateOnlyTimeOnlyStringConverters();
}
);


services.AddControllers();
services.AddScoped<CCDbContext>();

ApiExtensions.AddApiCors(services, configuration);
ApiExtensions.AddApiServices(services, configuration);

var app = builder.Build();


using var scope = app.Services.CreateScope();

await using var dbContext = scope.ServiceProvider.GetRequiredService<CCDbContext>();
await dbContext.Database.EnsureCreatedAsync();

app.UseCors();
app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();