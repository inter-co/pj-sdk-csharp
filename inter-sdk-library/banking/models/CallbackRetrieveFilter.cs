namespace inter_sdk_library;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

/// <summary>
/// The {@code CallbackRetrieveFilter} class represents a filter for
/// fetching callbacks.
/// <para> This class includes details such as transaction code
/// and end-to-end ID, allowing clients to specify criteria for
/// retrieving specific callback information.
/// </para>
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class CallbackRetrieveFilter : AbstractModel
{
    /// <summary> The transaction code associated with the callback. </summary>
    [JsonPropertyName("codigoTransacao")]
    public string TransactionCode { get; set; }

    /// <summary> The end-to-end ID of the transaction. </summary>
    [JsonPropertyName("endToEnd")]
    public string EndToEndId { get; set; }

    /// <summary> Default constructor </summary>
    public CallbackRetrieveFilter() { }

    /// <summary> Constructs a new CallbackRetrieveFilter with specified values. </summary>
    /// <param name="transactionCode"> The transaction code associated with the callback </param>
    /// <param name="endToEndId"> The end-to-end ID of the transaction </param>
    public CallbackRetrieveFilter(string transactionCode, string endToEndId)
    {
        TransactionCode = transactionCode;
        EndToEndId = endToEndId;
    }
}
