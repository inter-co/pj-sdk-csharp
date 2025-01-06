namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code PixPayload} class represents a container for a list of
/// transaction items related to PIX (Payment Instantâneo).
/// It holds multiple item payloads.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixPayload : AbstractModel
{
    /// <summary> A list of transaction items related to PIX. </summary>
    [JsonPropertyName("pix")]
    public List<ItemPayload> PixItems { get; set; }

    /// <summary> Constructs a new PixPayload with specified values. </summary>
    /// <param _name_="_pixItems_"> A list of transaction items related to PIX </param>
    public PixPayload(List<ItemPayload> pixItems) : base()
    {
        PixItems = pixItems;
    }

    /// <summary> Default constructor </summary>
    public PixPayload() { }
}
