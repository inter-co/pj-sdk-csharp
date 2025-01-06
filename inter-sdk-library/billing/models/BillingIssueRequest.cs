namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Numerics;
/// <summary>
/// The {@code BillingIssueRequest} class represents a request to issue a billing
/// statement, encapsulating important details such as the issue number, nominal
/// value, due date, scheduled days, payer details, applicable discounts, fines,
/// interest, message to the user, and final beneficiary.
/// <para>
/// This class is essential for creating requests related to
/// billing statements, ensuring all required fields are included.
/// </para>
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingIssueRequest : AbstractModel
{
    /// <summary> A custom identifier for the billing statement. </summary>
    [JsonPropertyName("seuNumero")]
    public string YourNumber { get; set; }
    /// <summary> The nominal value of the billing statement. </summary>
    [JsonPropertyName("valorNominal")]
    public decimal NominalValue { get; set; }
    /// <summary> The due date for the payment. </summary>
    [JsonPropertyName("dataVencimento")]
    public string DueDate { get; set; }
    /// <summary> The number of days scheduled until the due date. </summary>
    [JsonPropertyName("numDiasAgenda")]
    public int? ScheduledDays { get; set; } // Nullable to match Integer
    /// <summary> The payer's information. </summary>
    [JsonPropertyName("pagador")]
    public Person Payer { get; set; }
    /// <summary> The discount applicable to the billing statement. </summary>
    [JsonPropertyName("desconto")]
    public Discount Discount { get; set; }
    /// <summary> The fine applicable for late payments. </summary>
    [JsonPropertyName("multa")]
    public Fine Fine { get; set; }
    /// <summary> The interest applicable for late payments. </summary>
    [JsonPropertyName("mora")]
    public Mora Mora { get; set; }
    /// <summary> A message to the user regarding the billing statement. </summary>
    [JsonPropertyName("mensagem")]
    public Message Message { get; set; }
    /// <summary> The final beneficiary of the payment. </summary>
    [JsonPropertyName("beneficiarioFinal")]
    public Person FinalBeneficiary { get; set; }
    /// <summary> The method of receiving the payment. </summary>
    [JsonPropertyName("formasRecebimento")]
    public string ReceivingMethod { get; set; }
    /// <summary> Constructs a new BillingIssueRequest with specified values. </summary>
    /// <param name="yourNumber"> A custom identifier for the billing statement </param>
    /// <param name="nominalValue"> The nominal value of the billing statement </param>
    /// <param name="dueDate"> The due date for the payment </param>
    /// <param name="scheduledDays"> The number of days scheduled until the due date </param>
    /// <param name="payer"> The payer's information </param>
    /// <param name="discount"> The applicable discount </param>
    /// <param name="fine"> The applicable fine </param>
    /// <param name="mora"> The applicable interest for late payments </param>
    /// <param name="message"> The message to the user </param>
    /// <param name="finalBeneficiary"> The final beneficiary of the payment </param>
    /// <param name="receivingMethod"> The method of receiving the payment </param>
public BillingIssueRequest(string yourNumber,
                               decimal nominalValue,
                               string dueDate,
                               int? scheduledDays,
                               Person payer,
                               Discount discount,
                               Fine fine,
                               Mora mora,
                               Message message,
                               Person finalBeneficiary,
                               string receivingMethod)
    {
        YourNumber = yourNumber;
        NominalValue = nominalValue;
        DueDate = dueDate;
        ScheduledDays = scheduledDays;
        Payer = payer;
        Discount = discount;
        Fine = fine;
        Mora = mora;
        Message = message;
        FinalBeneficiary = finalBeneficiary;
        ReceivingMethod = receivingMethod;
    }
    /// <summary> Default constructor </summary>
    public BillingIssueRequest() { }
}
