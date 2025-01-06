namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code CobMoment} class represents the moments associated
/// with a charge, specifically the request and liquidation dates.
///
/// <p> This class provides a structure for holding important
/// timestamps related to the charging process.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class CobMoment : AbstractModel
{
    /// <summary> The date and time when the charge request was made. </summary>
    [JsonPropertyName("solicitacao")]
    public DateTime? Request { get; set; }

    /// <summary> The date and time when the charge was liquidated. </summary>
    [JsonPropertyName("liquidacao")]
    public DateTime? Liquidation { get; set; }

    /// <summary> Constructs a new CobMoment with specified values. </summary>
    /// <param _name_="_request_"> The date and time when the charge request was made </param>
    /// <param _name_="_liquidation_"> The date and time when the charge was liquidated </param>
    public CobMoment(DateTime? request, DateTime? liquidation)
    {
        Request = request;
        Liquidation = liquidation;
    }

    /// <summary> Default constructor </summary>
    public CobMoment() { }
}
