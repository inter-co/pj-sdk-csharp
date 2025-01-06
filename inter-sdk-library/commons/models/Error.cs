namespace inter_sdk_library;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

/// <summary>
/// The Error class represents an error response object containing
/// details about an error that occurred during processing. It includes
/// a title, a detailed description, the timestamp of the error,
/// any violations associated with the error, and additional fields.
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Error
{
    /// <summary>
    /// A brief title summarizing the type of error.
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// A detailed description of the error.
    /// </summary>
    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    /// <summary>
    /// The timestamp of when the error occurred.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; }

    /// <summary>
    /// A list of violations that occurred during the processing.
    /// </summary>
    [JsonPropertyName("violacoes")]
    public List<Violation> Violations { get; set; }

    /// <summary>
    /// An error message.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }
    /// <summary>
    /// Default constructor for Error.
    /// </summary>
    public Error() { }

    /// <summary>
    /// Constructor with parameters for Error.
    /// </summary>
    /// <param name="title">Title summarizing the error</param>
    /// <param name="detail">Detailed description of the error</param>
    /// <param name="timestamp">Timestamp of when the error occurred</param>
    /// <param name="violations">List of violations associated with the error</param>
    public Error(string title, string detail, string timestamp, List<Violation> violations, string message)
    {
        Title = title;
        Detail = detail;
        Timestamp = timestamp;
        Violations = violations;
        Message = message;
    }
}
