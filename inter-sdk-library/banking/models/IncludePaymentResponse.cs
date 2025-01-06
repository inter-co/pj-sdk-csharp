namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents the response for including a payment, containing details about the number of approvers,
/// scheduled date, payment status, transaction code, title, and message related to the payment inclusion request.
/// <para> 
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para> 
/// The class includes fields for the number of approvers, payment status, transaction code,
/// title, and message. It overrides Equals, GetHashCode, and ToString methods to include both
/// its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/> 
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class IncludePaymentResponse : AbstractModel
{
    /// <summary> The number of approvers required for the payment. </summary>
    [JsonPropertyName("quantidadeAprovadores")]
    public int? NumberOfApprovers { get; set; }

    /// <summary> The current status of the payment. </summary>
    [JsonPropertyName("statusPagamento")]
    public string PaymentStatus { get; set; }

    /// <summary> The transaction code for the payment. </summary>
    [JsonPropertyName("codigoTransacao")]
    public string TransactionCode { get; set; }

    /// <summary> The title associated with the payment. </summary>
    [JsonPropertyName("titulo")]
    public string Title { get; set; }

    /// <summary> A message providing additional details about the payment. </summary>
    [JsonPropertyName("mensagem")]
    public string Message { get; set; }

    /// <summary> Constructs a new IncludePaymentResponse with specified values. </summary>
    /// <param name="numberOfApprovers"> The number of approvers required for the payment </param>
    /// <param name="paymentStatus"> The current status of the payment </param>
    /// <param name="transactionCode"> The transaction code for the payment </param>
    /// <param name="title"> The title associated with the payment </param>
    /// <param name="message"> A message providing additional details about the payment </param>
    public IncludePaymentResponse(int? numberOfApprovers, string paymentStatus, 
                                  string transactionCode, string title, string message)
    {
        NumberOfApprovers = numberOfApprovers;
        PaymentStatus = paymentStatus;
        TransactionCode = transactionCode;
        Title = title;
        Message = message;
    }

    /// <summary> Default constructor </summary>
    public IncludePaymentResponse() { }
}