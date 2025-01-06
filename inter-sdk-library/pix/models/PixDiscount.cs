namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Discount} class represents the details of a discount
/// applicable to a transaction.
///
/// <p> It includes fields for the modality of the discount,
/// the percentage value, and a list of fixed date discounts that
/// may apply.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixDiscount : AbstractModel
{
    /// <summary> The modality of the discount. </summary>
    [JsonPropertyName("modalidade")]
    public string Modality { get; set; }

    /// <summary> The percentage value of the discount. </summary>
    [JsonPropertyName("valorPerc")]
    public string ValuePercentage { get; set; }

    /// <summary> A list of fixed date discounts that may apply. </summary>
    [JsonPropertyName("descontoDataFixa")]
    public List<FixedDateDiscount> FixedDateDiscounts { get; set; }

    /// <summary> Constructs a new Discount with specified values. </summary>
    /// <param _name_="_modality_"> The modality of the discount </param>
    /// <param _name_="_valuePercentage_"> The percentage value of the discount </param>
    /// <param _name_="_fixedDateDiscounts_"> A list of fixed date discounts that may apply </param>
    public PixDiscount(string? modality, string valuePercentage, List<FixedDateDiscount> fixedDateDiscounts) : base()
    {
        Modality = modality;
        ValuePercentage = valuePercentage;
        FixedDateDiscounts = fixedDateDiscounts;
    }

    /// <summary> Default constructor </summary>
    public PixDiscount() { }
}

