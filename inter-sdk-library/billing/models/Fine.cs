namespace inter_sdk_library;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a fine with a specific code, rate, and value.
/// <para> 
/// This class allows you to define a fine that can have a unique code,
/// a specified rate, and a monetary value. It also supports
/// additional fields, which can be used to store any extra information
/// related to the fine in a flexible manner.
/// </para>
/// <para> 
/// All fields are serializable to and from JSON format using Jackson
/// annotations. The {@code additionalFields} map allows for dynamic fields
/// that are not strictly defined within the class.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Fine : AbstractModel
{
    /// <summary> The code of the fine. </summary>
    [JsonPropertyName("codigo")]
    public string Code { get; set; }

    /// <summary> The rate of the fine. </summary>
    [JsonPropertyName("taxa")]
    public decimal? Rate { get; set; } // Nullable to match BigDecimal

    /// <summary> The value of the fine. </summary>
    [JsonPropertyName("valor")]
    public decimal? Value { get; set; } // Nullable to match BigDecimal

    /// <summary> Constructs a new Fine with specified values. </summary>
    /// <param name="code"> The code of the fine </param>
    /// <param name="rate"> The rate of the fine </param>
    /// <param name="value"> The value of the fine </param>
    public Fine(string code, decimal? rate, decimal? value)
    {
        Code = code;
        Rate = rate;
        Value = value;
    }

    /// <summary> Default constructor </summary>
    public Fine() { }
}
