namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

/// <summary>
/// The Violation class represents a violation that occurred
/// during processing, providing details about the reason for the
/// violation, the property involved, and the value that was
/// rejected or erroneous.
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Violation
{
    /// <summary>
    /// The reason for the violation.
    /// </summary>
    [JsonPropertyName("razao")]
    public string Reason { get; set; }

    /// <summary>
    /// The property that is associated with the violation.
    /// </summary>
    [JsonPropertyName("propriedade")]
    public string Property { get; set; }

    /// <summary>
    /// The value that was rejected or caused the violation.
    /// </summary>
    [JsonPropertyName("valor")]
    public string Value { get; set; }

    /// <summary>
    /// Default constructor for Violation.
    /// </summary>
    public Violation() { }

    /// <summary>
    /// Constructor with parameters for Violation.
    /// </summary>
    /// <param name="reason">The reason for the violation</param>
    /// <param name="property">The property associated with the violation</param>
    /// <param name="value">The value that was rejected</param>
    public Violation(string reason, string property, string value)
    {
        Reason = reason;
        Property = property;
        Value = value;
    }
}
