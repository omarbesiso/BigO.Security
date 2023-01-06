using System.Security.Claims;
using System.Security.Principal;
using BigO.Core.Validation;
using JetBrains.Annotations;

namespace BigO.Security;

[PublicAPI]
public static class SecurityExtensions
{
    /// <summary>
    ///     Converts the specified <paramref name="principal" /> object to a <see cref="ClaimsPrincipal" />.
    /// </summary>
    /// <param name="principal">The <see cref="IPrincipal" /> object to be converted.</param>
    /// <returns>The converted <see cref="ClaimsPrincipal" /> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="principal" /> is <c>null</c>.</exception>
    /// <exception cref="InvalidCastException"><paramref name="principal" /> is not a <see cref="ClaimsPrincipal" />.</exception>
    /// <remarks>
    ///     This method converts the specified <paramref name="principal" /> object to a <see cref="ClaimsPrincipal" />.
    ///     If <paramref name="principal" /> is <c>null</c>, an exception will be thrown.
    ///     If <paramref name="principal" /> cannot be converted to a <see cref="ClaimsPrincipal" />, an exception will be
    ///     thrown.
    /// </remarks>
    public static ClaimsPrincipal AsClaimsPrincipal(this IPrincipal principal)
    {
        Guard.NotNull(principal, nameof(principal));
        if (principal is not ClaimsPrincipal claimsPrincipal)
        {
            throw new InvalidCastException("Could not cast the provided IPrincipal object to a ClaimsPrincipal.");
        }

        return claimsPrincipal;
    }

    /// <summary>
    ///     Converts the specified <paramref name="principal" /> object to a <see cref="ClaimsPrincipal" /> of type
    ///     <typeparamref name="TClaimsPrincipal" />.
    /// </summary>
    /// <typeparam name="TClaimsPrincipal">
    ///     The type of <see cref="ClaimsPrincipal" /> to which the
    ///     <paramref name="principal" /> will be converted.
    /// </typeparam>
    /// <param name="principal">The <see cref="IPrincipal" /> object to be converted.</param>
    /// <returns>The converted <see cref="ClaimsPrincipal" /> object of type <typeparamref name="TClaimsPrincipal" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="principal" /> is <c>null</c>.</exception>
    /// <exception cref="InvalidCastException"><paramref name="principal" /> is not a <typeparamref name="TClaimsPrincipal" />.</exception>
    /// <remarks>
    ///     This method converts the specified <paramref name="principal" /> object to a <see cref="ClaimsPrincipal" /> of type
    ///     <typeparamref name="TClaimsPrincipal" />.
    ///     If <paramref name="principal" /> is <c>null</c>, an exception will be thrown.
    ///     If <paramref name="principal" /> cannot be converted to a <typeparamref name="TClaimsPrincipal" />, an exception
    ///     will be thrown.
    /// </remarks>
    public static TClaimsPrincipal AsClaimsPrincipal<TClaimsPrincipal>(this IPrincipal principal)
        where TClaimsPrincipal : ClaimsPrincipal
    {
        Guard.NotNull(principal, nameof(principal));
        if (principal is not TClaimsPrincipal claimsPrincipal)
        {
            throw new InvalidCastException(
                $"Could not cast the provided IPrincipal object to a {typeof(TClaimsPrincipal).FullName}.");
        }

        return claimsPrincipal;
    }

    /// <summary>
    ///     Converts the specified <paramref name="identity" /> object to a <see cref="ClaimsIdentity" />.
    /// </summary>
    /// <param name="identity">The <see cref="IIdentity" /> object to be converted.</param>
    /// <returns>The converted <see cref="ClaimsIdentity" /> object.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="identity" /> is <c>null</c>.</exception>
    /// <exception cref="InvalidCastException"><paramref name="identity" /> is not a <see cref="ClaimsIdentity" />.</exception>
    /// <remarks>
    ///     This method converts the specified <paramref name="identity" /> object to a <see cref="ClaimsIdentity" />.
    ///     If <paramref name="identity" /> is <c>null</c>, an exception will be thrown.
    ///     If <paramref name="identity" /> cannot be converted to a <see cref="ClaimsIdentity" />, an exception will be
    ///     thrown.
    /// </remarks>
    public static ClaimsIdentity AsClaimsIdentity(this IIdentity identity)
    {
        Guard.NotNull(identity, nameof(identity));
        if (identity is not ClaimsIdentity claimsIdentity)
        {
            throw new InvalidCastException("Could not cast the provided IIdentity object to a ClaimsIdentity");
        }

        return claimsIdentity;
    }

    /// <summary>
    ///     Converts the specified <paramref name="identity" /> object to a <see cref="ClaimsIdentity" /> of type
    ///     <typeparamref name="TClaimsIdentity" />.
    /// </summary>
    /// <typeparam name="TClaimsIdentity">
    ///     The type of <see cref="ClaimsIdentity" /> to which the <paramref name="identity" />
    ///     will be converted.
    /// </typeparam>
    /// <param name="identity">The <see cref="IIdentity" /> object to be converted.</param>
    /// <returns>The converted <see cref="ClaimsIdentity" /> object of type <typeparamref name="TClaimsIdentity" />.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="identity" /> is <c>null</c>.</exception>
    /// <exception cref="InvalidCastException"><paramref name="identity" /> is not a <typeparamref name="TClaimsIdentity" />.</exception>
    /// <remarks>
    ///     This method converts the specified <paramref name="identity" /> object to a <see cref="ClaimsIdentity" /> of type
    ///     <typeparamref name="TClaimsIdentity" />.
    ///     If <paramref name="identity" /> is <c>null</c>, an exception will be thrown.
    ///     If <paramref name="identity" /> cannot be converted to a <typeparamref name="TClaimsIdentity" />, an exception will
    ///     be thrown.
    /// </remarks>
    public static TClaimsIdentity AsClaimsIdentity<TClaimsIdentity>(this IIdentity identity)
        where TClaimsIdentity : ClaimsIdentity
    {
        Guard.NotNull(identity, nameof(identity));
        if (identity is not TClaimsIdentity claimsIdentity)
        {
            throw new InvalidCastException(
                $"Could not cast the provided IIdentity object to a {typeof(TClaimsIdentity).FullName}.");
        }

        return claimsIdentity;
    }
}