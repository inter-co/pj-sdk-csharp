namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a financial institution.
/// <para> 
/// This class encapsulates the key details of a financial institution,
/// including its code, name, ISPB (Instituição do Sistema de Pagamentos Brasileiro),
/// and type, which may be relevant for banking transactions and integration.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class FinancialInstitution : AbstractModel
{
    /// <summary> The unique code of the financial institution. </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary> The name of the financial institution. </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary> The ISPB code of the financial institution. </summary>
    [JsonPropertyName("ispb")]
    public string Ispb { get; set; }

    /// <summary> The type of financial institution. </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary> Constructs a new FinancialInstitution with specified values. </summary>
    /// <param name="code"> The unique code of the financial institution </param>
    /// <param name="name"> The name of the financial institution </param>
    /// <param name="ispb"> The ISPB code of the financial institution </param>
    /// <param name="type"> The type of financial institution </param>
    public FinancialInstitution(string code, string name, string ispb, string type)
    {
        Code = code;
        Name = name;
        Ispb = ispb;
        Type = type;
    }

    /// <summary> Default constructor </summary>
    public FinancialInstitution() { }
}
