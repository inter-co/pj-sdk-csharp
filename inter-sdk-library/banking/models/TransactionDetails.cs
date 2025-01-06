namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a transaction detail, which is a specific piece of information about a transaction.
/// <para> 
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para> 
/// The class includes a field for the type of the transaction detail. It overrides Equals, 
/// GetHashCode, and ToString methods to include both its own fields and those of the superclass.
/// </para>
/// </summary>
/// <see cref="AbstractModel"/> 
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class TransactionDetails : AbstractModel
{
    /// <summary> The type of the transaction detail. </summary>
    [JsonPropertyName("tipoDetalhe")]
    public string DetailType { get; set; }

    /// <summary> Constructs a new TransactionDetails with specified values. </summary>
    /// <param name="detailType"> The type of the transaction detail. </param>
    public TransactionDetails(string detailType)
    {
        DetailType = detailType;
    }

    /// <summary> Default constructor </summary>
    public TransactionDetails() { }
}
