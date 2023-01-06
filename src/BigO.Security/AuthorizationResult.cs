using JetBrains.Annotations;

namespace BigO.Security;

/// <summary>
///     Represents the result of an authorization rule.
/// </summary>
[PublicAPI]
public readonly struct AuthorizationResult
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthorizationResult" /> struct.
    /// </summary>
    /// <param name="successful">if set to <c>true</c> then the authorization rule has passed successfully.</param>
    /// <param name="message">The message.</param>
    public AuthorizationResult(bool successful, string? message = null)
    {
        Successful = successful;
        Message = message;
    }

    /// <summary>
    ///     Gets a value indicating whether the <see cref="IAuthorizationRule{TInput}" /> is successful.
    /// </summary>
    /// <value><c>true</c> if successful; otherwise, <c>false</c>.</value>
    public bool Successful { get; }

    /// <summary>
    ///     Gets an informative message about the rule passing or failing.
    /// </summary>
    public string? Message { get; }
}