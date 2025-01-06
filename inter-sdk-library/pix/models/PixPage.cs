namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code PixPage} class represents a paginated response containing
/// a list of PIX transactions. It includes parameters for pagination,
/// a list of PIX entries.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixPage : AbstractModel
{
    /// <summary> Parameters related to the pagination and filtering of the PIX transactions. </summary>
    [JsonPropertyName("parametros")]
    public Parameters Parameters { get; set; }

    /// <summary> A list of PIX transactions. </summary>
    [JsonPropertyName("pix")]
    public List<Pix> PixList { get; set; }

    /// <summary> Returns the total number of pages for the PIX response. </summary>
    /// <returns> the total number of pages, or 0 if parameters or pagination details are not available. </returns>
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

    /// <summary> Constructs a new PixPage with specified values. </summary>
    /// <param _name_="_parameters_"> The parameters associated with the request for PIX transactions </param>
    /// <param _name_="_pixList_"> A list of PIX transactions in this page response </param>
    public PixPage(Parameters parameters, List<Pix> pixList) : base()
    {
        Parameters = parameters;
        PixList = pixList;
    }

    /// <summary> Default constructor </summary>
    public PixPage() { }
}
