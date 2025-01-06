namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code Message} class represents a customizable message that can be
/// displayed to users, consisting of up to five lines of text.
/// <para> 
/// It is used to map data from a JSON structure, allowing the
/// deserialization of received information for user notifications or alerts.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Message : AbstractModel
{
    /// <summary> The first line of the message. </summary>
    [JsonPropertyName("linha1")]
    public string Line1 { get; set; }

    /// <summary> The second line of the message. </summary>
    [JsonPropertyName("linha2")]
    public string Line2 { get; set; }

    /// <summary> The third line of the message. </summary>
    [JsonPropertyName("linha3")]
    public string Line3 { get; set; }

    /// <summary> The fourth line of the message. </summary>
    [JsonPropertyName("linha4")]
    public string Line4 { get; set; }

    /// <summary> The fifth line of the message. </summary>
    [JsonPropertyName("linha5")]
    public string Line5 { get; set; }

    /// <summary> Constructs a new Message with specified values. </summary>
    /// <param name="line1"> The first line of the message </param>
    /// <param name="line2"> The second line of the message </param>
    /// <param name="line3"> The third line of the message </param>
    /// <param name="line4"> The fourth line of the message </param>
    /// <param name="line5"> The fifth line of the message </param>
    public Message(string line1, string line2, string line3, string line4, string line5)
    {
        Line1 = line1;
        Line2 = line2;
        Line3 = line3;
        Line4 = line4;
        Line5 = line5;
    }

    /// <summary> Default constructor </summary>
    public Message() { }
}
