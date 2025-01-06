namespace inter_sdk_library;

using System.Text.Json;
using System.Text;
using System.Collections.Generic;

public class BankingWebhookClient
{
    /// <summary>
    /// Deletes a specified webhook based on its type.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_webhookType_"> The type of the webhook to be deleted. </param>
    /// <exception cref="SdkException"> If there is an error during the deletion process, such as
    ///                      network issues or API response errors. </exception>
    public void Delete(Config config, string webhookType)
    {
        InterSdk.LogInfo($"DeleteWebhook banking {config.ClientId} {webhookType}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_WEBHOOK) + "/" + webhookType;
        HttpUtils.CallDelete(config, url, Constants.WEBHOOK_BANKING_WRITE_SCOPE, "Error deleting webhook");
    }

    /// <summary>
    /// Includes a new webhook configuration for a specified type and URL.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_webhookType_"> The type of the webhook to be included. </param>
    /// <param _name_="_webhookUrl_"> The URL where the webhook will send notifications. </param>
    /// <exception cref="SdkException"> If there is an error during the inclusion process, such as
    ///                      network issues or API response errors. </exception>
    public void Include(Config config, string webhookType, string webhookUrl)
    {
        InterSdk.LogInfo($"IncludeWebhookBanking {config.ClientId} {webhookType} {webhookUrl}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_WEBHOOK) + "/" + webhookType;
        var request = new IncludeWebhookRequest(webhookUrl);

        WebhookUtil.IncludeWebhook(config, url, request, Constants.WEBHOOK_BANKING_WRITE_SCOPE);
    }

    /// <summary>
    /// Retrieves a page of callback responses for a specified webhook type within a given date range.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_webhookType_"> The type of the webhook to retrieve callbacks for. </param>
    /// <param _name_="_initialDateHour_"> The start date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDateHour_"> The end date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> Optional filters to apply to the callback retrieval. </param>
    /// <returns> A {@link CallbackPage} object containing the requested page of callback responses. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public CallbackPage Retrieve(Config config, string webhookType, string initialDateHour, string finalDateHour, int page, int? pageSize, CallbackRetrieveFilter filter)
    {
        InterSdk.LogInfo($"RetrieveCallbacks {config.ClientId} {initialDateHour}-{finalDateHour}");
        return GetPage(config, webhookType, initialDateHour, finalDateHour, page, pageSize, filter);
    }

    /// <summary>
    /// Retrieves all callback responses for a specified webhook type within a given date range.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_webhookType_"> The type of the webhook to retrieve callbacks for. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_filter_"> Optional filters to apply to the callback retrieval. </param>
    /// <returns> A list of {@link RetrieveCallbackResponse} containing all callback responses
    ///         within the specified date range. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public List<RetrieveCallbackResponse> Retrieve(Config config, string webhookType, string initialDate, string finalDate, CallbackRetrieveFilter filter)
    {
        InterSdk.LogInfo($"RetrieveCallbacks {config.ClientId} {initialDate}-{finalDate}");
        int page = 0;
        CallbackPage callbackPage;
        var callbacks = new List<RetrieveCallbackResponse>();

        do
        {
            callbackPage = GetPage(config, webhookType, initialDate, finalDate, page, null, filter);
            callbacks.AddRange(callbackPage.Data);
            page++;
        } while (page < callbackPage.TotalPages);
        
        return callbacks;
    }

    /// <summary>
    /// Retrieves the configuration for a specified webhook type.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_webhookType_"> The type of the webhook to be retrieved. </param>
    /// <returns> A {@link Webhook} object containing the configuration details of the requested webhook. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as
    ///                      network issues or API response errors. </exception>
    public Webhook Retrieve(Config config, string webhookType)
    {
        InterSdk.LogInfo($"RetrieveWebhook banking {config.ClientId} {webhookType}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_WEBHOOK) + "/" + webhookType;

        return WebhookUtil.RetrieveWebhook(config, url, Constants.WEBHOOK_BANKING_READ_SCOPE);
    }

    /// <summary>
    /// Retrieves a specific page of callback responses for a specified webhook type.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_webhookType_"> The type of the webhook to retrieve callbacks for. </param>
    /// <param _name_="_initialDateHour_"> The start date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDateHour_"> The end date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> Optional filters to apply to the callback retrieval. </param>
    /// <returns> A {@link CallbackPage} object containing the requested page of callback responses. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    private CallbackPage GetPage(Config config, string webhookType, string initialDateHour, string finalDateHour, int page, int? pageSize, CallbackRetrieveFilter filter)
    {
        string url1 = UrlUtils.BuildUrl(config, Constants.URL_BANKING_WEBHOOK) + "/" + webhookType + "/callbacks";
        string url = url1
            + "?dataHoraInicio=" + initialDateHour
            + "&dataHoraFim=" + finalDateHour
            + "&pagina=" + page
            + (pageSize.HasValue ? "&tamanhoPagina=" + pageSize.Value : "")
            + AddFilters(filter);
        
        string json = HttpUtils.CallGet(config, url, Constants.WEBHOOK_BANKING_READ_SCOPE, "Error retrieving callbacks");
        
        try
        {
            return JsonSerializer.Deserialize<CallbackPage>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Constructs the query string for filters to be applied when retrieving callbacks.
    /// </summary>
    /// <param _name_="_filter_"> The filter object containing filtering criteria. </param>
    /// <returns> A query string that can be appended to the URL for filtering. </returns>
    private string AddFilters(CallbackRetrieveFilter filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }

        var stringFilter = new StringBuilder();
        
        if (!string.IsNullOrEmpty(filter.TransactionCode))
        {
            stringFilter.Append("&codigoTransacao=").Append(filter.TransactionCode);
        }
        
        if (!string.IsNullOrEmpty(filter.EndToEndId))
        {
            stringFilter.Append("&endToEnd=").Append(filter.EndToEndId);
        }
        
        return stringFilter.ToString();
    }
}
