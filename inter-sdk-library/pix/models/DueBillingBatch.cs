namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DueBillingBatch} class represents a batch of due billing
/// transactions.
///
/// <p> It includes fields for the batch ID, a description of the batch,
/// the creation date, and a list of individual due billing entities
/// associated with this batch.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DueBillingBatch : AbstractModel
{
    /// <summary> The unique identifier for the billing batch. </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary> A description of the billing batch. </summary>
    [JsonPropertyName("descricao")]
    public string Description { get; set; }

    /// <summary> The creation date of the billing batch. </summary>
    [JsonPropertyName("criacao")]
    public string CreationDate { get; set; }

    /// <summary> A list of due billing entities within the batch. </summary>
    [JsonPropertyName("cobsv")]
    public List<DueBillingEntity> DueBillingEntities { get; set; }

    /// <summary> Constructs a new DueBillingBatch with specified values. </summary>
    /// <param _name_="_id_"> The unique identifier for the billing batch </param>
    /// <param _name_="_description_"> A description of the billing batch </param>
    /// <param _name_="_creationDate_"> The creation date of the billing batch </param>
    /// <param _name_="_dueBillingEntities_"> A list of due billing entities within the batch </param>
    public DueBillingBatch(int id, string description, string creationDate, List<DueBillingEntity> dueBillingEntities) : base()
    {
        Id = id;
        Description = description;
        CreationDate = creationDate;
        DueBillingEntities = dueBillingEntities;
    }

    /// <summary> Default constructor </summary>
    public DueBillingBatch() { }
}
