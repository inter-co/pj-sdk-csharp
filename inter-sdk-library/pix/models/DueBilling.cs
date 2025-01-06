namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DueBilling} class represents the details of a billing
/// transaction that is due for payment.
///
/// <p> It includes fields for a unique key, payer's request,
/// additional information, debtor details, location, due billing
/// value, due billing calendar, and transaction ID (txid). It also
/// supports additional custom fields through a map of additional
/// attributes.
/// </p>
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DueBilling : AbstractModel
{
    /// <summary> The unique key for the billing transaction. </summary>
    [JsonPropertyName("chave")]
    public string Key { get; set; }

    /// <summary> The payer's request associated with the transaction. </summary>
    [JsonPropertyName("solicitacaoPagador")]
    public string PayerRequest { get; set; }

    /// <summary> Additional information relevant to the billing transaction. </summary>
    [JsonPropertyName("infoAdicionais")]
    public List<AdditionalInfo> AdditionalInfo { get; set; }

    /// <summary> The debtor associated with the billing transaction. </summary>
    [JsonPropertyName("devedor")]
    public Debtor Debtor { get; set; }

    /// <summary> The location relevant to the billing transaction. </summary>
    [JsonPropertyName("loc")]
    public Location Location { get; set; }

    /// <summary> The due billing value for the transaction. </summary>
    [JsonPropertyName("valor")]
    public DueBillingValue Value { get; set; }

    /// <summary> The calendar associated with the billing. </summary>
    [JsonPropertyName("calendario")]
    public DueBillingCalendar Calendar { get; set; }

    /// <summary> The transaction ID associated with the billing. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }

    /// <summary> Constructs a new DueBilling with specified values. </summary>
    /// <param _name_="_key_"> The unique key for the billing transaction </param>
    /// <param _name_="_payerRequest_"> The payer's request associated with the transaction </param>
    /// <param _name_="_additionalInfo_"> Additional information relevant to the billing transaction </param>
    /// <param _name_="_debtor_"> The debtor associated with the billing transaction </param>
    /// <param _name_="_location_"> The location relevant to the billing transaction </param>
    /// <param _name_="_value_"> The due billing value for the transaction </param>
    /// <param _name_="_calendar_"> The calendar associated with the billing </param>
    /// <param _name_="_txid_"> The transaction ID associated with the billing </param>
    public DueBilling(string key, string payerRequest, List<AdditionalInfo> additionalInfo, Debtor debtor, Location location, DueBillingValue value, DueBillingCalendar calendar, string txid) : base()
    {
        Key = key;
        PayerRequest = payerRequest;
        AdditionalInfo = additionalInfo;
        Debtor = debtor;
        Location = location;
        Value = value;
        Calendar = calendar;
        Txid = txid;
    }

    /// <summary> Default constructor </summary>
    public DueBilling() { }
}
