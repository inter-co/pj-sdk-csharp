namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a filter structure used to search for payments.
/// <para> 
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para> 
/// The class includes fields for barcode, transaction code, and the type of date 
/// to filter by. It overrides Equals, GetHashCode, and ToString methods to include 
/// both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/> 
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PaymentSearchFilter : AbstractModel
{
    /// <summary> The barcode for the payment. </summary>
    [JsonPropertyName("codBarraLinhaDigitavel")]
    public string Barcode { get; set; }

    /// <summary> The unique transaction code. </summary>
    [JsonPropertyName("codigoTransacao")]
    public string TransactionCode { get; set; }

    /// <summary> The type of date to filter payments by. </summary>
    [JsonPropertyName("filtrarDataPor")]
    public string FilterDateBy { get; set; }

    /// <summary> Constructs a new PaymentSearchFilter with specified values. </summary>
    /// <param name="barcode"> The barcode for the payment </param>
    /// <param name="transactionCode"> The unique transaction code </param>
    /// <param name="filterDateBy"> The type of date to filter payments by </param>
    public PaymentSearchFilter(string barcode, string transactionCode, string filterDateBy)
    {
        Barcode = barcode;
        TransactionCode = transactionCode;
        FilterDateBy = filterDateBy;
    }

    /// <summary> Default constructor </summary>
    public PaymentSearchFilter() { }
}
