namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code BankingPix} class represents a payment using BankingPix.
/// <para> 
/// It includes details such as the payment amount, payment date,
/// description, recipient information, and additional fields that can be
/// included for additional context.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BankingPix : AbstractModel
{
    /// <summary> The amount to be paid. </summary>
    [JsonPropertyName("valor")]
    public string Amount { get; set; }

    /// <summary> The date the payment is scheduled for. </summary>
    [JsonPropertyName("dataPagamento")]
    public string PaymentDate { get; set; }

    /// <summary> A brief description of the payment. </summary>
    [JsonPropertyName("descricao")]
    public string Description { get; set; }

    /// <summary> The recipient of the payment. </summary>
    [JsonPropertyName("destinatario")]
    public Recipient Recipient { get; set; }

    /// <summary> Constructs a new BankingPix payment with specified values. </summary>
    /// <param name="amount"> The amount to be paid </param>
    /// <param name="paymentDate"> The date the payment is scheduled for </param>
    /// <param name="description"> A brief description of the payment </param>
    /// <param name="recipient"> The recipient of the payment </param>
    public BankingPix(string amount, string paymentDate, string description, Recipient recipient)
    {
        Amount = amount;
        PaymentDate = paymentDate;
        Description = description;
        Recipient = recipient;
    }

    /// <summary> Default constructor </summary>
    public BankingPix() { }
}
