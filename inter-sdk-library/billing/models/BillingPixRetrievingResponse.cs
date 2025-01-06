namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code BillingPixRetrievingResponse} class represents the response received
/// when retrieving information about a Pix transaction.
/// <para> 
/// It contains the transaction identifier (txid) and the copy-paste
/// string of the Pix payment, allowing for easy transaction retrieval and processing.
/// This structure is utilized to map data from a JSON format, facilitating the
/// deserialization of the information received.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingPixRetrievingResponse : AbstractModel
{
    /// <summary> The transaction identifier for the Pix transaction. </summary>
    [JsonPropertyName("txid")]
    public string TransactionId { get; set; }

    /// <summary> The copy-paste string for the Pix payment. </summary>
    [JsonPropertyName("pixCopiaECola")]
    public string PixCopyAndPaste { get; set; }

    /// <summary> Constructs a new BillingPixRetrievingResponse with specified values. </summary>
    /// <param name="transactionId"> The transaction identifier for the Pix transaction </param>
    /// <param name="pixCopyAndPaste"> The copy-paste string for the Pix payment </param>
    public BillingPixRetrievingResponse(string transactionId, string pixCopyAndPaste)
    {
        TransactionId = transactionId;
        PixCopyAndPaste = pixCopyAndPaste;
    }

    /// <summary> Default constructor </summary>
    public BillingPixRetrievingResponse() { }
}
