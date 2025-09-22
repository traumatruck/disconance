using System.Collections.Immutable;
using Disconance.Interactions.Attributes;
using Disconance.Interactions.Commands;
using Disconance.Interactions.Processors;
using Disconance.Interactions.Events;
using Disconance.Interactions.Security;
using Disconance.Interactions.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Disconance.Interactions.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Registers interaction and component services and commands.
    /// </summary>
    /// <param name="serviceCollection">The instance of IServiceCollection used for dependency injection.</param>
    /// <returns>The updated IServiceCollection to support chaining of method calls.</returns>
    internal static IServiceCollection AddInteractions(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IInteractionSecurityHandler, NSecInteractionSecurityHandler>();
        serviceCollection.AddScoped<IInteractionRequestProcessor, InteractionRequestProcessor>();
        serviceCollection.AddScoped<ICommandProcessor, CommandProcessor>();
        serviceCollection.AddScoped<ICommandRegistrar, CommandRegistrar>();
        serviceCollection.AddScoped<ICommandRepository, CommandRepository>();
        serviceCollection.AddScoped<IModalSubmitHandler, ModalSubmitHandler>();
        serviceCollection.AddScoped<IMessageComponentHandler, MessageComponentHandler>();

        serviceCollection.AddScoped<IInteractionHandler, InteractionHandler>();
        serviceCollection.AddScoped<ICommandRegistrationService, CommandRegistrationService>();

        serviceCollection.AddSingleton<IInteractionEventPublisher, InteractionEventPublisher>();

        var assemblies = CommandAssemblyAttribute.GetCommandAssemblies();
        var assemblyTypes = assemblies.SelectMany(assembly => assembly.GetTypes()).ToImmutableArray();

        // Auto-register all event subscribers found in the scanned assemblies
        var subscriberTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false } &&
            typeof(IInteractionEventSubscriber).IsAssignableFrom(type));

        foreach (var type in subscriberTypes)
        {
            serviceCollection.AddScoped(typeof(IInteractionEventSubscriber), type);
        }

        // Register simple commands
        var simpleCommandTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false } && typeof(ISimpleCommand).IsAssignableFrom(type) &&
            type != typeof(ISimpleCommand));

        foreach (var type in simpleCommandTypes)
        {
            serviceCollection.AddScoped(typeof(ISimpleCommand), type);
        }

        // Register base commands
        var baseCommandTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false, BaseType.IsGenericType: true } &&
            type.BaseType.GetGenericTypeDefinition() == typeof(BaseCommand<>));

        foreach (var type in baseCommandTypes)
        {
            serviceCollection.AddScoped(type.BaseType!, type);
        }

        // Register subcommand groups
        var subcommandGroupTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false, BaseType.IsGenericType: true } &&
            type.BaseType.GetGenericTypeDefinition() == typeof(SubcommandGroup<,>));

        foreach (var type in subcommandGroupTypes)
        {
            serviceCollection.AddScoped(type.BaseType!, type);
        }

        // Register subcommands with a group
        var subcommandWithGroupTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false } && type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubcommand<,>)));

        foreach (var type in subcommandWithGroupTypes)
        {
            var @interface = type.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubcommand<,>));

            serviceCollection.AddScoped(@interface, type);
        }

        // Register subcommands without a group
        var subcommandTypes = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false } && type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubcommand<>)));

        foreach (var type in subcommandTypes)
        {
            serviceCollection.AddScoped(typeof(ICommand), type);

            var @interface = type.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISubcommand<>));

            serviceCollection.AddScoped(@interface, type);
        }

        // Register message components
        var messageComponents = assemblyTypes.Where(type =>
            type is { IsAbstract: false, IsInterface: false } && typeof(IMessageComponent).IsAssignableFrom(type) &&
            type != typeof(IMessageComponent));

        foreach (var type in messageComponents)
        {
            serviceCollection.AddScoped(typeof(IMessageComponent), type);
        }

        return serviceCollection;
    }
}