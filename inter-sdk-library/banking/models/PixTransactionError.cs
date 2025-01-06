namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code PixTransactionError} class represents an error
/// encountered during a Pix transaction.
/// <para> 
/// This class encapsulates details about the error, including
/// error codes and descriptions, which can assist in diagnosing 
/// issues that occurred during the transaction process.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixTransactionError : AbstractModel
{
    /// <summary> The error code associated with the transaction error. </summary>
    [JsonPropertyName("codigoErro")]
    public string ErrorCode { get; set; }

    /// <summary> A description of the error encountered. </summary>
    [JsonPropertyName("descricaoErro")]
    public string ErrorDescription { get; set; }

    /// <summary> A complementary error code providing additional context. </summary>
    [JsonPropertyName("codigoErroComplementar")]
    public string ComplementaryErrorCode { get; set; }

    /// <summary> Constructs a new PixTransactionError with specified values. </summary>
    /// <param name="errorCode"> The error code associated with the transaction error </param>
    /// <param name="errorDescription"> A description of the error encountered </param>
    /// <param name="complementaryErrorCode"> A complementary error code providing additional context </param>
    public PixTransactionError(string errorCode, string errorDescription, string complementaryErrorCode)
    {
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
        ComplementaryErrorCode = complementaryErrorCode;
    }

    /// <summary> Default constructor </summary>
    public PixTransactionError() { }
}
