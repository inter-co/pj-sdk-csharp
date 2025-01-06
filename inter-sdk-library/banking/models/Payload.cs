namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
/// <summary>
/// The {@code Payload} class represents the payload for a banking
/// transaction or request.
/// <para>
/// It includes details such as request code, movement date and time,
/// request date and time, end-to-end ID, recipient information, status,
/// movement type, amount, and any associated errors.
/// </para>
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Payload : AbstractModel
{
    /// <summary> The unique code for the transaction. </summary>
    [JsonPropertyName("codigoTransacao")]
    public string TransactionCode { get; set; }
    /// <summary> The digitable line for the transaction. </summary>
    [JsonPropertyName("linhaDigitavel")]
    public string DigitableLine { get; set; }
    /// <summary> The date and time of the movement. </summary>
    [JsonPropertyName("dataHoraMovimento")]
    public string MovementDateTime { get; set; }
    /// <summary> The date and time of the request. </summary>
    [JsonPropertyName("dataHoraSolicitacao")]
    public string RequestDateTime { get; set; }
    /// <summary> The name of the beneficiary. </summary>
    [JsonPropertyName("nomeBeneficiario")]
    public string BeneficiaryName { get; set; }
    /// <summary> The amount scheduled for the transaction. </summary>
    [JsonPropertyName("valorAgendado")]
    public string ScheduledAmount { get; set; }
    /// <summary> The value that was actually paid. </summary>
    [JsonPropertyName("valorPago")]
    public string PaidValue { get; set; }
    /// <summary> The end-to-end ID for the transaction. </summary>
    [JsonPropertyName("endToEnd")]
    public string EndToEndId { get; set; }
    /// <summary> The information of the recipient. </summary>
    [JsonPropertyName("recebedor")]
    public Receiver Receiver { get; set; }
    /// <summary> The current status of the transaction. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
    /// <summary> The type of movement (e.g., credit, debit). </summary>
    [JsonPropertyName("tipoMovimentacao")]
    public string MovementType { get; set; }
    /// <summary> The amount involved in the transaction. </summary>
    [JsonPropertyName("valor")]
    public string Amount { get; set; }
    /// <summary> A list of errors associated with the transaction. </summary>
    [JsonPropertyName("erros")]
    public List<CallbackError> Errors { get; set; } = new List<CallbackError>();
    /// <summary> The date of the payment. </summary>
    [JsonPropertyName("dataPagamento")]
    public string PaymentDate { get; set; }
    /// <summary> Constructs a new Payload with specified values. </summary>
    /// <param name="transactionCode"> The unique code for the transaction </param>
    /// <param name="digitableLine"> The digitable line for the transaction </param>
    /// <param name="movementDateTime"> The date and time of the movement </param>
    /// <param name="requestDateTime"> The date and time of the request </param>
    /// <param name="beneficiaryName"> The name of the beneficiary </param>
    /// <param name="scheduledAmount"> The amount scheduled for the transaction </param>
    /// <param name="paidValue"> The value that was actually paid </param>
    /// <param name="endToEndId"> The end-to-end ID for the transaction </param>
    /// <param name="receiver"> The information of the recipient </param>
    /// <param name="status"> The current status of the transaction </param>
    /// <param name="movementType"> The type of movement (e.g., credit, debit) </param>
    /// <param name="amount"> The amount involved in the transaction </param>
    /// <param name="errors"> A list of errors associated with the transaction </param>
    /// <param name="paymentDate"> The date of the payment </param>
    public Payload(string transactionCode, string digitableLine, string movementDateTime,
                   string requestDateTime, string beneficiaryName, string scheduledAmount,
                   string paidValue, string endToEndId, Receiver receiver, string status,
                   string movementType, string amount, List<CallbackError> errors,
                   string paymentDate)
    {
        TransactionCode = transactionCode;
        DigitableLine = digitableLine;
        MovementDateTime = movementDateTime;
        RequestDateTime = requestDateTime;
        BeneficiaryName = beneficiaryName;
        ScheduledAmount = scheduledAmount;
        PaidValue = paidValue;
        EndToEndId = endToEndId;
        Receiver = receiver;
        Status = status;
        MovementType = movementType;
        Amount = amount;
        Errors = errors;
        PaymentDate = paymentDate;
    }
    /// <summary> Default constructor </summary>
    public Payload() { }
}