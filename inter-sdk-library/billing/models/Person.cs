namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
/// <summary>
/// The {@code Person} class represents an individual's or company's information,
/// including identification details, contact information, and address.
/// <para>
/// It is used to map data from a JSON structure, enabling the
/// deserialization of received information. This class encapsulates essential
/// attributes necessary for identifying and contacting a person or entity.
/// </para>
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Person : AbstractModel
{
    /// <summary> The CPF or CNPJ number of the person or entity. </summary>
    [JsonPropertyName("cpfCnpj")]
    public string CpfCnpj { get; set; }
    /// <summary> The type of person, either individual or company. </summary>
    [JsonPropertyName("tipoPessoa")]
    public string PersonType { get; set; }
    /// <summary> The name of the person or company. </summary>
    [JsonPropertyName("nome")]
    public string Name { get; set; }
    /// <summary> The address of the person or company. </summary>
    [JsonPropertyName("endereco")]
    public string Address { get; set; }
    /// <summary> The number of the address. </summary>
    [JsonPropertyName("numero")]
    public string Number { get; set; }
    /// <summary> Additional complement information for the address. </summary>
    [JsonPropertyName("complemento")]
    public string Complement { get; set; }
    /// <summary> The neighborhood where the person or company is located. </summary>
    [JsonPropertyName("bairro")]
    public string Neighborhood { get; set; }
    /// <summary> The city of residence of the person or company. </summary>
    [JsonPropertyName("cidade")]
    public string City { get; set; }
    /// <summary> The state where the person or company is located. </summary>
    [JsonPropertyName("uf")]
    public string State { get; set; }
    /// <summary> The postal code for the address. </summary>
    [JsonPropertyName("cep")]
    public string ZipCode { get; set; }
    /// <summary> The email address of the person or company. </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }
    /// <summary> The area code for the telephone number. </summary>
    [JsonPropertyName("ddd")]
    public string AreaCode { get; set; }
    /// <summary> The telephone number of the person or company. </summary>
    [JsonPropertyName("telefone")]
    public string Phone { get; set; }
    /// <summary> Constructs a new Person with specified values. </summary>
    /// <param name="cpfCnpj"> The CPF or CNPJ number of the person or entity </param>
    /// <param name="personType"> The type of person (individual or company) </param>
    /// <param name="name"> The name of the person or company </param>
    /// <param name="address"> The address of the person or company </param>
    /// <param name="number"> The number of the address </param>
    /// <param name="complement"> Additional complement information for the address </param>
    /// <param name="neighborhood"> The neighborhood of the person or company </param>
    /// <param name="city"> The city of residence </param>
    /// <param name="state"> The state of residence </param>
    /// <param name="zipCode"> The postal code </param>
    /// <param name="email"> The email address </param>
    /// <param name="areaCode"> The area code for the telephone number </param>
/// <param name="phone"> The telephone number </param>
    public Person(string cpfCnpj, string personType, string name, string address, string number,
                  string complement, string neighborhood, string city, string state, string zipCode,
                  string email, string areaCode, string phone)
    {
        CpfCnpj = cpfCnpj;
        PersonType = personType;
        Name = name;
        Address = address;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        ZipCode = zipCode;
        Email = email;
        AreaCode = areaCode;
        Phone = phone;
    }
    /// <summary> Default constructor </summary>
    public Person() { }
}
