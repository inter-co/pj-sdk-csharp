namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code BillingPage} class represents a paginated response
/// containing detailed billing information, specifically for
/// immediate PIX transactions.
///
/// <p> It includes parameters for pagination, a list of
/// billing entries, and supports additional custom fields through
/// a map. This structure is essential for organizing responses and
/// providing a user-friendly way to navigate through billing data.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixBillingPage : AbstractModel
{
    /// <summary> The parameters associated with the billing response. </summary>
    [JsonPropertyName("parametros")]
    public Parameters Parameters { get; set; }

    /// <summary> A list of detailed billing entries for immediate PIX transactions. </summary>
    [JsonPropertyName("cobs")]
    public List<DetailedImmediatePixBilling> Billings { get; set; }

    /// <summary> Returns the total number of pages for the billing response. </summary>
    public int TotalPages
    {
        get
        {
            if (Parameters == null || Parameters.Pagination == null)
            {
                return 0;
            }
            return Parameters.Pagination.TotalPages;
        }
    }

    /// <summary> Constructs a new BillingPage with specified values. </summary>
    /// <param _name_="_parameters_"> The parameters associated with the billing response </param>
    /// <param _name_="_billings_"> A list of detailed billing entries for immediate PIX transactions </param>
    public PixBillingPage(Parameters parameters, List<DetailedImmediatePixBilling> billings)
    {
        Parameters = parameters;
        Billings = billings;
    }

    /// <summary> Default constructor </summary>
    public PixBillingPage() { }
}
