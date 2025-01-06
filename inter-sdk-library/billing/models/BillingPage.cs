namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code BillingPage} class represents a paginated response containing a
/// collection of retrieved billings.
/// <para> 
/// It includes details about the total number of pages, total elements,
/// and information indicating whether it is the first or last page. Additionally, it
/// holds a list of retrieved billing information. This structure supports pagination
/// in the billing retrieval processes.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingPage : AbstractModel
{
    /// <summary> The total number of pages available. </summary>
    [JsonPropertyName("totalPaginas")]
    public int? TotalPages { get; set; }

    /// <summary> The total number of elements (billings) available. </summary>
    [JsonPropertyName("totalElementos")]
    public int? TotalElements { get; set; }

    /// <summary> Indicates whether this is the last page of results. </summary>
    [JsonPropertyName("ultimaPagina")]
    public bool? LastPage { get; set; }

    /// <summary> Indicates whether this is the first page of results. </summary>
    [JsonPropertyName("primeiraPagina")]
    public bool? FirstPage { get; set; }

    /// <summary> The size of the page, indicating how many elements are displayed per page. </summary>
    [JsonPropertyName("tamanhoPagina")]
    public int? PageSize { get; set; }

    /// <summary> The number of elements on the current page. </summary>
    [JsonPropertyName("numeroDeElementos")]
    public int? NumberOfElements { get; set; }

    /// <summary> A list of retrieved billing information. </summary>
    [JsonPropertyName("cobrancas")]
    public List<RetrievedBillingCollectionUnit> Billings { get; set; }

    /// <summary> Returns the quantity of pages available. </summary>
    public int GetPageNumber()
    {
        return TotalPages ?? 0; // Retorna 0 se TotalPages for nulo
    }

    /// <summary> Constructs a new BillingPage with specified values. </summary>
    /// <param name="totalPages"> The total number of pages available </param>
    /// <param name="totalElements"> The total number of elements (billings) available </param>
    /// <param name="lastPage"> Indicates whether this is the last page of results </param>
    /// <param name="firstPage"> Indicates whether this is the first page of results </param>
    /// <param name="pageSize"> The size of the page </param>
    /// <param name="numberOfElements"> The number of elements on the current page </param>
    /// <param name="billings"> A list of retrieved billing information </param>
    public BillingPage(int? totalPages,
                       int? totalElements,
                       bool? lastPage,
                       bool? firstPage,
                       int? pageSize,
                       int? numberOfElements,
                       List<RetrievedBillingCollectionUnit> billings)
    {
        TotalPages = totalPages;
        TotalElements = totalElements;
        LastPage = lastPage;
        FirstPage = firstPage;
        PageSize = pageSize;
        NumberOfElements = numberOfElements;
        Billings = billings;
    }

    /// <summary> Default constructor </summary>
    public BillingPage() { }
}
