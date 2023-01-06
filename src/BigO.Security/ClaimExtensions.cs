using System.Security.Claims;
using BigO.Core.Extensions;
using BigO.Core.Validation;
using JetBrains.Annotations;

namespace BigO.Security;

/// <summary>
///     Utilities and helpers for claims.
/// </summary>
[PublicAPI]
public static class ClaimExtensions
{
    /// <summary>
    ///     Retrieves a claim from the specified collection by its type.
    /// </summary>
    /// <param name="claims">The collection of claims to search through. Cannot be <c>null</c>.</param>
    /// <param name="claimTypes">The types of claims to search for. Can be <c>null</c> or empty.</param>
    /// <returns>
    ///     A <see cref="Claim" /> object if found, or <c>null</c> if not found or if <paramref name="claimTypes" /> is
    ///     <c>null</c> or empty.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="claims" /> is <c>null</c>.</exception>
    /// <remarks>
    ///     This method searches through the specified collection of claims for a claim with a type that is present in the
    ///     <paramref name="claimTypes" /> array. If a matching claim is found, it is returned. If no match is found or if
    ///     <paramref name="claimTypes" /> is <c>null</c> or empty, <c>null</c> is returned.
    /// </remarks>
    public static Claim? GetClaimByType(this IEnumerable<Claim> claims, params string[] claimTypes)
    {
        Guard.NotNull(claims, nameof(claims));
        if (claimTypes.IsNullOrEmpty())
        {
            return null;
        }

        var claim = claims.FirstOrDefault(c => claimTypes.Contains(c.Type));
        return claim;
    }

    /// <summary>
    ///     Retrieves the value of a claim from the specified collection by its type.
    /// </summary>
    /// <param name="claims">The collection of claims to search through. Cannot be <c>null</c>.</param>
    /// <param name="claimTypes">The types of claims to search for. Can be <c>null</c> or empty.</param>
    /// <returns>
    ///     The value of the claim if found, or <c>null</c> if not found or if <paramref name="claimTypes" /> is
    ///     <c>null</c> or empty.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="claims" /> is <c>null</c>.</exception>
    /// <remarks>
    ///     This method searches through the specified collection of claims for a claim with a type that is present in the
    ///     <paramref name="claimTypes" /> array. If a matching claim is found, its value is returned. If no match is found or
    ///     if <paramref name="claimTypes" /> is <c>null</c> or empty, <c>null</c> is returned.
    /// </remarks>
    public static string? GetClaimValueByType(this IEnumerable<Claim> claims, params string[] claimTypes)
    {
        var claim = claims.GetClaimByType(claimTypes);
        var claimValue = claim?.Value.Trim();
        return claimValue;
    }

    /// <summary>
    ///     Retrieves a collection of claims from the specified collection by their type.
    /// </summary>
    /// <param name="claims">The collection of claims to search through. Cannot be <c>null</c>.</param>
    /// <param name="claimTypes">The types of claims to search for. Can be <c>null</c> or empty.</param>
    /// <returns>
    ///     A collection of <see cref="Claim" /> objects if found, or <c>null</c> if <paramref name="claimTypes" /> is
    ///     <c>null</c> or empty.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="claims" /> is <c>null</c>.</exception>
    /// <remarks>
    ///     This method searches through the specified collection of claims for claims with types that are present in the
    ///     <paramref name="claimTypes" /> array. If any matching claims are found, they are returned as a collection. If no
    ///     matches are found or if <paramref name="claimTypes" /> is <c>null</c> or empty, <c>null</c> is returned.
    /// </remarks>
    public static IEnumerable<Claim>? GetClaimsByType(this IEnumerable<Claim> claims, params string[] claimTypes)
    {
        Guard.NotNull(claims, nameof(claims));
        if (claimTypes.IsNullOrEmpty())
        {
            return null;
        }

        var matchingClaims = claims.Where(c => claimTypes.Contains(c.Type));
        return matchingClaims;
    }

    /// <summary>
    ///     Retrieves the values of claims from the specified collection by their type.
    /// </summary>
    /// <param name="claims">The collection of claims to search through. Cannot be <c>null</c>.</param>
    /// <param name="claimTypes">The types of claims to search for. Can be <c>null</c> or empty.</param>
    /// <returns>
    ///     A collection of claim values if found, or <c>null</c> if <paramref name="claimTypes" /> is <c>null</c> or
    ///     empty.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="claims" /> is <c>null</c>.</exception>
    /// <remarks>
    ///     This method searches through the specified collection of claims for claims with types that are present in the
    ///     <paramref name="claimTypes" /> array. If any matching claims are found, their values are returned as a collection.
    ///     If no matches are found or if <paramref name="claimTypes" /> is <c>null</c> or empty, <c>null</c> is returned.
    /// </remarks>
    public static IEnumerable<string>? GetClaimValuesByType(this IEnumerable<Claim> claims,
        params string[] claimTypes)
    {
        var matchingClaims = claims.GetClaimsByType(claimTypes);
        return matchingClaims?.Select(c => c.Value).ToList();
    }

    /// <summary>
    ///     Adds a unique claim to the specified <see cref="ClaimsIdentity" /> object.
    /// </summary>
    /// <param name="identity">The <see cref="ClaimsIdentity" /> object to add the claim to. Cannot be <c>null</c>.</param>
    /// <param name="claimType">The type of the claim to add. Cannot be <c>null</c>, empty, or white space.</param>
    /// <param name="claimValue">The value of the claim to add. Cannot be <c>null</c>, empty, or white space.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="identity" />, <paramref name="claimType" />, or
    ///     <paramref name="claimValue" /> is <c>null</c>, empty, or white space.
    /// </exception>
    /// <remarks>
    ///     This method adds a unique claim to the specified <see cref="ClaimsIdentity" /> object. If a claim with the same
    ///     type already exists, it is removed before the new claim is added.
    /// </remarks>
    public static void AddUniqueClaim(this ClaimsIdentity identity, string claimType, string claimValue)
    {
        Guard.NotNullOrWhiteSpace(claimType, nameof(claimType));
        Guard.NotNullOrWhiteSpace(claimValue, nameof(claimValue));

        var claims = identity.Claims.Where(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase)).ToList();
        if (claims.IsNotNullOrEmpty())
        {
            foreach (var claim in claims)
            {
                identity.RemoveClaim(claim);
            }
        }

        var newClaim = new Claim(claimType, claimValue);
        identity.AddClaim(newClaim);
    }

    /// <summary>
    ///     Adds a claim to the specified <see cref="ClaimsIdentity" /> object.
    /// </summary>
    /// <param name="identity">The <see cref="ClaimsIdentity" /> object to add the claim to. Cannot be <c>null</c>.</param>
    /// <param name="claimType">The type of the claim to add. Cannot be <c>null</c>, empty, or white space.</param>
    /// <param name="claimValue">The value of the claim to add. Cannot be <c>null</c>, empty, or white space.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="identity" />, <paramref name="claimType" />, or
    ///     <paramref name="claimValue" /> is <c>null</c>, empty, or white space.
    /// </exception>
    /// <remarks>
    ///     This method adds a claim to the specified <see cref="ClaimsIdentity" /> object.
    /// </remarks>
    public static void AddClaim(this ClaimsIdentity identity, string claimType, string claimValue)
    {
        Guard.NotNullOrWhiteSpace(claimType);
        Guard.NotNullOrWhiteSpace(claimValue);

        var claim = new Claim(claimType, claimValue);
        identity.AddClaim(claim);
    }
}