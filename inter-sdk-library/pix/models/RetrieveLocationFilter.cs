namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code RetrieveLocationFilter} class is used to filter location
/// requests based on certain criteria, including the presence of
/// transaction ID and the type of immediate billing.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class RetrieveLocationFilter : AbstractModel
{
    /// <summary> Indicates whether a transaction ID is present. </summary>
    [JsonPropertyName("txIdPresente")]
    public bool? TxIdPresent { get; set; } // Changed to bool? to allow nulls

    /// <summary> The type of immediate billing for filtering location requests. </summary>
    [JsonPropertyName("tipoCob")]
    public string BillingType { get; set; }

    /// <summary> Constructs a new RetrieveLocationFilter with specified values. </summary>
    /// <param _name_="_txIdPresent_"> Indicates whether a transaction ID is present </param>
    /// <param _name_="_billingType_"> The type of immediate billing for filtering location requests </param>
    public RetrieveLocationFilter(bool? txIdPresent, string billingType) : base()
    {
        TxIdPresent = txIdPresent;
        BillingType = billingType;
    }

    /// <summary> Default constructor </summary>
    public RetrieveLocationFilter() { }
}
