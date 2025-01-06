namespace inter_sdk_library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
/// <summary>
/// The {@code BillingRetrieveCallbackResponse} class represents the response structure
/// for retrieving callback information.
/// <para>
/// It includes details such as the URL of the webhook, the number of
/// attempts made to trigger the callback, the timestamp of the last trigger,
/// and the success status of the callback. Additionally, it may contain the
/// HTTP status, error message, and a list of payloads related to the callback.
/// This structure is essential for managing and responding to callback inquiries.
/// </para>
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingRetrieveCallbackResponse : AbstractModel
{
    /// <summary> The URL of the webhook that handles the callbacks. </summary>
    [JsonPropertyName("webhookUrl")]
    public string WebhookUrl { get; set; }
    /// <summary> The number of attempts made to trigger the callback. </summary>
    [JsonPropertyName("numeroTentativa")]
    public int? AttemptNumber { get; set; } // Nullable to match Integer
    /// <summary> The timestamp of the last trigger of the callback. </summary>
    [JsonPropertyName("dataHoraDisparo")]
    public string TriggerDateTime { get; set; }
    /// <summary> The success status of the callback attempt. </summary>
    [JsonPropertyName("sucesso")]
    public bool? Success { get; set; } // Nullable to match Boolean
    /// <summary> The HTTP status code returned from the last callback attempt. </summary>
    [JsonPropertyName("httpStatus")]
    public int? HttpStatus { get; set; } // Nullable to match Integer
    /// <summary> The error message related to the last callback attempt, if any. </summary>
    [JsonPropertyName("mensagemErro")]
    public string ErrorMessage { get; set; }
    /// <summary> A list of payloads related to the callback. </summary>
    [JsonPropertyName("payload")]
    public List<BillingPayload> Payload { get; set; }
    /// <summary> Constructs a new BillingRetrieveCallbackResponse with specified values. </summary>
    /// <param name="webhookUrl"> The URL of the webhook that handles the callbacks </param>
    /// <param name="attemptNumber"> The number of attempts made to trigger the callback </param>
    /// <param name="triggerDateTime"> The timestamp of the last trigger of the callback </param>
    /// <param name="success"> The success status of the callback attempt </param>
    /// <param name="httpStatus"> The HTTP status code returned from the last callback attempt </param>
    /// <param name="errorMessage"> The error message related to the last callback attempt, if any </param>
    /// <param name="payload"> A list of payloads related to the callback </param>
    public BillingRetrieveCallbackResponse(string webhookUrl,
                                    int? attemptNumber,
                                    string triggerDateTime,
                                    bool? success,
                                    int? httpStatus,
                                    string errorMessage,
                                    List<BillingPayload> payload)
    {
        WebhookUrl = webhookUrl;
        AttemptNumber = attemptNumber;
        TriggerDateTime = triggerDateTime;
        Success = success;
        HttpStatus = httpStatus;
        ErrorMessage = errorMessage;
        Payload = payload;
    }
    /// <summary> Default constructor </summary>
    public BillingRetrieveCallbackResponse() { }
}
