namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code PixReceiver} class represents the details of a recipient
/// involved in a transaction. It includes fields for the receiver's
/// name, CNPJ (Cadastro Nacional da Pessoa Jurídica), trade name,
/// city, state (UF), postal code (CEP), and address (logradouro).
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixReceiver : AbstractModel
{
    /// <summary> The name of the receiver. </summary>
    [JsonPropertyName("nome")]
    public string Name { get; set; }

    /// <summary> The CNPJ (Cadastro Nacional da Pessoa Jurídica) of the receiver. </summary>
    [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; }

    /// <summary> The trade name of the receiver. </summary>
    [JsonPropertyName("nomeFantasia")]
    public string TradeName { get; set; }

    /// <summary> The city where the receiver is located. </summary>
    [JsonPropertyName("cidade")]
    public string City { get; set; }

    /// <summary> The state (UF) where the receiver is located. </summary>
    [JsonPropertyName("uf")]
    public string State { get; set; }

    /// <summary> The postal code (CEP) of the receiver's address. </summary>
    [JsonPropertyName("cep")]
    public string PostalCode { get; set; }

    /// <summary> The street address (logradouro) of the receiver. </summary>
    [JsonPropertyName("logradouro")]
    public string Address { get; set; }

    /// <summary> Constructs a new PixReceiver with specified values. </summary>
    /// <param _name_="_name_"> The name of the receiver </param>
    /// <param _name_="_cnpj_"> The CNPJ of the receiver </param>
    /// <param _name_="_tradeName_"> The trade name of the receiver </param>
    /// <param _name_="_city_"> The city where the receiver is located </param>
    /// <param _name_="_state_"> The state (UF) where the receiver is located </param>
    /// <param _name_="_postalCode_"> The postal code (CEP) of the receiver's address </param>
    /// <param _name_="_address_"> The street address (logradouro) of the receiver </param>
    public PixReceiver(string name, string cnpj, string tradeName, string city, string state, string postalCode, string address) : base()
    {
        Name = name;
        Cnpj = cnpj;
        TradeName = tradeName;
        City = city;
        State = state;
        PostalCode = postalCode;
        Address = address;
    }

    /// <summary> Default constructor </summary>
    public PixReceiver() { }
}
