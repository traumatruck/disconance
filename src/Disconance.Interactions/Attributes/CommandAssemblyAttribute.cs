using System.Reflection;
using Disconance.Models;

namespace Disconance.Interactions.Attributes;

/// <summary>
///     Represents an attribute used to indicate that the assembly contains registerable commands.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public sealed class CommandAssemblyAttribute : Attribute
{
    /// <summary>
    ///     Gets or sets the optional Guild ID associated with the command assembly. If specified, commands within the assembly
    ///     will only be registered for the specified guild.
    /// </summary>
    public ulong? GuildId { get; set; } = null;

    /// <summary>
    ///     Retrieves all assemblies in the current application domain that are marked with the
    ///     <see cref="CommandAssemblyAttribute" />.
    /// </summary>
    /// <returns>An enumerable collection of assemblies that have the <see cref="CommandAssemblyAttribute" /> applied.</returns>
    public static IEnumerable<Assembly> GetCommandAssemblies()
    {
        //Get all assemblies on the running app that have the command assembly attribute
        return AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(a =>
            {
                try
                {
                    return a.IsDefined(typeof(CommandAssemblyAttribute), false);
                }
                catch
                {
                    return false;
                }
            });
    }
}