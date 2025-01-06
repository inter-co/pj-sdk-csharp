namespace inter_sdk_library;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

/// <summary>
/// The {@code BatchProcessing} class represents a batch processing
/// of payments. It includes information about the account responsible
/// for the payment, creation date, list of payment items, batch ID,
/// status, a custom identifier, and the quantity of payments in
/// the batch.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para>
/// The class includes fields for bank account, creation date, payments, batch ID, status, 
/// my identifier, payment quantity, and additional fields. 
/// It overrides Equals, GetHashCode, and ToString methods to include both its own fields 
/// and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/>
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BatchProcessing : AbstractModel
{
    /// <summary> The bank account responsible for the payment. </summary>
    [JsonPropertyName("contaCorrente")]
    public string BankAccount { get; set; }

    /// <summary> The creation date of the batch. </summary>
    [JsonPropertyName("dataCriacao")]
    public string CreationDate { get; set; }

    /// <summary> The list of payment items in the batch. </summary>
    [JsonPropertyName("pagamentos")]
    public List<BatchItem> Payments { get; set; }

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

    /// <summary> Default constructor </summary>
    public BatchProcessing() { }

    /// <summary> Constructs a new BatchProcessing with specified values. </summary>
    /// <param name="bankAccount"> The bank account responsible for the payment </param>
    /// <param name="creationDate"> The creation date of the batch </param>
    /// <param name="payments"> The list of payment items in the batch </param>
    /// <param name="batchId"> The batch ID </param>
    /// <param name="status"> The status of the batch </param>
    /// <param name="myIdentifier"> A custom identifier for the batch </param>
    /// <param name="paymentQuantity"> The quantity of payments in the batch </param>
    public BatchProcessing(string bankAccount,
                           string creationDate,
                           List<BatchItem> payments,
                           string batchId,
                           string status,
                           string myIdentifier,
                           int? paymentQuantity)
    {
        BankAccount = bankAccount;
        CreationDate = creationDate;
        Payments = payments;
        BatchId = batchId;
        Status = status;
        MyIdentifier = myIdentifier;
        PaymentQuantity = paymentQuantity;
    }
}
