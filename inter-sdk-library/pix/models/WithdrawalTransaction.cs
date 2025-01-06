namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code WithdrawalTransaction} class represents details of a
/// withdrawal operation. It includes fields for the withdrawal
/// details ({@link Withdrawal}) and any change returned ({@link Change}).
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class WithdrawalTransaction : AbstractModel
{
    /// <summary> The details of the withdrawal operation. </summary>
    [JsonPropertyName("saque")]
    public Withdrawal Withdrawal { get; set; }

    /// <summary> The change returned during the withdrawal. </summary>
    [JsonPropertyName("troco")]
    public Change Change { get; set; }

    /// <summary> Constructs a new WithdrawalTransaction with specified values. </summary>
    /// <param _name_="_withdrawal_"> The details of the withdrawal operation </param>
    /// <param _name_="_change_"> The change returned during the withdrawal </param>
    public WithdrawalTransaction(Withdrawal withdrawal, Change change) : base()
    {
        Withdrawal = withdrawal;
        Change = change;
    }

    /// <summary> Default constructor </summary>
    public WithdrawalTransaction() { }
}
