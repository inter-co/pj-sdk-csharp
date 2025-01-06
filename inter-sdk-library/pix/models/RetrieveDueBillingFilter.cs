namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code RetrieveDueBillingFilter} class is used to filter billing
/// records based on various criteria. It includes fields for
/// CPF, CNPJ, presence of location, and billing status.
/// Additionally, it supports custom fields through a map for
/// additional attributes.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class RetrieveDueBillingFilter : AbstractModel
{
    /// <summary> The CPF (Cadastro de Pessoas Físicas) number for filtering. </summary>
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    /// <summary> The CNPJ (Cadastro Nacional da Pessoa Jurídica) number for filtering. </summary>
    [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; }

    /// <summary> Indicates whether a location is present. </summary>
    [JsonPropertyName("locationPresente")]
    public bool? LocationPresent { get; set; } // Changed to bool? to allow nulls

    /// <summary> The billing status for filtering records. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary> Constructs a new RetrieveDueBillingFilter with specified values. </summary>
    /// <param _name_="_cpf_"> The CPF number for filtering </param>
    /// <param _name_="_cnpj_"> The CNPJ number for filtering </param>
    /// <param _name_="_locationPresent_"> Indicates if a location is present </param>
    /// <param _name_="_status_"> The billing status for filtering records </param>
    public RetrieveDueBillingFilter(string cpf, string cnpj, bool? locationPresent, string status) : base()
    {
        Cpf = cpf;
        Cnpj = cnpj;
        LocationPresent = locationPresent;
        Status = status;
    }

    /// <summary> Default constructor </summary>
    public RetrieveDueBillingFilter() { }
}
