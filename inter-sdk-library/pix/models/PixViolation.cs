namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code PixViolation} class represents a violation related to a
/// financial transaction or business rule. It includes details such
/// as the reason for the violation, the specific property affected,
/// and the value associated with the violation.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixViolation : AbstractModel
{
    /// <summary> The reason for the violation. </summary>
    [JsonPropertyName("razao")]
    public string Reason { get; set; }

    /// <summary> The specific property affected by the violation. </summary>
    [JsonPropertyName("propriedade")]
    public string Property { get; set; }

    /// <summary> The value associated with the violation. </summary>
    [JsonPropertyName("valor")]
    public string Value { get; set; }

    /// <summary> Constructs a new PixViolation with specified values. </summary>
    /// <param _name_="_reason_"> The reason for the violation </param>
    /// <param _name_="_property_"> The specific property affected by the violation </param>
    /// <param _name_="_value_"> The value associated with the violation </param>
    public PixViolation(string reason, string property, string value) : base()
    {
        Reason = reason;
        Property = property;
        Value = value;
    }

    /// <summary> Default constructor </summary>
    public PixViolation() { }
}
