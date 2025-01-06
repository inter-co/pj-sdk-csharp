namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code IncludeDueBillingBatchRequest} class represents a request
/// to include a batch of due billings.
///
/// <p> It consists of a description for the batch and a list
/// of due billings to be included in the request.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class IncludeDueBillingBatchRequest : AbstractModel
{
    /// <summary> A description for the batch of due billings. </summary>
    [JsonPropertyName("descricao")]
    public string Description { get; set; }

    /// <summary> A list of due billings to be included in the batch request. </summary>
    [JsonPropertyName("cobsv")]
    public List<DueBilling> DueBillings { get; set; }

    /// <summary> Constructs a new IncludeDueBillingBatchRequest with specified values. </summary>
    /// <param _name_="_description_"> A description for the batch of due billings </param>
    /// <param _name_="_dueBillings_"> A list of due billings to be included in the batch request </param>
    public IncludeDueBillingBatchRequest(string description, List<DueBilling> dueBillings) : base()
    {
        Description = description;
        DueBillings = dueBillings;
    }

    /// <summary> Default constructor </summary>
    public IncludeDueBillingBatchRequest() { }
}
