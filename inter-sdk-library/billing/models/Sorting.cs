namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code Sorting} class represents the sorting criteria used
/// for retrieving billing data.
/// <para> 
/// It includes fields for specifying the order by which
/// the results should be sorted, as well as the type of sorting
/// (ascending or descending). This structure is essential for
/// organizing the output of billing retrieval processes according
/// to user or system preferences.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Sorting : AbstractModel
{
    /// <summary> The criterion by which the results should be ordered. </summary>
    [JsonPropertyName("ordenarPor")]
    public string OrderBy { get; set; }

    /// <summary> The type of sorting to be applied (ascending/descending). </summary>
    [JsonPropertyName("tipoOrdenacao")]
    public string SortType { get; set; }

    /// <summary> Constructs a new Sorting with specified values. </summary>
    /// <param name="orderBy"> The criterion by which the results should be ordered </param>
    /// <param name="sortType"> The type of sorting to be applied </param>
    public Sorting(string orderBy, string sortType)
    {
        OrderBy = orderBy;
        SortType = sortType;
    }

    /// <summary> Default constructor </summary>
    public Sorting() { }
}
