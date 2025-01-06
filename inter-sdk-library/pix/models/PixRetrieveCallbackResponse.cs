namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code PixRetrieveCallbackResponse} class represents the response
/// received after attempting to retrieve callbacks. It includes
/// details such as the webhook URL, number of attempts,
/// timestamp of the trigger, success status, HTTP status,
/// error message, and associated payload.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixRetrieveCallbackResponse : AbstractModel
{
    /// <summary> The URL of the webhook where the callback is sent. </summary>
    [JsonPropertyName("webhookUrl")]
    public string WebhookUrl { get; set; }

    /// <summary> The number of attempts made to send the callback. </summary>
    [JsonPropertyName("numeroTentativa")]
    public int? AttemptNumber { get; set; } // Changed to int? to allow nulls

    /// <summary> The timestamp of when the callback was triggered. </summary>
    [JsonPropertyName("dataHoraDisparo")]
    public string TriggerTimestamp { get; set; }

    /// <summary> Indicates whether the callback was sent successfully. </summary>
    [JsonPropertyName("sucesso")]
    public bool? Success { get; set; } // Changed to bool? to allow nulls

    /// <summary> The HTTP status code returned after the callback attempt. </summary>
    [JsonPropertyName("httpStatus")]
    public int? HttpStatus { get; set; } // Changed to int? to allow nulls

    /// <summary> An error message that may be returned if the callback failed. </summary>
    [JsonPropertyName("mensagemErro")]
    public string ErrorMessage { get; set; }

    /// <summary> Payload associated with the callback request. </summary>
    [JsonPropertyName("payload")]
    public PixPayload Payload { get; set; }

    /// <summary> Constructs a new PixRetrieveCallbackResponse with specified values. </summary>
    /// <param _name_="_webhookUrl_"> The URL of the webhook where the callback is sent </param>
    /// <param _name_="_attemptNumber_"> The number of attempts made to send the callback </param>
    /// <param _name_="_triggerTimestamp_"> The timestamp of when the callback was triggered </param>
    /// <param _name_="_success_"> Indicates whether the callback was sent successfully </param>
    /// <param _name_="_httpStatus_"> The HTTP status code returned after the callback attempt </param>
    /// <param _name_="_errorMessage_"> An error message that may be returned if the callback failed </param>
    /// <param _name_="_payload_"> Payload associated with the callback request </param>
    public PixRetrieveCallbackResponse(string webhookUrl, int? attemptNumber, string triggerTimestamp, bool? success, int? httpStatus, string errorMessage, PixPayload payload) : base()
    {
        WebhookUrl = webhookUrl;
        AttemptNumber = attemptNumber;
        TriggerTimestamp = triggerTimestamp;
        Success = success;
        HttpStatus = httpStatus;
        ErrorMessage = errorMessage;
        Payload = payload;
    }

    /// <summary> Default constructor </summary>
    public PixRetrieveCallbackResponse() { }
}
