using JetBrains.Annotations;

namespace BigO.Security;

/// <summary>
///     Defines constants representing OpenId claim types.
/// </summary>
[PublicAPI]
public static class OpenIdClaimTypes
{
    /// <summary>
    ///     Authentication Context Class Reference, a string indicating the level of authentication. (value: "acr").
    /// </summary>
    /// <remarks>
    ///     Authentication Context Class Reference. String specifying an Authentication Context Class Reference value that
    ///     identifies the Authentication Context Class that the authentication performed satisfied. The value "0" indicates
    ///     the End-User authentication did not meet the requirements of ISO/IEC 29115 [ISO29115] level 1. Authentication using
    ///     a long-lived browser cookie, for instance, is one example where the use of "level 0" is appropriate.
    ///     Authentications with level 0 SHOULD NOT be used to authorize access to any resource of any monetary value.
    ///     An absolute URI or an RFC 6711 [RFC6711] registered name SHOULD be used as the acr value; registered names MUST NOT
    ///     be used with a different meaning than that which is registered. Parties using this claim will need to agree upon
    ///     the meanings of the values used, which may be context-specific. The acr value is a case sensitive string
    /// </remarks>
    public const string Acr = "acr";

    /// <summary>End-User's preferred postal address. (value: "address").</summary>
    /// <remarks>
    ///     <para>
    ///         The Address Claim represents a physical mailing address. Implementations MAY return only a subset of the
    ///         fields of an address, depending upon the information available and the End-User's privacy preferences. For
    ///         example, the country and region might be returned without returning more fine-grained address information.
    ///     </para>
    ///     <para>
    ///         Implementations MAY return just the full address as a single string in the formatted sub-field, or they MAY
    ///         return just the individual component fields using the other sub-fields, or they MAY return both. If both
    ///         variants are returned, they SHOULD be describing the same address, with the formatted address indicating how
    ///         the component fields are combined.
    ///     </para>
    ///     <para>
    ///         formatted : Full mailing address, formatted for display or use on a mailing label. This field MAY contain
    ///         multiple lines, separated by newlines. Newlines can be represented either as a carriage return/line feed pair
    ///         ("\r\n") or as a single line feed character ("\n").
    ///     </para>
    ///     <para>
    ///         street_address :  Full street address component, which MAY include house number, street name, Post Office Box,
    ///         and multi-line extended street address information. This field MAY contain multiple lines, separated by
    ///         newlines. Newlines can be represented either as a carriage return/line feed pair ("\r\n") or as a single line
    ///         feed character ("\n").
    ///     </para>
    ///     <para>locality : City or locality component.</para>
    ///     <para>region: State, province, prefecture, or region component.</para>
    ///     <para>postal_code : Zip code or postal code component.</para>
    ///     <para>country : Country name component.<br /></para>
    /// </remarks>
    public const string Address = "address";

    /// <summary>
    ///     Authentication Methods References, an array of strings indicating the methods used for authentication. (value:
    ///     "amr").
    /// </summary>
    /// <remarks>
    ///     JSON array of strings that are identifiers for authentication methods used in the authentication. For instance,
    ///     values might indicate that both password and OTP authentication methods were used. The definition of particular
    ///     values to be used in the amr Claim is beyond the scope of this specification. Parties using this claim will need to
    ///     agree upon the meanings of the values used, which may be context-specific. The amr value is an array of case
    ///     sensitive strings.
    /// </remarks>
    public const string Amr = "amr";

    /// <summary>
    ///     Audience, the client (application) for which the ID token is intended. (value: "aud").
    /// </summary>
    /// <remarks>
    ///     Audience(s) that this ID Token is intended for. It MUST contain the OAuth 2.0 client_id of the Relying Party as an
    ///     audience value. It MAY also contain identifiers for other audiences. In the general case, the aud value is an array
    ///     of case sensitive strings. In the common special case when there is one audience, the aud value MAY be a single
    ///     case sensitive string.
    /// </remarks>
    public const string Audience = "aud";

