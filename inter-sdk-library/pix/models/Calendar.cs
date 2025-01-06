namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Calendar} class represents the details of a calendar entry
/// related to a transaction.
///
/// <p> It includes fields for the expiration period and created
/// date, allowing for effective management of transaction timelines.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Calendar : AbstractModel
{
    /// <summary> The expiration period for the transaction. </summary>
    [JsonPropertyName("expiracao")]
    public int? Expiration { get; set; }

    /// <summary> The date when the transaction was created. </summary>
    [JsonPropertyName("criacao")]
    public DateTime? CreationDate { get; set; }

    /// <summary> Constructs a new Calendar with specified values. </summary>
    /// <param _name_="_expiration_"> The expiration period for the transaction </param>
    /// <param _name_="_creationDate_"> The date when the transaction was created </param>
    public Calendar(int? expiration, DateTime? creationDate)
    {
        Expiration = expiration;
        CreationDate = creationDate;
    }

    /// <summary> Default constructor </summary>
    public Calendar() { }
}
