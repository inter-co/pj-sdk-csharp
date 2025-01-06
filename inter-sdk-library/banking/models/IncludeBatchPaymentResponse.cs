namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code IncludeBatchPaymentResponse} class represents the response
/// for including payments in a batch. It contains details about
/// the batch ID, payment status, a custom identifier, and the
/// quantity of payments.
/// <para> 
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para> 
/// The class includes fields for batch ID, status, my identifier, payment quantity,
/// and additional fields. It overrides Equals, GetHashCode, and ToString methods 
/// to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/> 
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class IncludeBatchPaymentResponse : AbstractModel
{
    /// <summary> The batch ID. </summary>
    [JsonPropertyName("idLote")]
    public string BatchId { get; set; }

    /// <summary> The status of the batch. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary> A custom identifier for the batch. </summary>
    [JsonPropertyName("meuIdentificador")]
    public string MyIdentifier { get; set; }

    /// <summary> The quantity of payments in the batch. </summary>
    [JsonPropertyName("qtdePagamentos")]
    public int? PaymentQuantity { get; set; }

    /// <summary> Constructs a new IncludeBatchPaymentResponse with specified values. </summary>
    /// <param name="batchId"> The batch ID </param>
    /// <param name="status"> The status of the batch </param>
    /// <param name="myIdentifier"> A custom identifier for the batch </param>
    /// <param name="paymentQuantity"> The quantity of payments in the batch </param>
    public IncludeBatchPaymentResponse(string batchId, string status, string myIdentifier, int? paymentQuantity)
    {
        BatchId = batchId;
        Status = status;
        MyIdentifier = myIdentifier;
        PaymentQuantity = paymentQuantity;
    }

    /// <summary> Default constructor </summary>
    public IncludeBatchPaymentResponse() { }
}
