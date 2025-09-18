namespace Disconance.Http.Models;

/// <summary>
///     https://discord.com/developers/docs/topics/opcodes-and-status-codes#json
/// </summary>
public enum JsonErrorCode
{
    // 0: General error (such as a malformed request body, amongst other things)
    GeneralError = 0,

    // 10001: Unknown account
    UnknownAccount = 10001,

    // 10002: Unknown application
    UnknownApplication = 10002,

    // 10003: Unknown channel
    UnknownChannel = 10003,

    // 10004: Unknown guild
    UnknownGuild = 10004,

    // 10005: Unknown integration
    UnknownIntegration = 10005,

    // 10006: Unknown invite
    UnknownInvite = 10006,

    // 10007: Unknown member
    UnknownMember = 10007,

    // 10008: Unknown message
    UnknownMessage = 10008,

    // 10009: Unknown permission overwrite
    UnknownPermissionOverwrite = 10009,

    // 10010: Unknown provider
    UnknownProvider = 10010,

    // 10011: Unknown role
    UnknownRole = 10011,

    // 10012: Unknown token
    UnknownToken = 10012,

    // 10013: Unknown user
    UnknownUser = 10013,

    // 10014: Unknown emoji
    UnknownEmoji = 10014,

    // 10015: Unknown webhook
    UnknownWebhook = 10015,

    // 10016: Unknown webhook service
    UnknownWebhookService = 10016,

    // 10020: Unknown session
    UnknownSession = 10020,

    // 10021: Unknown asset
    UnknownAsset = 10021,

    // 10026: Unknown ban
    UnknownBan = 10026,

    // 10027: Unknown SKU
    UnknownSku = 10027,

    // 10028: Unknown store listing
    UnknownStoreListing = 10028,

    // 10029: Unknown entitlement
    UnknownEntitlement = 10029,

    // 10030: Unknown build
    UnknownBuild = 10030,

    // 10031: Unknown lobby
    UnknownLobby = 10031,

    // 10032: Unknown branch
    UnknownBranch = 10032,

    // 10033: Unknown store directory layout
    UnknownStoreDirectoryLayout = 10033,

    // 10036: Unknown redistributable
    UnknownRedistributable = 10036,

    // 10038: Unknown gift code
    UnknownGiftCode = 10038,

    // 10049: Unknown stream
    UnknownStream = 10049,

    // 10050: Unknown premium server subscribe cooldown
    UnknownPremiumServerSubscribeCooldown = 10050,

    // 10057: Unknown guild template
    UnknownGuildTemplate = 10057,

    // 10059: Unknown discoverable server category
    UnknownDiscoverableServerCategory = 10059,

    // 10060: Unknown sticker
    UnknownSticker = 10060,

    // 10061: Unknown sticker pack
    UnknownStickerPack = 10061,

    // 10062: Unknown interaction
    UnknownInteraction = 10062,

    // 10063: Unknown application command
    UnknownApplicationCommand = 10063,

    // 10065: Unknown voice state
    UnknownVoiceState = 10065,

    // 10066: Unknown application command permissions
    UnknownApplicationCommandPermissions = 10066,

    // 10067: Unknown stage instance
    UnknownStageInstance = 10067,

    // 10068: Unknown guild member verification form
    UnknownGuildMemberVerificationForm = 10068,

    // 10069: Unknown guild welcome screen
    UnknownGuildWelcomeScreen = 10069,

    // 10070: Unknown guild scheduled event
    UnknownGuildScheduledEvent = 10070,

    // 10071: Unknown guild scheduled event user
    UnknownGuildScheduledEventUser = 10071,

    // 10087: Unknown tag
    UnknownTag = 10087,

    // 10097: Unknown sound
    UnknownSound = 10097,

    // 20001: Bots cannot use this endpoint
    BotsCannotUseThisEndpoint = 20001,

    // 20002: Only bots can use this endpoint
    OnlyBotsCanUseThisEndpoint = 20002,

    // 20009: Explicit content cannot be sent to the desired recipient(s)
    ExplicitContentCannotBeSent = 20009,

    // 20012: You are not authorized to perform this action on this application
    NotAuthorizedForApplication = 20012,

    // 20016: This action cannot be performed due to slowmode rate limit
    SlowmodeRateLimit = 20016,

    // 20018: Only the owner of this account can perform this action
    OnlyOwnerCanPerformAction = 20018,

