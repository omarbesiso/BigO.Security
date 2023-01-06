using JetBrains.Annotations;

namespace BigO.Security;

/// <summary>
///     Defines the contract for an authorization test for an authenticated user trying to execute an operation.
/// </summary>
/// <typeparam name="TAuthorizationArgs">The arguments required for the authorization rule to execute.</typeparam>
[PublicAPI]
public interface IAuthorizationRule<in TAuthorizationArgs>
{
    /// <summary>
    ///     Defines a rule to determine whether execution of a certain action is authorized.
    /// </summary>
    /// <typeparam name="TAuthorizationArgs">The type of the arguments required to execute this rule.</typeparam>
    /// <remarks>
    ///     The <see cref="IsAuthorized" /> method of this interface should be called to determine whether the execution of a
    ///     certain action is authorized.
    ///     It returns a <see cref="Task{AuthorizationResult}" /> indicating whether the authorization rule has passed or
    ///     failed.
    /// </remarks>
    Task<AuthorizationResult> IsAuthorized(TAuthorizationArgs authorizationArgs);
}