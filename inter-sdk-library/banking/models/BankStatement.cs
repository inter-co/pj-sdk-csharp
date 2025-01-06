namespace inter_sdk_library;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Represents a bank statement, including a list of transactions.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses Newtonsoft.Json
/// for JSON mapping.
/// <para>
/// The class includes a list of transactions. It overrides Equals, GetHashCode,
/// and ToString methods to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/>
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BankStatement : AbstractModel
{
    /// <summary>
    /// The list of transactions in the bank statement.
    /// </summary>
    [JsonPropertyName("transacoes")]
    public List<Transaction> Transactions { get; set; }

    /// <summary> Default constructor </summary>
    public BankStatement() { }

    /// <summary> Constructs a new BankStatement with specified transactions. </summary>
    /// <param name="transactions">The list of transactions in the bank statement</param>
    public BankStatement(List<Transaction> transactions)
    {
        Transactions = transactions;
    }
}
