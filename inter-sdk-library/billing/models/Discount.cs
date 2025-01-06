namespace inter_sdk_library;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code Discount} class represents a discount applied to a specific
/// transaction.
/// <para> 
/// It includes details such as the discount code, the number of days
/// for which it is valid, the percentage rate of the discount, and the total
/// amount of the discount.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Discount : AbstractModel
{
    /// <summary> The discount code that categorizes the type of discount. </summary>
    [JsonPropertyName("codigo")]
    public string Code { get; set; }

    /// <summary> The number of days the discount is valid. </summary>
    [JsonPropertyName("quantidadeDias")]
    public int? NumberOfDays { get; set; } // Nullable to match Integer

    /// <summary> The percentage rate of the discount. </summary>
    [JsonPropertyName("taxa")]
    public decimal? Rate { get; set; } // Nullable to match BigDecimal

    /// <summary> The total amount of the discount. </summary>
    [JsonPropertyName("valor")]
    public decimal? Value { get; set; } // Nullable to match BigDecimal

    /// <summary> Constructs a new Discount with specified values. </summary>
    /// <param name="code"> The discount code </param>
    /// <param name="numberOfDays"> The number of days the discount is valid </param>
    /// <param name="rate"> The percentage rate of the discount </param>
    /// <param name="value"> The total amount of the discount </param>
    public Discount(string code, int? numberOfDays, decimal? rate, decimal? value)
    {
        Code = code;
        NumberOfDays = numberOfDays;
        Rate = rate;
        Value = value;
    }

    /// <summary> Default constructor </summary>
    public Discount() { }
}
