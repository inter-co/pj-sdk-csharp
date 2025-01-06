namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code FixedDateDiscount} class represents a discount
/// that applies to a specific date. It includes fields for
/// the percentage value of the discount and the associated date.
/// This structure is useful for managing fixed-date discounts
/// within a financial or sales system.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class FixedDateDiscount : AbstractModel
{
    /// <summary> The percentage value of the discount. </summary>
    [JsonPropertyName("valorPerc")]
    public string ValuePercentage { get; set; }

    /// <summary> The associated date for the discount. </summary>
    [JsonPropertyName("data")]
    public string Date { get; set; }

    /// <summary> Constructs a new FixedDateDiscount with specified values. </summary>
    /// <param _name_="_valuePercentage_"> The percentage value of the discount </param>
    /// <param _name_="_date_"> The associated date for the discount </param>
    public FixedDateDiscount(string valuePercentage, string date) : base()
    {
        ValuePercentage = valuePercentage;
        Date = date;
    }

    /// <summary> Default constructor </summary>
    public FixedDateDiscount() { }
}
