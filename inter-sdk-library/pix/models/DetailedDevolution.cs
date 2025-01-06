namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DetailedDevolution} class represents detailed information about a
/// refund process.
///
/// <p> It includes fields such as the refund ID, the return
/// transaction ID (rtrId), the amount of the refund, the current status,
/// and the reason for the refund. Additionally, it supports the inclusion
/// of any extra fields through a map for dynamic attributes that may not be
/// predefined. This structure is essential for managing and processing
/// refund-related information in billing systems.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DetailedDevolution : AbstractModel
{
    /// <summary> The unique identifier for the refund. </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary> The return transaction ID linked to the refund. </summary>
    [JsonPropertyName("rtrId")]
    public string RtrId { get; set; }

    /// <summary> The monetary value of the refund. </summary>
    [JsonPropertyName("valor")]
    public string Value { get; set; }

    /// <summary> The current status of the refund process. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary> The reason for initiating the refund. </summary>
    [JsonPropertyName("motivo")]
    public string Reason { get; set; }

    /// <summary> The nature of the devolution. </summary>
    [JsonPropertyName("natureza")]
    public string Nature { get; set; }

    /// <summary> A description providing additional context about the refund. </summary>
    [JsonPropertyName("descricao")]
    public string Description { get; set; }

    /// <summary> The moment the refund process occurred. </summary>
    [JsonPropertyName("horario")]
    public CobMoment Moment { get; set; }

    /// <summary> Constructs a new DetailedDevolution with specified values. </summary>
    /// <param _name_="_id_"> The unique identifier for the refund </param>
    /// <param _name_="_rtrId_"> The return transaction ID linked to the refund </param>
    /// <param _name_="_value_"> The monetary value of the refund </param>
    /// <param _name_="_status_"> The current status of the refund process </param>
    /// <param _name_="_reason_"> The reason for initiating the refund </param>
    /// <param _name_="_nature_"> The nature of the devolution </param>
    /// <param _name_="_description_"> A description providing additional context about the refund </param>
    /// <param _name_="_moment_"> The moment the refund process occurred </param>
    public DetailedDevolution(string id, string rtrId, string value, string status, string reason, string nature, string description, CobMoment moment)
    {
        Id = id;
        RtrId = rtrId;
        Value = value;
        Status = status;
        Reason = reason;
        Nature = nature;
        Description = description;
        Moment = moment;
    }

    /// <summary> Default constructor </summary>
    public DetailedDevolution() { }
}
