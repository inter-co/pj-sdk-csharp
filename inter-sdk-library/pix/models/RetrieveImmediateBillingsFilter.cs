namespace inter_sdk_library;

using Newtonsoft.Json;

//// <summary>
/// The {@code RetrieveImmediateBillingsFilter} class is used to filter
/// immediate billing records based on various criteria. It includes
/// fields for CPF, CNPJ, presence of location, and billing status.
/// Additionally, it supports custom fields through a map for
/// additional attributes.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class RetrieveImmediateBillingsFilter : AbstractModel
{
    /// <summary> The CPF (Cadastro de Pessoas Físicas) number for filtering. </summary>
    public string Cpf { get; set; }

    /// <summary> The CNPJ (Cadastro Nacional da Pessoa Jurídica) number for filtering. </summary>
    public string Cnpj { get; set; }

    /// <summary> Indicates whether a location is present. </summary>
    public bool? LocationPresente { get; set; } // Changed to bool? to allow nulls

    /// <summary> The billing status for filtering records. </summary>
    public string Status { get; set; }

    /// <summary> Constructs a new RetrieveImmediateBillingsFilter with specified values. </summary>
    /// <param _name_="_cpf_"> The CPF (Cadastro de Pessoas Físicas) number for filtering </param>
    /// <param _name_="_cnpj_"> The CNPJ (Cadastro Nacional da Pessoa Jurídica) number for filtering </param>
    /// <param _name_="_locationPresente_"> Indicates whether a location is present </param>
    /// <param _name_="_status_"> The billing status for filtering records </param>
    public RetrieveImmediateBillingsFilter(string cpf, string cnpj, bool? locationPresente, string status) : base()
    {
        Cpf = cpf;
        Cnpj = cnpj;
        LocationPresente = locationPresente;
        Status = status;
    }

    /// <summary> Default constructor </summary>
    public RetrieveImmediateBillingsFilter() { }
}
