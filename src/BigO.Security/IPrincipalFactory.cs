using System.Security.Claims;
using System.Security.Principal;
using JetBrains.Annotations;

namespace BigO.Security;

/// <summary>
///     Represents a factory for creating <see cref="System.Security.Principal.IPrincipal" />s.
/// </summary>
/// <typeparam name="TPrincipal">The type of the principal.</typeparam>
[PublicAPI]
public interface IPrincipalFactory<out TPrincipal> where TPrincipal : IPrincipal
{
    /// <summary>
    ///     Creates an instance of a <see cref="ClaimsPrincipal" />.
    /// </summary>
    /// <typeparam name="TPrincipal">The type of the principal.</typeparam>
    /// <returns>The new principal instance.</returns>
    public TPrincipal CreatePrincipal();
}