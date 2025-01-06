namespace inter_sdk_library;

using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Text.Json.Serialization;
public class BankingPaymentClient
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions 
    { 
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    /// <summary>
    /// Cancels a scheduled payment based on the provided transaction code.
    /// <p>
    /// This method constructs the URL to cancel the payment scheduling
    /// using the client's configuration and the transaction code. It logs 
    /// the cancellation request and handles any exceptions that may arise 
    /// during the HTTP call to the banking API.
    /// </p>
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing the client's details
    ///                        and environment settings. </param>
    /// <param _name_="_transactionCode_"> The unique code associated with the transaction 
    ///                        that is to be canceled. </param>
    /// <exception cref="SdkException"> If an error occurs during the cancellation process,
    ///                        such as issues with the HTTP request or response. </exception>
    public void Cancel(Config config, string transactionCode)
    {
        InterSdk.LogInfo($"CancelPaymentScheduling banking {config.ClientId} {transactionCode}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_PAYMENT) + "/" + transactionCode;
        HttpUtils.CallDelete(config, url, Constants.BILLET_PAYMENT_WRITE_SCOPE, "Error canceling payment scheduling");
    }

    /// <summary>
    /// Includes a list of payments in a batch using the provided configuration and identifier.
    /// <p>
    /// This method logs the inclusion operation and constructs a JSON representation
    /// of the batch payment request. It sends this request to the banking API and
    /// returns the response as an {@link IncludeBatchPaymentResponse} object.
    /// In case of errors during processing, an {@link SdkException} is thrown.
    /// </p>
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing the client's details
    ///                        and environment settings. </param>
    /// <param _name_="_myIdentifier_"> A unique identifier for the batch payment. </param>
    /// <param _name_="_payments_"> A list of {@link BatchItem} objects representing the payments
    ///                        to be included in the batch. </param>
    /// <returns> An {@link IncludeBatchPaymentResponse} object that contains
    ///                       the response from the banking API regarding the batch inclusion. </returns>
    /// <exception cref="SdkException"> If an error occurs while including the payments, such as
    ///                        issues with the HTTP request or response. </exception>
    public IncludeBatchPaymentResponse Include(Config config, string myIdentifier, List<BatchItem> payments)
    {
        InterSdk.LogInfo($"IncludeBatchPayment banking {config.ClientId} {myIdentifier} {payments.Count}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_PAYMENT_BATCH);
        
        var request = new Batch
        {
            MyIdentifier = myIdentifier,
            Payments = payments
        };

        try
        {
            string json = JsonSerializer.Serialize(request, jsonOptions);
            json = HttpUtils.CallPost(config, url, Constants.BATCH_PAYMENT_WRITE_SCOPE, "Error including payment in batch", json);
            return JsonSerializer.Deserialize<IncludeBatchPaymentResponse>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Includes a DARF payment request using the provided configuration and payment data.
    /// <p>
    /// This method logs the inclusion operation and converts the DARF payment object
    /// into a JSON string. It sends the request to the banking API and returns the
    /// response as an {@link IncludeDarfPaymentResponse} object. In the event of an
    /// error during processing, an {@link SdkException} is thrown.
    /// </p>
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing the client's details and
    ///                  environment settings. </param>
    /// <param _name_="_pagamento_"> The {@link DarfPayment} object containing the payment details
    ///                  to be included in the request. </param>
    /// <returns> An {@link IncludeDarfPaymentResponse} object that contains the
    ///                 response from the banking API regarding the DARF payment inclusion. </returns>
    /// <exception cref="SdkException"> If an error occurs while including the DARF payment, such as
    ///                      issues with the HTTP request or response. </exception>
    public IncludeDarfPaymentResponse Include(Config config, DarfPayment pagamento)
    {
        InterSdk.LogInfo($"IncludeDarfPayment banking {config.ClientId} {pagamento.RevenueCode}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_PAYMENT_DARF);
        
        try
        {
            string json = JsonSerializer.Serialize(pagamento, jsonOptions);
            json = HttpUtils.CallPost(config, url, Constants.DARF_PAYMENT_WRITE_SCOPE, "Error including DARF payment", json);
            return JsonSerializer.Deserialize<IncludeDarfPaymentResponse>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Includes a billet payment request using the provided configuration and payment data.
    /// <p>
    /// This method logs the inclusion operation and converts the billet payment object
    /// into a JSON string. It sends the request to the banking API and returns the
    /// response as an {@link IncludePaymentResponse} object. In case of errors during
    /// processing, an {@link SdkException} is thrown.
    /// </p>
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing the client's details and
    ///                 environment settings. </param>
    /// <param _name_="_payment_"> The {@link BilletPayment} object containing the payment details
    ///                 to be included in the request. </param>
    /// <returns> An {@link IncludePaymentResponse} object that contains the
    ///                response from the banking API regarding the billet payment inclusion. </returns>
    /// <exception cref="SdkException"> If an error occurs while including the billet payment, such as
    ///                      issues with the HTTP request or response. </exception>
    public IncludePaymentResponse Include(Config config, BilletPayment payment)
    {
        InterSdk.LogInfo($"IncludePayment {config.ClientId} {payment.Barcode}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_PAYMENT);

        try
        {
            string json = JsonSerializer.Serialize(payment, jsonOptions);
            json = HttpUtils.CallPost(config, url, Constants.BILLET_PAYMENT_WRITE_SCOPE, "Error including payment", json);
            return JsonSerializer.Deserialize<IncludePaymentResponse>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a list of DARF payments based on the specified date range and filters.
    /// <p>
    /// This method constructs the request URL using the client configuration, initial
    /// and final dates, and any additional filters provided. It sends the request to
    /// the banking API and returns the list of DARF payment responses.
    /// In the event of an error during processing, an {@link SdkException} is thrown.
    /// </p>
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing the client's details and
    ///                     environment settings. </param>
    /// <param _name_="_initialDate_"> The starting date for the payment retrieval in the format
    ///                     accepted by the API (e.g. "YYYY-MM-DD"). </param>
    /// <param _name_="_finalDate_"> The ending date for the payment retrieval in the same format
    ///                     as above. </param>
    /// <param _name_="_filtro_"> An optional {@link DarfPaymentSearchFilter} object that
    ///                     contains additional search criteria. </param>
    /// <returns> A list of {@link DarfPaymentResponse} objects representing
    ///                    the retrieved DARF payments. </returns>
    /// <exception cref="SdkException"> If an error occurs while retrieving the DARF payments,
    ///                      such as issues with the HTTP request or response. </exception>
    public List<DarfPaymentResponse> Retrieve(Config config, string initialDate, string finalDate, DarfPaymentSearchFilter filtro)
    {
        InterSdk.LogInfo($"RetrieveDarfPayments banking {config.ClientId} {initialDate}-{finalDate}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_PAYMENT_DARF) 
            + "?dataInicio=" + initialDate + "&dataFim=" + finalDate + AddFilters(filtro);

        string json = HttpUtils.CallGet(config, url, Constants.BILLET_PAYMENT_READ_SCOPE, "Error retrieving DARF payment");
        
        try
        {
            return JsonSerializer.Deserialize<List<DarfPaymentResponse>>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves payment batch details for a given batch ID.
    /// <p>
    /// This method logs the retrieval operation and constructs the request URL using
    /// the provided configuration and batch ID. It processes the JSON response,
    /// extracting relevant payment information and returning it as a {@link BatchProcessing} object.
    /// In case of errors during processing, an {@link SdkException} is thrown.
    /// </p>
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing the client's details and
    ///                 environment settings. </param>
    /// <param _name_="_batchId_"> The unique identifier for the batch of payments to be retrieved. </param>
    /// <returns> A {@link BatchProcessing} object that contains the details of the
    ///                payment batch along with the individual payments. </returns>
    /// <exception cref="SdkException"> If an error occurs while retrieving the payment batch, such as
    ///                      issues with the HTTP request or response. </exception>
    public BatchProcessing Retrieve(Config config, string batchId)
    {
        InterSdk.LogInfo($"RetrievePaymentBatch {config.ClientId} {batchId}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_PAYMENT_BATCH) + "/" + batchId;
        string json = HttpUtils.CallGet(config, url, Constants.BATCH_PAYMENT_READ_SCOPE, "Error to retrieve batch");

        try
        {
            var jsonLote = JsonDocument.Parse(json).RootElement;
            var payments = new List<BatchItem>();

            if (jsonLote.TryGetProperty("pagamentos", out var jsonArray))
            {
                foreach (var item in jsonArray.EnumerateArray())
                {
                    string paymentType = item.GetProperty("tipoPagamento").GetString();

                    BatchItem billetBatch = JsonSerializer.Deserialize<BatchItem>(item.GetRawText())!;
                    payments.Add(billetBatch);
                }
            }

            var batchProcessing = JsonSerializer.Deserialize<BatchProcessing>(jsonLote.ToString())!;
            batchProcessing.Payments = payments;
            return batchProcessing;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a list of payments based on the specified date range and filters.
    /// <p>
    /// This method constructs the request URL using the client configuration,
    /// initial and final dates, and any additional filters provided.
    /// It sends the request to the banking API and returns a list of
    /// {@link Payment} objects. In case of errors during processing,
    /// an {@link SdkException} is thrown.
    /// </p>
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing the client's details
    ///                     and environment settings. </param>
    /// <param _name_="_initialDate_"> The starting date for the payment retrieval in the format
    ///                     accepted by the API (e.g. "YYYY-MM-DD"). </param>
    /// <param _name_="_finalDate_"> The ending date for the payment retrieval in the same format
    ///                     as above. </param>
    /// <param _name_="_filtro_"> An optional {@link PaymentSearchFilter} object that
    ///                     contains additional search criteria. </param>
    /// <returns> A list of {@link Payment} objects representing the retrieved
    ///                    payments. </returns>
    /// <exception cref="SdkException"> If an error occurs while retrieving the payments, such as
    ///                      issues with the HTTP request or response. </exception>
    public List<Payment> Retrieve(Config config, string initialDate, string finalDate, PaymentSearchFilter filtro)
    {
        InterSdk.LogInfo($"RetrievePayments banking {config.ClientId} {initialDate}-{finalDate}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_PAYMENT) 
            + "?dataInicio=" + initialDate + "&dataFim=" + finalDate + AddFilters(filtro);

        string json = HttpUtils.CallGet(config, url, Constants.BILLET_PAYMENT_READ_SCOPE, "Error retrieving payments");
        
        try
        {
            return JsonSerializer.Deserialize<List<Payment>>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Adds filters to the request URL based on the provided {@link DarfPaymentSearchFilter}.
    /// <p>
    /// This private method builds query parameters from the filter object to be appended
    /// to the request URL. If no filters are provided, it returns an empty string.
    /// </p>
    /// </summary>
    /// <param _name_="_filtro_"> The {@link DarfPaymentSearchFilter} object containing optional filter criteria. </param>
    /// <returns> A string of query parameters representing the filters, or an empty
    ///              string if no filters are set. </returns>
    private string AddFilters(DarfPaymentSearchFilter filtro)
    {
        if (filtro == null)
        {
            return string.Empty;
        }

        var filter = new StringBuilder();
        
        if (filtro.RequestCode != null)
        {
            filter.Append("&codigoTransacao=").Append(filtro.RequestCode);
        }
        if (filtro.RevenueCode != null)
        {
            filter.Append("&codigoReceita=").Append(filtro.RevenueCode);
        }
        if (filtro.FilterDateBy != null)
        {
            filter.Append("&filtrarDataPor=").Append(filtro.FilterDateBy.ToString());
        }

        return filter.ToString();
    }

    /// <summary>
    /// Adds filters to the request URL based on the provided {@link PaymentSearchFilter}.
    /// <p>
    /// This private method builds query parameters from the filter object to be appended
    /// to the request URL. If no filters are provided, it returns an empty string.
    /// </p>
    /// </summary>
    /// <param _name_="_filter_"> The {@link PaymentSearchFilter} object containing optional filter criteria. </param>
    /// <returns> A string of query parameters representing the filters, or an empty
    ///              string if no filters are set. </returns>
    private string AddFilters(PaymentSearchFilter filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }
        
        var stringFilter = new StringBuilder();
        
        if (filter.Barcode != null)
        {
            stringFilter.Append("&codBarraLinhaDigitavel=").Append(filter.Barcode);
        }
        if (filter.TransactionCode != null)
        {
            stringFilter.Append("&codigoTransacao=").Append(filter.TransactionCode);
        }
        if (filter.FilterDateBy != null)
        {
            stringFilter.Append("&filtrarDataPor=").Append(filter.FilterDateBy.ToString());
        }
        
        return stringFilter.ToString();
    }
}