    /// <summary>
    ///     Authentication time, a timestamp indicating when the user last authenticated. (value: "auth_time").
    /// </summary>
    /// <remarks>
    ///     Time when the End-User authentication occurred. Its value is a JSON number representing the number of seconds from
    ///     1970-01-01T0:0:0Z as measured in UTC until the date/time. When a max_age request is made or when auth_time is
    ///     requested as an Essential Claim, then this Claim is REQUIRED; otherwise, its inclusion is OPTIONAL.
    /// </remarks>
    public const string AuthTime = "auth_time";

    /// <summary>
    ///     Authorized party, the client ID of the application that is authorized to use the ID token. (value: "azp").
    /// </summary>
    /// <remarks>
    ///     Authorized party - the party to which the ID Token was issued. If present, it MUST contain the OAuth 2.0 Client ID
    ///     of this party. This Claim is only needed when the ID Token has a single audience value and that audience is
    ///     different than the authorized party. It MAY be included even when the authorized party is the same as the sole
    ///     audience. The azp value is a case sensitive string containing a StringOrURI value.
    /// </remarks>
    public const string Azp = "azp";

    /// <summary>
    ///     Expiration time, a timestamp indicating when the ID token expires. (value: "exp").
    /// </summary>
    /// <remarks>
    ///     Expiration time on or after which the ID Token MUST NOT be accepted for processing. The processing of this
    ///     parameter requires that the current date/time MUST be before the expiration date/time listed in the value.
    ///     Implementers MAY provide for some small leeway, usually no more than a few minutes, to account for clock skew. Its
    ///     value is a JSON number representing the number of seconds from 1970-01-01T0:0:0Z as measured in UTC until the
    ///     date/time. See RFC 3339 [RFC3339] for details regarding date/times in general and UTC in particular.
    /// </remarks>
    public const string Exp = "exp";

    /// <summary>
    ///     Issued at, a timestamp indicating when the ID token was issued. (value: "iat").
    /// </summary>
    /// <remarks>
    ///     Time at which the JWT was issued. Its value is a JSON number representing the number of seconds from
    ///     1970-01-01T0:0:0Z as measured in UTC until the date/time.
    /// </remarks>
    public const string Iat = "iat";

    /// <summary>
    ///     Issuer Identifier for the Issuer of the token response. (value: "iss").
    /// </summary>
    /// <remarks>
    ///     . The iss value is a case sensitive URL using the https scheme that contains scheme, host, and optionally, port
    ///     number and path components and no query or fragment components.
    /// </remarks>
    public const string Iss = "iss";

    /// <summary>
    ///     A random string used to link the client request with the ID token. (value: "nonce").
    /// </summary>
    /// <remarks>
    ///     String value used to associate a Client session with an ID Token, and to mitigate replay attacks. The value is
    ///     passed through unmodified from the Authentication Request to the ID Token. If present in the ID Token, Clients MUST
    ///     verify that the nonce Claim Value is equal to the value of the nonce parameter sent in the Authentication Request.
    ///     If present in the Authentication Request, Authorization Servers MUST include a nonce Claim in the ID Token with the
    ///     Claim Value being the nonce value sent in the Authentication Request. Authorization Servers SHOULD perform no other
    ///     processing on nonce values used. The nonce value is a case sensitive string.
    /// </remarks>
    public const string Nonce = "nonce";

    /// <summary>
    ///     The object identifier for the user in Azure AD. (value: "iat").
    /// </summary>
    /// <remarks>
    ///     This value is the immutable and non-reusable identifier of the user. Use this value, not email, as a unique
    ///     identifier for users; email addresses can change. If you use the Azure AD Graph API in your app, object ID is that
    ///     value used to query profile information. (value: "oid").
    /// </remarks>
    public const string Oid = "oid";

    /// <summary>
    ///     Subject Identifier. A locally unique and never reassigned identifier within the Issuer for the End-User. (value:
    ///     "sub").
    /// </summary>
    /// <remarks>
    ///     A locally unique and never reassigned identifier within the Issuer for the End-User, which is
    ///     intended to be consumed by the Client, e.g., 24400320 or AItOawmwtWwcT0k51BayewNvutrJUqsvl6qs7A4. It MUST NOT
    ///     exceed 255 ASCII characters in length. The sub value is a case sensitive string.
    /// </remarks>
    public const string Sub = "sub";

