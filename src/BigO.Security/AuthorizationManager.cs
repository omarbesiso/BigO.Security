using System.Security;

namespace BigO.Security;

/// <summary>
///     Default implementation of the authorization manager. This class cannot be inherited. It uses the defined
///     authorization rules.
/// </summary>
/// <seealso cref="IAuthorizationManager" />
internal sealed class AuthorizationManager : IAuthorizationManager
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthorizationManager" /> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider from which to resolve the authorization rules.</param>
    public AuthorizationManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    ///     Authorizes the specified authenticated message.
    /// </summary>
    /// <typeparam name="TAuthorizationArgs">The arguments required for the authorization rule to execute.</typeparam>
    /// <param name="authorizationArgs">The arguments required to execute this rule.</param>
    public async Task Authorize<TAuthorizationArgs>(TAuthorizationArgs authorizationArgs)
        where TAuthorizationArgs : class
    {
        var authorizationRules = _serviceProvider.GetAuthorizationRules<TAuthorizationArgs>();

        var securityExceptions = new List<SecurityException>();
        foreach (var authorizationRule in authorizationRules)
        {
            var result = await authorizationRule.IsAuthorized(authorizationArgs);

            if (!result.Successful)
            {
                securityExceptions.Add(new SecurityException(result.Message));
            }
        }

        switch (securityExceptions.Count)
        {
            case 0:
                return;
            case 1:
                throw securityExceptions.First();
            default:
                var securityAggregateException = new AggregateException(securityExceptions);
                throw new SecurityException(
                    "Multiple authorization rules broken. Please see inner exception for details.",
                    securityAggregateException);
        }
    }
}