namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code LocationPage} class represents a paginated response
/// containing a list of locations. It includes parameters for
/// pagination, a list of locations, and supports additional
/// custom fields through a map.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class LocationPage : AbstractModel
{
    /// <summary> Parameters related to the response. </summary>
    [JsonPropertyName("parametros")]
    public Parameters Parameters { get; set; }

    /// <summary> A list of locations included in the response. </summary>
    [JsonPropertyName("loc")]
    public List<Location> Locations { get; set; }

    /// <summary> Returns the total number of pages for the locations response. </summary>
    /// <returns> the current page or 0 if parameters or pagination details are not available. </returns>
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

    /// <summary> Constructs a new LocationPage with specified values. </summary>
    /// <param _name_="_parameters_"> The parameters related to the response </param>
    /// <param _name_="_locations_"> A list of locations included in the response </param>
    public LocationPage(Parameters parameters, List<Location> locations) : base()
    {
        Parameters = parameters;
        Locations = locations;
    }

    /// <summary> Default constructor </summary>
    public LocationPage() { }
}
