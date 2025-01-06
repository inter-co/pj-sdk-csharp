namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code CallbackRetrieveFilter} class is used to filter callback requests
/// based on specific criteria, such as the transaction ID (txid).
///
/// <p> This class provides a structured way to specify filters
/// when retrieving callback data, allowing for efficient searches based
/// on transaction identifiers.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixCallbackRetrieveFilter : AbstractModel
{
    /// <summary> The transaction ID to filter callback requests. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }

    /// <summary> Constructs a new CallbackRetrieveFilter with specified values. </summary>
    /// <param _name_="_txid_"> The transaction ID to filter callback requests </param>
    public PixCallbackRetrieveFilter(string txid)
    {
        Txid = txid;
    }

    /// <summary> Default constructor </summary>
    public PixCallbackRetrieveFilter() { }
}
