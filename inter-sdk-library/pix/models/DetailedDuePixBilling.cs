namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code DetailedDuePixBilling} class extends the {@code DueBilling}
/// class and provides detailed information about a billing transaction
/// that is due.
///
/// <p> It includes fields for the PIX (copy and paste)
/// information, receiver details, billing status, revision number,
/// and a list of PIX transactions associated with the billing.
/// </p>
/// </summary>
/// <see _cref_="DueBilling"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class DetailedDuePixBilling : DueBilling
{
    /// <summary> The PIX copy and paste information. </summary>
    [JsonPropertyName("pixCopiaECola")]
    public string PixCopyAndPaste { get; set; }

    /// <summary> The details of the receiver for the billing transaction. </summary>
    [JsonPropertyName("recebedor")]
    public PixReceiver Receiver { get; set; }

    /// <summary> The current status of the billing transaction. </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary> The revision number for the billing transaction. </summary>
    [JsonPropertyName("revisao")]
    public int? Revision { get; set; }

    /// <summary> A list of PIX transactions associated with the billing. </summary>
    [JsonPropertyName("pix")]
    public List<Pix> PixTransactions { get; set; }

    /// <summary> Constructs a new DetailedDuePixBilling with specified values. </summary>
    /// <param _name_="_pixCopyAndPaste_"> The PIX copy and paste information </param>
    /// <param _name_="_receiver_"> The details of the receiver for the billing transaction </param>
    /// <param _name_="_status_"> The current status of the billing transaction </param>
    /// <param _name_="_revision_"> The revision number for the billing transaction </param>
    /// <param _name_="_pixTransactions_"> A list of PIX transactions associated with the billing </param>
    public DetailedDuePixBilling(string pixCopyAndPaste, PixReceiver receiver, string status, int? revision, List<Pix> pixTransactions) : base()
    {
        PixCopyAndPaste = pixCopyAndPaste;
        Receiver = receiver;
        Status = status;
        Revision = revision;
        PixTransactions = pixTransactions;
    }

    /// <summary> Default constructor </summary>
    public DetailedDuePixBilling() { }
}
