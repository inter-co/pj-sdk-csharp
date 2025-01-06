namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Represents the response for including a DARF (Documento de Arrecadação de Receitas Federais) payment.
/// It includes details such as authentication, payment date, detailed message, operation number, return type,
/// and transaction code.
/// <para> 
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para> 
/// The class includes fields for approver quantity, authentication, payment date,
/// return type, request code, and additional fields. It overrides Equals, GetHashCode, 
/// and ToString methods to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/> 
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class IncludeDarfPaymentResponse : AbstractModel
{
    /// <summary> The quantity of approvers required for the payment. </summary>
    [JsonPropertyName("quantidadeAprovadores")]
    public string ApproverQuantity { get; set; }

    /// <summary> The authentication code for the payment. </summary>
    [JsonPropertyName("autenticacao")]
    public string Authentication { get; set; }

    /// <summary> The date the payment was made. </summary>
    [JsonPropertyName("dataPagamento")]
    public string PaymentDate { get; set; }

    /// <summary> The type of return for the payment. </summary>
    [JsonPropertyName("tipoRetorno")]
    public string ReturnType { get; set; }

    /// <summary> The request code for the payment. </summary>
    [JsonPropertyName("codigoSolicitacao")]
    public string RequestCode { get; set; }

    /// <summary> Constructs a new IncludeDarfPaymentResponse with specified values. </summary>
    /// <param name="approverQuantity"> The quantity of approvers required for the payment </param>
    /// <param name="authentication"> The authentication code for the payment </param>
    /// <param name="paymentDate"> The date the payment was made </param>
    /// <param name="returnType"> The type of return for the payment </param>
    /// <param name="requestCode"> The request code for the payment </param>
    public IncludeDarfPaymentResponse(string approverQuantity, string authentication, 
                                       string paymentDate, string returnType, string requestCode)
    {
        ApproverQuantity = approverQuantity;
        Authentication = authentication;
        PaymentDate = paymentDate;
        ReturnType = returnType;
        RequestCode = requestCode;
    }

    /// <summary> Default constructor </summary>
    public IncludeDarfPaymentResponse() { }
}
