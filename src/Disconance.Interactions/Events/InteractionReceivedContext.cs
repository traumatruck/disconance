using Disconance.Models.Interactions;

namespace Disconance.Interactions.Events;

/// <summary>
///     Context passed to subscribers when an interaction is received.
/// </summary>
public sealed class InteractionReceivedContext
{
    /// <summary>
    ///     The deserialized interaction payload.
    /// </summary>
    public required Interaction Interaction { get; init; }
}