    /// <summary>
    ///     The user's birthdate in the format 'YYYY-MM-DD'. (value: "birthdate").
    /// </summary>
    /// <remarks>
    ///     End-User's birthday, represented as an ISO 8601:2004 [ISO8601‑2004] YYYY-MM-DD format. The year MAY be 0000,
    ///     indicating that it is omitted. To represent only the year, YYYY format is allowed. Note that depending on the
    ///     underlying platform's date related function, providing just year can result in varying month and day, so the
    ///     implementers need to take this factor into account to correctly process the dates.
    /// </remarks>
    public const string Birthdate = "birthdate";

    /// <summary>
    ///     The user's email address. (value: "email").
    /// </summary>
    /// <remarks>
    ///     End-User's preferred e-mail address. Its value MUST conform to the RFC 5322 [RFC5322] addr-spec syntax. The RP MUST
    ///     NOT rely upon this value being unique, as discussed in Section 5.7.
    /// </remarks>
    public const string Email = "email";

    /// <summary>
    ///     A boolean value indicating whether the user's email address has been verified. (value: "email_verified").
    /// </summary>
    /// <remarks>
    ///     True if the End-User's e-mail address has been verified; otherwise false. When this Claim Value is true, this means
    ///     that the OP took affirmative steps to ensure that this e-mail address was controlled by the End-User at the time
    ///     the verification was performed. The means by which an e-mail address is verified is context-specific, and dependent
    ///     upon the trust framework or contractual agreements within which the parties are operating.
    /// </remarks>
    public const string EmailVerified = "email_verified";

    /// <summary>
    ///     The user's family or last name. (value: "family_name").
    /// </summary>
    /// <remarks>
    ///     Surname(s) or last name(s) of the End-User. Note that in some cultures, people can have multiple family names or no
    ///     family name; all can be present, with the names being separated by space characters.
    /// </remarks>
    public const string FamilyName = "family_name";

    /// <summary>
    ///     The user's gender, e.g., 'male', 'female', or 'other'. (value: "gender").
    /// </summary>
    /// <remarks>
    ///     End-User's gender. Values defined by this specification are female and male. Other values MAY be used when neither
    ///     of the defined values are applicable.
    /// </remarks>
    public const string Gender = "gender";

    /// <summary>
    ///     The user's given or first name. (value: "given_name").
    /// </summary>
    /// <remarks>
    ///     Given name(s) or first name(s) of the End-User. Note that in some cultures, people can have multiple given names;
    ///     all can be present, with the names being separated by space characters.
    /// </remarks>
    public const string GivenName = "given_name";

    /// <summary>The user's preferred language and locale, e.g., 'en-US'. (value: "locale").</summary>
    /// <remarks>
    ///     End-User's locale, represented as a
    ///     <a href="https://openid.net/specs/openid-connect-core-1_0.html#RFC5646">BCP47</a>[RFC5646] language tag. This is
    ///     typically an <a href="https://openid.net/specs/openid-connect-core-1_0.html#ISO639-1">ISO 639-1 Alpha-2</a>
    ///     [ISO639‑1] language code in lowercase and an
    ///     <a href="https://openid.net/specs/openid-connect-core-1_0.html#ISO3166-1">ISO 3166-1 Alpha-2</a> [ISO3166‑1]
    ///     country code in uppercase, separated by a dash. For example, en-US or fr-CA. As a compatibility note, some
    ///     implementations have used an underscore as the separator rather than a dash, for example, en_US; Relying Parties
    ///     MAY choose to accept this locale syntax as well.
    /// </remarks>
    public const string Locale = "locale";

    /// <summary>
    ///     The user's middle name. (value: "middle_name").
    /// </summary>
    /// <remarks>
    ///     Middle name(s) of the End-User. Note that in some cultures, people can have multiple middle names; all can be
    ///     present, with the names being separated by space characters. Also note that in some cultures, middle names are not
    ///     used.
    /// </remarks>
    public const string MiddleName = "middle_name";

    /// <summary>
    ///     The user's full name. (value: "name").
    /// </summary>
    /// <remarks>
    ///     End-User's full name in displayable form including all name parts, possibly including titles and suffixes, ordered
    ///     according to the End-User's locale and preferences.
    /// </remarks>
    public const string Name = "name";

