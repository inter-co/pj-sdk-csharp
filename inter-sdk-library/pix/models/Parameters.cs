namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Parameters} class represents a collection of parameters
/// including pagination details. It supports additional custom fields
/// via a map of additional attributes.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Parameters : AbstractModel
{
    /// <summary> The start date for the parameters. </summary>
    [JsonPropertyName("inicio")]
    public string Begin { get; set; } = null;

    /// <summary> The end date for the parameters. </summary>
    [JsonPropertyName("fim")]
    public string End { get; set; } = null;

    /// <summary> The CPF (Cadastro de Pessoa Física) for filtering. </summary>
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; } = null;

    /// <summary> The CNPJ (Cadastro Nacional da Pessoa Jurídica) for filtering. </summary>
    [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; } = null;

    /// <summary> Indicates whether the location is present in the parameters. </summary>
    [JsonPropertyName("locationPresente")]
    public bool? LocationPresent { get; set; } = null;

    /// <summary> The status for filtering the parameters. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = null;

    /// <summary> Pagination details associated with the parameters. </summary>
    [JsonPropertyName("paginacao")]
    public Pagination Pagination { get; set; }

    /// <summary> The type of billing associated with the parameters. </summary>
    [JsonPropertyName("tipoCob")]
    public string CobType { get; set; }

    /// <summary> Constructs a new Parameters with specified values. </summary>
    /// <param _name_="_begin_"> The start date for the parameters </param>
    /// <param _name_="_end_"> The end date for the parameters </param>
    /// <param _name_="_cpf_"> The CPF for filtering </param>
    /// <param _name_="_cnpj_"> The CNPJ for filtering </param>
    /// <param _name_="_locationPresent_"> Indicates if the location is present </param>
    /// <param _name_="_status_"> The status for filtering </param>
    /// <param _name_="_pagination_"> Pagination details associated with the parameters </param>
    /// <param _name_="_cobType_"> The type of billing associated with the parameters </param>
    public Parameters(string begin, string end, string cpf, string cnpj, bool? locationPresent, string status, Pagination pagination, string cobType) : base()
    {
        Begin = begin;
        End = end;
        Cpf = cpf;
        Cnpj = cnpj;
        LocationPresent = locationPresent;
        Status = status;
        Pagination = pagination;
        CobType = cobType;
    }

    /// <summary> Default constructor </summary>
    public Parameters() { }
}