    // 20022: This message cannot be edited due to announcement rate limits
    AnnouncementRateLimit = 20022,

    // 20024: Under minimum age
    UnderMinimumAge = 20024,

    // 20028: The channel you are writing has hit the write rate limit
    ChannelWriteRateLimit = 20028,

    // 20029: The write action you are performing on the server has hit the write rate limit
    ServerWriteRateLimit = 20029,

    // 20031: Your Stage topic, server name, server description, or channel names contain words that are not allowed
    ContainsDisallowedWords = 20031,

    // 20035: Guild premium subscription level too low
    GuildPremiumLevelTooLow = 20035,

    // 30001: Maximum number of guilds reached (100)
    MaxGuildsReached = 30001,

    // 30002: Maximum number of friends reached (1000)
    MaxFriendsReached = 30002,

    // 30003: Maximum number of pins reached for the channel (50)
    MaxPinsReached = 30003,

    // 30004: Maximum number of recipients reached (10)
    MaxRecipientsReached = 30004,

    // 30005: Maximum number of guild roles reached (250)
    MaxGuildRolesReached = 30005,

    // 30007: Maximum number of webhooks reached (15)
    MaxWebhooksReached = 30007,

    // 30008: Maximum number of emojis reached
    MaxEmojisReached = 30008,

    // 30010: Maximum number of reactions reached (20)
    MaxReactionsReached = 30010,

    // 30011: Maximum number of group DMs reached (10)
    MaxGroupDMsReached = 30011,

    // 30013: Maximum number of guild channels reached (500)
    MaxGuildChannelsReached = 30013,

    // 30015: Maximum number of attachments in a message reached (10)
    MaxAttachmentsReached = 30015,

    // 30016: Maximum number of invites reached (1000)
    MaxInvitesReached = 30016,

    // 30018: Maximum number of animated emojis reached
    MaxAnimatedEmojisReached = 30018,

    // 30019: Maximum number of server members reached
    MaxServerMembersReached = 30019,

    // 30030: Maximum number of server categories has been reached (5)
    MaxServerCategoriesReached = 30030,

    // 30031: Guild already has a template
    GuildAlreadyHasTemplate = 30031,

    // 30032: Maximum number of application commands reached
    MaxApplicationCommandsReached = 30032,

    // 30033: Maximum number of thread participants has been reached (1000)
    MaxThreadParticipantsReached = 30033,

    // 30034: Maximum number of daily application command creates has been reached (200)
    MaxDailyApplicationCommandCreatesReached = 30034,

    // 30035: Maximum number of bans for non-guild members have been exceeded
    MaxBansForNonGuildMembersExceeded = 30035,

    // 30037: Maximum number of bans fetches has been reached
    MaxBansFetchesReached = 30037,

    // 30038: Maximum number of uncompleted guild scheduled events reached (100)
    MaxUncompletedGuildScheduledEventsReached = 30038,

    // 30039: Maximum number of stickers reached
    MaxStickersReached = 30039,

    // 30040: Maximum number of prune requests has been reached. Try again later
    MaxPruneRequestsReached = 30040,

    // 30042: Maximum number of guild widget settings updates has been reached. Try again later
    MaxGuildWidgetSettingsUpdatesReached = 30042,

    // 30045: Maximum number of soundboard sounds reached
    MaxSoundboardSoundsReached = 30045,

    // 30046: Maximum number of edits to messages older than 1 hour reached. Try again later
    MaxEditsToOldMessagesReached = 30046,

    // 30047: Maximum number of pinned threads in a forum channel has been reached
    MaxPinnedThreadsInForumReached = 30047,

    // 30048: Maximum number of tags in a forum channel has been reached
    MaxTagsInForumReached = 30048,

    // 30052: Bitrate is too high for channel of this type
    BitrateTooHigh = 30052,

    // 30056: Maximum number of premium emojis reached (25)
    MaxPremiumEmojisReached = 30056,

    // 30058: Maximum number of webhooks per guild reached (1000)
    MaxWebhooksPerGuildReached = 30058,

    // 30060: Maximum number of channel permission overwrites reached (1000)
    MaxChannelPermissionOverwritesReached = 30060,

    // 30061: The channels for this guild are too large
    GuildChannelsTooLarge = 30061,

    // 40001: Unauthorized. Provide a valid token and try again
    Unauthorized = 40001,

