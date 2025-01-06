namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingRetrieveCallbacksFilter
{
    /// <summary> The billing request code. </summary>
    [JsonPropertyName("codigoSolicitacao")]
    public string RequestCode { get; set; }

    /// <summary> Constructs a new BillingRetrieveCallbacksFilter with specified values. </summary>
    public BillingRetrieveCallbacksFilter(string requestCode)
    {
        RequestCode = requestCode;
    }

    /// <summary> Default constructor </summary>
    public BillingRetrieveCallbacksFilter() { }
}
