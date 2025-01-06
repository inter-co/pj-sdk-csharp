namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code Pix} class represents information related to a Pix payment.
/// It includes fields such as the unique end-to-end identifier, transaction
/// ID (txid), the amount of the payment, the recipient's key used for the
/// transfer, the timestamp of the transaction, payer information, and a
/// list of detailed refunds associated with this payment.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Pix : AbstractModel
{
    /// <summary> The unique end-to-end identifier for the Pix transaction. </summary>
    [JsonPropertyName("endToEndId")]
    public string EndToEndId { get; set; }

    /// <summary> The transaction ID (txid) associated with the Pix payment. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }

    /// <summary> The amount of the payment in a string format. </summary>
    [JsonPropertyName("valor")]
    public string Value { get; set; }

    /// <summary> The recipient's key used for the transfer. </summary>
    [JsonPropertyName("chave")]
    public string Key { get; set; }

    /// <summary> The timestamp of the transaction. </summary>
    [JsonPropertyName("horario")]
    public DateTime? Timestamp { get; set; } // Changed to DateTime? to allow nulls

    /// <summary> Information about the payer involved in the transaction. </summary>
    [JsonPropertyName("infoPagador")]
    public string PayerInfo { get; set; }

    /// <summary> A list of detailed refunds associated with the Pix payment. </summary>
    [JsonPropertyName("devolucoes")]
    public List<DetailedDevolution> Refunds { get; set; }

    /// <summary> Components of the value associated with the payment. </summary>
    [JsonPropertyName("componentesValor")]
    public ValueComponent ValueComponents { get; set; }

    /// <summary> Constructs a new Pix with specified values. </summary>
    /// <param _name_="_endToEndId_"> The unique end-to-end identifier for the Pix transaction </param>
    /// <param _name_="_txid_"> The transaction ID associated with the Pix payment </param>
    /// <param _name_="_value_"> The amount of the payment in a string format </param>
    /// <param _name_="_key_"> The recipient's key used for the transfer </param>
    /// <param _name_="_timestamp_"> The timestamp of the transaction </param>
    /// <param _name_="_payerInfo_"> Information about the payer involved in the transaction </param>
    /// <param _name_="_refunds_"> A list of detailed refunds associated with the Pix payment </param>
    /// <param _name_="_valueComponents_"> Components of the value associated with the payment </param>
    public Pix(string endToEndId, string txid, string value, string key, DateTime? timestamp, string payerInfo, List<DetailedDevolution> refunds, ValueComponent valueComponents) : base()
    {
        EndToEndId = endToEndId;
        Txid = txid;
        Value = value;
        Key = key;
        Timestamp = timestamp;
        PayerInfo = payerInfo;
        Refunds = refunds;
        ValueComponents = valueComponents;
    }

    /// <summary> Default constructor </summary>
    public Pix() { }
}
