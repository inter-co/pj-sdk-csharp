namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Fees} class represents the details of fees applied
/// to a transaction. It includes fields for the modality of the fees
/// (indicating the type or category) and the value or percentage
/// associated with the fees.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Fees : AbstractModel
{
    /// <summary> The modality of the fees. </summary>
    [JsonPropertyName("modalidade")]
    public int? Modality { get; set; }

    /// <summary> The value or percentage associated with the fees. </summary>
    [JsonPropertyName("valorPerc")]
    public string ValuePercentage { get; set; }

    /// <summary> Constructs a new Fees with specified values. </summary>
    /// <param _name_="_modality_"> The modality of the fees </param>
    /// <param _name_="_valuePercentage_"> The value or percentage associated with the fees </param>
    public Fees(int? modality, string valuePercentage) : base()
    {
        Modality = modality;
        ValuePercentage = valuePercentage;
    }

    /// <summary> Default constructor </summary>
    public Fees() { }
}
