namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents detailed information about an enriched financial transaction.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para>
/// The class includes a field for the detail type. It overrides Equals, GetHashCode,
/// and ToString methods to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/> 
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class EnrichedTransactionDetails : AbstractModel
{
    /// <summary> The type of the detail. </summary>
    [JsonPropertyName("tipoDetalhe")]
    public string DetailType { get; set; }

    /// <summary> Constructs a new EnrichedTransactionDetails with the specified detail type. </summary>
    /// <param name="detailType"> The type of the detail </param>
    public EnrichedTransactionDetails(string detailType)
    {
        DetailType = detailType;
    }

    /// <summary> Default constructor </summary>
    public EnrichedTransactionDetails() { }
}
