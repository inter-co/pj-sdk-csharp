namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code AdditionalInfo} class represents extra information
/// that can be associated with a transaction or entity.
///
/// <p> It includes fields for the name and value of the
/// additional information, allowing enhanced details to be captured
/// within the transaction context.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class AdditionalInfo : AbstractModel
{
    /// <summary> The name of the additional information. </summary>
    [JsonPropertyName("nome")]
    public string Name { get; set; }

    /// <summary> The value of the additional information. </summary>
    [JsonPropertyName("valor")]
    public string Value { get; set; }

    /// <summary> Constructs a new AdditionalInfo with specified values. </summary>
    /// <param _name_="_name_"> The name of the additional information </param>
    /// <param _name_="_value_"> The value of the additional information </param>
    public AdditionalInfo(string name, string value)
    {
        Name = name;
        Value = value;
    }

    /// <summary> Default constructor </summary>
    public AdditionalInfo() { }
}
