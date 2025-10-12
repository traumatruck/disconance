using System.Reflection;
using Disconance.Interactions.Commands.Modals;
using Microsoft.Extensions.DependencyInjection;

namespace Disconance.Interactions.Commands.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommands(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICommandRegistrationService, CommandRegistrationService>();

        // Scan all assemblies and register interaction commands/components/modals
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            Type[] types;

            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException)
            {
                continue;
            }

            foreach (var type in types)
            {
                if (type.IsAbstract || type.IsInterface || type.IsGenericTypeDefinition || type == typeof(object))
                {
                    continue;
                }

                // Register command types
                var isCommandType = typeof(ICommand).IsAssignableFrom(type);
                var isCommandBehaviorType = typeof(ICommandBehavior).IsAssignableFrom(type);

                if (isCommandType)
                {
                    serviceCollection.AddScoped(typeof(ICommand), type);

                    // Only register as Command if it actually inherits from Command
                    if (typeof(Command).IsAssignableFrom(type))
                    {
                        serviceCollection.AddScoped(typeof(Command), type);
                    }
                }

                if (isCommandBehaviorType)
                {
                    serviceCollection.AddScoped(typeof(ICommandBehavior), type);
                }
                
                // Register message component types
                var isMessageComponentType = typeof(IMessageComponent).IsAssignableFrom(type);
                
                if (isMessageComponentType)
                {
                    serviceCollection.AddScoped(typeof(IMessageComponent), type);
                }
                
                // Register modal types
                var isModalType = typeof(IModalForm).IsAssignableFrom(type);
                
                if (isModalType)
                {
                    serviceCollection.AddScoped(typeof(IModalForm), type);
                }
            }
        }

        return serviceCollection;
    }
}