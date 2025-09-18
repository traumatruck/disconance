namespace Disconance.Models.Interactions;

// https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-response-object-interaction-callback-type
public enum InteractionCallbackType
{
    /// <summary>
    ///     ACK a Ping
    /// </summary>
    // PONG
    Pong = 1,

    /// <summary>
    ///     Respond to an interaction with a message
    /// </summary>
    // CHANNEL_MESSAGE_WITH_SOURCE
    ChannelMessageWithSource = 4,

    /// <summary>
    ///     ACK an interaction and edit a response later, the user sees a loading state
    /// </summary>
    // DEFERRED_CHANNEL_MESSAGE_WITH_SOURCE
    DeferredChannelMessageWithSource = 5,

    /// <summary>
    ///     ACK an interaction and edit the original message later; the user does not see a loading state.
    ///     Only valid for component-based interactions
    /// </summary>
    // DEFERRED_UPDATE_MESSAGE
    DeferredUpdateMessage = 6,

    /// <summary>
    ///     For components, edit the message the component was attached to.
    ///     Only valid for component-based interactions
    /// </summary>
    // UPDATE_MESSAGE
    UpdateMessage = 7,

    /// <summary>
    ///     Respond to an autocomplete interaction with suggested choices
    /// </summary>
    // APPLICATION_COMMAND_AUTOCOMPLETE_RESULT
    ApplicationCommandAutocompleteResult = 8,

    /// <summary>
    ///     Respond to an interaction with a popup modal
    ///     Not available for MODAL_SUBMIT and PING interactions.
    /// </summary>
    // MODAL
    Modal = 9,

    /// <summary>
    ///     Deprecated
    ///     Respond to an interaction with an upgrade button, only available for apps with monetization enabled
    /// </summary>
    // PREMIUM_REQUIRED
    PremiumRequired = 10,

    /// <summary>
    ///     Launch the Activity associated with the app. Only available for apps with Activities enabled
    /// </summary>
    // LAUNCH_ACTIVITY
    LaunchActivity = 12
}