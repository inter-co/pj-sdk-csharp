namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Location} class represents information about a payment location
/// in a billing system. It includes fields such as the type of billing
/// (CobType), a unique identifier for the location, the actual location
/// value, and the creation date of the location entry. Additionally, it
/// allows for the inclusion of any extra fields through a map for dynamic
/// attributes that may not be predefined. This structure is essential for
/// managing payment locations in the context of financial transactions.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Location : AbstractModel
{
    /// <summary> The type of billing associated with the location. </summary>
    [JsonPropertyName("tipoCob")]
    public string BillingType { get; set; }

    /// <summary> The unique identifier for the location. </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; } // Changed to long? to handle possible nulls

    /// <summary> The actual location value. </summary>
    [JsonPropertyName("location")]
    public string LocationValue { get; set; }

    /// <summary> The creation date of the location entry. </summary>
    [JsonPropertyName("criacao")]
    public DateTime? CreationDate { get; set; } // Changed to DateTime? to handle possible nulls

    /// <summary> The transaction ID associated with the location. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }

    /// <summary> Constructs a new Location with specified values. </summary>
    /// <param _name_="_billingType_"> The type of billing associated with the location </param>
    /// <param _name_="_id_"> The unique identifier for the location </param>
    /// <param _name_="_location_"> The actual location value </param>
    /// <param _name_="_creationDate_"> The creation date of the location entry </param>
    /// <param _name_="_txid_"> The transaction ID associated with the location </param>
    public Location(string billingType, long? id, string location, DateTime? creationDate, string txid) : base()
    {
        BillingType = billingType;
        Id = id;
        LocationValue = location;
        CreationDate = creationDate;
        Txid = txid;
    }

    /// <summary> Default constructor </summary>
    public Location() { }
}
