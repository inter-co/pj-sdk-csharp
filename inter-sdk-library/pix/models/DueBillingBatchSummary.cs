namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DueBillingBatchSummary} class summarizes the results
/// of a billing batch processing.
///
/// <p> It includes fields for the creation date of the processing,
/// the status of the processing, and totals for the billing transactions
/// including the total number of charges, denied charges, and created
/// charges in the batch.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DueBillingBatchSummary : AbstractModel
{
    /// <summary> The creation date of the processing operation. </summary>
    [JsonPropertyName("dataCriacaoProcessamento")]
    public string ProcessingCreationDate { get; set; }

    /// <summary> The status of the processing operation. </summary>
    [JsonPropertyName("statusProcessamento")]
    public string ProcessingStatus { get; set; }

    /// <summary> The total number of charges in the batch. </summary>
    [JsonPropertyName("totalCobrancas")]
    public int? TotalBilling { get; set; }

    /// <summary> The total number of denied charges. </summary>
    [JsonPropertyName("totalCobrancasNegadas")]
    public int? TotalBillingDenied { get; set; }

    /// <summary> The total number of created charges. </summary>
    [JsonPropertyName("totalCobrancasCriadas")]
    public int? TotalBillingCreated { get; set; }

    /// <summary> Constructs a new DueBillingBatchSummary with specified values. </summary>
    /// <param _name_="_processingCreationDate_"> The creation date of the processing operation </param>
    /// <param _name_="_processingStatus_"> The status of the processing operation </param>
    /// <param _name_="_totalBilling_"> The total number of charges in the batch </param>
    /// <param _name_="_totalBillingDenied_"> The total number of denied charges </param>
    /// <param _name_="_totalBillingCreated_"> The total number of created charges </param>
    public DueBillingBatchSummary(string processingCreationDate, string processingStatus, int? totalBilling, int? totalBillingDenied, int? totalBillingCreated) : base()
    {
        ProcessingCreationDate = processingCreationDate;
        ProcessingStatus = processingStatus;
        TotalBilling = totalBilling;
        TotalBillingDenied = totalBillingDenied;
        TotalBillingCreated = totalBillingCreated;
    }

    /// <summary> Default constructor </summary>
    public DueBillingBatchSummary() { }
}
