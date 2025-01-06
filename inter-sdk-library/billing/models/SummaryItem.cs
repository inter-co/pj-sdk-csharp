namespace inter_sdk_library;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code SummaryItem} class represents a summary item in a billing
/// context.
/// <para> 
/// It includes fields to capture the status of the item, the
/// quantity of items, and the monetary value associated with it.
/// Additionally, it supports the inclusion of any extra fields through
/// a map for dynamic attributes that may not be predefined. This structure
/// is useful for summarizing detailed billing information.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class SummaryItem : AbstractModel
{
    /// <summary> The status of the summary item. </summary>
    [JsonPropertyName("situacao")]
    public string Situation { get; set; }

    /// <summary> The quantity of items in the summary. </summary>
    [JsonPropertyName("quantidade")]
    public int? Quantity { get; set; } // Nullable to match Integer

    /// <summary> The monetary value associated with the summary item. </summary>
    [JsonPropertyName("valor")]
    public decimal? Value { get; set; } // Nullable to match BigDecimal

    /// <summary> Constructs a new SummaryItem with specified values. </summary>
    /// <param name="situation"> The status of the summary item </param>
    /// <param name="quantity"> The quantity of items </param>
    /// <param name="value"> The monetary value associated with the item </param>
    public SummaryItem(string situation, int? quantity, decimal? value)
    {
        Situation = situation;
        Quantity = quantity;
        Value = value;
    }

    /// <summary> Default constructor </summary>
    public SummaryItem() { }
}
