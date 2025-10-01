using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;

namespace Disconance.Interactions.Commands;

/// <inheritdoc />
public class CommandRepository(IServiceProvider serviceProvider) : ICommandRepository
{
    /// <inheritdoc />
    public IEnumerable<ICommand> GetAllCommands()
    {
        var simpleCommands = GetSimpleCommands();
        var baseCommands = GetBaseCommands();
        var subcommandGroups = GetSubcommandGroups();
        var subcommands = GetSubcommands();

        return Enumerable.Empty<ICommand>()
            .Concat(simpleCommands)
            .Concat(baseCommands)
            .Concat(subcommandGroups)
            .Concat(subcommands);
    }

    /// <inheritdoc />
    public IEnumerable<ISimpleCommand> GetSimpleCommands()
    {
        return serviceProvider.GetServices<ISimpleCommand>();
    }

    /// <inheritdoc />
    public IEnumerable<IBaseCommand> GetBaseCommands()
    {
        var assembly = CommandAssemblyAttribute.GetCommandAssemblies();
        var assemblyTypes = assembly.SelectMany(a => a.GetTypes());

        var baseCommandTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false, BaseType.IsGenericType: true } &&
            type.BaseType.GetGenericTypeDefinition() == typeof(BaseCommand<>));

        foreach (var type in baseCommandTypes)
        {
            if (serviceProvider.GetService(type.BaseType!) is IBaseCommand command)
            {
                yield return command;
            }
        }
    }

    /// <inheritdoc />
    public IEnumerable<ICommand> GetSubcommandGroups()
    {
        var assembly = CommandAssemblyAttribute.GetCommandAssemblies();
        var assemblyTypes = assembly.SelectMany(a => a.GetTypes());

        var subcommandGroupTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false, BaseType.IsGenericType: true } &&
            type.BaseType.GetGenericTypeDefinition() == typeof(SubcommandGroup<,>));

        foreach (var type in subcommandGroupTypes)
        {
            if (serviceProvider.GetService(type.BaseType!) is ICommand baseCommand)
            {
                yield return baseCommand;
            }
        }
    }

    /// <inheritdoc />
    public IEnumerable<ICommand> GetSubcommands()
    {
        var assembly = CommandAssemblyAttribute.GetCommandAssemblies();
        var assemblyTypes = assembly.SelectMany(a => a.GetTypes()).ToImmutableArray();

        // Subcommands with group
        var subcommandWithGroupTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false } && type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubcommand<,>)));

        foreach (var type in subcommandWithGroupTypes)
        {
            var @interface = type.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubcommand<,>));

            if (serviceProvider.GetService(@interface) is ICommand command)
            {
                yield return command;
            }
        }

        // Subcommands without group
        var subcommandTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false } && type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubcommand<>)));

        foreach (var type in subcommandTypes)
        {
            var @interface = type.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubcommand<>));

            if (serviceProvider.GetService(@interface) is ICommand command)
            {
                yield return command;
            }
        }
    }
}