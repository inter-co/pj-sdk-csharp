namespace inter_sdk_library;

using Newtonsoft.Json;
using System.Text.Json.Serialization;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BatchItem : BatchPaymentUnit
{
    /// <summary> The payment type, which is always "DARF". </summary>
    [JsonPropertyName("tipoPagamento")]
    public string PaymentType { get; set;}

    /// <summary> The detail of the payment. </summary>
    [JsonPropertyName("detalhe")]
    public string Detail { get; set; }

    /// <summary> The transaction ID of the payment. </summary>
    [JsonPropertyName("idTransacao")]
    public string TransactionId { get; set; }

    /// <summary> The status of the payment. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }


    /// <summary> Constructs a new DarfPaymentBatch with specified values. </summary>
    /// <param name="detail"> The detail of the payment </param>
    /// <param name="transactionId"> The transaction ID of the payment </param>
    /// <param name="status"> The status of the payment </param>
    public BatchItem(string detail, string transactionId, string status, string cnpjOrCpf,
                       string revenueCode,
                       string dueDate,
                       string description,
                       string enterpriseName,
                       string enterprisePhone,
                       string assessmentPeriod,
                       string paymentDate,
                       string inclusionDate,
                       decimal value,
                       string totalValue,
                       string fineAmount,
                       string interestAmount,
                       string reference,
                       string darfType,
                       string type,
                       string principalValue,
                       string barcode,
                       decimal amountToPay,
                       string beneficiaryDocument)
        : base(cnpjOrCpf, revenueCode, dueDate, description, enterpriseName, enterprisePhone, assessmentPeriod, paymentDate, inclusionDate, value, totalValue, fineAmount, interestAmount, reference, darfType, type, principalValue, barcode, amountToPay, beneficiaryDocument)
    {
        CnpjOrCpf = cnpjOrCpf;
        RevenueCode = revenueCode;
        DueDate = dueDate;
        Description = description;
        EnterpriseName = enterpriseName;
        EnterprisePhone = enterprisePhone;
        AssessmentPeriod = assessmentPeriod;
        PaymentDate = paymentDate;
        InclusionDate = inclusionDate;
        Value = value;
        TotalValue = totalValue;
        FineAmount = fineAmount;
        InterestAmount = interestAmount;
        Reference = reference;
        DarfType = darfType;
        Type = type;
        PrincipalValue = principalValue;
        Detail = detail;
        TransactionId = transactionId;
        Status = status;
    }

    public BatchItem () {}
}
