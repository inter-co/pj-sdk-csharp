namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Change} class represents details regarding change to be
/// returned in a withdrawal transaction.
///
/// <p> It includes fields such as the amount of change, the
/// modification modality, the agent modality used for the transaction,
/// and the service provider responsible for the change service.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Change : AbstractModel
{
    /// <summary> The amount of change to be returned. </summary>
    [JsonPropertyName("valor")]
    public string Amount { get; set; }

    /// <summary> The modality of modification applicable to the change. </summary>
    [JsonPropertyName("modalidadeAlteracao")]
    public int? ModificationModality { get; set; }

    /// <summary> The modality of the agent involved in the transaction. </summary>
    [JsonPropertyName("modalidadeAgente")]
    public string AgentModality { get; set; }

    /// <summary> The service provider responsible for the change service. </summary>
    /// <p> This field identifies the provider that handles
    /// the service of returning change during the withdrawal. </p>
    [JsonPropertyName("prestadorDoServicoDeSaque")]
    public string ChangeServiceProvider { get; set; }

    /// <summary> Constructs a new Change with specified values. </summary>
    /// <param _name_="_amount_"> The amount of change to be returned </param>
    /// <param _name_="_modificationModality_"> The modality of modification applicable to the change </param>
    /// <param _name_="_agentModality_"> The modality of the agent involved in the transaction </param>
    /// <param _name_="_changeServiceProvider_"> The service provider responsible for the change service </param>
    public Change(string amount, int? modificationModality, string agentModality, string changeServiceProvider)
    {
        Amount = amount;
        ModificationModality = modificationModality;
        AgentModality = agentModality;
        ChangeServiceProvider = changeServiceProvider;
    }

    /// <summary> Default constructor </summary>
    public Change() { }
}
