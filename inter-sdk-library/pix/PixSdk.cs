namespace inter_sdk_library;

public class PixSdk
{
    private Config config;
    private DueBillingClient dueBillingClient;
    private DueBillingBatchClient dueBillingBatchClient;
    private ImmediateBillingClient immediateBillingClient;
    private LocationClient locationClient;
    private PixClient pixClient;
    private PixWebhookSdk pixWebhookSdk;

    public PixSdk(Config config) 
    {
        this.config = config;
    }

    /// <summary>
    /// Includes a due billing entry for a PIX transaction.
    /// </summary>
    /// <param _name_="_txid_"> The transaction ID associated with the due billing. </param>
    /// <param _name_="_billing_"> The DueBilling object containing the billing details to be included. </param>
    /// <returns> A GeneratedDueBilling object containing the details of the included due billing. </returns>
    /// <exception cref="SdkException"> If an error occurs during the inclusion process. </exception>
    public GeneratedDueBilling IncludeDuePixBilling(string txid, DueBilling billing)
    {
        if (dueBillingClient == null)
        {
            dueBillingClient = new DueBillingClient();
        }

        return dueBillingClient.Include(config, txid, billing);
    }

    /// <summary>
    /// Retrieves the detailed due billing information for a specific PIX transaction.
    /// </summary>
    /// <param _name_="_txid_"> The transaction ID associated with the due billing to be retrieved. </param>
    /// <returns> A DetailedDuePixBilling object containing the details of the retrieved due billing. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public DetailedDuePixBilling RetrieveDuePixBilling(string txid)
    {
        if (dueBillingClient == null)
        {
            dueBillingClient = new DueBillingClient();
        }

        return dueBillingClient.Retrieve(config, txid);
    }

    /// <summary>
    /// Retrieves a list of detailed due billing entries for a specified period, applying optional filters.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the billing collection retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the billing collection retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Optional filter criteria to refine the billing collection retrieval. </param>
    /// <returns> A list of DetailedDuePixBilling objects containing the retrieved billing information. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public List<DetailedDuePixBilling> RetrieveBillingCollection(string initialDate, string finalDate, RetrieveDueBillingFilter filter)
    {
        if (dueBillingClient == null)
        {
            dueBillingClient = new DueBillingClient();
        }

        return dueBillingClient.Retrieve(config, initialDate, finalDate, filter);
    }

    /// <summary>
    /// Retrieves a paginated collection of due billing entries for a specified period, applying optional filters.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the billing collection retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the billing collection retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_page_"> The page number for pagination. </param>
    /// <param _name_="_pageSize_"> The number of items per page. If null, a default size will be used. </param>
    /// <param _name_="_filter_"> Optional filter criteria to refine the billing collection retrieval. </param>
    /// <returns> A DueBillingPage object containing the paginated list of retrieved due billing entries. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public DueBillingPage RetrieveBillingCollection(string initialDate, string finalDate, int page, int? pageSize, RetrieveDueBillingFilter filter)
    {
        if (dueBillingClient == null)
        {
            dueBillingClient = new DueBillingClient();
        }

        return dueBillingClient.Retrieve(config, initialDate, finalDate, page, pageSize, filter);
    }

    /// <summary>
    /// Reviews a due billing entry for a PIX transaction.
    /// </summary>
    /// <param _name_="_txid_"> The transaction ID associated with the due billing to be reviewed. </param>
    /// <param _name_="_billing_"> The DueBilling object containing the billing details to be reviewed. </param>
    /// <returns> A GeneratedDueBilling object containing the details of the reviewed due billing. </returns>
    /// <exception cref="SdkException"> If an error occurs during the review process. </exception>
    public GeneratedDueBilling ReviewDuePixBilling(string txid, DueBilling billing)
    {
        if (dueBillingClient == null)
        {
            dueBillingClient = new DueBillingClient();
        }

        return dueBillingClient.Review(config, txid, billing);
    }

    /// <summary>
    /// Includes a batch of due billing entries for a specific PIX transaction.
    /// </summary>
    /// <param _name_="_txid_"> The transaction ID associated with the due billing batch. </param>
    /// <param _name_="_batchRequest_"> The IncludeDueBillingBatchRequest object containing the details of the billing batch to be included. </param>
    /// <exception cref="SdkException"> If an error occurs during the inclusion process. </exception>
    public void IncludeDueBillingBatch(string txid, IncludeDueBillingBatchRequest batchRequest)
    {
        if (dueBillingBatchClient == null)
        {
            dueBillingBatchClient = new DueBillingBatchClient();
        }

        dueBillingBatchClient.Include(config, txid, batchRequest);
    }

