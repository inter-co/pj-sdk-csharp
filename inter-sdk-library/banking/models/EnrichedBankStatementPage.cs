namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a paginated response containing enriched transaction data, including total pages, total elements,
/// last page indicator, first page indicator, page size, number of elements, and a list of transactions.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON, allowing the deserialization of received
/// information. It uses System.Text.Json for JSON mapping.
/// <para>
/// The class includes fields for total pages, total elements, last page indicator, first page indicator, page size,
/// number of elements, and a list of transactions. It overrides Equals, GetHashCode, and ToString methods to include both
/// its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/> 
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class EnrichedBankStatementPage : AbstractModel
{
    /// <summary> The total number of pages. </summary>
    [JsonPropertyName("totalPaginas")]
    public int? TotalPages { get; set; }

    /// <summary> The total number of elements. </summary>
    [JsonPropertyName("totalElementos")]
    public int? TotalElements { get; set; }

    /// <summary> Indicates if this is the last page. </summary>
    [JsonPropertyName("ultimaPagina")]
    public bool? LastPage { get; set; }

    /// <summary> Indicates if this is the first page. </summary>
    [JsonPropertyName("primeiraPagina")]
    public bool? FirstPage { get; set; }

    /// <summary> The size of the page. </summary>
    [JsonPropertyName("tamanhoPagina")]
    public int? PageSize { get; set; }

    /// <summary> The number of elements on the current page. </summary>
    [JsonPropertyName("numeroDeElementos")]
    public int? NumberOfElements { get; set; }

    /// <summary> The list of enriched transactions on the current page. </summary>
    [JsonPropertyName("transacoes")]
    public List<EnrichedTransaction> Transactions { get; set; }

    /// <summary> Constructs a new EnrichedStatementPage with specified values. </summary>
    /// <param name="totalPages"> The total number of pages. </param>
    /// <param name="totalElements"> The total number of elements. </param>
    /// <param name="lastPage"> Indicates if this is the last page. </param>
    /// <param name="firstPage"> Indicates if this is the first page. </param>
    /// <param name="pageSize"> The size of the page. </param>
    /// <param name="numberOfElements"> The number of elements in the current page. </param>
    /// <param name="transactions"> The list of enriched transactions. </param>
    public EnrichedBankStatementPage(int? totalPages, int? totalElements, bool? lastPage, bool? firstPage, int? pageSize, int? numberOfElements, List<EnrichedTransaction> transactions)
    {
        TotalPages = totalPages;
        TotalElements = totalElements;
        LastPage = lastPage;
        FirstPage = firstPage;
        PageSize = pageSize;
        NumberOfElements = numberOfElements;
        Transactions = transactions;
    }

    /// <summary> Default constructor </summary>
    public EnrichedBankStatementPage() { }
}
