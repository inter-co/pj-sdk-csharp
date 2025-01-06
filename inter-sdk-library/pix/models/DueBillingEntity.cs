namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DueBillingEntity} class represents a single billing
/// transaction within a due billing batch.
///
/// <p> It includes fields for the transaction ID (txid), the
/// status of the transaction, any associated problem details, and
/// the creation date of the transaction.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DueBillingEntity : AbstractModel
{
    /// <summary> The transaction ID associated with the billing entity. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }

    /// <summary> The current status of the billing transaction. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary> The problem associated with the billing transaction. </summary>
    [JsonPropertyName("problema")]
    public Problem Problem { get; set; }

    /// <summary> The creation date of the billing transaction. </summary>
    [JsonPropertyName("criacao")]
    public string CreationDate { get; set; }

    /// <summary> Constructs a new DueBillingEntity with specified values. </summary>
    /// <param _name_="_txid_"> The transaction ID associated with the billing entity </param>
    /// <param _name_="_status_"> The current status of the billing transaction </param>
    /// <param _name_="_problem_"> The problem associated with the billing transaction </param>
    /// <param _name_="_creationDate_"> The creation date of the billing transaction </param>
    public DueBillingEntity(string txid, string status, Problem problem, string creationDate) : base()
    {
        Txid = txid;
        Status = status;
        Problem = problem;
        CreationDate = creationDate;
    }

    /// <summary> Default constructor </summary>
    public DueBillingEntity() { }
}
