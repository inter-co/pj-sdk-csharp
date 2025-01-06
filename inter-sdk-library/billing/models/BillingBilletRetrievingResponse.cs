namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code BillingBilletRetrievingResponse} class represents the response received
/// when retrieving information about a billing slip.
/// <para> 
/// It contains details such as the unique number assigned to the billing
/// slip, the barcode for payment, and the digit line that can be used for manual entry.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingBilletRetrievingResponse : AbstractModel
{
    /// <summary> The unique number assigned to the billing slip. </summary>
    [JsonPropertyName("nossoNumero")]
    public string OurNumber { get; set; }

    /// <summary> The barcode for payment. </summary>
    [JsonPropertyName("codigoBarras")]
    public string Barcode { get; set; }

    /// <summary> The digit line for manual entry. </summary>
    [JsonPropertyName("linhaDigitavel")]
    public string DigitLine { get; set; }

    /// <summary> Constructs a new BillingBilletRetrievingResponse with specified values. </summary>
    /// <param name="ourNumber"> The unique number assigned to the billing slip </param>
    /// <param name="barcode"> The barcode for payment </param>
    /// <param name="digitLine"> The digit line for manual entry </param>
    public BillingBilletRetrievingResponse(string ourNumber, string barcode, string digitLine)
    {
        OurNumber = ourNumber;
        Barcode = barcode;
        DigitLine = digitLine;
    }

    /// <summary> Default constructor </summary>
    public BillingBilletRetrievingResponse() { }
}
