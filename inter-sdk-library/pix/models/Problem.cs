namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Problem} class represents an error or problem encountered
/// during a PIX transaction. It includes various fields detailing the
/// nature of the problem, including its type, title, status, and any
/// relevant violations.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Problem : AbstractModel
{
    /// <summary> The type of the problem. </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary> A brief title describing the problem. </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary> The HTTP status code associated with the problem. </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; } // Changed to int? to allow nulls

    /// <summary> Detailed information about the problem. </summary>
    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    /// <summary> A unique correlation ID for tracing the problem. </summary>
    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; set; }

    /// <summary> A list of violations associated with the problem. </summary>
    [JsonPropertyName("violacoes")]
    public List<Violation> Violations { get; set; }

    /// <summary> Constructs a new Problem with specified values. </summary>
    /// <param _name_="_type_"> The type of the problem </param>
    /// <param _name_="_title_"> A brief title describing the problem </param>
    /// <param _name_="_status_"> The HTTP status code associated with the problem </param>
    /// <param _name_="_detail_"> Detailed information about the problem </param>
    /// <param _name_="_correlationId_"> A unique correlation ID for tracing the problem </param>
    /// <param _name_="_violations_"> A list of violations associated with the problem </param>
    public Problem(string type, string title, int? status, string detail, string correlationId, List<Violation> violations) : base()
    {
        Type = type;
        Title = title;
        Status = status;
        Detail = detail;
        CorrelationId = correlationId;
        Violations = violations;
    }

    /// <summary> Default constructor </summary>
    public Problem() { }
}
