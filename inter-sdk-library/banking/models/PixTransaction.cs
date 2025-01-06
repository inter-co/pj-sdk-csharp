namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
/// <summary>
/// The {@code PixTransaction} class represents a Pix payment transaction.
/// <para>
/// It encapsulates information about the transaction, including
/// the account, recipient details, errors if any, payment amount,
/// status, and associated timestamps.
/// </para>
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixTransaction : AbstractModel
{
    /// <summary> The account associated with the transaction. </summary>
    [JsonPropertyName("contaCorrente")]
    public string Account { get; set; }
    /// <summary> The recipient of the Pix transaction. </summary>
    [JsonPropertyName("recebedor")]
    public Receiver Receiver { get; set; }
    /// <summary> Any errors encountered during the transaction. </summary>
    [JsonPropertyName("erros")]
    public List<PixTransactionError> Errors { get; set; }
    /// <summary> The end-to-end ID for tracking the transaction. </summary>
    [JsonPropertyName("endToEnd")]
    public string EndToEnd { get; set; }
    /// <summary> The value of the Pix transaction. </summary>
    [JsonPropertyName("valor")]
    public decimal Value { get; set; }
    /// <summary> The current status of the Pix transaction. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
    /// <summary> The date and time when the movement occurred. </summary>
    [JsonPropertyName("dataHoraMovimento")]
    public string MovementDateTime { get; set; }
    /// <summary> The date and time when the request was made. </summary>
    [JsonPropertyName("dataHoraSolicitacao")]
    public string RequestDateTime { get; set; }
    /// <summary> The key associated with the recipient. </summary>
    [JsonPropertyName("chave")]
    public string Key { get; set; }
    /// <summary> The request code associated with the transaction. </summary>
    [JsonPropertyName("codigoSolicitacao")]
    public string RequestCode { get; set; }
    /// <summary> Constructs a new PixTransaction with specified values. </summary>
    /// <param name="account"> The account associated with the transaction </param>
    /// <param name="receiver"> The recipient of the Pix transaction </param>
    /// <param name="errors"> Any errors encountered during the transaction </param>
    /// <param name="endToEnd"> The end-to-end ID for tracking the transaction </param>
    /// <param name="value"> The value of the Pix transaction </param>
    /// <param name="status"> The current status of the Pix transaction </param>
    /// <param name="movementDateTime"> The date and time when the movement occurred </param>
    /// <param name="requestDateTime"> The date and time when the request was made </param>
    /// <param name="key"> The key associated with the recipient </param>
    /// <param name="requestCode"> The request code associated with the transaction </param>
    public PixTransaction(string account, Receiver receiver, List<PixTransactionError> errors,
                          string endToEnd, int value, string status,
                          string movementDateTime, string requestDateTime,
                          string key, string requestCode)
    {
        Account = account;
        Receiver = receiver;
        Errors = errors;
        EndToEnd = endToEnd;
        Value = value;
        Status = status;
        MovementDateTime = movementDateTime;
        RequestDateTime = requestDateTime;
        Key = key;
        RequestCode = requestCode;
    }
    /// <summary> Default constructor </summary>
    public PixTransaction() { }
}
