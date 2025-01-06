namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DueBillingValue} class represents the structure of a billing
/// value in a transaction.
///
/// <p> It includes fields for the original value, fines (Fine),
/// fees (Fees), reductions (Reduction), and discounts (Discount).
/// This structure allows for a comprehensive representation of all
/// financial aspects related to the billing transaction.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DueBillingValue : AbstractModel
{
    /// <summary> The original value of the billing transaction. </summary>
    [JsonPropertyName("original")]
    public string OriginalValue { get; set; }

    /// <summary> The penalty associated with the billing transaction. </summary>
    [JsonPropertyName("multa")]
    public PixFine Penalty { get; set; }

    /// <summary> The fees associated with the billing transaction. </summary>
    [JsonPropertyName("juros")]
    public Fees Interest { get; set; }

    /// <summary> The reduction applied to the billing transaction. </summary>
    [JsonPropertyName("abatimento")]
    public Reduction Reduction { get; set; }

    /// <summary> The discount applied to the billing transaction. </summary>
    [JsonPropertyName("desconto")]
    public PixDiscount Discount { get; set; }

    /// <summary> Constructs a new DueBillingValue with specified values. </summary>
    /// <param _name_="_originalValue_"> The original value of the billing transaction </param>
    /// <param _name_="_penalty_"> The penalty associated with the billing transaction </param>
    /// <param _name_="_interest_"> The fees associated with the billing transaction </param>
    /// <param _name_="_reduction_"> The reduction applied to the billing transaction </param>
    /// <param _name_="_discount_"> The discount applied to the billing transaction </param>
    public DueBillingValue(string originalValue, PixFine penalty, Fees interest, Reduction reduction, PixDiscount discount) : base()
    {
        OriginalValue = originalValue;
        Penalty = penalty;
        Interest = interest;
        Reduction = reduction;
        Discount = discount;
    }

    /// <summary> Default constructor </summary>
    public DueBillingValue() { }
}
