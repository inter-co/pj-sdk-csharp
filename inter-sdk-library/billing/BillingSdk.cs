namespace inter_sdk_library;

public class BillingSdk
{
    private Config config;
    private BillingClient billingClient;
    private BillingWebhookClient billingWebhookClient;

    public BillingSdk(Config config) {
        this.config = config;
    }

    /// <summary>
    /// Cancels a billing request specified by the request code.
    /// </summary>
    /// <param _name_="_requestCode_"> The unique code identifying the billing request to be canceled. </param>
    /// <param _name_="_cancellationReason_"> Reason for canceling the billing request. </param>
    /// <exception cref="SdkException"> If an error occurs during the cancellation process. </exception>
    public void CancelBilling(string requestCode, string cancellationReason)
    {
        if (billingClient == null)
        {
            billingClient = new BillingClient();
        }

        billingClient.Cancel(config, requestCode, cancellationReason);
    }

    /// <summary>
    /// Issues a billing request based on the provided billing issue details.
    /// </summary>
    /// <param _name_="_billingIssueRequest_"> The request object containing details for the billing issue. </param>
    /// <returns> A response object containing the outcome of the billing issue process. </returns>
    /// <exception cref="SdkException"> If an error occurs during the billing issue process. </exception>
    public BillingIssueResponse IssueBilling(BillingIssueRequest billingIssueRequest)
    {
        if (billingClient == null)
        {
            billingClient = new BillingClient();
        }

        return billingClient.Issue(config, billingIssueRequest);
    }

    /// <summary>
    /// Retrieves the billing information based on the specified request code.
    /// </summary>
    /// <param _name_="_requestCode_"> The unique code identifying the billing request to retrieve. </param>
    /// <returns> An object containing the details of the retrieved billing information. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public RetrievedBilling RetrieveBilling(string requestCode)
    {
        if (billingClient == null)
        {
            billingClient = new BillingClient();
        }

        return billingClient.Retrieve(config, requestCode);
    }

    /// <summary>
    /// Retrieves a collection of billing information for a specified period, applying optional filters and sorting.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the billing retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the billing retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Optional filter criteria to refine the billing retrieval. </param>
    /// <param _name_="_sort_"> Optional sorting parameters for the retrieved collection. </param>
    /// <returns> A list of retrieved billing information objects. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public List<RetrievedBillingCollectionUnit> RetrieveBillingCollection(string initialDate, string finalDate, BillingRetrievalFilter filter, Sorting sort)
    {
        if (billingClient == null)
        {
            billingClient = new BillingClient();
        }

        return billingClient.Retrieve(config, initialDate, finalDate, filter, sort);
    }

    /// <summary>
    /// Retrieves a paginated collection of billing information for a specified period, applying optional filters and sorting.
    /// </summary&gt.
    /// <param _name_="_initialDate_"> The starting date for the billing retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the billing retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_page_"> The page number for pagination. </param>
    /// <param _name_="_pageSize_"> The number of items per page. If null, default size will be used. </param>
    /// <param _name_="_filter_"> Optional filter criteria to refine the billing retrieval. </param>
    /// <param _name_="_sort_"> Optional sorting parameters for the retrieved collection. </param>
    /// <returns> A BillingPage object containing the retrieved billing information. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public BillingPage RetrieveBillingCollection(string initialDate, string finalDate, int page, int? pageSize, BillingRetrievalFilter filter, Sorting sort)
    {
        if (billingClient == null)
        {
            billingClient = new BillingClient();
        }

        return billingClient.Retrieve(config, initialDate, finalDate, page, pageSize, filter, sort);
    }

    /// <summary>
    /// Retrieves the billing PDF document based on the specified request code and saves it to a file.
    /// </summary>
    /// <param _name_="_requestCode_"> The unique code identifying the billing request for which the PDF should be retrieved. </param>
    /// <param _name_="_file_"> The path to the file where the PDF will be saved. </param>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public void RetrieveBillingPdf(string requestCode, string file)
    {
        if (billingClient == null)
        {
            billingClient = new BillingClient();
        }

        billingClient.Retrieve(config, requestCode, file);
    }

