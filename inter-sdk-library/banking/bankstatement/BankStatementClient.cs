namespace inter_sdk_library;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
public class BankStatementClient
{
    /// <summary>
    /// Retrieves the bank statement for a specified date range.
    /// </summary>
    /// <param name="config"> The configuration object containing necessary parameters such as client ID. </param>
    /// <param name="initialDate"> The start date for the bank statement period, formatted as a string. </param>
    /// <param name="finalDate"> The end date for the bank statement period, formatted as a string. </param>
    /// <returns> A <see cref="BankStatement"/> object containing the statement details. </returns>
    /// <exception cref="SdkException"> If an error occurs during the retrieval of the statement or if an error
    /// occurs during the JSON parsing. </exception>
    public BankStatement RetrieveStatement(Config config, string initialDate, string finalDate)
    {
        InterSdk.LogInfo($"RetrieveBankStatement {config.ClientId} {initialDate}-{finalDate}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_STATEMENT) + "?dataInicio=" + initialDate + "&dataFim=" + finalDate;
        string json = HttpUtils.CallGet(config, url, Constants.READ_BALANCE_SCOPE, "Error retrieving statement");
        try
        {
            return JsonSerializer.Deserialize<BankStatement>(json)!;
        }
        catch (SdkException exception)
        {
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }
    /// <summary>
    /// Retrieves the bank statement in PDF format for a specified date range and saves it to sa file.
    /// </summary>
    /// <param name="config"> The configuration object containing necessary parameters such as client ID. </param>
    /// <param name="initialDate"> The start date for the bank statement period, formatted as a string. </param>
    /// <param name="finalDate"> The end date for the bank statement period, formatted as a string. </param>
    /// <param name="file"> The path where the PDF file will be saved. </param>
    /// <exception cref="SdkException"> If an error occurs during the retrieval of the statement or if an error
    /// occurs during the PDF decoding or file writing process. </exception>
    public void RetrieveStatementInPdf(Config config, string initialDate, string finalDate, string file)
    {
        InterSdk.LogInfo($"RetrieveBankStatementInPdf {config.ClientId} {initialDate}-{finalDate}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_STATEMENT_PDF) + "?dataInicio=" + initialDate + "&dataFim=" + finalDate;
        string json = HttpUtils.CallGet(config, url, Constants.READ_BALANCE_SCOPE, "Error retrieving statement in pdf");
        try
        {
            PdfReturn pdfReturn = JsonSerializer.Deserialize<PdfReturn>(json)!;
            byte[] decodedBytes = Convert.FromBase64String(pdfReturn.Pdf);
            using (FileStream stream = new FileStream(file, FileMode.Create))
            {
                stream.Write(decodedBytes, 0, decodedBytes.Length);
            }
        }
        catch (SdkException exception)
        {
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }
    /// <summary>
    /// Retrieves a specific page of enriched bank statements within a given date range.
    /// </summary>
    /// <param name="config"> The configuration object containing client information. </param>
    /// <param name="initialDate"> The start date of the statement range (inclusive). </param>
    /// <param name="finalDate"> The end date of the statement range (inclusive). </param>
    /// <param name="page"> The page number to retrieve. </param>
    /// <param name="pageSize"> The number of items per page (optional). </param>
    /// <param name="filter"> Optional filters for retrieving enriched bank statements. </param>
    /// <returns> An <see cref="EnrichedBankStatementPage"/> containing the requested page of enriched statements. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public EnrichedBankStatementPage RetrieveEnrichedStatementPage(Config config, string initialDate, string finalDate, int page, int? pageSize, FilterRetrieveEnrichedStatement filter)
    {
        InterSdk.LogInfo($"RetrieveEnrichedBankStatement {config.ClientId} {initialDate} - {finalDate}");
        return GetPage(config, initialDate, finalDate, page, pageSize, filter);
    }
    /// <summary>
    /// Retrieves a list of enriched transactions within a given date range.
    /// </summary>
    /// <param name="config"> The configuration object containing client information. </param>
    /// <param name="initialDate"> The start date of the statement range (inclusive). </param>
    /// <param name="finalDate"> The end date of the statement range (inclusive). </param>
    /// <param name="filter"> Optional filters for retrieving enriched bank statements. </param>
    /// <returns> A list of <see cref="EnrichedTransaction"/> representing all transactions within the date range. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public List<EnrichedTransaction> RetrieveStatementInRange(Config config, string initialDate, string finalDate, FilterRetrieveEnrichedStatement filter)
    {
        InterSdk.LogInfo($"RetrieveEnrichedBankStatement {config.ClientId} {initialDate} - {finalDate}");
        int page = 0;
        EnrichedBankStatementPage transactionPage;
        List<EnrichedTransaction> transactions = new List<EnrichedTransaction>();
        do
        {
            transactionPage = GetPage(config, initialDate, finalDate, page, null, filter);
            transactions.AddRange(transactionPage.Transactions);
            page++;
        } while (page < transactionPage.TotalPages);
        return transactions;
    }
    /// <summary>
    /// Retrieves a page of enriched bank statements based on the provided parameters.
    /// </summary>
    /// <param name="config"> The configuration object containing client information. </param>
    /// <param name="initialDate"> The start date of the statement range (inclusive). </param>
    /// <param name="finalDate"> The end date of the statement range (inclusive). </param>
    /// <param name="page"> The page number to retrieve. </param>
    /// <param name="pageSize"> The number of items per page (optional). </param>
    /// <param name="filter"> Optional filters for retrieving enriched bank statements. </param>
    /// <returns> An <see cref="EnrichedBankStatementPage"/> containing the requested page of enriched statements. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    private EnrichedBankStatementPage GetPage(Config config, string initialDate, string finalDate, int page, int? pageSize, FilterRetrieveEnrichedStatement filter)
    {
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_ENRICHED_STATEMENT)
            + "?dataInicio=" + initialDate
            + "&dataFim=" + finalDate
            + "&pagina=" + page
            + (pageSize != null ? "&tamanhoPagina=" + pageSize : "")
            + AddFilters(filter);
        string json = HttpUtils.CallGet(config, url, Constants.READ_BALANCE_SCOPE, "Error retrieving enriched statement");
        try
        {
            return JsonSerializer.Deserialize<EnrichedBankStatementPage>(json)!;
        }
        catch (SdkException exception)
        {
InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }
    /// <summary>
    /// Constructs the query string for filters to be applied when retrieving enriched bank statements.
    /// </summary>
    /// <param name="filter"> The filter object containing filtering criteria. </param>
    /// <returns> A query string that can be appended to the URL for filtering. </returns>
    private string AddFilters(FilterRetrieveEnrichedStatement filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }
        var stringFilter = new StringBuilder();
        if (filter.OperationType != null)
        {
            stringFilter.Append("&tipoOperacao").Append("=").Append(filter.OperationType.ToString());
        }
        if (filter.TransactionType != null)
        {
            stringFilter.Append("&tipoTransacao").Append("=").Append(filter.TransactionType.ToString());
        }
        return stringFilter.ToString();
    }
}