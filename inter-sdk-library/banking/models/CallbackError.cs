namespace inter_sdk_library;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Represents an error callback response.
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class CallbackError : AbstractModel
{
    /// <summary> The error code associated with the callback error. </summary>
    [JsonPropertyName("codigoErro")]
    public string ErrorCode { get; set; }

    /// <summary> The description of the callback error. </summary>
    [JsonPropertyName("descricaoErro")]
    public string ErrorDescription { get; set; }

    /// <summary> Default constructor </summary>
    public CallbackError() { }

    /// <summary> Constructs a new CallbackError with specified values. </summary>
    /// <param name="errorCode"> The error code associated with the callback error </param>
    /// <param name="errorDescription"> The description of the callback error </param>
    public CallbackError(string errorCode, string errorDescription)
    {
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
    }
}
