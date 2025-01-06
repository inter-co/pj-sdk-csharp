namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code ComponentValue} class represents a component associated
/// with a monetary value.
///
/// <p> It includes the value, the agent's modality, and the
/// service provider responsible for handling withdrawal transactions.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class ComponentValue : AbstractModel
{
    /// <summary> The monetary value of the component. </summary>
    /// <p> This field holds the amount associated with the
    /// component, represented as a string. </p>
    [JsonPropertyName("valor")]
    public string Value { get; set; }

    /// <summary> The modality of the agent involved in the withdrawal. </summary>
    [JsonPropertyName("modalidadeAgente")]
    public string AgentModality { get; set; }

    /// <summary> The service provider handling withdrawal transactions. </summary>
    [JsonPropertyName("prestadorDoServicoDeSaque")]
    public string WithdrawalServiceProvider { get; set; }

    /// <summary> Constructs a new ComponentValue with specified values. </summary>
    /// <param _name_="_value_"> The monetary value of the component </param>
    /// <param _name_="_agentModality_"> The modality of the agent involved in the withdrawal </param>
    /// <param _name_="_withdrawalServiceProvider_"> The service provider handling withdrawal transactions </param>
    public ComponentValue(string value, string agentModality, string withdrawalServiceProvider)
    {
        Value = value;
        AgentModality = agentModality;
        WithdrawalServiceProvider = withdrawalServiceProvider;
    }

    /// <summary> Default constructor </summary>
    public ComponentValue() { }
}
