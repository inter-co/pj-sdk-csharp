namespace inter_sdk_library;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a batch of payment items.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses Newtonsoft.Json
/// for JSON mapping.
/// <para>
/// The class includes fields for a unique identifier and a list of payment items.
/// It overrides Equals, GetHashCode, and ToString methods to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/>
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Batch : AbstractModel
{
    /// <summary> A unique identifier for the batch. </summary>
    [JsonPropertyName("meuIdentificador")]
    public string MyIdentifier { get; set; }

    /// <summary> A list of payment items included in the batch. </summary>
    [JsonPropertyName("pagamentos")]
    public List<BatchItem> Payments { get; set; }

    /// <summary> Default constructor </summary>
    public Batch() { }

    /// <summary> Constructs a new Batch with specified values. </summary>
    /// <param name="myIdentifier"> A unique identifier for the batch </param>
    /// <param name="payments"> A list of payment items included in the batch </param>
    public Batch(string myIdentifier, List<BatchItem> payments)
    {
        MyIdentifier = myIdentifier;
        Payments = payments;
    }
}
