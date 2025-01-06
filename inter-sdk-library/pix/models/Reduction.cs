namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Reduction} class represents the details of a discount
/// applicable to a transaction. It includes fields for the modality
/// of the discount (indicating the type or category) and the value or
/// percentage of the discount applied. This structure is important for
/// managing financial discounts within a system.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Reduction : AbstractModel
{
    /// <summary> The modality of the discount. </summary>
    [JsonPropertyName("modalidade")]
    public int? Modality { get; set; } // Changed to int? to allow nulls

    /// <summary> The value or percentage of the discount. </summary>
    [JsonPropertyName("valorPerc")]
    public string ValuePercentage { get; set; }

    /// <summary> Constructs a new Reduction with specified values. </summary>
    /// <param _name_="_modality_"> The modality of the discount </param>
    /// <param _name_="_valuePercentage_"> The value or percentage of the discount </param>
    public Reduction(int? modality, string valuePercentage) : base()
    {
        Modality = modality;
        ValuePercentage = valuePercentage;
    }

    /// <summary> Default constructor </summary>
    public Reduction() { }
}