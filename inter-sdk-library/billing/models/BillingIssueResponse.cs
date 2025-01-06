namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code BillingIssueResponse} class represents the response received after
/// issuing a billing statement, containing the request code assigned automatically
/// by the bank upon the issuance of the title.
/// <para> 
/// This response is critical for confirming successful billing operations,
/// allowing users to track or reference their requests based on the generated request code.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingIssueResponse : AbstractModel
{
    /// <summary> The request code assigned by the bank. </summary>
    [JsonPropertyName("codigoSolicitacao")]
    public string RequestCode { get; set; }

    /// <summary> Constructs a new BillingIssueResponse with specified values. </summary>
    /// <param name="requestCode"> The request code assigned by the bank </param>
    public BillingIssueResponse(string requestCode)
    {
        RequestCode = requestCode;
    }

    /// <summary> Default constructor </summary>
    public BillingIssueResponse() { }
}
