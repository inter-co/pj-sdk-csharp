namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code RetrievePixResponse} class represents the response received
/// when retrieving a Pix transaction.
/// <para> 
/// It includes details about the Pix transaction itself as
/// well as the associated history, allowing users to understand
/// the current state and past events related to the transaction.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class RetrievePixResponse : AbstractModel
{
    /// <summary> The details of the Pix transaction. </summary>
    [JsonPropertyName("transacaoPix")]
    public PixTransaction PixTransaction { get; set; }
    /// <summary> The history of events related to the Pix transaction. </summary>
    [JsonPropertyName("historico")]
    public List<PixHistoryEntity> History { get; set; }

    /// <summary> Constructs a new RetrievePixResponse with specified values. </summary>
    /// <param name="pixTransaction"> The details of the Pix transaction </param>
    /// <param name="history"> The history of events related to the Pix transaction </param>
    public RetrievePixResponse(PixTransaction pixTransaction, List<PixHistoryEntity> history)
    {
        PixTransaction = pixTransaction;
        History = history;
    }

    /// <summary> Default constructor </summary>
    public RetrievePixResponse() { }
}
