namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Webhook
{
    /// <summary>
    /// The URL of the webhook to be invoked.
    /// </summary>
    [JsonPropertyName("webhookUrl")]
    public string WebhookUrl { get; set; }

    /// <summary>
    /// The date when the webhook was created.
    /// </summary>
    [JsonPropertyName("criacao")]
    public string CreationDate { get; set; }

    /// <summary>
    /// Constructor with parameters for Webhook.
    /// </summary>
    public Webhook(string WebhookUrl, string CreationDate)
    {
        this.WebhookUrl = WebhookUrl;
        this.CreationDate = CreationDate;
    }
}
