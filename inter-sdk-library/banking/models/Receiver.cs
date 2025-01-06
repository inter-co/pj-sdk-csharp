namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code Receiver} class represents the recipient of a payment.
/// <para> 
/// It includes details such as agency code, ISPB code,
/// CNPJ/CPF number, name, account number, and account type,
/// which are essential for processing a payment to the recipient.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Receiver : AbstractModel
{
    /// <summary> The agency code of the recipient's bank. </summary>
    [JsonPropertyName("codAgencia")]
    public string AgencyCode { get; set; }

    /// <summary> The ISPB code of the recipient's bank. </summary>
    [JsonPropertyName("codIspb")]
    public string IspbCode { get; set; }

    /// <summary> The CPF or CNPJ of the recipient. </summary>
    [JsonPropertyName("cpfCnpj")]
    public string CpfOrCnpj { get; set; }

    /// <summary> The name of the recipient. </summary>
    [JsonPropertyName("nome")]
    public string Name { get; set; }

    /// <summary> The account number of the recipient. </summary>
    [JsonPropertyName("nroConta")]
    public string AccountNumber { get; set; }

    /// <summary> The type of account of the recipient. </summary>
    [JsonPropertyName("tipoConta")]
    public string AccountType { get; set; }

    /// <summary> Constructs a new Receiver with specified values. </summary>
    /// <param name="agencyCode"> The agency code of the recipient's bank </param>
    /// <param name="ispbCode"> The ISPB code of the recipient's bank </param>
    /// <param name="cpfOrCnpj"> The CPF or CNPJ of the recipient </param>
    /// <param name="name"> The name of the recipient </param>
    /// <param name="accountNumber"> The account number of the recipient </param>
    /// <param name="accountType"> The type of account of the recipient </param>
    public Receiver(string agencyCode, string ispbCode, string cpfOrCnpj, string name, string accountNumber, string accountType)
    {
        AgencyCode = agencyCode;
        IspbCode = ispbCode;
        CpfOrCnpj = cpfOrCnpj;
        Name = name;
        AccountNumber = accountNumber;
        AccountType = accountType;
    }

    /// <summary> Default constructor </summary>
    public Receiver() { }
}
