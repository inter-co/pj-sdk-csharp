namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Pagination} class represents the pagination details
/// for a collection of items, including the current page, items
/// per page, total number of pages, and total number of items.
/// It also supports additional custom fields via a map of
/// additional attributes.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Pagination : AbstractModel
{
    /// <summary> The current page number in the paginated response. </summary>
    [JsonPropertyName("paginaAtual")]
    public int CurrentPage { get; set; }

    /// <summary> The number of items per page in the paginated response. </summary>
    [JsonPropertyName("itensPorPagina")]
    public int ItemsPerPage { get; set; }

    /// <summary> The total number of pages available in the collection. </summary>
    [JsonPropertyName("quantidadeDePaginas")]
    public int TotalPages { get; set; }

    /// <summary> The total number of items in the collection. </summary>
    [JsonPropertyName("quantidadeTotalDeItens")]
    public int TotalItems { get; set; }

    /// <summary> Constructs a new Pagination with specified values. </summary>
    /// <param _name_="_currentPage_"> The current page number in the paginated response </param>
    /// <param _name_="_itemsPerPage_"> The number of items per page in the paginated response </param>
    /// <param _name_="_totalPages_"> The total number of pages available in the collection </param>
    /// <param _name_="_totalItems_"> The total number of items in the collection </param>
    public Pagination(int currentPage, int itemsPerPage, int totalPages, int totalItems) : base()
    {
        CurrentPage = currentPage;
        ItemsPerPage = itemsPerPage;
        TotalPages = totalPages;
        TotalItems = totalItems;
    }

    /// <summary> Default constructor </summary>
    public Pagination() { }
}