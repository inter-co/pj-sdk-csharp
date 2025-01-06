namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code PixHistoryEntity} class represents an entry in the history of a Pix payment.
/// <para> 
/// It includes details about the status of the Pix transaction and the timestamp
/// of the event, enabling tracking of changes throughout the transaction process.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixHistoryEntity : AbstractModel
{
    /// <summary> The status of the Pix transaction. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary> The date and time of the event related to the Pix transaction. </summary>
    [JsonPropertyName("dataHoraEvento")]
    public string EventDateTime { get; set; }

    /// <summary> Constructs a new PixHistoryEntity with specified values. </summary>
    /// <param name="status"> The status of the Pix transaction </param>
    /// <param name="eventDateTime"> The date and time of the event related to the Pix transaction </param>
    public PixHistoryEntity(string status, string eventDateTime)
    {
        Status = status;
        EventDateTime = eventDateTime;
    }

    /// <summary> Default constructor </summary>
    public PixHistoryEntity() { }
}
