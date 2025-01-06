namespace inter_sdk_library;

using System.Text.Json;
using System.Text.Json.Serialization;
public class WebhookUtil
{
    private static JsonSerializerOptions jsonOptions = new JsonSerializerOptions 
    { 
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    /// <summary>
    /// Includes a webhook by sending a PUT request to the specified URL.
    /// </summary>
    /// <param _name_="_config_"> The configuration object which contains necessary settings,
    ///               such as authentication information. </param>
    /// <param _name_="_url_"> The endpoint URL to which the webhook should be added. </param>
    /// <param _name_="_request_"> The {@link IncludeWebhookRequest} object containing the
    ///                details of the webhook to include. </param>
    /// <param _name_="_scope_"> The scope under which the request is made. </param>
    /// <exception cref="SdkException"> If an error occurs during the request, including
    ///                      serialization issues or HTTP call failures. </exception>
    public static void IncludeWebhook(Config config, string url, IncludeWebhookRequest request, string scope)
    {
        try
        {
            string json = JsonSerializer.Serialize(request, jsonOptions);
            HttpUtils.CallPut(config, url, scope, "Error including webhook", json);
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a webhook from the specified URL by sending a GET request.
    /// </summary>
    /// <param _name_="_config_"> The configuration object to set the required settings for
    ///               the request. </param>
    /// <param _name_="_url_"> The endpoint URL from which to retrieve the webhook. </param>
    /// <param _name_="_scope_"> The scope under which the request is made. </param>
    /// <returns> The retrieved {@link Webhook} object. </returns>
    /// <exception cref="SdkException"> If an error occurs during the HTTP call, including
    ///                      serialization issues or request failures. </exception>
    public static Webhook RetrieveWebhook(Config config, string url, string scope)
    {
        string json = HttpUtils.CallGet(config, url, scope, "Error retrieving webhook");
        
        try
        {
            return JsonSerializer.Deserialize<Webhook>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }
}
