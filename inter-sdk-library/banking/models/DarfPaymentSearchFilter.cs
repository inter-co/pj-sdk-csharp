namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a filter structure used to search for DARF (Documento de Arrecadação de Receitas Federais) payments.
/// It includes criteria such as transaction code, revenue code, and the type of date to filter by.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para>
/// The class includes fields for request code, revenue code, and the type of date to filter by.
/// It overrides Equals, GetHashCode, and ToString methods to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/> 
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DarfPaymentSearchFilter : AbstractModel
{
    /// <summary> The request code for the DARF payment. </summary>
    [JsonPropertyName("codigoSolicitacao")]
    public string RequestCode { get; set; }

    /// <summary> The revenue code for the DARF payment. </summary>
    [JsonPropertyName("codigoReceita")]
    public string RevenueCode { get; set; }

    /// <summary> The type of date to filter payments by. </summary>
    [JsonPropertyName("filtrarDataPor")]
    public string FilterDateBy { get; set; }

    /// <summary> Constructs a new DarfPaymentSearchFilter with specified values. </summary>
    /// <param name="requestCode"> The request code for the DARF payment </param>
    /// <param name="revenueCode"> The revenue code for the DARF payment </param>
    /// <param name="filterDateBy"> The type of date to filter payments by </param>
    public DarfPaymentSearchFilter(string requestCode, string revenueCode, string filterDateBy)
    {
        RequestCode = requestCode;
        RevenueCode = revenueCode;
        FilterDateBy = filterDateBy;
    }

    /// <summary> Default constructor </summary>
    public DarfPaymentSearchFilter() { }
}
