namespace inter_sdk_library;

using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class DueBillingClient
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions 
    { 
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    /// <summary>
    /// Includes a due billing entry into the system for a specified transaction ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_txid_"> The transaction ID associated with the due billing. </param>
    /// <param _name_="_billing_"> The {@link DueBilling} object containing the billing details to be included. </param>
    /// <returns> A {@link GeneratedDueBilling} object containing the details of the generated billing. </returns>
    /// <exception cref="SdkException"> If there is an error during the inclusion process, such as network issues
    ///                      or API response errors. </exception>
    public GeneratedDueBilling IncludeDueBilling(Config config, string txid, DueBilling billing)
    {
        InterSdk.LogInfo($"IncludeDueBilling {config.ClientId} {txid}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS) + "/" + txid;

        try
        {
            string json = JsonSerializer.Serialize(billing, jsonOptions);
            json = HttpUtils.CallPut(config, url, Constants.PIX_SCHEDULED_BILLING_WRITE_SCOPE, "Error including due billing", json);
            return JsonSerializer.Deserialize<GeneratedDueBilling>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves detailed information about a scheduled Pix billing using the provided transaction ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_txid_"> The transaction ID associated with the scheduled Pix billing. </param>
    /// <returns> A {@link DetailedDuePixBilling} object containing the details of the scheduled billing. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public DetailedDuePixBilling RetrieveDueBilling(Config config, string txid)
    {
        InterSdk.LogInfo($"RetrieveDueBilling {config.ClientId} txId={txid}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS) + "/" + txid;
        string json = HttpUtils.CallGet(config, url, Constants.PIX_SCHEDULED_BILLING_READ_SCOPE, "Error retrieving due billing");
        
        try
        {
            return JsonSerializer.Deserialize<DetailedDuePixBilling>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a page of scheduled Pix billings within a specified date range and optional filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> Optional filters to be applied during retrieval. </param>
    /// <returns> A {@link DueBillingPage} object containing the requested page of due billings. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public DueBillingPage RetrieveDueBillingPage(Config config, string initialDate, string finalDate, int page, int? pageSize, RetrieveDueBillingFilter filter)
    {
        InterSdk.LogInfo($"RetrieveDueBillingList {config.ClientId} {initialDate}-{finalDate} page={page}");
        return GetPage(config, initialDate, finalDate, page, pageSize, filter);
    }

    /// <summary>
    /// Retrieves all scheduled Pix billings within a specified date range and applies the given filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_filter_"> Optional filters to be applied during retrieval. </param>
    /// <returns> A list of {@link DetailedDuePixBilling} objects containing all retrieved billings. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public List<DetailedDuePixBilling> RetrieveDueBillingInRange(Config config, string initialDate, string finalDate, RetrieveDueBillingFilter filter)
    {
        InterSdk.LogInfo($"RetrieveDueBillingList {config.ClientId} {initialDate}-{finalDate}");
        int page = 0;
        DueBillingPage dueBillingPage;
        var billings = new List<DetailedDuePixBilling>();

        do
        {
            dueBillingPage = GetPage(config, initialDate, finalDate, page, null, filter);
            billings.AddRange(dueBillingPage.DueBillings);
            page++;
        } while (page < dueBillingPage.GetTotalPages());

        return billings;
    }

    /// <summary>
    /// Reviews a scheduled Pix billing entry based on the specified transaction ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_txid_"> The transaction ID associated with the due billing to be reviewed. </param>
    /// <param _name_="_billing_"> The {@link DueBilling} object containing the updated billing details. </param>
    /// <returns> A {@link GeneratedDueBilling} object containing the details of the reviewed billing. </returns>
    /// <exception cref="SdkException"> If there is an error during the review process, such as network issues
    ///                      or API response errors. </exception>
    public GeneratedDueBilling ReviewDueBilling(Config config, string txid, DueBilling billing)
    {
        InterSdk.LogInfo($"ReviewDueBilling {config.ClientId} {txid}");

        try
        {
            string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS) + "/" + txid;
            string json = JsonSerializer.Serialize(billing, jsonOptions);
            json = HttpUtils.CallPatch(config, url, Constants.PIX_SCHEDULED_BILLING_WRITE_SCOPE, "Error retrieving due billing", json);
            
            return JsonSerializer.Deserialize<GeneratedDueBilling>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a specific page of scheduled Pix billings based on the provided criteria.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> Optional filters to be applied during retrieval. </param>
    /// <returns> A {@link DueBillingPage} object containing the requested page of due billings. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    private DueBillingPage GetPage(Config config, string initialDate, string finalDate, int page, int? pageSize, RetrieveDueBillingFilter filter)
    {
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_SCHEDULED_BILLINGS)
            + "?inicio=" + initialDate
            + "&fim=" + finalDate
            + "&paginacao.paginaAtual=" + page
            + (pageSize.HasValue ? "&paginacao.itensPorPagina=" + pageSize.Value : "")
            + AddFilters(filter);

        string json = HttpUtils.CallGet(config, url, Constants.PIX_SCHEDULED_BILLING_READ_SCOPE, "Error retrieving due billing");
        
        try
        {
            return JsonSerializer.Deserialize<DueBillingPage>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Constructs the query string for filters to be applied when retrieving due billings.
    /// </summary>
    /// <param _name_="_filter_"> The filter object containing filtering criteria. </param>
    /// <returns> A query string that can be appended to the URL for filtering. </returns>
    private string AddFilters(RetrieveDueBillingFilter filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }

        var stringFilter = new StringBuilder();

        if (!string.IsNullOrEmpty(filter.Cpf))
        {
            stringFilter.Append("&cpf=").Append(filter.Cpf);
        }
        if (!string.IsNullOrEmpty(filter.Cnpj))
        {
            stringFilter.Append("&cnpj=").Append(filter.Cnpj);
        }
        if (filter.LocationPresent.HasValue)
        {
            stringFilter.Append("&locationPresente=").Append(filter.LocationPresent.Value);
        }
        if (filter.Status != null)
        {
            stringFilter.Append("&status=").Append(filter.Status.ToString());
        }

        return stringFilter.ToString();
    }
}