    /// <summary>
    /// Retrieves a due billing batch by its identifier.
    /// </summary>
    /// <param _name_="_id_"> The identifier of the billing batch to be retrieved. </param>
    /// <returns> A DueBillingBatch object containing the details of the retrieved billing batch. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public DueBillingBatch RetrieveDueBillingBatch(string id)
    {
        if (dueBillingBatchClient == null)
        {
            dueBillingBatchClient = new DueBillingBatchClient();
        }

        return dueBillingBatchClient.Retrieve(config, id);
    }

    /// <summary>
    /// Retrieves a paginated collection of due billing batches for a specified period.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the billing batch collection retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the billing batch collection retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_page_"> The page number for pagination. </param>
    /// <param _name_="_pageSize_"> The number of items per page. If null, a default size will be used. </param>
    /// <returns> A DueBillingBatchPage object containing the paginated list of retrieved due billing batches. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public DueBillingBatchPage RetrieveDueBillingBatchCollection(string initialDate, string finalDate, int page, int? pageSize)
    {
        if (dueBillingBatchClient == null)
        {
            dueBillingBatchClient = new DueBillingBatchClient();
        }

        return dueBillingBatchClient.Retrieve(config, initialDate, finalDate, page, pageSize);
    }

    /// <summary>
    /// Retrieves a list of due billing batches for a specified period.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the billing batch collection retrieval. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the billing batch collection retrieval. Format: YYYY-MM-DD. </param>
    /// <returns> A list of DueBillingBatch objects containing the retrieved billing batches. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public List<DueBillingBatch> RetrieveDueBillingBatchCollection(string initialDate, string finalDate)
    {
        if (dueBillingBatchClient == null)
        {
            dueBillingBatchClient = new DueBillingBatchClient();
        }

        return dueBillingBatchClient.Retrieve(config, initialDate, finalDate);
    }

    /// <summary>
    /// Retrieves the situation of a specific due billing batch by its identifier.
    /// </summary>
    /// <param _name_="_id_"> The identifier of the billing batch whose situation is to be retrieved. </param>
    /// <param _name_="_situation_"> The specific situation to filter the results. </param>
    /// <returns> A DueBillingBatch object containing the details of the retrieved billing batch situation. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public DueBillingBatch RetrieveDueBillingBatchBySituation(string id, string situation)
    {
        if (dueBillingBatchClient == null)
        {
            dueBillingBatchClient = new DueBillingBatchClient();
        }

        return dueBillingBatchClient.RetrieveBySituation(config, id, situation);
    }

    /// <summary>
    /// Retrieves the summary of a specific due billing batch by its identifier.
    /// </summary>
    /// <param _name_="_id_"> The identifier of the billing batch whose summary is to be retrieved. </param>
    /// <returns> A DueBillingBatchSummary object containing the summary details of the retrieved billing batch. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public DueBillingBatchSummary RetrieveDueBillingBatchSummary(string id)
    {
        if (dueBillingBatchClient == null)
        {
            dueBillingBatchClient = new DueBillingBatchClient();
        }

        return dueBillingBatchClient.RetrieveSummary(config, id);
    }

    /// <summary>
    /// Reviews a due billing batch identified by its ID.
    /// </summary>
    /// <param _name_="_id_"> The identifier of the billing batch to be reviewed. </param>
    /// <param _name_="_request_"> The IncludeDueBillingBatchRequest object containing details for the review process. </param>
    /// <exception cref="SdkException"> If an error occurs during the review process. </exception>
    public void ReviewDueBillingBatch(string id, IncludeDueBillingBatchRequest request)
    {
        if (dueBillingBatchClient == null)
        {
            dueBillingBatchClient = new DueBillingBatchClient();
        }

        dueBillingBatchClient.Review(config, id, request);
    }

    /// <summary>
    /// Includes an immediate billing entry for a PIX transaction.
    /// </summary>
    /// <param _name_="_billing_"> The PixBilling object containing the details of the immediate billing to be included. </param>
    /// <returns> A GeneratedImmediateBilling object containing the details of the included immediate billing. </returns>
    /// <exception cref="SdkException"> If an error occurs during the inclusion process. </exception>
    public GeneratedImmediateBilling IncludeImmediateBilling(PixBilling billing)
    {
        if (immediateBillingClient == null)
        {
            immediateBillingClient = new ImmediateBillingClient();
        }
        return immediateBillingClient.Include(config, billing);
    }

