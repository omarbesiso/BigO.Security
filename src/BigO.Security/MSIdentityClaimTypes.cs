using JetBrains.Annotations;

namespace BigO.Security;

/// <summary>
///     Defines constants representing Microsoft Identity claim types.
/// </summary>
[PublicAPI]
public static class MSIdentityClaimTypes
{
    /// <summary>
    ///     Old Object Id claim: http://schemas.microsoft.com/identity/claims/objectidentifier.
    /// </summary>
    public const string ObjectId = "http://schemas.microsoft.com/identity/claims/objectidentifier";

    /// <summary>
    ///     Old Role claim: "http://schemas.microsoft.com/ws/2008/06/identity/claims/role".
    /// </summary>
    public const string Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

    /// <summary>
    ///     Older scope claim: "http://schemas.microsoft.com/identity/claims/scope".
    /// </summary>
    public const string Scope = "http://schemas.microsoft.com/identity/claims/scope";

    /// <summary>
    ///     Old TenantId claim: "http://schemas.microsoft.com/identity/claims/tenantid".
    /// </summary>
    public const string TenantId = "http://schemas.microsoft.com/identity/claims/tenantid";
}