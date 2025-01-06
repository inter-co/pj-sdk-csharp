namespace inter_sdk_library;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code Mora} class represents the interest applied to an overdue
/// payment.
/// <para> 
/// It includes details such as the interest code, the percentage rate
/// of the interest, and the total amount of the interest. This class is used
/// to map data from a JSON structure, allowing the deserialization of
/// received information.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Mora : AbstractModel
{
    /// <summary> The interest code that categorizes the type of interest. </summary>
    [JsonPropertyName("codigo")]
    public string Code { get; set; }

    /// <summary> The percentage rate of the interest. </summary>
    [JsonPropertyName("taxa")]
    public decimal? Rate { get; set; } // Nullable to match BigDecimal

    /// <summary> The total amount of the interest. </summary>
    [JsonPropertyName("valor")]
    public decimal? Value { get; set; } // Nullable to match BigDecimal

    /// <summary> Constructs a new Mora with specified values. </summary>
    /// <param name="code"> The interest code </param>
    /// <param name="rate"> The percentage rate of the interest </param>
    /// <param name="value"> The total amount of the interest </param>
    public Mora(string code, decimal? rate, decimal? value)
    {
        Code = code;
        Rate = rate;
        Value = value;
    }

    /// <summary> Default constructor </summary>
    public Mora() { }
}