    // 40002: You need to verify your account in order to perform this action
    AccountVerificationRequired = 40002,

    // 40003: You are opening direct messages too fast
    OpeningDMsTooFast = 40003,

    // 40004: Send messages has been temporarily disabled
    SendMessagesTemporarilyDisabled = 40004,

    // 40005: Request entity too large. Try sending something smaller in size
    RequestEntityTooLarge = 40005,

    // 40006: This feature has been temporarily disabled server-side
    FeatureTemporarilyDisabled = 40006,

    // 40007: The user is banned from this guild
    UserBannedFromGuild = 40007,

    // 40012: Connection has been revoked
    ConnectionRevoked = 40012,

    // 40018: Only consumable SKUs can be consumed
    OnlyConsumableSkusCanBeConsumed = 40018,

    // 40019: You can only delete sandbox entitlements.
    OnlyDeleteSandboxEntitlements = 40019,

    // 40032: Target user is not connected to voice
    TargetUserNotConnectedToVoice = 40032,

    // 40033: This message has already been crossposted
    MessageAlreadyCrossposted = 40033,

    // 40041: An application command with that name already exists
    ApplicationCommandNameExists = 40041,

    // 40043: Application interaction failed to send
    ApplicationInteractionFailedToSend = 40043,

    // 40058: Cannot send a message in a forum channel
    CannotSendMessageInForumChannel = 40058,

    // 40060: Interaction has already been acknowledged
    InteractionAlreadyAcknowledged = 40060,

    // 40061: Tag names must be unique
    TagNamesMustBeUnique = 40061,

    // 40062: Service resource is being rate limited
    ServiceResourceRateLimited = 40062,

    // 40066: There are no tags available that can be set by non-moderators
    NoTagsAvailableForNonModerators = 40066,

    // 40067: A tag is required to create a forum post in this channel
    TagRequiredForForumPost = 40067,

    // 40074: An entitlement has already been granted for this resource
    EntitlementAlreadyGranted = 40074,

    // 40094: This interaction has hit the maximum number of follow up messages
    MaxFollowUpMessagesReached = 40094,

    // 40333: Cloudflare is blocking your request. This can often be resolved by setting a proper User Agent
    CloudflareBlockingRequest = 40333,

    // 50001: Missing access
    MissingAccess = 50001,

    // 50002: Invalid account type
    InvalidAccountType = 50002,

    // 50003: Cannot execute action on a DM channel
    CannotExecuteOnDmChannel = 50003,

    // 50004: Guild widget disabled
    GuildWidgetDisabled = 50004,

    // 50005: Cannot edit a message authored by another user
    CannotEditOthersMessage = 50005,

    // 50006: Cannot send an empty message
    CannotSendEmptyMessage = 50006,

    // 50007: Cannot send messages to this user
    CannotSendMessagesToUser = 50007,

    // 50008: Cannot send messages in a non-text channel
    CannotSendMessagesInNonTextChannel = 50008,

    // 50009: Channel verification level is too high for you to gain access
    ChannelVerificationLevelTooHigh = 50009,

    // 50010: OAuth2 application does not have a bot
    OAuth2ApplicationHasNoBot = 50010,

    // 50011: OAuth2 application limit reached
    OAuth2ApplicationLimitReached = 50011,

    // 50012: Invalid OAuth2 state
    InvalidOAuth2State = 50012,

    // 50013: You lack permissions to perform that action
    MissingPermissions = 50013,

    // 50014: Invalid authentication token provided
    InvalidAuthToken = 50014,

    // 50015: Note was too long
    NoteTooLong = 50015,

    // 50016: Provided too few or too many messages to delete. Must provide at least 2 and fewer than 100 messages to delete
    InvalidBulkDeleteCount = 50016,

    // 50017: Invalid MFA Level
    InvalidMfaLevel = 50017,

    // 50019: A message can only be pinned to the channel it was sent in
    MessagePinChannelMismatch = 50019,

    // 50020: Invite code was either invalid or taken
    InvalidOrTakenInviteCode = 50020,

    // 50021: Cannot execute action on a system message
    CannotExecuteOnSystemMessage = 50021,

    // 50024: Cannot execute action on this channel type
    CannotExecuteOnChannelType = 50024,

    // 50025: Invalid OAuth2 access token provided
    InvalidOAuth2AccessToken = 50025,