    /// <summary>
    ///     The user's nickname or preferred username. (value: "nickname").
    /// </summary>
    /// <remarks>
    ///     Casual name of the End-User that may or may not be the same as the given_name. For instance, a nickname value of
    ///     Mike might be returned alongside a given_name value of Michael.
    /// </remarks>
    public const string Nickname = "nickname";

    /// <summary>The user's phone number. (value: "phone_number").</summary>
    /// <remarks>
    ///     End-User's preferred telephone number.
    ///     <a href="https://openid.net/specs/openid-connect-core-1_0.html#E.164">E.164</a> is RECOMMENDED as the format of
    ///     this Claim, for example, +1
    ///     (425) 555-1212 or +56 (2) 687 2400. If the phone number contains an extension, it is RECOMMENDED that the extension
    ///     be represented using the <a href="https://openid.net/specs/openid-connect-core-1_0.html#RFC3966">RFC 3966</a>
    ///     extension syntax, for example, +1 (604) 555-1234;ext=5678.
    /// </remarks>
    public const string PhoneNumber = "phone_number";

    /// <summary>
    ///     A boolean value indicating whether the user's phone number has been verified. (value: "phone_number_verified").
    /// </summary>
    /// <remarks>
    ///     True if the End-User's phone number has been verified; otherwise false. When this Claim Value is true, this means
    ///     that the OP took affirmative steps to ensure that this phone number was controlled by the End-User at the time the
    ///     verification was performed. The means by which a phone number is verified is context-specific, and dependent upon
    ///     the trust framework or contractual agreements within which the parties are operating. When true, the phone_number
    ///     Claim MUST be in E.164 format and any extensions MUST be represented in RFC 3966 format.
    /// </remarks>
    public const string PhoneNumberVerified = "phone_number_verified";

    /// <summary>
    ///     A URL pointing to the user's profile picture. (value: "picture").
    /// </summary>
    /// <remarks>
    ///     URL of the End-User's profile picture. This URL MUST refer to an image file (for example, a PNG, JPEG, or GIF image
    ///     file), rather than to a Web page containing an image. Note that this URL SHOULD specifically reference a profile
    ///     photo of the End-User suitable for displaying when describing the End-User, rather than an arbitrary photo taken by
    ///     the End-User.
    /// </remarks>
    public const string Picture = "picture";

    /// <summary>
    ///     The user's preferred username for the application. (value: "preferred_username").
    /// </summary>
    /// <remarks>
    ///     Shorthand name by which the End-User wishes to be referred to at the RP, such as janedoe or j.doe. This value MAY
    ///     be any valid JSON string including special characters such as @, /, or whitespace.
    /// </remarks>
    public const string PreferredUsername = "preferred_username";

    /// <summary>
    ///     A URL pointing to the user's public profile page. (value: "profile").
    /// </summary>
    /// <remarks>
    ///     URL of the End-User's profile page. The contents of this Web page SHOULD be about the End-User.
    /// </remarks>
    public const string Profile = "profile";

    /// <summary>
    ///     A timestamp indicating when the user's information was last updated. (value: "updated_at").
    /// </summary>
    /// <remarks>
    ///     Time the End-User's information was last updated. Its value is a JSON number representing the number of seconds
    ///     from 1970-01-01T0:0:0Z as measured in UTC until the date/time.
    /// </remarks>
    public const string UpdatedAt = "updated_at";

    /// <summary>
    ///     A URL pointing to the user's personal website or blog. (value: "website").
    /// </summary>
    /// <remarks>
    ///     URL of the End-User's Web page or blog. This Web page SHOULD contain information published by the End-User or an
    ///     organization that the End-User is affiliated with.
    /// </remarks>
    public const string Website = "website";

    /// <summary>The user's preferred time zone, e.g., 'America/Los_Angeles'. (value: "zoneinfo").</summary>
    /// <remarks>
    ///     String from <a href="https://openid.net/specs/openid-connect-core-1_0.html#zoneinfo">zoneinfo</a> time zone
    ///     database
    ///     representing the End-User's time zone. For example, Europe/Paris or America/Los_Angeles.
    /// </remarks>
    public const string Zoneinfo = "zoneinfo";
}