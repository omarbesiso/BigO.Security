using BigO.Core.Validation;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace BigO.Security;

[PublicAPI]
public static class SecurityServiceProviderExtensions
{
    /// <summary>
    ///     Retrieves all registered implementations of <see cref="IAuthorizationRule{TAuthorizationArgs}" /> from the
    ///     specified <paramref name="serviceProvider" />.
    /// </summary>
    /// <typeparam name="TAuthorizationArgs">The type of authorization arguments for which the authorization rules apply.</typeparam>
    /// <param name="serviceProvider">The <see cref="IServiceProvider" /> from which the authorization rules will be retrieved.</param>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> of all registered <see cref="IAuthorizationRule{TAuthorizationArgs}" />
    ///     implementations.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="serviceProvider" /> is <c>null</c>.</exception>
    /// <remarks>
    ///     This method retrieves all registered implementations of <see cref="IAuthorizationRule{TAuthorizationArgs}" /> from
    ///     the
    ///     specified <paramref name="serviceProvider" /> and returns them as an <see cref="IEnumerable{T}" />.
    ///     If <paramref name="serviceProvider" /> is <c>null</c>, an exception will be thrown.
    /// </remarks>
    public static IEnumerable<IAuthorizationRule<TAuthorizationArgs>> GetAuthorizationRules<TAuthorizationArgs>(
        this IServiceProvider serviceProvider)
    {
        Guard.NotNull(serviceProvider, nameof(serviceProvider));
        return serviceProvider.GetServices<IAuthorizationRule<TAuthorizationArgs>>();
    }
}