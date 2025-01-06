namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code PixBilling} class represents the detailed information
/// about a PIX billing transaction. It includes fields for the transaction
/// ID (txid), calendar details, debtor information, location, transaction
/// value (PixValue), key, payer request, and additional information.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixBilling : AbstractModel
{
    /// <summary> The transaction ID (txid) associated with the PIX billing. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }

    /// <summary> The calendar details related to the transaction. </summary>
    [JsonPropertyName("calendario")]
    public Calendar Calendar { get; set; }

    /// <summary> Information about the debtor. </summary>
    [JsonPropertyName("devedor")]
    public Debtor Debtor { get; set; }

    /// <summary> Location details associated with the PIX billing. </summary>
    [JsonPropertyName("loc")]
    public Location Location { get; set; }

    /// <summary> The transaction value represented by an instance of PixValue. </summary>
    [JsonPropertyName("valor")]
    public PixValue Value { get; set; }

    /// <summary> The recipient's key used for the transfer. </summary>
    [JsonPropertyName("chave")]
    public string Key { get; set; }

    /// <summary> The payer's request information as a string. </summary>
    [JsonPropertyName("solicitacaoPagador")]
    public string PayerRequest { get; set; }

    /// <summary> Additional information related to the billing as a list. </summary>
    [JsonPropertyName("infoAdicionais")]
    public List<AdditionalInfo> AdditionalInfo { get; set; }

    /// <summary> Constructs a new PixBilling with specified values. </summary>
    /// <param _name_="_txid_"> The transaction ID (txid) associated with the PIX billing </param>
    /// <param _name_="_calendar_"> The calendar details related to the transaction </param>
    /// <param _name_="_debtor_"> Information about the debtor </param>
    /// <param _name_="_location_"> Location details associated with the PIX billing </param>
    /// <param _name_="_value_"> The transaction value represented by an instance of PixValue </param>
    /// <param _name_="_key_"> The recipient's key used for the transfer </param>
    /// <param _name_="_payerRequest_"> The payer's request information as a string </param>
    /// <param _name_="_additionalInfo_"> Additional information related to the billing as a list </param>
    public PixBilling(string txid, Calendar calendar, Debtor debtor, Location location, PixValue value, string key, string payerRequest, List<AdditionalInfo> additionalInfo) : base()
    {
        Txid = txid;
        Calendar = calendar;
        Debtor = debtor;
        Location = location;
        Value = value;
        Key = key;
        PayerRequest = payerRequest;
        AdditionalInfo = additionalInfo;
    }

    /// <summary> Default constructor </summary>
    public PixBilling() { }
}
