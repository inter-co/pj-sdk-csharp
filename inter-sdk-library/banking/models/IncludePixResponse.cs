namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code IncludePixResponse} class represents the response for including a Pix payment.
/// <para> 
/// It contains transaction details such as return type, transaction ID,
/// schedule ID, payment date, operation date, and approval ID.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class IncludePixResponse : AbstractModel
{
    /// <summary> The type of return for the Pix payment. </summary>
    [JsonPropertyName("tipoRetorno")]
    public string ReturnType { get; set; }

    /// <summary> The end-to-end ID for the Pix transaction. </summary>
    [JsonPropertyName("endToEndId")]
    public string EndToEndId { get; set; }

    /// <summary> The request code for the Pix payment. </summary>
    [JsonPropertyName("codigoSolicitacao")]
    public string RequestCode { get; set; }

    /// <summary> The date on which the payment was made. </summary>
    [JsonPropertyName("dataPagamento")]
    public string PaymentDate { get; set; }

    /// <summary> The scheduling code for the payment, if applicable. </summary>
    [JsonPropertyName("codigoAgendamento")]
    public string SchedulingCode { get; set; }

    /// <summary> The operation date of the transaction. </summary>
    [JsonPropertyName("dataOperacao")]
    public string OperationDate { get; set; }

    /// <summary> The hour at which the payment was made. </summary>
    [JsonPropertyName("horaPagamento")]
    public string PaymentHour { get; set; }

    /// <summary> Constructs a new IncludePixResponse with specified values. </summary>
    /// <param name="returnType"> The type of return for the Pix payment </param>
    /// <param name="endToEndId"> The end-to-end ID for the Pix transaction </param>
    /// <param name="requestCode"> The request code for the Pix payment </param>
    /// <param name="paymentDate"> The date on which the payment was made </param>
    /// <param name="schedulingCode"> The scheduling code for the payment </param>
    /// <param name="operationDate"> The operation date of the transaction </param>
    /// <param name="paymentHour"> The hour at which the payment was made </param>
    public IncludePixResponse(string returnType, string endToEndId, 
                              string requestCode, string paymentDate, 
                              string schedulingCode, string operationDate, 
                              string paymentHour)
    {
        ReturnType = returnType;
        EndToEndId = endToEndId;
        RequestCode = requestCode;
        PaymentDate = paymentDate;
        SchedulingCode = schedulingCode;
        OperationDate = operationDate;
        PaymentHour = paymentHour;
    }

    /// <summary> Default constructor </summary>
    public IncludePixResponse() { }
}
