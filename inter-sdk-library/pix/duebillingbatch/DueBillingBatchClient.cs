namespace inter_sdk_library;

using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class DueBillingBatchClient
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions 
    { 
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    /// <summary>
    /// Includes a batch request for due billing based on the provided configuration,
    /// batch ID, and request details.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_id_"> The unique identifier for the batch of due billings to be included. </param>
    /// <param _name_="_request_"> The {@link IncludeDueBillingBatchRequest} object containing the details
    ///                of the due billing batch request to be included. </param>
    /// <exception cref="SdkException"> If there is an error during the inclusion process, such as network issues
    ///                      or API response errors. </exception>
    public void Include(Config config, string id, IncludeDueBillingBatchRequest request)
    {
        InterSdk.LogInfo($"IncludeDueBillingBatch {config.ClientId} {request}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS_BATCH) + "/" + id;

        try
        {
            string json = JsonSerializer.Serialize(request, jsonOptions);
            HttpUtils.CallPut(config, url, Constants.PIX_SCHEDULED_BILLING_BATCH_WRITE_SCOPE, "Error including due billing in batch", json);
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a due billing batch based on the provided configuration and batch ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_id_"> The unique identifier for the due billing batch to be retrieved. </param>
    /// <returns> A {@link DueBillingBatch} object containing the details of the retrieved due billing batch. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public DueBillingBatch Retrieve(Config config, string id)
    {
        InterSdk.LogInfo($"RetrieveDueBillingBatch {config.ClientId} id={id}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS_BATCH) + "/" + id;
        string json = HttpUtils.CallGet(config, url, Constants.PIX_SCHEDULED_BILLING_BATCH_READ_SCOPE, "Error retrieving due billing batch");
        
        try
        {
            return JsonSerializer.Deserialize<DueBillingBatch>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a paginated list of due billing batches based on the specified date range and page number.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <returns> A {@link DueBillingBatchPage} object containing the requested page of due billing batches. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public DueBillingBatchPage Retrieve(Config config, string initialDate, string finalDate, int page, int? pageSize)
    {
        InterSdk.LogInfo($"RetrieveDueBillingBatchList {config.ClientId} {initialDate}-{finalDate} page={page}");
        return GetPage(config, initialDate, finalDate, page, pageSize);
    }

    /// <summary>
    /// Retrieves all due billing batches within the specified date range.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <returns> A list of {@link DueBillingBatch} objects containing all retrieved billing batches. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public List<DueBillingBatch> Retrieve(Config config, string initialDate, string finalDate)
    {
        InterSdk.LogInfo($"RetrieveDueBillingBatchList {config.ClientId} {initialDate}-{finalDate}");
        int page = 0;
        DueBillingBatchPage dueBillingPage;
        var batches = new List<DueBillingBatch>();

        do
        {
            dueBillingPage = GetPage(config, initialDate, finalDate, page, null);
            batches.AddRange(dueBillingPage.Batches);
            page++;
        } while (page < dueBillingPage.GetTotalPages());

        return batches;
    }

    /// <summary>
    /// Reviews a due billing batch based on the provided configuration, batch ID, and review request details.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_id_"> The unique identifier for the due billing batch to be reviewed. </param>
    /// <param _name_="_request_"> The {@link IncludeDueBillingBatchRequest} object containing the details to update the review. </param>
    /// <exception cref="SdkException"> If there is an error during the review process, such as network issues
    ///                      or API response errors. </exception>
    public void Review(Config config, string id, IncludeDueBillingBatchRequest request)
    {
        InterSdk.LogInfo($"IncludeDueBillingBatch {config.ClientId} {request}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS_BATCH) + "/" + id;

        try
        {
            string json = JsonSerializer.Serialize(request, jsonOptions);
            HttpUtils.CallPatch(config, url, Constants.PIX_SCHEDULED_BILLING_BATCH_WRITE_SCOPE, "Error reviewing due billing in batch", json);
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves the summary of a due billing batch based on the provided configuration and batch ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_id_"> The unique identifier for the due billing batch to be retrieved. </param>
    /// <returns> A {@link DueBillingBatchSummary} object containing the summary details of the retrieved due billing batch. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public DueBillingBatchSummary RetrieveSummary(Config config, string id)
    {
        InterSdk.LogInfo($"RetrieveDueBillingBatch {config.ClientId} id={id}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS_BATCH) + "/" + id + "/sumario";
        string json = HttpUtils.CallGet(config, url, Constants.PIX_SCHEDULED_BILLING_BATCH_READ_SCOPE, "Error retrieving due billing batch summary");

        try
        {
            return JsonSerializer.Deserialize<DueBillingBatchSummary>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a due billing batch identified by the specified ID and situation.
    /// This method constructs a URL using the provided configuration, ID, and situation,
    /// performs a GET request to retrieve the corresponding due billing batch,
    /// and maps the JSON response to a {@link DueBillingBatch} object.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information for making the request. </param>
    /// <param _name_="_id_"> The unique identifier of the due billing batch to retrieve. </param>
    /// <param _name_="_situation_"> The situation status to filter the due billing batch. </param>
    /// <returns> A {@link DueBillingBatch} object representing the retrieved billing batch. </returns>
    /// <exception cref="SdkException"> If an error occurs while making the HTTP request or processing the response.
    ///                      This includes issues related to network access, invalid responses,
    ///                      and JSON mapping errors. </exception>
    public DueBillingBatch RetrieveBySituation(Config config, string id, string situation)
    {
        InterSdk.LogInfo($"RetrieveDueBillingBatchSituation {config.ClientId} id={id}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS_BATCH) + "/" + id + "/situacao/" + situation;
        string json = HttpUtils.CallGet(config, url, Constants.PIX_SCHEDULED_BILLING_BATCH_READ_SCOPE, "Error retrieving due billing batch by situation");

        try
        {
            return JsonSerializer.Deserialize<DueBillingBatch>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a specific page of due billing batches based on the provided criteria.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <returns> A {@link DueBillingBatchPage} object containing the requested page of due billing batches. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    private DueBillingBatchPage GetPage(Config config, string initialDate, string finalDate, int page, int? pageSize)
    {
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS_BATCH) + "?inicio=" + initialDate 
                    + "&fim=" + finalDate 
                    + "&paginacao.paginaAtual=" + page 
                    + (pageSize.HasValue ? "&paginacao.itensPorPagina=" + pageSize.Value : "");
                    
        string json = HttpUtils.CallGet(config, url, Constants.PIX_SCHEDULED_BILLING_BATCH_READ_SCOPE, "Error retrieving due billing batch");
        
        try
        {
            return JsonSerializer.Deserialize<DueBillingBatchPage>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }
}
