namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents the base filter used for retrieving billing information.
/// <para> 
/// This class includes fields for filtering by billing date type, billing
/// situation, payer information, and the billing type. It allows for the
/// inclusion of any additional fields for customized filtering. This structure
/// is essential for defining search criteria in billing retrieval processes.
/// </para>
/// </summary>
/// <see cref="AbstractModel"/> 
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BaseBillingRetrievalFilter : AbstractModel
{
    /// <summary> The type of billing date to filter by. </summary>
    [JsonPropertyName("filtrarDataPor")]
    public string FilterDateBy { get; set; }

    /// <summary> The current situation of the billing. </summary>
    [JsonPropertyName("situacao")]
    public string Situation { get; set; }

    /// <summary> The payer's information. </summary>
    [JsonPropertyName("pessoaPagadora")]
    public string Payer { get; set; }

    /// <summary> The CPF or CNPJ of the payer. </summary>
    [JsonPropertyName("cpfCnpjPessoaPagadora")]
    public string PayerCpfCnpj { get; set; }

    /// <summary> A custom identifier for the billing. </summary>
    [JsonPropertyName("seuNumero")]
    public string YourNumber { get; set; }

    /// <summary> The type of billing being retrieved. </summary>
    [JsonPropertyName("tipoCobranca")]
    public BillingType BillingType { get; set; }

    /// <summary> Constructs a new BaseBillingRetrievalFilter with specified values. </summary>
    /// <param name="filterDateBy"> The type of billing date to filter by </param>
    /// <param name="situation"> The current situation of the billing </param>
    /// <param name="payer"> The payer's information </param>
    /// <param name="payerCpfCnpj"> The CPF or CNPJ of the payer </param>
    /// <param name="yourNumber"> A custom identifier for the billing </param>
    /// <param name="billingType"> The type of billing being retrieved </param>
    public BaseBillingRetrievalFilter(string filterDateBy,
                                       string situation,
                                       string payer,
                                       string payerCpfCnpj,
                                       string yourNumber,
                                       BillingType billingType)
    {
        FilterDateBy = filterDateBy;
        Situation = situation;
        Payer = payer;
        PayerCpfCnpj = payerCpfCnpj;
        YourNumber = yourNumber;
        BillingType = billingType;
    }

    /// <summary> Default constructor </summary>
    public BaseBillingRetrievalFilter() { }
}
