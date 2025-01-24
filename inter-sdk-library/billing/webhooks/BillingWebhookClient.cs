namespace inter_sdk_library;

using System.Text.Json;
using System.Text;
using System.Collections.Generic;

public class BillingWebhookClient
{
    /// <summary>
    /// Deletes the billing webhook associated with the specified configuration.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <exception cref="SdkException"> If there is an error during the deletion process, such as network issues
    ///                      or API response errors. </exception>
    public void DeleteWebhook(Config config)
    {
        InterSdk.LogInfo($"DeleteWebhook billing {config.ClientId}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING_WEBHOOK);
        HttpUtils.CallDelete(config, url, Constants.BILLET_BILLING_WRITE_SCOPE, "Error deleting webhook");
    }

    /// <summary>
    /// Includes a new webhook URL for billing notifications.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_webhookUrl_"> The URL to be included as a webhook for billing notifications. </param>
    /// <exception cref="SdkException"> If there is an error during the inclusion process, such as network issues
    ///                      or API response errors. </exception>
    public void IncludeWebhook(Config config, string webhookUrl)
    {
        InterSdk.LogInfo($"IncludeWebhook billing {config.ClientId} {webhookUrl}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING_WEBHOOK);
        var request = new IncludeWebhookRequest(webhookUrl);

        WebhookUtil.IncludeWebhook(config, url, request, Constants.BILLET_BILLING_WRITE_SCOPE);
    }

    /// <summary>
    /// Retrieves a page of callback responses based on the specified date range and optional filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDateHour_"> The start date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDateHour_"> The end date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> Optional filters to be applied to the callback retrieval. </param>
    /// <returns> A {@link BillingCallbackPage} object containing the requested page of callback responses. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public BillingCallbackPage RetrieveCallbackPage(Config config, string initialDateHour, string finalDateHour, int page, int? pageSize, BillingRetrieveCallbacksFilter filter)
    {
        InterSdk.LogInfo($"RetrieveCallback {config.ClientId} {initialDateHour}-{finalDateHour}");
        return GetPage(config, initialDateHour, finalDateHour, page, pageSize, filter);
    }

    /// <summary>
    /// Retrieves all callback responses within the specified date range, applying the given filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDateHour_"> The start date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDateHour_"> The end date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_filter_"> Optional filters to be applied to the callback retrieval. </param>
    /// <returns> A list of {@link BillingRetrieveCallbackResponse} objects containing all callback responses
    /// within the specified date range. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public List<BillingRetrieveCallbackResponse> RetrieveCallbackInRange(Config config, string initialDateHour, string finalDateHour, BillingRetrieveCallbacksFilter filter)
    {
        InterSdk.LogInfo($"RetrieveCallback {config.ClientId} {initialDateHour}-{finalDateHour}");
        int page = 0;
        BillingCallbackPage callbackPage;
        var callbacks = new List<BillingRetrieveCallbackResponse>();

        do
        {
            callbackPage = GetPage(config, initialDateHour, finalDateHour, page, null, filter);
            callbacks.AddRange(callbackPage.Callbacks);
            page++;
        } while (page < callbackPage.TotalPages);

        return callbacks;
    }

    /// <summary>
    /// Retrieves the webhook configuration associated with the specified client configuration.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <returns> A {@link Webhook} object containing the current webhook settings. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public Webhook RetrieveWebhook(Config config)
    {
        InterSdk.LogInfo($"RetrieveWebhook billing {config.ClientId}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING_WEBHOOK);

        return WebhookUtil.RetrieveWebhook(config, url, Constants.BILLET_BILLING_READ_SCOPE);
    }

    /// <summary>
    /// Retrieves a specific page of callbacks from the webhook.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDateHour_"> The start date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDateHour_"> The end date and hour for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> Optional filters to be applied to the callback retrieval. </param>
    /// <returns> A {@link BillingCallbackPage} object containing the requested page of callback responses. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                     or API response errors. </exception>
    private BillingCallbackPage GetPage(Config config, string initialDateHour, string finalDateHour, int page, int? pageSize, BillingRetrieveCallbacksFilter filter)
    {
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING_WEBHOOK_CALLBACKS)
            + "?dataHoraInicio=" + initialDateHour
            + "&dataHoraFim=" + finalDateHour
            + "&pagina=" + page
            + (pageSize.HasValue ? "&itensPorPagina=" + pageSize.Value : "")
            + AddFilters(filter);

        string json = HttpUtils.CallGet(config, url, Constants.BILLET_BILLING_READ_SCOPE, "Error retrieving callbacks");

        try
        {
            return JsonSerializer.Deserialize<BillingCallbackPage>(json)!;
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
    private string AddFilters(BillingRetrieveCallbacksFilter filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }

        var stringFilter = new StringBuilder();

        if (filter.RequestCode != null)
        {
            stringFilter.Append("&codigoSolicitacao=").Append(filter.RequestCode);
        }

        return stringFilter.ToString();
    }
}
