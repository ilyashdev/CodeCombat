using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;

public class TelegramAuthFilter : IAsyncAuthorizationFilter
{
    private readonly RequestDelegate _next;
    private const string TelegramApiUrl = "https://api.telegram.org/bot{0}/getMe";

    public TelegramAuthFilter(RequestDelegate next)
    {
        _next = next;
    }

    public async Task OnAuthorizationAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("X-Telegram-Token", out var token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Telegram token missing");
            return;
        }

        if (!await ValidateTelegramToken(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid Telegram token");
            return;
        }

        await _next(context);
    }

    private async Task<bool> ValidateTelegramToken(string? token)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(string.Format(TelegramApiUrl, token));
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var jsonData = JsonDocument.Parse(json);
            return jsonData.RootElement.GetProperty("ok").GetBoolean();
        }
        return false;
    }
}
