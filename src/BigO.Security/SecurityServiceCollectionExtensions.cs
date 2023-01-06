using BigO.Core.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace BigO.Security;

public static class SecurityServiceCollectionExtensions
{
    public static IServiceCollection AddAuthorizationSecurity(this IServiceCollection serviceCollection)
    {
        Guard.NotNull(serviceCollection, nameof(serviceCollection));

        serviceCollection.AddTransient<IAuthorizationManager, AuthorizationManager>();
        return serviceCollection;
    }
}