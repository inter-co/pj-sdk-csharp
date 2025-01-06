namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Represents the balance of a bank account, including information about available,
/// blocked amounts, and limits.
/// <para />
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses Newtonsoft.Json
/// for JSON mapping.
/// <para />
/// The class includes fields for available balance, blocked amounts due to various reasons,
/// and credit limit. It overrides Equals, GetHashCode, and ToString methods to include both
/// its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/>
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Balance : AbstractModel
{
    /// <summary>
    /// The available balance in the account.
    /// </summary>
    [JsonPropertyName("disponivel")]
    public decimal Available { get; set; }

    /// <summary>
    /// The amount blocked due to checks.
    /// </summary>
    [JsonPropertyName("bloqueadoCheque")]
    public decimal CheckBlocked { get; set; }

    /// <summary>
    /// The amount blocked due to judicial orders.
    /// </summary>
    [JsonPropertyName("bloqueadoJudicialmente")]
    public decimal JudiciallyBlocked { get; set; }

    /// <summary>
    /// The amount blocked due to administrative reasons.
    /// </summary>
    [JsonPropertyName("bloqueadoAdministrativo")]
    public decimal AdministrativelyBlocked { get; set; }

    /// <summary>
    /// The credit limit of the account.
    /// </summary>
    [JsonPropertyName("limite")]
    public decimal Limit { get; set; }

    /// <summary>
    /// Constructs a new Balance with specified values.
    /// </summary>
    /// <param name="available">The available balance in the account</param>
    /// <param name="checkBlocked">The amount blocked due to checks</param>
    /// <param name="judiciallyBlocked">The amount blocked due to judicial orders</param>
    /// <param name="administrativelyBlocked">The amount blocked due to administrative reasons</param>
    /// <param name="limit">The credit limit of the account</param>
    public Balance(decimal available,
                   decimal checkBlocked,
                   decimal judiciallyBlocked,
                   decimal administrativelyBlocked,
                   decimal limit)
    {
        Available = available;
        CheckBlocked = checkBlocked;
        JudiciallyBlocked = judiciallyBlocked;
        AdministrativelyBlocked = administrativelyBlocked;
        Limit = limit;
    }
    public Balance() { }
}