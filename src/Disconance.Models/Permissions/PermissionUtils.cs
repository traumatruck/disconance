using System.Numerics;

namespace Disconance.Models.Permissions;

/// <summary>
///     Utility class for handling permission strings (as used in models like Role and Overwrite).
///     Permissions are stored as strings representing big integers.
/// </summary>
public static class PermissionUtils
{
    /// <summary>
    ///     Checks if a specific permission is set in the given permission string.
    /// </summary>
    /// <param name="permissions">The permission string from a model (e.g., Role.Permissions).</param>
    /// <param name="permission">The permission flag to check.</param>
    /// <returns>True if the permission is granted.</returns>
    public static bool HasPermission(this string permissions, Permission permission)
    {
        if (string.IsNullOrEmpty(permissions))
        {
            return false;
        }

        if (BigInteger.TryParse(permissions, out var permValue))
        {
            return (permValue & (ulong) permission) != 0;
        }

        return false;
    }

    /// <summary>
    ///     Adds a permission to the given permission string.
    /// </summary>
    /// <param name="permissions">The current permission string.</param>
    /// <param name="permission">The permission to add.</param>
    /// <returns>The updated permission string.</returns>
    public static string AddPermission(this string permissions, Permission permission)
    {
        var permValue = string.IsNullOrEmpty(permissions) ? BigInteger.Zero : BigInteger.Parse(permissions);
        permValue |= (ulong) permission;
        return permValue.ToString();
    }

    /// <summary>
    ///     Removes a permission from the given permission string.
    /// </summary>
    /// <param name="permissions">The current permission string.</param>
    /// <param name="permission">The permission to remove.</param>
    /// <returns>The updated permission string.</returns>
    public static string RemovePermission(this string permissions, Permission permission)
    {
        var permValue = string.IsNullOrEmpty(permissions) ? BigInteger.Zero : BigInteger.Parse(permissions);
        permValue &= ~(BigInteger) (ulong) permission;
        return permValue.ToString();
    }

    /// <summary>
    ///     Computes effective permissions by applying overwrites (allow/deny) to base permissions.
    ///     Simplified example; expand for full hierarchy as per Discord docs.
    /// </summary>
    /// <param name="basePermissions">Base permission string (e.g., from Role).</param>
    /// <param name="allow">Allow overwrite string (e.g., from Overwrite.Allow).</param>
    /// <param name="deny">Deny overwrite string (e.g., from Overwrite.Deny).</param>
    /// <returns>The effective permission string.</returns>
    public static string ApplyOverwrites(this string basePermissions, string allow, string deny)
    {
        var baseValue = string.IsNullOrEmpty(basePermissions) ? BigInteger.Zero : BigInteger.Parse(basePermissions);
        var allowValue = string.IsNullOrEmpty(allow) ? BigInteger.Zero : BigInteger.Parse(allow);
        var denyValue = string.IsNullOrEmpty(deny) ? BigInteger.Zero : BigInteger.Parse(deny);

        // Apply denies first, then allows (simplified hierarchy)
        baseValue &= ~denyValue;
        baseValue |= allowValue;

        return baseValue.ToString();
    }
}