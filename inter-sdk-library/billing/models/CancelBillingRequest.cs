namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code CancelBillingRequest} class represents a request to cancel a billing.
/// <para> 
/// This class includes the reason for cancellation and allows for the
/// inclusion of additional fields that may be required by the specific use case.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class CancelBillingRequest : AbstractModel
{
    /// <summary> The reason for canceling the billing. </summary>
    [JsonPropertyName("motivoCancelamento")]
    public string CancellationReason { get; set; }

    /// <summary> Constructs a new CancelBillingRequest with specified values. </summary>
    /// <param name="cancellationReason"> The reason for canceling the billing </param>
    public CancelBillingRequest(string cancellationReason)
    {
        CancellationReason = cancellationReason;
    }

    /// <summary> Default constructor </summary>
    public CancelBillingRequest() { }
}
