namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code GeneratedDueBilling} class represents a generated
/// due billing transaction.
///
/// <p> It includes various fields that describe the billing
/// details, such as keys, payer requests, debtor and receiver
/// information, billing values, and additional dynamic fields.
/// </p>
/// </summary>
/// <see cref="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class GeneratedDueBilling : AbstractModel
{
    /// <summary> The unique key associated with the billing transaction. </summary>
    [JsonPropertyName("chave")]
    public string Key { get; set; }
    /// <summary> The request made by the payer for this billing transaction. </summary>
    [JsonPropertyName("solicitacaoPagador")]
    public string PayerRequest { get; set; }
    /// <summary> Additional information related to the billing transaction. </summary>
    [JsonPropertyName("infoAdicionais")]
    public List<AdditionalInfo> AdditionalInfo { get; set; }
    /// <summary> The copy-paste format of the PIX transaction. </summary>
    [JsonPropertyName("pixCopiaECola")]
    public string PixCopyPaste { get; set; }
    /// <summary> Information about the debtor of the billing. </summary>
    [JsonPropertyName("devedor")]
    public Debtor Debtor { get; set; }
    /// <summary> Information about the receiver of the billing. </summary>
    [JsonPropertyName("recebedor")]
    public PixReceiver Receiver { get; set; }
    /// <summary> Location details associated with the billing. </summary>
    [JsonPropertyName("loc")]
    public Location Location { get; set; }
    /// <summary> The current status of the billing transaction. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
    /// <summary> The value associated with the billing transaction. </summary>
    [JsonPropertyName("valor")]
    public DueBillingValue Value { get; set; }
    /// <summary> The billing calendar details related to the transaction. </summary>
    [JsonPropertyName("calendario")]
    public DueBillingCalendar Calendar { get; set; }
    /// <summary> The transaction ID associated with the billing. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }
    /// <summary> The revision number of the billing transaction. </summary>
    [JsonPropertyName("revisao")]
    public int? Revision { get; set; }
    /// <summary> Constructs a new GeneratedDueBilling with specified values. </summary>
    /// <param name="key"> The unique key associated with the billing transaction </param>
    /// <param name="payerRequest"> The request made by the payer for this billing transaction </param>
    /// <param name="additionalInfo"> Additional information related to the billing transaction </param>
    /// <param name="pixCopyPaste"> The copy-paste format of the PIX transaction </param>
    /// <param name="debtor"> Information about the debtor of the billing </param>
    /// <param name="receiver"> Information about the receiver of the billing </param>
    /// <param name="location"> Location details associated with the billing </param>
    /// <param name="status"> The current status of the billing transaction </param>
    /// <param name="value"> The value associated with the billing transaction </param>
    /// <param name="calendar"> The billing calendar details related to the transaction </param>
    /// <param name="txid"> The transaction ID associated with the billing </param>
    /// <param name="revision"> The revision number of the billing transaction </param>
    public GeneratedDueBilling(string key, string payerRequest, List<AdditionalInfo> additionalInfo, string pixCopyPaste, Debtor debtor, PixReceiver receiver, Location location, string status, DueBillingValue value, DueBillingCalendar calendar, string txid, int? revision) : base()
    {
        Key = key;
        PayerRequest = payerRequest;
        AdditionalInfo = additionalInfo;
        PixCopyPaste = pixCopyPaste;
        Debtor = debtor;
        Receiver = receiver;
        Location = location;
        Status = status;
        Value = value;
        Calendar = calendar;
        Txid = txid;
        Revision = revision;
    }
    /// <summary> Default constructor </summary>
    public GeneratedDueBilling() { }
}
