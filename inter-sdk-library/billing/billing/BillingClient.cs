namespace inter_sdk_library;

using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;

public class BillingClient
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions 
    { 
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Cancels a billing request identified by its request code.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_requestCode_"> The unique identifier for the billing request to be canceled. </param>
    /// <param _name_="_cancellationReason_"> The reason for canceling the billing request. </param>
    /// <exception cref="SdkException"> If there is an error during the cancellation process, such as
    ///                      network issues or API response errors. </exception>
    public void CancelBilling(Config config, string requestCode, string cancellationReason)
    {
        InterSdk.LogInfo($"CancelBilling {config.ClientId} {requestCode} {cancellationReason}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING) + "/" + requestCode + "/cancelar";
        var request = new CancelBillingRequest { CancellationReason = cancellationReason };

        try
        {
            string json = JsonSerializer.Serialize(request, jsonOptions);
            HttpUtils.CallPost(config, url, Constants.BILLET_BILLING_WRITE_SCOPE, "Error canceling billing", json);
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Issues a new billing request based on the provided billing issue details.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_billingIssueRequest_"> The request object containing details for the billing to be issued. </param>
    /// <returns> A {@link BillingIssueResponse} object containing the response details from the billing issue process. </returns>
    /// <exception cref="SdkException"> If there is an error during the billing issuance process, such as network issues
    ///                      or API response errors. </exception>
    public BillingIssueResponse IssueBilling(Config config, BillingIssueRequest billingIssueRequest)
    {
        InterSdk.LogInfo($"IssueBilling {config.ClientId} {billingIssueRequest.YourNumber}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING);
        
        try
        {
            string json = JsonSerializer.Serialize(billingIssueRequest, jsonOptions );
            json = HttpUtils.CallPost(config, url, Constants.BILLET_BILLING_WRITE_SCOPE, "Error issuing billing", json);
            return JsonSerializer.Deserialize<BillingIssueResponse>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves billing details based on the provided request code.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_requestCode_"> The unique identifier for the billing request to be retrieved. </param>
    /// <returns> A {@link RetrievedBilling} object containing the details of the requested billing. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as
    ///                      network issues or API response errors. </exception>
    public RetrievedBilling RetrieveBilling(Config config, string requestCode)
    {
        InterSdk.LogInfo($"RetrieveIssue {config.ClientId} requestCode={requestCode}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING) + "/" + requestCode;
        string json = HttpUtils.CallGet(config, url, Constants.BILLET_BILLING_READ_SCOPE, "Error retrieving billing");
        
        try
        {
            return JsonSerializer.Deserialize<RetrievedBilling>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a page of billing records based on the specified parameters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> Optional filters to be applied to the billing retrieval. </param>
    /// <param _name_="_sort_"> Optional sorting criteria for the billing retrieval. </param>
    /// <returns> A {@link BillingPage} object containing the requested page of billing records. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public BillingPage RetrieveBillingPage(Config config, string initialDate, string finalDate, int page, int? pageSize, BillingRetrievalFilter filter, Sorting sort)
    {
        InterSdk.LogInfo($"RetrieveBillingCollection {config.ClientId} {initialDate}-{finalDate}");
        return GetPage(config, initialDate, finalDate, page, pageSize, filter, sort);
    }

    /// <summary>
    /// Retrieves all billing records within the specified date range, applying the given filters and sorting.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_filter_"> Optional filters to be applied to the billing retrieval. </param>
    /// <param _name_="_sort_"> Optional sorting criteria for the billing retrieval. </param>
    /// <returns> A list of {@link RetrievedBilling} objects containing all billing records
    /// within the specified date range. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public List<RetrievedBillingCollectionUnit> RetrieveBillingInRange(Config config, string initialDate, string finalDate, BillingRetrievalFilter filter, Sorting sort)
    {
        InterSdk.LogInfo($"RetrieveBillingCollection {config.ClientId} {initialDate}-{finalDate}");
        int page = 0;
        BillingPage billingPage;
        var billing = new List<RetrievedBillingCollectionUnit>();

        do
        {
            billingPage = GetPage(config, initialDate, finalDate, page, null, filter, sort);
            billing.AddRange(billingPage.Billings);
            page++;
        } while (page < billingPage.TotalPages);

        return billing;
    }

    /// <summary>
    /// Retrieves the billing PDF identified by the provided request code and saves it to a specified file.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_requestCode_"> The unique identifier for the billing request whose PDF is to be retrieved. </param>
    /// <param _name_="_file_"> The file path where the PDF document will be saved. </param>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public void RetrieveBillingInPdf(Config config, string requestCode, string file)
    {
        InterSdk.LogInfo($"RetrieveBillingPdf {config.ClientId} requestCode={requestCode}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING) + "/" + requestCode + "/pdf";
        string json = HttpUtils.CallGet(config, url, Constants.BILLET_BILLING_READ_SCOPE, "Error retrieving billing pdf");
        PdfReturn pdfReturn = JsonSerializer.Deserialize<PdfReturn>(json)!;
        SdkUtils.WritePdf(pdfReturn.Pdf, file);
    }

    /// <summary>
    /// Retrieves a summary of billing records within a specified date range and optional filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_filter_"> Optional filters to be applied to the billing summary retrieval. </param>
    /// <returns> A {@link Summary} object containing the billing summary details. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public Summary RetrieveBillingSummary(Config config, string initialDate, string finalDate, BillingRetrievalFilter filter)
    {
        InterSdk.LogInfo($"RetrieveBillingSummary {config.ClientId} {initialDate}-{finalDate}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING_SUMMARY)
            + "?dataInicial=" + initialDate
            + "&dataFinal=" + finalDate
            + AddFilters(filter);
        
        string json = HttpUtils.CallGet(config, url, Constants.BILLET_BILLING_READ_SCOPE, "Error retrieving billing summary");
        
        try
        {
            return JsonSerializer.Deserialize<Summary>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a specific page of billing records based on the specified parameters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> Optional filters to be applied to the billing retrieval. </param>
    /// <param _name_="_sort_"> Optional sorting criteria for the billing retrieval. </param>
    /// <returns> A {@link BillingPage} object containing the requested page of billing records. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    private BillingPage GetPage(Config config, string initialDate, string finalDate, int page, int? pageSize, BillingRetrievalFilter filter, Sorting sort)
    {
        string url = UrlUtils.BuildUrl(config, Constants.URL_BILLING)
            + "?dataInicial=" + initialDate
            + "&dataFinal=" + finalDate
            + "&paginacao.paginaAtual=" + page
            + (pageSize.HasValue ? "&paginacao.itensPorPagina=" + pageSize.Value : "")
            + AddFilters(filter)
            + AddSort(sort);
        
        string json = HttpUtils.CallGet(config, url, Constants.BILLET_BILLING_READ_SCOPE, "Error retrieving billing collection");
        
        try
        {
            return JsonSerializer.Deserialize<BillingPage>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Constructs the query string for filters to be applied when retrieving billing records.
    /// </summary>
    /// <param _name_="_filter_"> The filter object containing filtering criteria. </param>
    /// <returns> A query string that can be appended to the URL for filtering. </returns>
    private string AddFilters(BillingRetrievalFilter filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }

        var stringFilter = new StringBuilder();

        if (filter.FilterDateBy != null)
        {
            stringFilter.Append("&filtrarDataPor=").Append(filter.FilterDateBy.ToString());
        }
        if (filter.Situation != null)
        {
            stringFilter.Append("&situacao=").Append(filter.Situation.ToString());
        }
        if (filter.Payer != null)
        {
            stringFilter.Append("&pessoaPagadora=").Append(filter.Payer);
        }
        if (filter.PayerCpfCnpj != null)
        {
            stringFilter.Append("&cpfCnpjPessoaPagadora=").Append(filter.PayerCpfCnpj);
        }
        if (filter.YourNumber != null)
        {
            stringFilter.Append("&seuNumero=").Append(filter.YourNumber);
        }
        if (filter.BillingType != null)
        {
            stringFilter.Append("&tipoCobranca=").Append(filter.BillingType);
        }

        return stringFilter.ToString();
    }

    /// <summary>
    /// Constructs the query string for sorting to be applied when retrieving billing records.
    /// </summary>
    /// <param _name_="_sort_"> The sorting object containing sorting criteria. </param>
    /// <returns> A query string that can be appended to the URL for sorting. </returns>
    private string AddSort(Sorting sort)
    {
        if (sort == null)
        {
            return string.Empty;
        }

        var order = new StringBuilder();

        if (sort.OrderBy != null)
        {
            order.Append("&ordenarPor=").Append(sort.OrderBy.ToString());
        }
        if (sort.SortType != null)
        {
            order.Append("&tipoOrdenacao=").Append(sort.SortType.ToString());
        }

        return order.ToString();
    }
}

