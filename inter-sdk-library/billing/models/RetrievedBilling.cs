namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
/// <summary>
/// The {@code RetrievedBilling} class represents the response containing different
/// formats of a retrieved billing.
/// <para> 
/// It includes references to the billing information, the associated
/// billing slip (billet), and the Pix payment details. This class is used to
/// consolidate data from multiple retrieval responses, allowing for easy access
/// to all relevant billing formats in a single structure.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class RetrievedBilling : AbstractModel
{
    /// <summary> The detailed billing information. </summary>
    [JsonPropertyName("cobranca")]
    public BillingRetrievingResponse Billing { get; set; }

    /// <summary> The billing slip associated with the payment. </summary>
    [JsonPropertyName("boleto")]
    public BillingBilletRetrievingResponse Slip { get; set; }

    /// <summary> The Pix payment details associated with the billing. </summary>
    [JsonPropertyName("pix")]
    public BillingPixRetrievingResponse Pix { get; set; }

    /// <summary> Constructs a new RetrievedBilling with specified values. </summary>
    /// <param name="billing"> The detailed billing information </param>
    /// <param name="slip"> The billing slip associated with the payment </param>
    /// <param name="pix"> The Pix payment details associated with the billing </param>
    public RetrievedBilling(BillingRetrievingResponse billing, BillingBilletRetrievingResponse slip, BillingPixRetrievingResponse pix)
    {
        Billing = billing;
        Slip = slip;
        Pix = pix;
    }

    /// <summary> Default constructor </summary>
    public RetrievedBilling() { }
}
