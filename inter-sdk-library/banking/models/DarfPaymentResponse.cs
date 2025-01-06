namespace inter_sdk_library;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;
/// <summary>
/// The {@code DarfPaymentResponse} class represents the response
/// for a DARF (Documento de Arrecadação de Receitas Federais) payment.
/// It includes transaction details and financial amounts related to the payment.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para>
/// The class includes fields for request code, DARF type, amounts, payment status,
/// and additional fields. It overrides equals, GetHashCode, and ToString methods
/// to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/>
/// <since>1.0</since>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DarfPaymentResponse : AbstractModel
{
    /// <summary> The request code for the DARF payment. </summary>
    [JsonPropertyName("codigoSolicitacao")]
    public string RequestCode { get; set; }
    /// <summary> The type of DARF. </summary>
    [JsonPropertyName("tipoDarf")]
    public string DarfType { get; set; }
    /// <summary> The amount of the DARF payment. </summary>
    [JsonPropertyName("valor")]
    public decimal Amount { get; set; }
    /// <summary> The fine amount for the DARF payment. </summary>
    [JsonPropertyName("valorMulta")]
    public decimal FineAmount { get; set; }
    /// <summary> The interest amount for the DARF payment. </summary>
    [JsonPropertyName("valorJuros")]
    public decimal InterestAmount { get; set; }
    /// <summary> The total amount of the DARF payment. </summary>
    [JsonPropertyName("valorTotal")]
    public decimal TotalAmount { get; set; }
    /// <summary> The type of the DARF payment. </summary>
    [JsonPropertyName("tipo")]
    public string Type { get; set; }
    /// <summary> The assessment period for the DARF payment. </summary>
    [JsonPropertyName("periodoApuracao")]
    public string AssessmentPeriod { get; set; }
    /// <summary> The payment date for the DARF payment. </summary>
    [JsonPropertyName("dataPagamento")]
    public string PaymentDate { get; set; }
    /// <summary> The reference for the DARF payment. </summary>
    [JsonPropertyName("referencia")]
    public string Reference { get; set; }
    /// <summary> The due date for the DARF payment. </summary>
    [JsonPropertyName("dataVencimento")]
    public string DueDate { get; set; }
    /// <summary> The revenue code for the DARF payment. </summary>
    [JsonPropertyName("codigoReceita")]
    public string RevenueCode { get; set; }
    /// <summary> The payment status of the DARF payment. </summary>
    [JsonPropertyName("statusPagamento")]
    public string PaymentStatus { get; set; }
    /// <summary> The inclusion date for the DARF payment. </summary>
    [JsonPropertyName("dataInclusao")]
    public string InclusionDate { get; set; }
    /// <summary> The CNPJ or CPF associated with the DARF payment. </summary>
    [JsonPropertyName("cnpjCpf")]
    public string CnpjCpf { get; set; }
    /// <summary> The number of necessary approvals for the DARF payment. </summary>
    [JsonPropertyName("aprovacoesNecessarias")]
    public int? NecessaryApprovals { get; set; }
    /// <summary> The number of realized approvals for the DARF payment. </summary>
    [JsonPropertyName("aprovacoesRealizadas")]
    public int? RealizedApprovals { get; set; }
    /// <summary> Constructs a new DarfPaymentResponse with specified values. </summary>
    /// <param name="requestCode"> The request code for the DARF payment </param>
    /// <param name="darfType"> The type of DARF </param>
    /// <param name="amount"> The amount of the DARF payment </param>
    /// <param name="fineAmount"> The fine amount for the DARF payment </param>
    /// <param name="interestAmount"> The interest amount for the DARF payment </param>
    /// <param name="totalAmount"> The total amount of the DARF payment </param>
    /// <param name="type"> The type of the DARF payment </param>
    /// <param name="assessmentPeriod"> The assessment period for the DARF payment </param>
    /// <param name="paymentDate"> The payment date for the DARF payment </param>
    /// <param name="reference"> The reference for the DARF payment </param>
    /// <param name="dueDate"> The due date for the DARF payment </param>
    /// <param name="revenueCode"> The revenue code for the DARF payment </param>
    /// <param name="paymentStatus"> The payment status of the DARF payment </param>
    /// <param name="inclusionDate"> The inclusion date for the DARF payment </param>
    /// <param name="cnpjCpf"> The CNPJ or CPF associated with the DARF payment </param>
    /// <param name="necessaryApprovals"> The number of necessary approvals for the DARF payment </param>
    /// <param name="realizedApprovals"> The number of realized approvals for the DARF payment </param>
    public DarfPaymentResponse(string requestCode,
                               string darfType,
                               decimal amount,
                               decimal fineAmount,
                               decimal interestAmount,
                               decimal totalAmount,
                               string type,
                               string assessmentPeriod,
                               string paymentDate,
                               string reference,
                               string dueDate,
                               string revenueCode,
                               string paymentStatus,
                               string inclusionDate,
                               string cnpjCpf,
                               int? necessaryApprovals,
                               int? realizedApprovals)
    {
        RequestCode = requestCode;
        DarfType = darfType;
        Amount = amount;
        FineAmount = fineAmount;
        InterestAmount = interestAmount;
        TotalAmount = totalAmount;
        Type = type;
        AssessmentPeriod = assessmentPeriod;
        PaymentDate = paymentDate;
        Reference = reference;
        DueDate = dueDate;
        RevenueCode = revenueCode;
        PaymentStatus = paymentStatus;
        InclusionDate = inclusionDate;
        CnpjCpf = cnpjCpf;
        NecessaryApprovals = necessaryApprovals;
        RealizedApprovals = realizedApprovals;
    }

    public DarfPaymentResponse () {}
}
