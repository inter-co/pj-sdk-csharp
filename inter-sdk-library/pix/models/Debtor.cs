namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Debtor} class represents information about a debtor in
/// a billing system.
///
/// <p> It includes fields such as CPF (Brazilian individual
/// taxpayer identification number), CNPJ (Brazilian corporate taxpayer
/// identification number), name, email, city, state (UF), postal code (CEP),
/// and address (logradouro). </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Debtor : AbstractModel
{
    /// <summary> The CPF of the debtor. </summary>
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; }

    /// <summary> The CNPJ of the debtor. </summary>
    [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; }

    /// <summary> The name of the debtor. </summary>
    [JsonPropertyName("nome")]
    public string Name { get; set; }

    /// <summary> The email address of the debtor. </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary> The city where the debtor resides. </summary>
    [JsonPropertyName("cidade")]
    public string City { get; set; }

    /// <summary> The state (UF) where the debtor resides. </summary>
    [JsonPropertyName("uf")]
    public string State { get; set; }

    /// <summary> The postal code (CEP) of the debtor's address. </summary>
    [JsonPropertyName("cep")]
    public string PostalCode { get; set; }

    /// <summary> The address of the debtor. </summary>
    [JsonPropertyName("logradouro")]
    public string Address { get; set; }

    /// <summary> Constructs a new Debtor with specified values. </summary>
    /// <param _name_="_cpf_"> The CPF of the debtor </param>
    /// <param _name_="_cnpj_"> The CNPJ of the debtor </param>
    /// <param _name_="_name_"> The name of the debtor </param>
    /// <param _name_="_email_"> The email of the debtor </param>
    /// <param _name_="_city_"> The city of the debtor's address </param>
    /// <param _name_="_state_"> The state (UF) of the debtor's address </param>
    /// <param _name_="_postalCode_"> The postal code (CEP) of the debtor's address </param>
    /// <param _name_="_address_"> The complete address (logradouro) of the debtor </param>
    public Debtor(string cpf, string cnpj, string name, string email, string city, string state, string postalCode, string address)
    {
        Cpf = cpf;
        Cnpj = cnpj;
        Name = name;
        Email = email;
        City = city;
        State = state;
        PostalCode = postalCode;
        Address = address;
    }

    /// <summary> Default constructor </summary>
    public Debtor() { }
}
