namespace inter_sdk_library;

using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Text.Json.Serialization;
public class ImmediateBillingClient
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions 
    { 
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    /// <summary>
    /// Includes a new immediate billing or updates an existing one based on the provided configuration and billing details.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_billing_"> The {@link PixBilling} object containing the details of the billing to be included. </param>
    /// <returns> A {@link GeneratedImmediateBilling} object containing the details of the generated immediate billing. </returns>
    /// <exception cref="SdkException"> If there is an error during the inclusion process, such as network issues
    ///                      or API response errors. </exception>
    public GeneratedImmediateBilling IncludeImmediateBilling(Config config, PixBilling billing)
    {
        InterSdk.LogInfo($"IncludeImmediateBilling {config.ClientId} {billing.Txid}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_IMMEDIATE_BILLINGS);
        
        try
        {
            string json = JsonSerializer.Serialize(billing, jsonOptions);
            
            if (billing.Txid == null)
            {
                json = HttpUtils.CallPost(config, url, Constants.PIX_IMMEDIATE_BILLING_WRITE_SCOPE, "Error including immediate billing", json);
            }
            else
            {
                url += "/" + billing.Txid;
                json = HttpUtils.CallPut(config, url, Constants.PIX_IMMEDIATE_BILLING_WRITE_SCOPE, "Error including immediate billing", json);
            }

            return JsonSerializer.Deserialize<GeneratedImmediateBilling>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves the details of an immediate billing based on the provided configuration and transaction ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_txId_"> The unique transaction ID for the immediate billing to be retrieved. </param>
    /// <returns> A {@link DetailedImmediatePixBilling} object containing the details of the retrieved immediate billing. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public DetailedImmediatePixBilling RetrieveImmediateBilling(Config config, string txId)
    {
        InterSdk.LogInfo($"RetrieveImmediateBilling {config.ClientId} txId={txId}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_IMMEDIATE_BILLINGS) + "/" + txId;
        string json = HttpUtils.CallGet(config, url, Constants.PIX_IMMEDIATE_BILLING_READ_SCOPE, "Error retrieving immediate billing");
        
        try
        {
            return JsonSerializer.Deserialize<DetailedImmediatePixBilling>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a paginated list of immediate billings based on the specified date range, page number, and filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> A {@link RetrieveImmediateBillingsFilter} object containing filter criteria. </param>
    /// <returns> A {@link BillingPage} object containing the requested page of immediate billings. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public PixBillingPage RetrieveImmediateBillingPage(Config config, string initialDate, string finalDate, int page, int? pageSize, RetrieveImmediateBillingsFilter filter)
    {
        InterSdk.LogInfo($"RetrieveImmediateBillingList {config.ClientId} {initialDate}-{finalDate} page={page}");
        return GetPage(config, initialDate, finalDate, page, pageSize, filter);
    }

    /// <summary>
    /// Retrieves all immediate billings within the specified date range and filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_filter_"> A {@link RetrieveImmediateBillingsFilter} object containing filter criteria. </param>
    /// <returns> A list of {@link DetailedImmediatePixBilling} objects containing all retrieved immediate billings. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public List<DetailedImmediatePixBilling> RetrieveImmediateBillingInRange(Config config, string initialDate, string finalDate, RetrieveImmediateBillingsFilter filter)
    {
        InterSdk.LogInfo($"RetrieveImmediateBillingList {config.ClientId} {initialDate}-{finalDate}");
        int page = 0;
        PixBillingPage billingPage;
        var billings = new List<DetailedImmediatePixBilling>();

        do
        {
            billingPage = GetPage(config, initialDate, finalDate, page, null, filter);
            billings.AddRange(billingPage.Billings);
            page++;
        } while (page < billingPage.TotalPages);

        return billings;
    }

    /// <summary>
    /// Reviews an immediate billing based on the provided configuration and billing details.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_billing_"> The {@link PixBilling} object containing the details of the billing to be reviewed. </param>
    /// <returns> A {@link GeneratedImmediateBilling} object containing the details of the reviewed immediate billing. </returns>
    /// <exception cref="SdkException"> If there is an error during the review process, such as network issues
    ///                      or API response errors. </exception>
    public GeneratedImmediateBilling ReviewImmediateBilling(Config config, PixBilling billing)
    {
        InterSdk.LogInfo($"ReviewImmediateBilling {config.ClientId} {billing.Txid}");

        try
        {
            string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_IMMEDIATE_BILLINGS) + "/" + billing.Txid;
            string json = JsonSerializer.Serialize(billing, jsonOptions);
            json = HttpUtils.CallPatch(config, url, Constants.PIX_IMMEDIATE_BILLING_WRITE_SCOPE, "Error reviewing immediate billing", json);
            
            return JsonSerializer.Deserialize<GeneratedImmediateBilling>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a specific page of immediate billings based on the provided criteria.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> A {@link RetrieveImmediateBillingsFilter} object containing filter criteria. </param>
    /// <returns> A {@link BillingPage} object containing the requested page of immediate billings. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    private PixBillingPage GetPage(Config config, string initialDate, string finalDate, int page, int? pageSize, RetrieveImmediateBillingsFilter filter)
    {
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_IMMEDIATE_BILLINGS) + "?inicio=" + initialDate + 
                    "&fim=" + finalDate + 
                    "&paginacao.paginaAtual=" + page + 
                    (pageSize.HasValue ? "&paginacao.itensPorPagina=" + pageSize.Value : "") + 
                    AddFilters(filter);
                    
        string json = HttpUtils.CallGet(config, url, Constants.PIX_IMMEDIATE_BILLING_READ_SCOPE, "Error retrieving list of immediate billings");
        
        try
        {
            return JsonSerializer.Deserialize<PixBillingPage>(json)!;
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
    /// <param _name_="_filter_"> A {@link RetrieveImmediateBillingsFilter} object containing filter criteria. </param>
    /// <returns> A string containing the appended filter parameters for the URL. </returns>
    private string AddFilters(RetrieveImmediateBillingsFilter filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }

        var stringFilter = new StringBuilder();
        if (filter.Cpf != null)
        {
            stringFilter.Append("&cpf").Append("=").Append(filter.Cpf);
        }
        if (filter.Cnpj != null)
        {
            stringFilter.Append("&cnpj").Append("=").Append(filter.Cnpj);
        }
        if (filter.LocationPresente != null)
        {
            stringFilter.Append("&locationPresente").Append("=").Append(filter.LocationPresente);
        }
        if (filter.Status != null)
        {
            stringFilter.Append("&status").Append("=").Append(filter.Status.ToString());
        }

        return stringFilter.ToString();
    }
}