    /// <summary>
    /// Retrieves the details of an immediate billing entry by its transaction ID.
    /// </summary>
    /// <param _name_="_txid_"> The transaction ID associated with the immediate billing to be retrieved. </param>
    /// <returns> A DetailedImmediatePixBilling object containing the details of the retrieved immediate billing. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public DetailedImmediatePixBilling RetrieveImmediateBilling(string txid)
    {
        if (immediateBillingClient == null)
        {
            immediateBillingClient = new ImmediateBillingClient();
        }
        return immediateBillingClient.Retrieve(config, txid);
    }

    /// <summary>
    /// Retrieves a list of detailed immediate billing entries for a specified period, optionally filtered.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the retrieval of immediate billings. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the retrieval of immediate billings. Format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> The filter criteria for retrieving the immediate billings. </param>
    /// <returns> A list of DetailedImmediatePixBilling objects containing the details of the retrieved immediate billings. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public List<DetailedImmediatePixBilling> RetrieveImmediateBillingList(string initialDate, string finalDate, RetrieveImmediateBillingsFilter filter)
    {
        if (immediateBillingClient == null)
        {
            immediateBillingClient = new ImmediateBillingClient();
        }
        return immediateBillingClient.Retrieve(config, initialDate, finalDate, filter);
    }

    /// <summary>
    /// Retrieves a paginated list of immediate billing entries for a specified period, optionally filtered.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the retrieval of immediate billings. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the retrieval of immediate billings. Format: YYYY-MM-DD. </param>
    /// <param _name_="_page_"> The page number for pagination. </param>
    /// <param _name_="_pageSize_"> The number of items per page. If null, a default size will be used. </param>
    /// <param _name_="_filter_"> The filter criteria for retrieving the immediate billings. </param>
    /// <returns> A BillingPage object containing the paginated list of retrieved immediate billings. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public PixBillingPage RetrieveImmediateBillingList(string initialDate, string finalDate, int page, int? pageSize, RetrieveImmediateBillingsFilter filter)
    {
        if (immediateBillingClient == null)
        {
            immediateBillingClient = new ImmediateBillingClient();
        }
        return immediateBillingClient.Retrieve(config, initialDate, finalDate, page, pageSize, filter);
    }

    /// <summary>
    /// Reviews an immediate billing entry for a PIX transaction.
    /// </summary>
    /// <param _name_="_billing_"> The PixBilling object containing the details of the immediate billing to be reviewed. </param>
    /// <returns> A GeneratedImmediateBilling object containing the details of the reviewed immediate billing. </returns>
    /// <exception cref="SdkException"> If an error occurs during the review process. </exception>
    public GeneratedImmediateBilling ReviewImmediateBilling(PixBilling billing)
    {
        if (immediateBillingClient == null)
        {
            immediateBillingClient = new ImmediateBillingClient();
        }
        return immediateBillingClient.Review(config, billing);
    }

    /// <summary>
    /// Includes a location associated with an immediate billing type.
    /// </summary>
    /// <param _name_="_immediateBillingType_"> The ImmediateBillingType object containing the details of the location to be included. </param>
    /// <returns> A Location object containing the details of the included location. </returns>
    /// <exception cref="SdkException"> If an error occurs during the inclusion process. </exception>
    public Location IncludeLocation(string immediateBillingType)
    {
        if (locationClient == null)
        {
            locationClient = new LocationClient();
        }
        return locationClient.Include(config, immediateBillingType);
    }

    /// <summary>
    /// Retrieves a location by its identifier.
    /// </summary>
    /// <param _name_="_locationId_"> The identifier of the location to be retrieved. </param>
    /// <returns> A Location object containing the details of the retrieved location. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public Location RetrieveLocation(string locationId)
    {
        if (locationClient == null)
        {
            locationClient = new LocationClient();
        }
        return locationClient.Retrieve(config, locationId);
    }

