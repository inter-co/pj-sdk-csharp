namespace inter_sdk_library;

using Newtonsoft.Json;
using System.Text.Json.Serialization;
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class IncludeWebhookRequest
{
    /// <summary>
    /// The URL of the webhook to be included.
    /// </summary>
    [JsonPropertyName("webhookUrl")]
    public string WebhookUrl { get; set;}

    public IncludeWebhookRequest(string webhookUrl)
    {
        WebhookUrl = webhookUrl;
    }
}
