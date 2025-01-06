namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DevolutionRequestBody} class represents the body
/// of a request for a devolution (refund) operation.
///
/// <p> It includes the refund amount, nature of the devolution,
/// and a description to provide context for the refund request.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DevolutionRequestBody : AbstractModel
{
    /// <summary> The amount to be refunded. </summary>
    [JsonPropertyName("valor")]
    public string Value { get; set; }

    /// <summary> The nature of the devolution. </summary>
    [JsonPropertyName("natureza")]
    public string Nature { get; set; }

    /// <summary> A description of the devolution request. </summary>
    [JsonPropertyName("descricao")]
    public string Description { get; set; }

    /// <summary> Constructs a new DevolutionRequestBody with specified values. </summary>
    /// <param _name_="_value_"> The amount to be refunded </param>
    /// <param _name_="_nature_"> The nature of the devolution </param>
    /// <param _name_="_description_"> A description of the devolution request </param>
    public DevolutionRequestBody(string value, string nature, string description)
    {
        Value = value;
        Nature = nature;
        Description = description;
    }

    /// <summary> Default constructor </summary>
    public DevolutionRequestBody() { }
}