    // 50026: Missing required OAuth2 scope
    MissingOAuth2Scope = 50026,

    // 50027: Invalid webhook token provided
    InvalidWebhookToken = 50027,

    // 50028: Invalid role
    InvalidRole = 50028,

    // 50033: Invalid Recipient(s)
    InvalidRecipients = 50033,

    // 50034: A message provided was too old to bulk delete
    MessageTooOldToBulkDelete = 50034,

    // 50035: Invalid form body (returned for both application/json and multipart/form-data bodies), or invalid Content-Type provided
    InvalidFormBodyOrContentType = 50035,

    // 50036: An invite was accepted to a guild the application's bot is not in
    InviteAcceptedToGuildBotNotIn = 50036,

    // 50039: Invalid Activity Action
    InvalidActivityAction = 50039,

    // 50041: Invalid API version provided
    InvalidApiVersion = 50041,

    // 50045: File uploaded exceeds the maximum size
    FileTooLarge = 50045,

    // 50046: Invalid file uploaded
    InvalidFileUploaded = 50046,

    // 50054: Cannot self-redeem this gift
    CannotSelfRedeemGift = 50054,

    // 50055: Invalid Guild
    InvalidGuild = 50055,

    // 50057: Invalid SKU
    InvalidSku = 50057,

    // 50067: Invalid request origin
    InvalidRequestOrigin = 50067,

    // 50068: Invalid message type
    InvalidMessageType = 50068,

    // 50070: Payment source required to redeem gift
    PaymentSourceRequired = 50070,

    // 50073: Cannot modify a system webhook
    CannotModifySystemWebhook = 50073,

    // 50074: Cannot delete a channel required for Community guilds
    CannotDeleteRequiredCommunityChannel = 50074,

    // 50080: Cannot edit stickers within a message
    CannotEditStickersInMessage = 50080,

    // 50081: Invalid sticker sent
    InvalidStickerSent = 50081,

    // 50083: Tried to perform an operation on an archived thread, such as editing a message or adding a user to the thread
    OperationOnArchivedThread = 50083,

    // 50084: Invalid thread notification settings
    InvalidThreadNotificationSettings = 50084,

    // 50085: before value is earlier than the thread creation date
    BeforeValueEarlierThanThreadCreation = 50085,

    // 50086: Community server channels must be text channels
    CommunityChannelsMustBeText = 50086,

    // 50091: The entity type of the event is different from the entity you are trying to start the event for
    EventEntityTypeMismatch = 50091,

    // 50095: This server is not available in your location
    ServerNotAvailableInLocation = 50095,

    // 50097: This server needs monetization enabled in order to perform this action
    MonetizationRequired = 50097,

    // 50101: This server needs more boosts to perform this action
    MoreBoostsRequired = 50101,

    // 50109: The request body contains invalid JSON.
    InvalidJson = 50109,

    // 50110: The provided file is invalid.
    ProvidedFileInvalid = 50110,

    // 50123: The provided file type is invalid.
    ProvidedFileTypeInvalid = 50123,

    // 50124: The provided file duration exceeds maximum of 5.2 seconds.
    ProvidedFileDurationTooLong = 50124,

    // 50131: Owner cannot be pending member
    OwnerCannotBePendingMember = 50131,

    // 50132: Ownership cannot be transferred to a bot user
    OwnershipCannotBeTransferredToBot = 50132,

    // 50138: Failed to resize asset below the maximum size: 262144
    AssetResizeFailed = 50138,

    // 50144: Cannot mix subscription and non subscription roles for an emoji
    CannotMixSubscriptionRolesForEmoji = 50144,

    // 50145: Cannot convert between premium emoji and normal emoji
    CannotConvertBetweenPremiumAndNormalEmoji = 50145,

    // 50146: Uploaded file not found.
    UploadedFileNotFound = 50146,

    // 50151: The specified emoji is invalid
    SpecifiedEmojiInvalid = 50151,

    // 50159: Voice messages do not support additional content.
    VoiceMessagesNoAdditionalContent = 50159,

    // 50160: Voice messages must have a single audio attachment.
    VoiceMessagesSingleAudioAttachment = 50160,

    // 50161: Voice messages must have supporting metadata.
    VoiceMessagesMissingMetadata = 50161,

    // 50162: Voice messages cannot be edited.
    VoiceMessagesCannotBeEdited = 50162,

