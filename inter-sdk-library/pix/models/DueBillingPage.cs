namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DueBillingPage} class represents a paginated response
/// containing detailed billing information that is due for payment.
///
/// <p> It includes parameters for pagination, a list of detailed
/// due billings, and supports additional custom fields through a map.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DueBillingPage : AbstractModel
{
    /// <summary> The parameters associated with the request for due billings. </summary>
    [JsonPropertyName("parametros")]
    public Parameters Parameters { get; set; }

    /// <summary> A list of detailed due billings in this page response. </summary>
    [JsonPropertyName("cobs")]
    public List<DetailedDuePixBilling> DueBillings { get; set; }

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

    /// <summary> Constructs a new DueBillingPage with specified values. </summary>
    /// <param _name_="_parameters_"> The parameters associated with the request for due billings </param>
    /// <param _name_="_dueBillings_"> A list of detailed due billings in this page response </param>
    public DueBillingPage(Parameters parameters, List<DetailedDuePixBilling> dueBillings) : base()
    {
        Parameters = parameters;
        DueBillings = dueBillings;
    }

    /// <summary> Default constructor </summary>
    public DueBillingPage() { }
}
