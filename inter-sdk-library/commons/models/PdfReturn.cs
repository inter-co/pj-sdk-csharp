namespace inter_sdk_library;

using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// This class represents the necessary configurations
/// for integration with the system. This class contains sensitive
/// information and crucial operating parameters for the client's
/// functionality.
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]public class PdfReturn
{
    /// <summary>
    /// he PDF file represented as a Base64 encoded string.
    /// </summary>
    [JsonPropertyName("pdf")]
    public string Pdf { get; set;}

    public PdfReturn(string pdf)
    {
        Pdf = pdf;
    }
}