    // 50163: Cannot delete guild subscription integration
    CannotDeleteGuildSubscriptionIntegration = 50163,

    // 50173: You cannot send voice messages in this channel.
    CannotSendVoiceMessagesInChannel = 50173,

    // 50178: The user account must first be verified
    UserAccountMustBeVerified = 50178,

    // 50192: The provided file does not have a valid duration.
    ProvidedFileInvalidDuration = 50192,

    // 50600: You do not have permission to send this sticker.
    NoPermissionToSendSticker = 50600,

    // 60003: Two factor is required for this operation
    TwoFactorRequired = 60003,

    // 80004: No users with DiscordTag exist
    NoUsersWithDiscordTagExist = 80004,

    // 90001: Reaction was blocked
    ReactionBlocked = 90001,

    // 90002: User cannot use burst reactions
    UserCannotUseBurstReactions = 90002,

    // 110001: Application not yet available. Try again later
    ApplicationNotYetAvailable = 110001,

    // 130000: API resource is currently overloaded. Try again a little later
    ApiResourceOverloaded = 130000,

    // 150006: The Stage is already open
    StageAlreadyOpen = 150006,

    // 160002: Cannot reply without permission to read message history
    CannotReplyWithoutReadHistory = 160002,

    // 160004: A thread has already been created for this message
    ThreadAlreadyCreatedForMessage = 160004,

    // 160005: Thread is locked
    ThreadLocked = 160005,

    // 160006: Maximum number of active threads reached
    MaxActiveThreadsReached = 160006,

    // 160007: Maximum number of active announcement threads reached
    MaxActiveAnnouncementThreadsReached = 160007,

    // 170001: Invalid JSON for uploaded Lottie file
    InvalidJsonForLottie = 170001,

    // 170002: Uploaded Lotties cannot contain rasterized images such as PNG or JPEG
    LottieCannotContainRasterizedImages = 170002,

    // 170003: Sticker maximum framerate exceeded
    StickerMaxFramerateExceeded = 170003,

    // 170004: Sticker frame count exceeds maximum of 1000 frames
    StickerFrameCountExceeded = 170004,

    // 170005: Lottie animation maximum dimensions exceeded
    LottieMaxDimensionsExceeded = 170005,

    // 170006: Sticker frame rate is either too small or too large
    StickerFrameRateInvalid = 170006,

    // 170007: Sticker animation duration exceeds maximum of 5 seconds
    StickerAnimationDurationExceeded = 170007,

    // 180000: Cannot update a finished event
    CannotUpdateFinishedEvent = 180000,

    // 180002: Failed to create stage needed for stage event
    FailedToCreateStageForEvent = 180002,

    // 200000: Message was blocked by automatic moderation
    MessageBlockedByAutoMod = 200000,

    // 200001: Title was blocked by automatic moderation
    TitleBlockedByAutoMod = 200001,

    // 220001: Webhooks posted to forum channels must have a thread_name or thread_id
    WebhookForumThreadNameOrIdRequired = 220001,

    // 220002: Webhooks posted to forum channels cannot have both a thread_name and thread_id
    WebhookForumCannotHaveBothThreadNameAndId = 220002,

    // 220003: Webhooks can only create threads in forum channels
    WebhookCanOnlyCreateThreadsInForum = 220003,

    // 220004: Webhook services cannot be used in forum channels
    WebhookServicesCannotBeUsedInForum = 220004,

    // 240000: Message blocked by harmful links filter
    MessageBlockedByHarmfulLinks = 240000,

    // 350000: Cannot enable onboarding, requirements are not met
    CannotEnableOnboardingRequirementsNotMet = 350000,

    // 350001: Cannot update onboarding while below requirements
    CannotUpdateOnboardingBelowRequirements = 350001,

    // 500000: Failed to ban users
    FailedToBanUsers = 500000,

    // 520000: Poll voting blocked
    PollVotingBlocked = 520000,

    // 520001: Poll expired
    PollExpired = 520001,

    // 520002: Invalid channel type for poll creation
    InvalidChannelTypeForPoll = 520002,

    // 520003: Cannot edit a poll message
    CannotEditPollMessage = 520003,

    // 520004: Cannot use an emoji included with the poll
    CannotUseEmojiWithPoll = 520004,

    // 520006: Cannot expire a non-poll message
    CannotExpireNonPollMessage = 520006
}