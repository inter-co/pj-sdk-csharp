namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
/// <summary>
/// The {@code Payload} class represents the data structure used for
/// handling billing information.
/// <para>
/// It includes attributes such as unique request code, user-defined
/// numbers, billing status, receipt details, and payment identifiers. This
/// structure is essential for managing the flow of billing data within the
/// application.
/// </para>
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingPayload : AbstractModel
{
    /// <summary> A unique code for identifying the billing request. </summary>
    [JsonPropertyName("codigoSolicitacao")]
    public string RequestCode { get; set; }
    /// <summary> A user-defined number associated with the billing. </summary>
    [JsonPropertyName("seuNumero")]
    public string YourNumber { get; set; }
    /// <summary> The current situation or status of the billing. </summary>
    [JsonPropertyName("situacao")]
    public string Situation { get; set; }
    /// <summary> The date and time when the billing status was last updated. </summary>
    [JsonPropertyName("dataHoraSituacao")]
    public string StatusDateTime { get; set; }
    /// <summary> The total amount received for the billing. </summary>
    [JsonPropertyName("valorTotalRecebido")]
    public string TotalAmountReceived { get; set; }
    /// <summary> The origin from which the payment was received. </summary>
    [JsonPropertyName("origemRecebimento")]
    public string ReceivingOrigin { get; set; }
    /// <summary> The number associated with the billing as designated by the institution. </summary>
    [JsonPropertyName("nossoNumero")]
    public string OurNumber { get; set; }
    /// <summary> The barcode associated with the billing for automated processing. </summary>
    [JsonPropertyName("codigoBarras")]
    public string Barcode { get; set; }
    /// <summary> The payment line used for manual payment processing. </summary>
    [JsonPropertyName("linhaDigitavel")]
    public string PaymentLine { get; set; }
    /// <summary> The transaction ID associated with the payment. </summary>
    [JsonPropertyName("txid")]
    public string Txid { get; set; }
    /// <summary> The copy-and-paste format for a PIX transaction. </summary>
    [JsonPropertyName("pixCopiaECola")]
    public string PixCopyAndPaste { get; set; }
    /// <summary> Constructs a new Payload with specified values. </summary>
    /// <param name="requestCode"> A unique code for identifying the billing request </param>
    /// <param name="yourNumber"> A user-defined number associated with the billing </param>
    /// <param name="situation"> The current situation or status of the billing </param>
    /// <param name="statusDateTime"> The date and time when the billing status was last updated </param>
    /// <param name="totalAmountReceived"> The total amount received for the billing </param>
    /// <param name="receivingOrigin"> The origin from which the payment was received </param>
    /// <param name="ourNumber"> The number associated with the billing as designated by the institution </param>
    /// <param name="barcode"> The barcode associated with the billing for automated processing </param>
    /// <param name="paymentLine"> The payment line used for manual payment processing </param>
    /// <param name="txid"> The transaction ID associated with the payment </param>
    /// <param name="pixCopyAndPaste"> The copy-and-paste format for a PIX transaction </param>
    public BillingPayload(string requestCode,
                   string yourNumber,
                   string situation,
                   string statusDateTime,
                   string totalAmountReceived,
                   string receivingOrigin,
                   string ourNumber,
                   string barcode,
                   string paymentLine,
                   string txid,
                   string pixCopyAndPaste)
    {
        RequestCode = requestCode;
        YourNumber = yourNumber;
        Situation = situation;
        StatusDateTime = statusDateTime;
        TotalAmountReceived = totalAmountReceived;
        ReceivingOrigin = receivingOrigin;
        OurNumber = ourNumber;
        Barcode = barcode;
        PaymentLine = paymentLine;
        Txid = txid;
        PixCopyAndPaste = pixCopyAndPaste;
    }
    /// <summary> Default constructor </summary>
    public BillingPayload() { }
}
