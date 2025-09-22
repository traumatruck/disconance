using Disconance.Interactions.Commands;
using Disconance.Interactions.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Disconance.Interactions.Extensions;

public static class WebApplicationExtensions
{
    public static async Task UseInteractionsAsync(this WebApplication webApplication)
    {
        webApplication.MapPost("api/interactions", async (HttpContext context, IInteractionHandler interactionHandler) =>
        {
            var result = await interactionHandler.HandleInteractionAsync(context.Request);

            return result;
        });

        // Register commands on startup
        await RegisterCommandsAsync(webApplication);
    }

    private static async Task RegisterCommandsAsync(WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        var commandRegistrationService = scope.ServiceProvider.GetRequiredService<ICommandRegistrationService>();
        var applicationLifetime = scope.ServiceProvider.GetRequiredService<IHostApplicationLifetime>();

        await commandRegistrationService.RegisterAllCommandsAsync(applicationLifetime.ApplicationStopping);
    }
}