    /// <summary>
    /// Retrieves a list of locations for a specified period, optionally filtered.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the retrieval of locations. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the retrieval of locations. Format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> The filter criteria for retrieving the locations. </param>
    /// <returns> A list of Location objects containing the details of the retrieved locations. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public List<Location> RetrieveLocationsList(string initialDate, string finalDate, RetrieveLocationFilter filter)
    {
        if (locationClient == null)
        {
            locationClient = new LocationClient();
        }
        return locationClient.Retrieve(config, initialDate, finalDate, filter);
    }

    /// <summary>
    /// Retrieves a paginated list of locations for a specified period, optionally filtered.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the retrieval of locations. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the retrieval of locations. Format: YYYY-MM-DD. </param>
    /// <param _name_="_page_"> The page number for pagination. </param>
    /// <param _name_="_pageSize_"> The number of items per page. If null, a default size will be used. </param>
    /// <param _name_="_filter_"> The filter criteria for retrieving the locations. </param>
    /// <returns> A LocationPage object containing the paginated list of retrieved locations. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public LocationPage RetrieveLocationsList(string initialDate, string finalDate, int page, int? pageSize, RetrieveLocationFilter filter)
    {
        if (locationClient == null)
        {
            locationClient = new LocationClient();
        }
        return locationClient.Retrieve(config, initialDate, finalDate, page, pageSize, filter);
    }

    /// <summary>
    /// Unlinks a location by its identifier.
    /// </summary>
    /// <param _name_="_id_"> The identifier of the location to be unlinked. </param>
    /// <returns> A Location object containing the details of the unlinked location. </returns>
    /// <exception cref="SdkException"> If an error occurs during the unlinking process. </exception>
    public Location UnlinkLocation(string id)
    {
        if (locationClient == null)
        {
            locationClient = new LocationClient();
        }
        return locationClient.Unlink(config, id);
    }

    /// <summary>
    /// Requests a devolution for a specific transaction.
    /// </summary>
    /// <param _name_="_e2eId_"> The end-to-end identifier for the transaction. </param>
    /// <param _name_="_id_"> The identifier of the devolution request. </param>
    /// <param _name_="_devolutionRequestBody_"> The body containing the details for the devolution request. </param>
    /// <returns> A DetailedDevolution object containing the details of the requested devolution. </returns>
    /// <exception cref="SdkException"> If an error occurs during the request process. </exception>
    public DetailedDevolution RequestDevolution(string e2eId, string id, DevolutionRequestBody devolutionRequestBody)
    {
        if (pixClient == null)
        {
            pixClient = new PixClient();
        }
        return pixClient.Request(config, e2eId, id, devolutionRequestBody);
    }

    /// <summary>
    /// Retrieves the details of a specific devolution by its identifiers.
    /// </summary>
    /// <param _name_="_e2eId_"> The end-to-end identifier for the transaction. </param>
    /// <param _name_="_id_"> The identifier of the devolution to be retrieved. </param>
    /// <returns> A DetailedDevolution object containing the details of the retrieved devolution. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public DetailedDevolution RetrieveDevolution(string e2eId, string id)
    {
        if (pixClient == null)
        {
            pixClient = new PixClient();
        }
        return pixClient.Retrieve(config, e2eId, id);
    }

    /// <summary>
    /// Retrieves a list of PIX transactions for a specified period, optionally filtered.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the retrieval of PIX transactions. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the retrieval of PIX transactions. Format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> The filter criteria for retrieving the PIX transactions. </param>
    /// <returns> A list of Pix objects containing the details of the retrieved PIX transactions. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public List<Pix> RetrievePixList(string initialDate, string finalDate, RetrievedPixFilter filter)
    {
        if (pixClient == null)
        {
            pixClient = new PixClient();
        }
        return pixClient.Retrieve(config, initialDate, finalDate, filter);
    }

    /// <summary>
    /// Retrieves a paginated list of PIX transactions for a specified period, optionally filtered.
    /// </summary>
    /// <param _name_="_initialDate_"> The starting date for the retrieval of PIX transactions. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> The ending date for the retrieval of PIX transactions. Format: YYYY-MM-DD. </param>
    /// <param _name_="_page_"> The page number for pagination. </param>
    /// <param _name_="_pageSize_"> The number of items per page. If null, a default size will be used. </param>
    /// <param _name_="_filter_"> The filter criteria for retrieving the PIX transactions. </param>
    /// <returns> A PixPage object containing the paginated list of retrieved PIX transactions. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public PixPage RetrievePixList(string initialDate, string finalDate, int page, int? pageSize, RetrievedPixFilter filter)
    {
        if (pixClient == null)
        {
            pixClient = new PixClient();
        }
        return pixClient.Retrieve(config, initialDate, finalDate, page, pageSize, filter);
    }

