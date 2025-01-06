namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DetailedImmediatePixBilling} class extends the basic charge details by
/// adding additional fields specific to a detailed view of a PIX charge.
///
/// <p> It includes the location of the transaction, the current status,
/// a copy-paste (copia e cola) representation of the PIX transaction,
/// a revision number, and a list of PIX transactions. This structure
/// provides comprehensive details necessary for tracking and managing
/// specific charge instances within the PIX system.
/// </p>
/// </summary>
/// <see _cref_="PixCharge"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DetailedImmediatePixBilling
{
    /// <summary> The debtor associated with the PIX charge. </summary>
    [JsonPropertyName("devedor")]
    public Debtor Debtor { get; set; }

    /// <summary> The value of the PIX charge. </summary>
    [JsonPropertyName("valor")]
    public PixValue Value { get; set; }

    /// <summary> The key associated with the PIX transaction. </summary>
    [JsonPropertyName("chave")]
    public string Key { get; set; }

    /// <summary> The calendar information related to the PIX charge. </summary>
    [JsonPropertyName("calendario")]
    public Calendar Calendar { get; set; }

    /// <summary> Location details associated with the PIX charge. </summary>
    [JsonPropertyName("loc")]
    public Location Loc { get; set; }
    
    /// <summary> A string representation of the location. </summary>
    [JsonPropertyName("location")]
    public string Location { get; set; }

    /// <summary> The transaction ID related to the PIX charge. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }

    /// <summary> The current status of the PIX charge. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary> The PIX copy and paste information. </summary>
    [JsonPropertyName("pixCopiaECola")]
    public string PixCopyAndPaste { get; set; }

    /// <summary> The payer's request information as a string. </summary>
    [JsonPropertyName("solicitacaoPagador")]
    public string PayerRequest { get; set; }

    /// <summary> The revision number for the PIX charge. </summary>
    [JsonPropertyName("revisao")]
    public int? Revision { get; set; }

    /// <summary> A list of PIX transactions associated with the charge. </summary>
    [JsonPropertyName("pix")]
    public List<Pix> PixTransactions { get; set; }

    /// <summary> Constructs a new DetailedImmediatePixBilling with specified values. </summary>
    /// <param name="debtor"> The debtor associated with the PIX charge </param>
    /// <param name="value"> The value of the PIX charge </param>
    /// <param name="key"> The key associated with the PIX transaction </param>
    /// <param name="calendar"> The calendar information related to the PIX charge </param>
    /// <param name="loc"> Location details associated with the PIX charge </param>
    /// <param name="location"> A string representation of the location </param>
    /// <param name="txid"> The transaction ID related to the PIX charge </param>
    /// <param name="status"> The current status of the PIX charge </param>
    /// <param name="pixCopyAndPaste"> The PIX copy and paste information </param>
    /// <param name="payerRequest"> The payer's request information as a string </param>
    /// <param name="revision"> The revision number for the PIX charge </param>
    /// <param name="pixTransactions"> A list of PIX transactions associated with the charge </param>
    public DetailedImmediatePixBilling(Debtor debtor, PixValue value, string key, Calendar calendar, Location loc, string location, string txid, string status, string pixCopyAndPaste, string payerRequest, int? revision, List<Pix> pixTransactions)
    {
        Debtor = debtor;
        Value = value;
        Key = key;
        Calendar = calendar;
        Loc = loc;
        Location = location;
        Txid = txid;
        Status = status;
        PixCopyAndPaste = pixCopyAndPaste;
        PayerRequest = payerRequest;
        Revision = revision;
        PixTransactions = pixTransactions;
    }

    /// <summary> Default constructor </summary>
    public DetailedImmediatePixBilling() { }
}
