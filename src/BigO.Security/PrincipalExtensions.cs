using System.Security.Claims;
using BigO.Core.Validation;
using JetBrains.Annotations;

namespace BigO.Security;

[PublicAPI]
public static class PrincipalExtensions
{
    /// <summary>
    ///     Retrieves the value of a claim from the specified <see cref="ClaimsPrincipal" /> object by its type.
    /// </summary>
    /// <param name="claimsPrincipal">The <see cref="ClaimsPrincipal" /> object to search through. Cannot be <c>null</c>.</param>
    /// <param name="claimType">The type of the claim to search for. Cannot be <c>null</c>, empty, or white space.</param>
    /// <returns>The value of the claim if found, or <c>null</c> if not found.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="claimsPrincipal" /> or
    ///     <paramref name="claimType" /> is <c>null</c>, empty, or white space.
    /// </exception>
    /// <remarks>
    ///     This method searches through the claims of the specified <see cref="ClaimsPrincipal" /> object for a claim with the
    ///     specified type. If a matching claim is found, its value is returned. If no match is found, <c>null</c> is returned.
    /// </remarks>
    public static string? GetClaimValue(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        Guard.NotNull(claimsPrincipal);
        Guard.NotNullOrWhiteSpace(claimType);

        var claim = claimsPrincipal.Claims.FirstOrDefault(c =>
            c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
        return claim?.Value;
    }

    /// <summary>
    ///     Retrieves the value of a claim from the specified <see cref="ClaimsPrincipal" /> object by its type as a
    ///     <see cref="Guid" />.
    /// </summary>
    /// <param name="claimsPrincipal">The <see cref="ClaimsPrincipal" /> object to search through. Cannot be <c>null</c>.</param>
    /// <param name="claimType">The type of the claim to search for. Cannot be <c>null</c>, empty, or white space.</param>
    /// <returns>The value of the claim as a <see cref="Guid" />.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="claimsPrincipal" /> or
    ///     <paramref name="claimType" /> is <c>null</c>, empty, or white space.
    /// </exception>
    /// <exception cref="FormatException">Thrown when the value of the claim cannot be converted to a <see cref="Guid" />.</exception>
    /// <remarks>
    ///     This method searches through the claims of the specified <see cref="ClaimsPrincipal" /> object for a claim with the
    ///     specified type. If a matching claim is found, its value is converted to a <see cref="Guid" /> and returned. If no
    ///     match is found, an exception is thrown.
    /// </remarks>
    public static Guid GetClaimValueAsGuid(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        Guard.NotNull(claimsPrincipal);
        Guard.NotNullOrWhiteSpace(claimType);

        var claim = claimsPrincipal.Claims.First(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
        return new Guid(claim.Value);
    }

    /// <summary>
    ///     Retrieves the value of a claim from the specified <see cref="ClaimsPrincipal" /> object by its type as a
    ///     <see cref="bool" />.
    /// </summary>
    /// <param name="claimsPrincipal">The <see cref="ClaimsPrincipal" /> object to search through. Cannot be <c>null</c>.</param>
    /// <param name="claimType">The type of the claim to search for. Cannot be <c>null</c>, empty, or white space.</param>
    /// <returns>The value of the claim as a <see cref="bool" />.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="claimsPrincipal" /> or
    ///     <paramref name="claimType" /> is <c>null</c>, empty, or white space.
    /// </exception>
    /// <exception cref="FormatException">Thrown when the value of the claim cannot be converted to a <see cref="bool" />.</exception>
    /// <remarks>
    ///     This method searches through the claims of the specified <see cref="ClaimsPrincipal" /> object for a claim with the
    ///     specified type. If a matching claim is found, its value is converted to a <see cref="bool" /> and returned. If no
    ///     match is found, an exception is thrown.
    /// </remarks>
    public static bool GetClaimValueAsBoolean(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        Guard.NotNull(claimsPrincipal);
        Guard.NotNullOrWhiteSpace(claimType);

        var claim = claimsPrincipal.Claims.First(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
        return Convert.ToBoolean(claim.Value);
    }

    /// <summary>
    ///     Retrieves the values of claims from the specified <see cref="ClaimsPrincipal" /> object by their type as a
    ///     <see cref="List{T}" /> of <see cref="string" />.
    /// </summary>
    /// <param name="claimsPrincipal">The <see cref="ClaimsPrincipal" /> object to search through. Cannot be <c>null</c>.</param>
    /// <param name="claimType">The type of the claims to search for. Cannot be <c>null</c>, empty, or white space.</param>
    /// <returns>The values of the claims as a <see cref="List{T}" /> of <see cref="string" />.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="claimsPrincipal" /> or
    ///     <paramref name="claimType" /> is <c>null</c>, empty, or white space.
    /// </exception>
    /// <remarks>
    ///     This method searches through the claims of the specified <see cref="ClaimsPrincipal" /> object for claims with the
    ///     specified type. If matching claims are found, their values are returned as a <see cref="List{T}" /> of
    ///     <see cref="string" />. If no matches are found, an empty list is returned.
    /// </remarks>
    public static List<string> GetClaimValues(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        Guard.NotNull(claimsPrincipal);
        Guard.NotNullOrWhiteSpace(claimType);

        var claims = claimsPrincipal.Claims.Where(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
        return claims.Select(c => c.Value).ToList();
    }

    /// <summary>
    ///     Retrieves the values of claims from the specified <see cref="ClaimsPrincipal" /> object by their type as a
    ///     <see cref="List{T}" /> of <see cref="Guid" />.
    /// </summary>
    /// <param name="claimsPrincipal">The <see cref="ClaimsPrincipal" /> object to search through. Cannot be <c>null</c>.</param>
    /// <param name="claimType">The type of the claims to search for. Cannot be <c>null</c>, empty, or white space.</param>
    /// <returns>The values of the claims as a <see cref="List{T}" /> of <see cref="Guid" />.</returns>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="claimsPrincipal" /> or
    ///     <paramref name="claimType" /> is <c>null</c>, empty, or white space.
    /// </exception>
    /// <exception cref="FormatException">Thrown when the value of a claim cannot be converted to a <see cref="Guid" />.</exception>
    /// <remarks>
    ///     This method searches through the claims of the specified <see cref="ClaimsPrincipal" /> object for claims with the
    ///     specified type. If matching claims are found, their values are converted to a <see cref="Guid" /> and returned as a
    ///     <see cref="List{T}" />. If no matches are found, an empty list is returned.
    /// </remarks>
    public static List<Guid> GetClaimValuesAsGuids(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        Guard.NotNull(claimsPrincipal);
        Guard.NotNullOrWhiteSpace(claimType);

        var claims =
            claimsPrincipal.Claims.Where(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
        return claims.Select(c => new Guid(c.Value)).ToList();
    }
}