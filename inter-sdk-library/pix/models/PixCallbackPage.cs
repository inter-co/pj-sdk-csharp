namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code PixCallbackPage} class represents a paginated response
/// of callbacks, containing information about the total number
/// of pages, total elements, flags indicating if it's the
/// first or last page, page size and number of elements in the
/// current page, along with the actual list of callback responses.
/// 
/// <p> This structure is essential for managing and navigating
/// through large sets of callback data effectively.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixCallbackPage : AbstractModel
{
    /// <summary> The total number of pages available for callback responses. </summary>
    [JsonPropertyName("totalPaginas")]
    public int? TotalPages { get; set; }

    /// <summary> The total number of elements across all pages. </summary>
    [JsonPropertyName("totalElementos")]
    public int? TotalElements { get; set; }

    /// <summary> A flag indicating if the current page is the last one. </summary>
    [JsonPropertyName("ultimaPagina")]
    public bool? LastPage { get; set; }

    /// <summary> A flag indicating if the current page is the first one. </summary>
    [JsonPropertyName("primeiraPagina")]
    public bool? FirstPage { get; set; }

    /// <summary> The size of each page in terms of the number of elements. </summary>
    [JsonPropertyName("tamanhoPagina")]
    public int? PageSize { get; set; }

    /// <summary> The number of elements present on the current page. </summary>
    [JsonPropertyName("numeroDeElementos")]
    public int? NumberOfElements { get; set; }

    /// <summary> The actual list of callback responses for the current page. </summary>
    [JsonPropertyName("data")]
    public List<RetrieveCallbackResponse> Data { get; set; }

    /// <summary> Returns the total number of pages for the callback response. </summary>
    /// <returns> the total number of pages or 0 if no pages are specified. </returns>
    public int PageNumber
    {
        get
        {
            return TotalPages ?? 0;
        }
    }

    /// <summary> Constructs a new PixCallbackPage with specified values. </summary>
    /// <param _name_="_totalPages_"> The total number of pages available for callback responses </param>
    /// <param _name_="_totalElements_"> The total number of elements across all pages </param>
    /// <param _name_="_lastPage_"> A flag indicating if the current page is the last one </param>
    /// <param _name_="_firstPage_"> A flag indicating if the current page is the first one </param>
    /// <param _name_="_pageSize_"> The size of each page in terms of the number of elements </param>
    /// <param _name_="_numberOfElements_"> The number of elements present on the current page </param>
    /// <param _name_="_data_"> The actual list of callback responses for the current page </param>
    public PixCallbackPage(int? totalPages, int? totalElements, bool? lastPage, bool? firstPage, int? pageSize, int? numberOfElements, List<RetrieveCallbackResponse> data) : base()
    {
        TotalPages = totalPages;
        TotalElements = totalElements;
        LastPage = lastPage;
        FirstPage = firstPage;
        PageSize = pageSize;
        NumberOfElements = numberOfElements;
        Data = data;
    }

    /// <summary> Default constructor </summary>
    public PixCallbackPage() { }
}
