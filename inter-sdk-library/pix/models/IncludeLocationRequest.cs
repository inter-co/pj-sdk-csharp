namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code IncludeLocationRequest} class represents a request
/// to include location details for immediate billing.
///
/// <p> It contains the type of immediate billing that is associated
/// with the location request.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class IncludeLocationRequest : AbstractModel
{
    /// <summary> The type of immediate billing associated with the location. </summary>
    [JsonPropertyName("tipoCob")]
    public string ImmediateBillingType { get; set; }

    /// <summary> Constructs a new IncludeLocationRequest with specified values. </summary>
    /// <param _name_="_immediateBillingType_"> The type of immediate billing associated with the location </param>
    public IncludeLocationRequest(string immediateBillingType) : base()
    {
        ImmediateBillingType = immediateBillingType;
    }

    /// <summary> Default constructor </summary>
    public IncludeLocationRequest() { }
}
