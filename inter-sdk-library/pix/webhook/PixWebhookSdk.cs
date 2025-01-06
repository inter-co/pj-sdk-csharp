namespace inter_sdk_library;

using System.Text.Json;
using System.Text;
using System.Collections.Generic;

public class PixWebhookSdk
{
    /// <summary>
    /// Deletes a webhook identified by the provided key.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_key_"> The unique key of the webhook to be deleted. </param>
    /// <exception cref="SdkException"> If there is an error during the deletion process, such as network issues
    ///                      or API response errors. </exception>
    public void Delete(Config config, string key)
    {
        InterSdk.LogInfo($"DeleteWebhook pix {config.ClientId} {key}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_WEBHOOK) + "/" + key;

        HttpUtils.CallDelete(config, url, Constants.PIX_WEBHOOK_WRITE_SCOPE, "Error deleting webhook");
    }

    /// <summary>
    /// Includes a webhook for the specified key and webhook URL.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_key_"> The unique key for which the webhook is being included. </param>
    /// <param _name_="_webhookUrl_"> The URL of the webhook to be included. </param>
    /// <exception cref="SdkException"> If there is an error during the inclusion process, such as network issues
    ///                      or API response errors. </exception>
    public void Include(Config config, string key, string webhookUrl)
    {
        InterSdk.LogInfo($"IncludeWebhook pix {config.ClientId} {key} {webhookUrl}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_WEBHOOK) + "/" + key;
        var request = new IncludeWebhookRequest(webhookUrl);

        WebhookUtil.IncludeWebhook(config, url, request, Constants.PIX_WEBHOOK_WRITE_SCOPE);
    }

    /// <summary>
    /// Retrieves a paginated list of callback notifications based on specified date range and filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDateHour_"> The start date and time for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDateHour_"> The end date and time for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> A {@link CallbackRetrieveFilter} object containing filter criteria. </param>
    /// <returns> A {@link PixCallbackPage} object containing the requested page of callback notifications. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public PixCallbackPage Retrieve(Config config, string initialDateHour, string finalDateHour, int page, int? pageSize, PixCallbackRetrieveFilter filter)
    {
        InterSdk.LogInfo($"RetrieveCallbacks pix {config.ClientId} {initialDateHour}-{finalDateHour}");
        
        return GetPage(config, initialDateHour, finalDateHour, page, pageSize, filter);
    }

    /// <summary>
    /// Retrieves all callback notifications within the specified date range and filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDateHour_"> The start date and time for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDateHour_"> The end date and time for the retrieval range (inclusive). </param>
    /// <param _name_="_filter_"> A {@link CallbackRetrieveFilter} object containing filter criteria. </param>
    /// <returns> A list of {@link RetrieveCallbackResponse} objects containing all retrieved callbacks. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public List<RetrieveCallbackResponse> Retrieve(Config config, string initialDateHour, string finalDateHour, PixCallbackRetrieveFilter filter)
    {
        InterSdk.LogInfo($"RetrieveCallbacks pix {config.ClientId} {initialDateHour}-{finalDateHour}");
        
        int page = 0;
        PixCallbackPage callbackPage;
        var callbacks = new List<RetrieveCallbackResponse>();

        do
        {
            callbackPage = GetPage(config, initialDateHour, finalDateHour, page, null, filter);
            callbacks.AddRange(callbackPage.Data);
            page++;
        } while (page < callbackPage.TotalPages);

        return callbacks;
    }

    /// <summary>
    /// Retrieves a webhook identified by the provided key.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_key_"> The unique key of the webhook to be retrieved. </param>
    /// <returns> A {@link Webhook} object containing the details of the retrieved webhook. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public Webhook Retrieve(Config config, string key)
    {
        InterSdk.LogInfo($"RetrieveWebhook pix {config.ClientId} {key}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_WEBHOOK) + "/" + key;

        return WebhookUtil.RetrieveWebhook(config, url, Constants.PIX_WEBHOOK_READ_SCOPE);
    }

    /// <summary>
    /// Retrieves a specific page of callback notifications based on the provided date range and filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDateHour_"> The start date and time for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDateHour_"> The end date and time for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> A {@link CallbackRetrieveFilter} object containing filter criteria. </param>
    /// <returns> A {@link PixCallbackPage} object containing the requested page of callback notifications. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    private PixCallbackPage GetPage(Config config, string initialDateHour, string finalDateHour, int page, int? pageSize, PixCallbackRetrieveFilter filter)
    {
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_WEBHOOK_CALLBACKS) +
                    "?dataHoraInicio=" + initialDateHour +
                    "&dataHoraFim=" + finalDateHour +
                    "&pagina=" + page + 
                    (pageSize.HasValue ? "&tamanhoPagina=" + pageSize.Value : "") + 
                    AddFilters(filter);

        string json = HttpUtils.CallGet(config, url, Constants.PIX_WEBHOOK_READ_SCOPE, "Error retrieving callbacks");
        
        try
        {
            return JsonSerializer.Deserialize<PixCallbackPage>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Adds filter parameters to the URL based on the provided filter criteria.
    /// </summary>
    /// <param _name_="_filter_"> A {@link CallbackRetrieveFilter} object containing filter criteria. </param>
    /// <returns> A string containing the appended filter parameters for the URL. </returns>
    private string AddFilters(PixCallbackRetrieveFilter filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }

        var stringFilter = new StringBuilder();

        if (filter.Txid != null)
        {
            stringFilter.Append("&txid").Append("=").Append(filter.Txid);
        }

        return stringFilter.ToString();
    }
}
