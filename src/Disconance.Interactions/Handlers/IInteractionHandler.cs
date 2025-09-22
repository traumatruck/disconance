using Microsoft.AspNetCore.Http;

namespace Disconance.Interactions.Handlers;

public interface IInteractionHandler
{
    Task<IResult> HandleInteractionAsync(HttpRequest interactionRequest);
}