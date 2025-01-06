namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

/// <summary>
/// The {@code GetTokenResponse} class represents the response
/// object returned when obtaining an access token from the system.
/// </summary>
/// 
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class GetTokenResponse
{
    /// <summary>
    /// The access token for authentication.
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// The type of the token returned.
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    /// <summary>
    /// The lifetime of the access token in seconds.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int? ExpiresIn { get; set; }

    /// <summary>
    /// The scope of access granted by the token.
    /// </summary>
    [JsonPropertyName("scope")]
    public string Scope { get; set; }

    /// <summary>
    /// The timestamp when the token was created.
    /// </summary>
    public long CreatedAt { get; set; }

    public GetTokenResponse(){}
    
    public GetTokenResponse(string accessToken, string tokenType, int? expiresIn, string scope, long createdAt)
    {
        AccessToken = accessToken;
        TokenType = tokenType;
        ExpiresIn = expiresIn;
        Scope = scope;
        CreatedAt = createdAt;
    }
}
