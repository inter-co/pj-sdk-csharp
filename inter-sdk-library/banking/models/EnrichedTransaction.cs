namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
/// <summary>
/// Represents a financial transaction with enriched details, including information such as CPMF, transaction ID,
/// inclusion date, transaction date, transaction type, operation type, value, title, description, and details.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON, allowing the deserialization of received
/// information. It uses System.Text.Json for JSON mapping.
/// <para>
/// The class includes fields for CPMF, transaction ID, inclusion date, transaction date, transaction type,
/// operation type, value, title, description, and details. It overrides Equals, GetHashCode, and ToString methods
/// to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/>
/// <since>1.0</since>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class EnrichedTransaction : AbstractModel
{
    /// <summary> The CPMF of the transaction. </summary>
    [JsonPropertyName("cpmf")]
    public string Cpmf { get; set; }
    /// <summary> The ID of the transaction. </summary>
    [JsonPropertyName("idTransacao")]
    public string TransactionId { get; set; }
    /// <summary> The inclusion date of the transaction. </summary>
    [JsonPropertyName("dataInclusao")]
    public string InclusionDate { get; set; }
    /// <summary> The transaction date. </summary>
    [JsonPropertyName("dataTransacao")]
    public string TransactionDate { get; set; }
    /// <summary> The type of the transaction. </summary>
    [JsonPropertyName("tipoTransacao")]
    public string TransactionType { get; set; }
    /// <summary> The type of the operation. </summary>
    [JsonPropertyName("tipoOperacao")]
    public string OperationType { get; set; }
    /// <summary> The value of the transaction. </summary>
    [JsonPropertyName("valor")]
    public string Value { get; set; }
    /// <summary> The title of the transaction. </summary>
    [JsonPropertyName("titulo")]
    public string Title { get; set; }
    /// <summary> The description of the transaction. </summary>
    [JsonPropertyName("descricao")]
    public string Description { get; set; }
    /// <summary> The details of the transaction. </summary>
    [JsonPropertyName("detalhes")]
    public EnrichedTransactionDetails Details { get; set; }
    /// <summary> Constructs a new EnrichedTransaction with specified values. </summary>
    /// <param name="cpmf"> The CPMF of the transaction </param>
    /// <param name="transactionId"> The ID of the transaction </param>
    /// <param name="inclusionDate"> The inclusion date of the transaction </param>
    /// <param name="transactionDate"> The transaction date </param>
    /// <param name="transactionType"> The type of the transaction </param>
    /// <param name="operationType"> The type of the operation </param>
    /// <param name="value"> The value of the transaction </param>
    /// <param name="title"> The title of the transaction </param>
    /// <param name="description"> The description of the transaction </param>
    /// <param name="details"> The details of the transaction </param>
    public EnrichedTransaction(string cpmf,
                               string transactionId,
                               string inclusionDate,
                               string transactionDate,
                               string transactionType,
                               string operationType,
                               string value,
                               string title,
                               string description,
                                EnrichedTransactionDetails details)
    {
        Cpmf = cpmf;
        TransactionId = transactionId;
        InclusionDate = inclusionDate;
        TransactionDate = transactionDate;
        TransactionType = transactionType;
        OperationType = operationType;
        Value = value;
        Title = title;
        Description = description;
        Details = details;
    }
    /// <summary> Default constructor </summary>
    public EnrichedTransaction() { }
}
