namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
/// <summary>
/// Represents payment information for a DARF (Documento de Arrecadação de Receitas Federais).
/// It includes details such as CNPJ/CPF, revenue code, due date, description, company details, amounts, and any additional fields.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para>
/// The class includes fields for CNPJ/CPF, revenue code, due date, description, enterprise details, amounts, and additional fields.
/// It overrides equals, hashCode, and toString methods to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/>
/// <since>1.0</since>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BatchPaymentUnit : AbstractModel
{
    /// <summary> The CNPJ or CPF associated with the DARF payment. </summary>
    [JsonPropertyName("cnpjCpf")]
    public string CnpjOrCpf { get; set; }
    /// <summary> The revenue code for the DARF payment. </summary>
    [JsonPropertyName("codigoReceita")]
    public string RevenueCode { get; set; }
    /// <summary> The due date for the DARF payment. </summary>
    [JsonPropertyName("dataVencimento")]
    public string DueDate { get; set; }
    /// <summary> The description of the DARF payment. </summary>
    [JsonPropertyName("descricao")]
    public string Description { get; set; }
    /// <summary> The name of the enterprise associated with the DARF payment. </summary>
    [JsonPropertyName("nomeEmpresa")]
    public string EnterpriseName { get; set; }
    /// <summary> The phone number of the enterprise associated with the DARF payment. </summary>
    [JsonPropertyName("telefoneEmpresa")]
    public string EnterprisePhone { get; set; }
    /// <summary> The assessment period for the DARF payment. </summary>
    [JsonPropertyName("periodoApuracao")]
    public string AssessmentPeriod { get; set; }
    /// <summary> The payment date for the DARF payment. </summary>
    [JsonPropertyName("dataPagamento")]
    public string PaymentDate { get; set; }
    /// <summary> The inclusion date for the DARF payment. </summary>
    [JsonPropertyName("dataInclusao")]
    public string InclusionDate { get; set; }
    /// <summary> The value of the DARF payment. </summary>
    [JsonPropertyName("valor")]
    public decimal Value { get; set; }
    /// <summary> The total value of the DARF payment. </summary>
    [JsonPropertyName("valorTotal")]
    public string TotalValue { get; set; }
    /// <summary> The fine amount for the DARF payment. </summary>
    [JsonPropertyName("valorMulta")]
    public string FineAmount { get; set; }
    /// <summary> The interest amount for the DARF payment. </summary>
    [JsonPropertyName("valorJuros")]
    public string InterestAmount { get; set; }
    /// <summary> The reference for the DARF payment. </summary>
    [JsonPropertyName("referencia")]
    public string Reference { get; set; }
    /// <summary> The type of DARF. </summary>
    [JsonPropertyName("tipoDarf")]
    public string DarfType { get; set; }
    /// <summary> The type of the DARF payment. </summary>
    [JsonPropertyName("tipo")]
    public string Type { get; set; }
    /// <summary> The principal value of the DARF payment. </summary>
    [JsonPropertyName("valorPrincipal")]
    public string PrincipalValue { get; set; }

    /// <summary> The barcode of the ticket. </summary>
    [JsonPropertyName("codBarraLinhaDigitavel")]
    public string Barcode { get; set; }

    /// <summary> The amount to be paid. </summary>
    [JsonPropertyName("valorPagar")]
    public decimal AmountToPay { get; set; }

    /// <summary> The beneficiary's document (CPF/CNPJ). </summary>
    [JsonPropertyName("cpfCnpjBeneficiario")]
    public string BeneficiaryDocument { get; set; }
    /// <summary> Constructs a new DarfPayment with specified values. </summary>
    /// <param name="cnpjOrCpf"> The CNPJ or CPF associated with the DARF payment </param>
    /// <param name="revenueCode"> The revenue code for the DARF payment </param>
    /// <param name="dueDate"> The due date for the DARF payment </param>
    /// <param name="description"> The description of the DARF payment </param>
    /// <param name="enterpriseName"> The name of the enterprise associated with the DARF payment </param>
    /// <param name="enterprisePhone"> The phone number of the enterprise associated with the DARF payment </param>
    /// <param name="assessmentPeriod"> The assessment period for the DARF payment </param>
    /// <param name="paymentDate"> The payment date for the DARF payment </param>
    /// <param name="inclusionDate"> The inclusion date for the DARF payment </param>
    /// <param name="value"> The value of the DARF payment </param>
    /// <param name="totalValue"> The total value of the DARF payment </param>
    /// <param name="fineAmount"> The fine amount for the DARF payment </param>
    /// <param name="interestAmount"> The interest amount for the DARF payment </param>
    /// <param name="reference"> The reference for the DARF payment </param>
    /// <param name="darfType"> The type of DARF </param>
    /// <param name="type"> The type of the DARF payment </param>
    /// <param name="principalValue"> The principal value of the DARF payment </param>
    public BatchPaymentUnit(string cnpjOrCpf,
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
        Barcode = barcode;
        PrincipalValue = principalValue;
        AmountToPay = amountToPay;
        BeneficiaryDocument = beneficiaryDocument;
    }

    public BatchPaymentUnit() { }
}
