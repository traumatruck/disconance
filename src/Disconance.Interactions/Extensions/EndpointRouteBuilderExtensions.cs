using Disconance.Interactions.Processors;
using Disconance.Interactions.Processors.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Disconance.Interactions.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static RouteHandlerBuilder MapInteractionsEndpoint(this IEndpointRouteBuilder webApplication)
    {
        return webApplication.MapPost("api/interactions",
            async (HttpContext context, IInteractionRequestProcessor interactionRequestProcessor) =>
            {
                var interactionRequestProcessorResult =
                    await interactionRequestProcessor.ProcessInteractionRequestAsync(context.Request);

                return interactionRequestProcessorResult switch
                {
                    SuccessfulInteractionRequestProcessorResult successfulResult =>
                        Results.Content(successfulResult.SerializedInteractionResponse, "application/json"),
                    FailedInteractionRequestProcessorResult failedResult =>
                        Results.Problem(failedResult.ErrorMessage),
                    UnauthorizedInteractionRequestProcessorResult =>
                        Results.Unauthorized(),
                    _ =>
                        Results.BadRequest()
                };
            });
    }
}