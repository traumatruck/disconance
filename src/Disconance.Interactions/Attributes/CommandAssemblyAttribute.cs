using System.Reflection;

namespace Disconance.Interactions.Attributes;

/// <summary>
///     Represents an attribute used to indicate that the assembly contains registerable commands.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public sealed class CommandAssemblyAttribute : Attribute
{
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