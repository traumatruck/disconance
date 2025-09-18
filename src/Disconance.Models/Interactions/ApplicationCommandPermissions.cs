namespace Disconance.Models.Interactions
{
    public class ApplicationCommandPermissions
    {
        /// <summary>
        /// The ID of the command.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The ID of the application.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// The ID of the guild.
        /// </summary>
        public string GuildId { get; set; }

        /// <summary>
        /// The permissions for the command, scoped to the guild.
        /// </summary>
        public List<ApplicationCommandPermission> Permissions { get; set; } = new();
    }
}
