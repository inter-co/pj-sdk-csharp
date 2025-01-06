namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code RetrievedPixFilter} class is used to filter received
/// PIX transactions based on various criteria. It includes fields
/// for transaction ID (txId), presence of transaction ID, presence
/// of return, and identification numbers such as CPF and CNPJ.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class RetrievedPixFilter : AbstractModel
{
    /// <summary> The transaction ID (txId) for filtering transactions. </summary>
    [JsonPropertyName("txId")]
    public string TxId { get; set; }

    /// <summary> Indicates whether a transaction ID is present. </summary>
    [JsonPropertyName("txIdPresente")]
    public bool? TxIdPresent { get; set; } // Changed to bool? to allow nulls

    /// <summary> Indicates whether a devolution is present. </summary>
    [JsonPropertyName("devolucaoPresente")]
    public bool? DevolutionPresent { get; set; } // Changed to bool? to allow nulls

    /// <summary> The CPF of the person related to the transaction. </summary>
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    /// <summary> The CNPJ of the entity related to the transaction. </summary>
    [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; }

    /// <summary> Constructs a new RetrievedPixFilter with specified values. </summary>
    /// <param _name_="_txId_"> The transaction ID (txId) for filtering transactions </param>
    /// <param _name_="_txIdPresent_"> Indicates whether a transaction ID is present </param>
    /// <param _name_="_devolutionPresent_"> Indicates whether a devolution is present </param>
    /// <param _name_="_cpf_"> The CPF of the person related to the transaction </param>
    /// <param _name_="_cnpj_"> The CNPJ of the entity related to the transaction </param>
    public RetrievedPixFilter(string txId, bool? txIdPresent, bool? devolutionPresent, string cpf, string cnpj) : base()
    {
        TxId = txId;
        TxIdPresent = txIdPresent;
        DevolutionPresent = devolutionPresent;
        Cpf = cpf;
        Cnpj = cnpj;
    }

    /// <summary> Default constructor </summary>
    public RetrievedPixFilter() { }
}
