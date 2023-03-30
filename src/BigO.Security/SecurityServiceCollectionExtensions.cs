using BigO.Core.Validation;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace BigO.Security;

[PublicAPI]
public static class SecurityServiceCollectionExtensions
{
    /// <summary>
    /// Adds the authorization security registrations.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <returns>A reference to the <see cref="IServiceCollection"/> instance after the operation has completed.</returns>
    public static IServiceCollection AddAuthorizationSecurity(this IServiceCollection serviceCollection)
    {
        Guard.NotNull(serviceCollection, nameof(serviceCollection));

        serviceCollection.AddTransient<IAuthorizationManager, AuthorizationManager>();
        return serviceCollection;
    }
}