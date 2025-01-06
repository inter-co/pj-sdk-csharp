namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DueBillingBatchPage} class represents a paginated
/// response for due billing batches.
///
/// <p> It includes fields for request parameters and
/// a list of batches, allowing for easy access to pagination
/// information and additional dynamic fields.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DueBillingBatchPage : AbstractModel
{
    /// <summary> The parameters associated with the request. </summary>
    [JsonPropertyName("parametros")]
    public Parameters Parameters { get; set; }

    /// <summary> A list of due billing batches in this page response. </summary>
    [JsonPropertyName("lotes")]
    public List<DueBillingBatch> Batches { get; set; }

    /// <summary> Returns the total number of pages for the billing due response. </summary>
    /// <returns> the total number of pages, or 0 if parameters or pagination details are not available. </returns>
    public int GetTotalPages()
    {
        if (Parameters == null || Parameters.Pagination == null)
        {
            return 0;
        }
        return Parameters.Pagination.TotalPages;
    }

    /// <summary> Constructs a new DueBillingBatchPage with specified values. </summary>
    /// <param _name_="_parameters_"> The parameters associated with the request </param>
    /// <param _name_="_batches_"> A list of due billing batches in this page response </param>
    public DueBillingBatchPage(Parameters parameters, List<DueBillingBatch> batches) : base()
    {
        Parameters = parameters;
        Batches = batches;
    }

    /// <summary> Default constructor </summary>
    public DueBillingBatchPage() { }
}
