namespace Disconance.Models.Interactions;

// https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-type
public enum InteractionType
{
    // PING
    Ping = 1,

    // APPLICATION_COMMAND
    ApplicationCommand = 2,

    //MESSAGE_COMPONENT
    MessageComponent = 3,

    // APPLICATION_COMMAND_AUTOCOMPLETE
    ApplicationCommandAutocomplete = 4,

    // MODAL_SUBMIT
    ModalSubmit = 5
}