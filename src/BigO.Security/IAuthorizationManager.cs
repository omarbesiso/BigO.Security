using JetBrains.Annotations;

namespace BigO.Security;

/// <summary>
///     Defines the contract for a manager providing authorization checks for authenticated messages.
/// </summary>
[PublicAPI]
public interface IAuthorizationManager
{
    /// <summary>
    ///     Authorizes an operation using the specified arguments.
    /// </summary>
    /// <typeparam name="TAuthorizationArgs">The type of arguments required for the authorization rule to execute.</typeparam>
    /// <param name="authorizationArgs">The arguments required to execute this rule. Cannot be <c>null</c>.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="authorizationArgs" /> is <c>null</c>.</exception>
    /// <exception cref="Exception">Thrown when an error occurs while attempting to authorize the operation.</exception>
    /// <remarks>
    ///     This method attempts to authorize a operation using the specified arguments. It will throw an exception if either
    ///     the arguments are null or if an error occurs during the authorization process.
    /// </remarks>
    Task Authorize<TAuthorizationArgs>(TAuthorizationArgs authorizationArgs) where TAuthorizationArgs : class;
}