    /// <summary>
    /// Retrieves the details of a specific PIX transaction by its end-to-end identifier.
    /// </summary>
    /// <param _name_="_e2eId_"> The end-to-end identifier for the PIX transaction. </param>
    /// <returns> A Pix object containing the details of the retrieved PIX transaction. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public Pix RetrievePix(string e2eId)
    {
        if (pixClient == null)
        {
            pixClient = new PixClient();
        }
        return pixClient.Retrieve(config, e2eId);
    }

    /// <summary>
    /// Retrieves a list of callback responses for a specified period, optionally filtered.
    /// </summary>
    /// <param _name_="_initialDateHour_"> The starting date and hour for the retrieval of callbacks. Format: YYYY-MM-DD HH:mm. </param>
    /// <param _name_="_finalDateHour_"> The ending date and hour for the retrieval of callbacks. Format: YYYY-MM-DD HH:mm. </param>
    /// <param _name_="_filter_"> The filter criteria for retrieving the callback responses. </param>
    /// <returns> A list of RetrieveCallbackResponse objects containing the details of the retrieved callbacks. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public List<RetrieveCallbackResponse> RetrieveCallbacks(string initialDateHour, string finalDateHour, PixCallbackRetrieveFilter filter)
    {
        if (pixWebhookSdk == null)
        {
            pixWebhookSdk = new PixWebhookSdk();
        }
        return pixWebhookSdk.Retrieve(config, initialDateHour, finalDateHour, filter);
    }

    /// <summary>
    /// Retrieves a paginated list of callback responses for a specified period, optionally filtered.
    /// </summary>
    /// <param _name_="_initialDateHour_"> The starting date and hour for the retrieval of callbacks. Format: YYYY-MM-DD HH:mm. </param>
    /// <param _name_="_finalDateHour_"> The ending date and hour for the retrieval of callbacks. Format: YYYY-MM-DD HH:mm. </param>
    /// <param _name_="_page_"> The page number for pagination. </param>
    /// <param _name_="_pageSize_"> The number of items per page. If null, a default size will be used. </param>
    /// <param _name_="_filter_"> The filter criteria for retrieving the callback responses. </param>
    /// <returns> A CallbackPage object containing the paginated list of retrieved callbacks. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public PixCallbackPage RetrieveCallbacks(string initialDateHour, string finalDateHour, int page, int? pageSize, PixCallbackRetrieveFilter filter)
    {
        if (pixWebhookSdk == null)
        {
            pixWebhookSdk = new PixWebhookSdk();
        }
        return pixWebhookSdk.Retrieve(config, initialDateHour, finalDateHour, page, pageSize, filter);
    }

    /// <summary>
    /// Includes a new webhook for a specified key.
    /// </summary>
    /// <param _name_="_key_"> The identifier key for which the webhook is being included. </param>
    /// <param _name_="_webhookUrl_"> The URL of the webhook to be included. </param>
    /// <exception cref="SdkException"> If an error occurs during the inclusion of the webhook. </exception>
    public void IncludeWebhook(string key, string webhookUrl)
    {
        if (pixWebhookSdk == null)
        {
            pixWebhookSdk = new PixWebhookSdk();
        }
        pixWebhookSdk.Include(config, key, webhookUrl);
    }

    /// <summary>
    /// Retrieves the details of a specific webhook by its identifier key.
    /// </summary>
    /// <param _name_="_key_"> The identifier key for the webhook to be retrieved. </param>
    /// <returns> A Webhook object containing the details of the retrieved webhook. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval process. </exception>
    public Webhook RetrieveWebhook(string key)
    {
        if (pixWebhookSdk == null)
        {
            pixWebhookSdk = new PixWebhookSdk();
        }
        return pixWebhookSdk.Retrieve(config, key);
    }

    /// <summary>
    /// Deletes a specific webhook identified by its key.
    /// </summary>
    /// <param _name_="_key_"> The identifier key for the webhook to be deleted. </param>
    /// <exception cref="SdkException"> If an error occurs during the deletion process. </exception>
    public void DeleteWebhook(string key)
    {
        if (pixWebhookSdk == null)
        {
            pixWebhookSdk = new PixWebhookSdk();
        }
        pixWebhookSdk.Delete(config, key);
    }
}
