namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Withdrawal} class represents details regarding a withdrawal
/// transaction. It includes fields such as the amount of the withdrawal,
/// the modification modality, the agent modality used for the transaction,
/// and the service provider responsible for the withdrawal.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Withdrawal : AbstractModel
{
    /// <summary> The amount of the withdrawal. </summary>
    [JsonPropertyName("valor")]
    public string Amount { get; set; }

    /// <summary> The modification modality for the withdrawal. </summary>
    [JsonPropertyName("modalidadeAlteracao")]
    public int? ModificationModality { get; set; } // Changed to int? to allow nulls

    /// <summary> The agent modality used for the transaction. </summary>
    [JsonPropertyName("modalidadeAgente")]
    public string AgentModality { get; set; }

    /// <summary> The service provider responsible for the withdrawal. </summary>
    [JsonPropertyName("prestadorDoServicoDeSaque")]
    public string WithdrawalServiceProvider { get; set; }

    /// <summary> Constructs a new Withdrawal with specified values. </summary>
    /// <param _name_="_amount_"> The amount of the withdrawal </param>
    /// <param _name_="_modificationModality_"> The modification modality for the withdrawal </param>
    /// <param _name_="_agentModality_"> The agent modality used for the transaction </param>
    /// <param _name_="_withdrawalServiceProvider_"> The service provider responsible for the withdrawal </param>
    public Withdrawal(string amount, int? modificationModality, string agentModality, string withdrawalServiceProvider) : base()
    {
        Amount = amount;
        ModificationModality = modificationModality;
        AgentModality = agentModality;
        WithdrawalServiceProvider = withdrawalServiceProvider;
    }

    /// <summary> Default constructor </summary>
    public Withdrawal() { }
}