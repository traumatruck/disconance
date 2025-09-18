namespace Disconance.Models.Components;

/// <summary>
///     Type of component.
///     https://discord.com/developers/docs/interactions/message-components#component-object-component-types
/// </summary>
public enum ComponentType
{
    /// <summary>
    ///     Action Row - Container to display a row of interactive components.
    /// </summary>
    ActionRow = 1,

    /// <summary>
    ///     Button - Button object.
    /// </summary>
    Button = 2,

    /// <summary>
    ///     String Select - Select menu for picking from defined text options.
    /// </summary>
    StringSelect = 3,

    /// <summary>
    ///     Text Input - Text input object.
    /// </summary>
    TextInput = 4,

    /// <summary>
    ///     User Select - Select menu for users.
    /// </summary>
    UserSelect = 5,

    /// <summary>
    ///     Role Select - Select menu for roles.
    /// </summary>
    RoleSelect = 6,

    /// <summary>
    ///     Mentionable Select - Select menu for mentionables (users and roles).
    /// </summary>
    MentionableSelect = 7,

    /// <summary>
    ///     Channel Select - Select menu for channels.
    /// </summary>
    ChannelSelect = 8,

    /// <summary>
    ///     Section - Container to display text alongside an accessory component.
    /// </summary>
    Section = 9,

    /// <summary>
    ///     Text Display - Markdown text.
    /// </summary>
    TextDisplay = 10,

    /// <summary>
    ///     Thumbnail - Small image that can be used as an accessory.
    /// </summary>
    Thumbnail = 11,

    /// <summary>
    ///     Media Gallery - Display images and other media.
    /// </summary>
    MediaGallery = 12,

    /// <summary>
    ///     File - Displays an attached file.
    /// </summary>
    File = 13,

    /// <summary>
    ///     Separator - Component to add vertical padding between other components.
    /// </summary>
    Separator = 14,

    /// <summary>
    ///     Container - Container that visually groups a set of components.
    /// </summary>
    Container = 17,

    /// <summary>
    ///     Label - Container associating a label and description with a component.
    /// </summary>
    Label = 18
}
