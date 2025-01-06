namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code PixFine} class represents the details of a penalty or
/// fine imposed on a transaction. It includes fields for the modality
/// of the fine (indicating the type or category) and the value or percentage
/// to be applied.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixFine : AbstractModel
{
    /// <summary> The modality of the fine. </summary>
    [JsonPropertyName("modalidade")]
    public int? Modality { get; set; }

    /// <summary> The value or percentage associated with the fine. </summary>
    [JsonPropertyName("valorPerc")]
    public string ValuePercentage { get; set; }

    /// <summary> Constructs a new PixFine with specified values. </summary>
    /// <param _name_="_modality_"> The modality of the fine </param>
    /// <param _name_="_valuePercentage_"> The value or percentage associated with the fine </param>
    public PixFine(int? modality, string valuePercentage) : base()
    {
        Modality = modality;
        ValuePercentage = valuePercentage;
    }

    /// <summary> Default constructor </summary>
    public PixFine() { }
}
