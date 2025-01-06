namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code CallbackPage} class represents a paginated response
/// for callbacks.
/// <para> This class includes details such as total pages, total
/// elements, current page status, page size, number of elements,
/// and the data for the current page.
/// </para>
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class CallbackPage : AbstractModel
{
    /// <summary> The total number of pages available in the response. </summary>
    [JsonPropertyName("totalPaginas")]
    public int? TotalPages { get; set; }

    /// <summary> The total number of elements across all pages. </summary>
    [JsonPropertyName("totalElementos")]
    public int? TotalElements { get; set; }

    /// <summary> Indicates if the current page is the last page. </summary>
    [JsonPropertyName("ultimaPagina")]
    public bool? LastPage { get; set; }

    /// <summary> Indicates if the current page is the first page. </summary>
    [JsonPropertyName("primeiraPagina")]
    public bool? FirstPage { get; set; }

    /// <summary> The size of each page, i.e., the maximum number of elements. </summary>
    [JsonPropertyName("tamanhoPagina")]
    public int? PageSize { get; set; }

    /// <summary> The number of elements on the current page. </summary>
    [JsonPropertyName("numeroDeElementos")]
    public int? NumberOfElements { get; set; }

    /// <summary> A list of callback response data for the current page. </summary>
    [JsonPropertyName("data")]
    public List<RetrieveCallbackResponse> Data { get; set; }

    /// <summary> Returns the total number of pages. </summary>
    /// <returns> the total number of pages available in the response. </returns>
    public int? GetNumberOfPages()
    {
        return TotalPages;
    }

    /// <summary> Constructs a new CallbackPage with specified values. </summary>
    /// <param name="totalPages"> The total number of pages available in the response </param>
    /// <param name="totalElements"> The total number of elements across all pages </param>
    /// <param name="lastPage"> Indicates if the current page is the last page </param>
    /// <param name="firstPage"> Indicates if the current page is the first page </param>
    /// <param name="pageSize"> The size of each page </param>
    /// <param name="numberOfElements"> The number of elements on the current page </param>
    /// <param name="data"> A list of callback response data for the current page </param>
    public CallbackPage(int? totalPages, int? totalElements, bool? lastPage, bool? firstPage, int? pageSize, int? numberOfElements, List<RetrieveCallbackResponse> data)
    {
        TotalPages = totalPages;
        TotalElements = totalElements;
        LastPage = lastPage;
        FirstPage = firstPage;
        PageSize = pageSize;
        NumberOfElements = numberOfElements;
        Data = data;
    }

    public CallbackPage () {}
}
