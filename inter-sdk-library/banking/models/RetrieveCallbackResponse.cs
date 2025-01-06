namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code RetrieveCallbackResponse} class represents the response for
/// fetching callbacks.
/// <para> 
/// It includes details such as the webhook URL, attempt number,
/// trigger date and time, success status, HTTP status, error message,
/// and a list of payloads that may have been generated or received
/// during the callback process.
/// </para>
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class RetrieveCallbackResponse : AbstractModel
{
    /// <summary> The URL of the webhook associated with the callback. </summary>
    [JsonPropertyName("webhookUrl")]
    public string WebhookUrl { get; set; }

    /// <summary> The attempt number of the callback. </summary>
    [JsonPropertyName("numeroTentativa")]
    public int? AttemptNumber { get; set; }

    /// <summary> The date and time the callback was sent. </summary>
    [JsonPropertyName("dataEnvio")]
    public string SendingTime { get; set; }

    /// <summary> The date and time when the callback was triggered. </summary>
    [JsonPropertyName("dataHoraDisparo")]
    public string TriggerDateTime { get; set; }

    /// <summary> Indicates whether the callback was successful. </summary>
    [JsonPropertyName("sucesso")]
    public bool? Success { get; set; }

    /// <summary> The HTTP status code returned by the callback. </summary>
    [JsonPropertyName("httpStatus")]
    public int? HttpStatus { get; set; }

    /// <summary> A message detailing any error that occurred. </summary>
    [JsonPropertyName("mensagemErro")]
    public string ErrorMessage { get; set; }

    /// <summary> The list of payloads associated with the callback. </summary>
    [JsonPropertyName("payload")]
    public List<Payload> Payload { get; set; }

    /// <summary> Constructs a new RetrieveCallbackResponse with specified values. </summary>
    /// <param name="webhookUrl"> The URL of the webhook associated with the callback </param>
    /// <param name="attemptNumber"> The attempt number of the callback </param>
    /// <param name="sendingTime"> The date and time the callback was sent </param>
    /// <param name="triggerDateTime"> The date and time when the callback was triggered </param>
    /// <param name="success"> Indicates whether the callback was successful </param>
    /// <param name="httpStatus"> The HTTP status code returned by the callback </param>
    /// <param name="errorMessage"> A message detailing any error that occurred </param>
    /// <param name="payload"> The list of payloads associated with the callback </param>
    public RetrieveCallbackResponse(string webhookUrl, int? attemptNumber, string sendingTime, string triggerDateTime, bool? success, int? httpStatus, string errorMessage, List<Payload> payload)
    {
        WebhookUrl = webhookUrl;
        AttemptNumber = attemptNumber;
        SendingTime = sendingTime;
        TriggerDateTime = triggerDateTime;
        Success = success;
        HttpStatus = httpStatus;
        ErrorMessage = errorMessage;
        Payload = payload;
    }

    /// <summary> Default constructor </summary>
    public RetrieveCallbackResponse() { }
}
