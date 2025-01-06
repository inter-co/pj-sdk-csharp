namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code BillingRetrievalFilter} class extends the base filter
/// class for retrieving billing information.
/// <para> 
/// It includes pagination details, specifically the page
/// number and the number of items per page. This structure is used
/// to specify filtering criteria when retrieving billing data from a
/// paginated source.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingRetrievalFilter : BaseBillingRetrievalFilter
{
    /// <summary> The current page number for pagination. </summary>
    [JsonPropertyName("pagina")]
    public int Page { get; set; }

    /// <summary> The number of items to display per page. </summary>
    [JsonPropertyName("itensPorPagina")]
    public int ItemsPerPage { get; set; }

    /// <summary> Constructs a new BillingRetrievalFilter with specified values. </summary>
    /// <param name="page"> The current page number for pagination </param>
    /// <param name="itemsPerPage"> The number of items to display per page </param>
    public BillingRetrievalFilter(int page, int itemsPerPage)
    {
        Page = page;
        ItemsPerPage = itemsPerPage;
    }

    /// <summary> Default constructor </summary>
    public BillingRetrievalFilter() { }
}
