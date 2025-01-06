namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DueBillingCalendar} class represents the calendar details
/// related to a billing transaction.
///
/// <p> It includes fields for the creation date, validity period
/// after expiration, and the due date. This structure is essential for
/// managing the timing and validity of billing processes.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DueBillingCalendar : AbstractModel
{
    /// <summary> The creation date of the billing entry. </summary>
    [JsonPropertyName("criacao")]
    public DateTime CreationDate { get; set; }

    /// <summary> The validity period after the due date. </summary>
    [JsonPropertyName("validadeAposVencimento")]
    public int? ValidityAfterExpiration { get; set; }

    /// <summary> The due date for the billing transaction. </summary>
    [JsonPropertyName("dataDeVencimento")]
    public string DueDate { get; set; }

    /// <summary> Constructs a new DueBillingCalendar with specified values. </summary>
    /// <param _name_="_creationDate_"> The creation date of the billing entry </param>
    /// <param _name_="_validityAfterExpiration_"> The validity period after the due date </param>
    /// <param _name_="_dueDate_"> The due date for the billing transaction </param>
    public DueBillingCalendar(DateTime creationDate, int? validityAfterExpiration, string dueDate) : base()
    {
        CreationDate = creationDate;
        ValidityAfterExpiration = validityAfterExpiration;
        DueDate = dueDate;
    }

    /// <summary> Default constructor </summary>
    public DueBillingCalendar() { }
}