    /// <summary>
    /// Retrieves a summary of billing information for a specified period, applying optional filters.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the billing summary retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the billing summary retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Optional filter criteria to refine the billing summary retrieval. </param>
    /// <returns> A Summary object containing the billing information summary. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public Summary RetrieveBillingSummary(string initialDate, string finalDate, BillingRetrievalFilter filter)
    {
        if (billingClient == null)
        {
            billingClient = new BillingClient();
        }

        return billingClient.Retrieve(config, initialDate, finalDate, filter);
    }

    /// <summary>
    /// Retrieves a list of callback responses for a specified period, applying optional filters.
    /// </summary>
    /// <param _name_="_initialDateHour_"> The starting date and hour for the callback retrieval. Format: YYYY-MM-DDTHH:mm. </param>
    /// <param _name_="_finalDateHour_"> The ending date and hour for the callback retrieval. Format: YYYY-MM-DDTHH:mm. </param>
    /// <param _name_="_filter_"> Optional filter criteria to refine the callback retrieval. </param>
    /// <returns> A list of BillingRetrieveCallbackResponse objects containing the retrieved callback information. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public List<BillingRetrieveCallbackResponse> RetrieveCallbacks(string initialDateHour, string finalDateHour, BillingRetrieveCallbacksFilter filter)
    {
        if (billingWebhookClient == null)
        {
            billingWebhookClient = new BillingWebhookClient();
        }

        return billingWebhookClient.Retrieve(config, initialDateHour, finalDateHour, filter);
    }

    /// <summary>
    /// Retrieves a paginated list of callbacks for a specified period, applying optional filters.
    /// </summary>
    /// <param _name_="_initialDateHour_"> The starting date and hour for the callback retrieval. Format: YYYY-MM-DDTHH:mm. </param>
    /// <param _name_="_finalDateHour_"> The ending date and hour for the callback retrieval. Format: YYYY-MM-DDTHH:mm. </param>
    /// <param _name_="_page_"> The page number for pagination. </param>
    /// <param _name_="_pageSize_"> The number of items per page. If null, default size will be used. </param>
    /// <param _name_="_filter_"> Optional filter criteria to refine the callback retrieval. </param>
    /// <returns> A CallbackPage object containing the paginated list of retrieved callbacks. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public BillingCallbackPage RetrieveCallbacks(string initialDateHour, string finalDateHour, int page, int? pageSize, BillingRetrieveCallbacksFilter filter)
    {
        if (billingWebhookClient == null)
        {
            billingWebhookClient = new BillingWebhookClient();
        }

        return billingWebhookClient.Retrieve(config, initialDateHour, finalDateHour, page, pageSize, filter);
    }

    /// <summary>
    /// Includes a webhook URL for receiving notifications.
    /// </summary>
    /// <param _name_="_url_"> The URL of the webhook to be included. </param>
    /// <exception cref="SdkException"> If an error occurs during the inclusion process. </exception>
    public void IncludeWebhook(string url)
    {
        if (billingWebhookClient == null)
        {
            billingWebhookClient = new BillingWebhookClient();
        }

        billingWebhookClient.Include(config, url);
    }

    /// <summary>
    /// Retrieves the currently configured webhook information.
    /// </summary>
    /// <returns> A Webhook object containing the details of the configured webhook. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public Webhook RetrieveWebhook()
    {
        if (billingWebhookClient == null)
        {
            billingWebhookClient = new BillingWebhookClient();
        }

        return billingWebhookClient.Retrieve(config);
    }

    /// <summary>
    /// Deletes the currently configured webhook.
    /// </summary>
    /// <exception cref="SdkException"> If an error occurs during the deletion process. </exception>
    public void DeleteWebhook()
    {
        if (billingWebhookClient == null)
        {
            billingWebhookClient = new BillingWebhookClient();
        }

        billingWebhookClient.Delete(config);
    }
}
