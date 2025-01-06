namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code ItemPayload} class represents the payload for a transaction item,
/// containing various attributes such as the key, value components,
/// devolution requests, transaction IDs, timestamps, and payer information.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class ItemPayload : AbstractModel
{
    /// <summary> The unique key associated with the transaction item. </summary>
    [JsonPropertyName("chave")]
    public string Key { get; set; }

    /// <summary> The components of the value associated with the transaction item. </summary>
    [JsonPropertyName("componentesValor")]
    public ValueComponent ValueComponents { get; set; }

    /// <summary> A list of devolution requests related to the transaction item. </summary>
    [JsonPropertyName("devolucoes")]
    public List<DevolutionRequestBody> Devolutions { get; set; }

    /// <summary> The end-to-end identifier for the transaction. </summary>
    [JsonPropertyName("endToEndId")]
    public string EndToEndId { get; set; }

    /// <summary> The timestamp of the transaction item. </summary>
    [JsonPropertyName("horario")]
    public string Timestamp { get; set; }

    /// <summary> Information about the payer involved in the transaction. </summary>
    [JsonPropertyName("infoPagador")]
    public string PayerInfo { get; set; }

    /// <summary> The transaction ID associated with the item. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }

    /// <summary> The value associated with the transaction item. </summary>
    [JsonPropertyName("valor")]
    public string Value { get; set; }

    /// <summary> Constructs a new ItemPayload with specified values. </summary>
    /// <param _name_="_key_"> The unique key associated with the transaction item </param>
    /// <param _name_="_valueComponents_"> The components of the value associated with the transaction item </param>
    /// <param _name_="_devolutions_"> A list of devolution requests related to the transaction item </param>
    /// <param _name_="_endToEndId_"> The end-to-end identifier for the transaction </param>
    /// <param _name_="_timestamp_"> The timestamp of the transaction item </param>
    /// <param _name_="_payerInfo_"> Information about the payer involved in the transaction </param>
    /// <param _name_="_txid_"> The transaction ID associated with the item </param>
    /// <param _name_="_value_"> The value associated with the transaction item </param>
    public ItemPayload(string key, ValueComponent valueComponents, List<DevolutionRequestBody> devolutions, string endToEndId, string timestamp, string payerInfo, string txid, string value)
    {
        Key = key;
        ValueComponents = valueComponents;
        Devolutions = devolutions;
        EndToEndId = endToEndId;
        Timestamp = timestamp;
        PayerInfo = payerInfo;
        Txid = txid;
        Value = value;
    }

    /// <summary> Default constructor </summary>
    public ItemPayload() { }
}
