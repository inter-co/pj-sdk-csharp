namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code ValueComponent} class represents various monetary
/// components related to a financial transaction, including the
/// original amount, change (troco), discounts, and additional
/// charges such as interest (juros) and penalties (multa).
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class ValueComponent : AbstractModel
{
    /// <summary> The original amount of the financial transaction. </summary>
    [JsonPropertyName("original")]
    public ComponentValue Original { get; set; }

    /// <summary> The change (troco) amount to be returned after the transaction. </summary>
    [JsonPropertyName("troco")]
    public ComponentValue Change { get; set; }

    /// <summary> The discount amount (abatimento) applied to the transaction. </summary>
    [JsonPropertyName("abatimento")]
    public ComponentValue DiscountAmount { get; set; }

    /// <summary> The direct discount applied to the transaction. </summary>
    [JsonPropertyName("desconto")]
    public ComponentValue DirectDiscount { get; set; }

    /// <summary> The interest (juros) charged on the transaction. </summary>
    [JsonPropertyName("juros")]
    public ComponentValue Interest { get; set; }

    /// <summary> The penalty (multa) charged on the transaction. </summary>
    [JsonPropertyName("multa")]
    public ComponentValue Penalty { get; set; }

    /// <summary> Constructs a new ValueComponent with specified values. </summary>
    /// <param _name_="_original_"> The original amount of the financial transaction </param>
    /// <param _name_="_change_"> The change amount to be returned after the transaction </param>
    /// <param _name_="_discountAmount_"> The discount amount applied to the transaction </param>
    /// <param _name_="_directDiscount_"> The direct discount applied to the transaction </param>
    /// <param _name_="_interest_"> The interest charged on the transaction </param>
    /// <param _name_="_penalty_"> The penalty charged on the transaction </param>
    public ValueComponent(ComponentValue original, ComponentValue change, ComponentValue discountAmount, ComponentValue directDiscount, ComponentValue interest, ComponentValue penalty) : base()
    {
        Original = original;
        Change = change;
        DiscountAmount = discountAmount;
        DirectDiscount = directDiscount;
        Interest = interest;
        Penalty = penalty;
    }

    /// <summary> Default constructor </summary>
    public ValueComponent() { }
}
