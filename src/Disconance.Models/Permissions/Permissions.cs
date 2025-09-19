namespace Disconance.Models.Permissions;

/// <summary>
///     Enum for Discord permission flags, using bitwise values. Permissions are stored as strings in models (e.g.,
///     Role.Permissions), so use utility methods to convert and check.
/// </summary>
[Flags]
public enum Permission : ulong
{
    /// <summary>
    ///     Allows creation of instant invites (T, V, S)
    /// </summary>
    CreateInstantInvite = 1UL << 0,

    /// <summary>
    ///     Allows kicking members (*)
    /// </summary>
    KickMembers = 1UL << 1,

    /// <summary>
    ///     Allows banning members (*)
    /// </summary>
    BanMembers = 1UL << 2,

    /// <summary>
    ///     Allows all permissions and bypasses overwrites (*)
    /// </summary>
    Administrator = 1UL << 3,

    /// <summary>
    ///     Allows management and editing of channels (T, V, S) (*)
    /// </summary>
    ManageChannels = 1UL << 4,

    /// <summary>
    ///     Allows management and editing of the guild (*)
    /// </summary>
    ManageGuild = 1UL << 5,

    /// <summary>
    ///     Allows adding reactions to messages (T, V, S)
    /// </summary>
    AddReactions = 1UL << 6,

    /// <summary>
    ///     Allows viewing audit logs
    /// </summary>
    ViewAuditLog = 1UL << 7,

    /// <summary>
    ///     Allows priority speaker in voice (V)
    /// </summary>
    PrioritySpeaker = 1UL << 8,

    /// <summary>
    ///     Allows going live (V, S)
    /// </summary>
    Stream = 1UL << 9,

    /// <summary>
    ///     Allows viewing channels (T, V, S)
    /// </summary>
    ViewChannel = 1UL << 10,

    /// <summary>
    ///     Allows sending messages (T, V, S)
    /// </summary>
    SendMessages = 1UL << 11,

    /// <summary>
    ///     Allows TTS messages (T, V, S)
    /// </summary>
    SendTtsMessages = 1UL << 12,

    /// <summary>
    ///     Allows deleting others' messages (T, V, S) (*)
    /// </summary>
    ManageMessages = 1UL << 13,

    /// <summary>
    ///     Allows auto-embedding links (T, V, S)
    /// </summary>
    EmbedLinks = 1UL << 14,

    /// <summary>
    ///     Allows uploading images and files (T, V, S)
    /// </summary>
    AttachFiles = 1UL << 15,

    /// <summary>
    ///     Allows reading message history (T, V, S)
    /// </summary>
    ReadMessageHistory = 1UL << 16,

    /// <summary>
    ///     Allows @everyone/@here (T, V, S)
    /// </summary>
    MentionEveryone = 1UL << 17,

    /// <summary>
    ///     Allows external emojis (T, V, S)
    /// </summary>
    UseExternalEmojis = 1UL << 18,

    /// <summary>
    ///     Allows viewing guild insights
    /// </summary>
    ViewGuildInsights = 1UL << 19,

    /// <summary>
    ///     Allows joining voice (V, S)
    /// </summary>
    Connect = 1UL << 20,

    /// <summary>
    ///     Allows speaking in voice (V)
    /// </summary>
    Speak = 1UL << 21,

    /// <summary>
    ///     Allows muting in voice (V, S)
    /// </summary>
    MuteMembers = 1UL << 22,

    /// <summary>
    ///     Allows deafening in voice (V)
    /// </summary>
    DeafenMembers = 1UL << 23,

    /// <summary>
    ///     Allows moving members in voice (V, S)
    /// </summary>
    MoveMembers = 1UL << 24,

    /// <summary>
    ///     Allows voice activity detection (V)
    /// </summary>
    UseVad = 1UL << 25,

    /// <summary>
    ///     Allows changing own nickname
    /// </summary>
    ChangeNickname = 1UL << 26,

    /// <summary>
    ///     Allows changing others' nicknames
    /// </summary>
    ManageNicknames = 1UL << 27,

    /// <summary>
    ///     Allows managing roles (T, V, S) (*)
    /// </summary>
    ManageRoles = 1UL << 28,

    /// <summary>
    ///     Allows managing webhooks (T, V, S) (*)
    /// </summary>
    ManageWebhooks = 1UL << 29,

    /// <summary>
    ///     Allows managing expressions (*)
    /// </summary>
    ManageGuildExpressions = 1UL << 30,

    /// <summary>
    ///     Allows using app commands (T, V, S)
    /// </summary>
    UseApplicationCommands = 1UL << 31,

    /// <summary>
    ///     Allows requesting to speak in stage (S)
    /// </summary>
    RequestToSpeak = 1UL << 32,

    /// <summary>
    ///     Allows managing events (V, S)
    /// </summary>
    ManageEvents = 1UL << 33,

    /// <summary>
    ///     Allows managing threads (T) (*)
    /// </summary>
    ManageThreads = 1UL << 34,

    /// <summary>
    ///     Allows creating public threads (T)
    /// </summary>
    CreatePublicThreads = 1UL << 35,

    /// <summary>
    ///     Allows creating private threads (T)
    /// </summary>
    CreatePrivateThreads = 1UL << 36,

    /// <summary>
    ///     Allows external stickers (T, V, S)
    /// </summary>
    UseExternalStickers = 1UL << 37,

    /// <summary>
    ///     Allows sending in threads (T)
    /// </summary>
    SendMessagesInThreads = 1UL << 38,

    /// <summary>
    ///     Allows embedded activities (T, V)
    /// </summary>
    UseEmbeddedActivities = 1UL << 39,

    /// <summary>
    ///     Allows timing out members (**)
    /// </summary>
    ModerateMembers = 1UL << 40,

    /// <summary>
    ///     Allows viewing monetization analytics (*)
    /// </summary>
    ViewCreatorMonetizationAnalytics = 1UL << 41,

    /// <summary>
    ///     Allows using soundboard (V)
    /// </summary>
    UseSoundboard = 1UL << 42,

    /// <summary>
    ///     Allows creating expressions
    /// </summary>
    CreateGuildExpressions = 1UL << 43,

    /// <summary>
    ///     Allows creating events (V, S)
    /// </summary>
    CreateEvents = 1UL << 44,

    /// <summary>
    ///     Allows external sounds (V)
    /// </summary>
    UseExternalSounds = 1UL << 45,

    /// <summary>
    ///     Allows voice messages (T, V, S)
    /// </summary>
    SendVoiceMessages = 1UL << 46,

    /// <summary>
    ///     Allows sending polls (T, V, S)
    /// </summary>
    SendPolls = 1UL << 49,

    /// <summary>
    ///     Allows external apps (T, V, S)
    /// </summary>
    UseExternalApps = 1UL << 50,

    /// <summary>
    ///     Allows pinning messages (T)
    /// </summary>
    PinMessages = 1UL << 51
}