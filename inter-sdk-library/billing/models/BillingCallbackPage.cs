namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code CallbackPage} class represents a paginated response containing
/// a collection of callback responses.
/// <para> 
/// It includes details about the total number of pages, total elements,
/// and indicators for whether it is the first or last page. Additionally, it
/// holds a list of retrieved callback information, supporting pagination for
/// callback retrieval processes.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingCallbackPage : AbstractModel
{
    /// <summary> The total number of pages available. </summary>
    [JsonPropertyName("totalPaginas")]
    public int? TotalPages { get; set; } // Nullable to match Integer

    /// <summary> The total number of elements (callbacks) available. </summary>
    [JsonPropertyName("totalElementos")]
    public int? TotalElements { get; set; } // Nullable to match Integer

    /// <summary> Indicates whether this is the last page of results. </summary>
    [JsonPropertyName("ultimaPagina")]
    public bool? LastPage { get; set; } // Nullable to match Boolean

    /// <summary> Indicates whether this is the first page of results. </summary>
    [JsonPropertyName("primeiraPagina")]
    public bool? FirstPage { get; set; } // Nullable to match Boolean

    /// <summary> The size of the page, indicating how many elements are displayed per page. </summary>
    [JsonPropertyName("size")]
    public int? PageSize { get; set; } // Nullable to match Integer

    /// <summary> The number of elements on the current page. </summary>
    [JsonPropertyName("numberOfElements")]
    public int? NumberOfElements { get; set; } // Nullable to match Integer

    /// <summary> A list of retrieved callback information. </summary>
    [JsonPropertyName("data")]
    public List<BillingRetrieveCallbackResponse> Callbacks { get; set; }

    /// <summary> Returns the quantity of pages available. </summary>
    public int GetPageNumber()
    {
        return TotalPages ?? 0; // Retorna 0 se TotalPages for nulo
    }

    /// <summary> Constructs a new CallbackPage with specified values. </summary>
    /// <param name="totalPages"> The total number of pages available </param>
    /// <param name="totalElements"> The total number of elements (callbacks) available </param>
    /// <param name="lastPage"> Indicates whether this is the last page of results </param>
    /// <param name="firstPage"> Indicates whether this is the first page of results </param>
    /// <param name="pageSize"> The size of the page </param>
    /// <param name="numberOfElements"> The number of elements on the current page </param>
    /// <param name="callbacks"> A list of callbacks </param>
    public BillingCallbackPage(int? totalPages,
                        int? totalElements,
                        bool? lastPage,
                        bool? firstPage,
                        int? pageSize,
                        int? numberOfElements,
                        List<BillingRetrieveCallbackResponse> callbacks)
    {
        TotalPages = totalPages;
        TotalElements = totalElements;
        LastPage = lastPage;
        FirstPage = firstPage;
        PageSize = pageSize;
        NumberOfElements = numberOfElements;
        Callbacks = callbacks;
    }

    /// <summary> Default constructor </summary>
    public BillingCallbackPage() { }
}
