namespace Disconance.Models.Interactions
{
    public class ApplicationCommandPermission
    {
        /// <summary>
        /// The ID of the role or user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The type of permission. 1 for role, 2 for user.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Whether the permission is granted (true) or denied (false).
        /// </summary>
        public bool Permission { get; set; }
    }
}
