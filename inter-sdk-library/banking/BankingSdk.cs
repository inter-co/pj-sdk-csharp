namespace inter_sdk_library;

public class BankingSdk {
    private Config config;

    private BalanceClient balanceClient;
    private BankStatementClient bankStatementClient;
    private BankingPaymentClient bankingPaymentClient;
    private BankingPixClient bankingPixClient;
    private BankingWebhookClient bankingWebhookClient;
    
    public BankingSdk(Config config) {
        this.config = config;
    }

    /// <summary>
    /// Retrieves the statement for a specific period. The maximum period between the dates is 90 days.
    /// </summary>
    /// <param _name_="_initialDate_"> Starting date for the statement query. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> Ending date for the statement query. Format: YYYY-MM-DD. </param>
    /// <returns> List of transactions. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Extrato/operation/Extrato">Consult Statement</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public BankStatement RetrieveStatement(string initialDate, string finalDate)
    {
        if (bankStatementClient == null)
        {
            bankStatementClient = new BankStatementClient();
        }

        return bankStatementClient.Retrieve(config, initialDate, finalDate);
    }

    /// <summary>
    /// Retrieves the statement in PDF format for a specific period. The maximum period between the dates is 90 days.
    /// </summary>
    /// <param _name_="_initialDate_"> Starting date for the statement export. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> Ending date for the statement export. Format: YYYY-MM-DD. </param>
    /// <param _name_="_file_"> PDF file that will be saved. </param>
    /// <see href="https://developers.inter.co/references/banking#tag/Extrato/operation/ExtratoExport">Retrieve Statement in PDF</see>
    /// <exception cref="SdkException"> If there is an error during the export process. </exception>
    public void RetrieveStatementInPdf(string initialDate, string finalDate, string file)
    {
        if (bankStatementClient == null)
        {
            bankStatementClient = new BankStatementClient();
        }

        bankStatementClient.Retrieve(config, initialDate, finalDate, file);
    }

    /// <summary>
    /// Retrieves enriched statements within a date range using the specified filters.
    /// </summary>
    /// <param _name_="_initialDate_"> Starting date for the query. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> Ending date for the query. Format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Filters for the query (optional, can be null). </param>
    /// <returns> List of enriched transactions. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Extrato/operation/ExtratoComplete">Query Enriched Statement</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public List<EnrichedTransaction> RetrieveEnrichedStatement(string initialDate, string finalDate, FilterRetrieveEnrichedStatement filter)
    {
        if (bankStatementClient == null)
        {
            bankStatementClient = new BankStatementClient();
        }

        return bankStatementClient.Retrieve(config, initialDate, finalDate, filter);
    }

    /// <summary>
    /// Retrieves enriched statements with detailed information about each transaction for a specific period. The maximum period between the dates is 90 days.
    /// </summary>
    /// <param _name_="_initialDate_"> Starting date for the statement export. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> Ending date for the statement export. Format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Filters for the query (optional, can be null). </param>
    /// <param _name_="_page_"> Page number starting from 0. </param>
    /// <returns> List of enriched transactions. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Extrato/operation/ExtratoComplete">Query Enriched Statement</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public EnrichedBankStatementPage RetrieveEnrichedStatement(string initialDate, string finalDate, FilterRetrieveEnrichedStatement filter, int page)
    {
        if (bankStatementClient == null)
        {
            bankStatementClient = new BankStatementClient();
        }

        return bankStatementClient.Retrieve(config, initialDate, finalDate, page, null, filter);
    }

    /// <summary>
    /// Retrieves enriched statements with detailed information about each transaction for a specific period. The maximum period between the dates is 90 days.
    /// </summary>
    /// <param _name_="_initialDate_"> Starting date for the statement export. Format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> Ending date for the statement export. Format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Filters for the query (optional, can be null). </param>
    /// <param _name_="_page_"> Page number starting from 0. </param>
    /// <param _name_="_pageSize_"> Size of the page, default = 50. </param>
    /// <returns> List of enriched transactions. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Extrato/operation/ExtratoComplete">Query Enriched Statement</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public EnrichedBankStatementPage RetrieveEnrichedStatement(string initialDate, string finalDate, FilterRetrieveEnrichedStatement filter, int page, int pageSize)
    {
        if (bankStatementClient == null)
        {
            bankStatementClient = new BankStatementClient();
        }

        return bankStatementClient.Retrieve(config, initialDate, finalDate, page, pageSize, filter);
    }

    /// <summary>
    /// Retrieves the balance for a specific period.
    /// </summary>
    /// <param _name_="_balanceDate_"> Date for querying the positional balance. Format: YYYY-MM-DD. </param>
    /// <returns> Object containing the account balances as of the specified date. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Saldo/operation/Saldo">Query Balance</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public Balance RetrieveBalance(string balanceDate)
    {
        if (balanceClient == null)
        {
            balanceClient = new BalanceClient();
        }

        return balanceClient.Retrieve(config, balanceDate);
    }

    /// <summary>
    /// Method for including an immediate payment or scheduling the payment of a billet, agreement, or tax with a barcode.
    /// </summary>
    /// <param _name_="_payment_"> Payment data </param>
    /// <returns> Object containing quantity of approvers, payment status, transaction code, etc. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Pagamento/operation/pagarBoleto">Include Payment with Barcode</see>
    /// <exception cref="SdkException"> If there is an error during the payment process. </exception>
    public IncludePaymentResponse IncludePayment(BilletPayment payment)
    {
        if (bankingPaymentClient == null)
        {
            bankingPaymentClient = new BankingPaymentClient();
        }

        return bankingPaymentClient.Include(config, payment);
    }

    /// <summary>
    /// Retrieves information about billets payments.
    /// </summary>
    /// <param _name_="_initialDate_"> Starting date, according to the "filterDateBy" field. Accepted format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> Ending date, according to the "filterDateBy" field. Accepted format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Filters for the query (optional, can be null). </param>
    /// <returns> List of payments. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Pagamento/operation/buscarInformacoesPagamentos">Retrieve Payments</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public List<Payment> RetrievePayment(string initialDate, string finalDate, PaymentSearchFilter filter)
    {
        if (bankingPaymentClient == null)
        {
            bankingPaymentClient = new BankingPaymentClient();
        }

        return bankingPaymentClient.Retrieve(config, initialDate, finalDate, filter);
    }

    /// <summary>
    /// Method for including an immediate DARF payment without a barcode.
    /// </summary>
    /// <param _name_="_Payment_"> Payment data </param>
    /// <returns> Object containing authentication, operation number, return type, transaction code, etc. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Pagamento/operation/pagamentosDarf">Include DARF Payment</see>
    /// <exception cref="SdkException"> If there is an error during the payment process. </exception>
    public IncludeDarfPaymentResponse IncludeDarfPayment(DarfPayment payment)
    {
        if (bankingPaymentClient == null)
        {
            bankingPaymentClient = new BankingPaymentClient();
        }

        return bankingPaymentClient.Include(config, payment);
    }

    /// <summary>
    /// Retrieves information about DARF payments.
    /// </summary>
    /// <param _name_="_initialDate_"> Starting date, according to the "filterDateBy" field. Accepted format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDate_"> Ending date, according to the "filterDateBy" field. Accepted format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Filters for the query (optional, can be null). </param>
    /// <returns> List of payments. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Pagamento/operation/buscarInformacoesPagamentoDarf">Retrieve DARF Payments</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public List<DarfPaymentResponse> RetrieveDarfPayments(string initialDate, string finalDate, DarfPaymentSearchFilter filter)
    {
        if (bankingPaymentClient == null)
        {
            bankingPaymentClient = new BankingPaymentClient();
        }

        return bankingPaymentClient.Retrieve(config, initialDate, finalDate, filter);
    }

    /// <summary>
    /// Inclusion of a batch of payments entered by the client.
    /// </summary>
    /// <param _name_="_myIdentifier_"> Identifier for the batch for the client. </param>
    /// <param _name_="_payments_"> Payments to be processed. </param>
    /// <returns> Information regarding the batch processing. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Pagamento/operation/pagamentosLote">Include Batch Payments</see>
    /// <exception cref="SdkException"> If there is an error during the batch processing. </exception>
    public IncludeBatchPaymentResponse IncludeBatchPayment(string myIdentifier, List<BatchItem> payments)
    {
        if (bankingPaymentClient == null)
        {
            bankingPaymentClient = new BankingPaymentClient();
        }

        return bankingPaymentClient.Include(config, myIdentifier, payments);
    }

    /// <summary>
    /// Retrieves a batch of payments entered by the client.
    /// </summary>
    /// <param _name_="_batchId_"> Identifier for the batch. </param>
    /// <returns> Information regarding the batch processing. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Pagamento/operation/buscarInformacoesPagamentoLote">Retrieve Batch Payments</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public BatchProcessing RetrievePaymentBatch(string batchId)
    {
        if (bankingPaymentClient == null)
        {
            bankingPaymentClient = new BankingPaymentClient();
        }

        return bankingPaymentClient.Retrieve(config, batchId);
    }

    /// <summary>
    /// Method for including a Pix payment/transfer using banking data or a key.
    /// </summary>
    /// <param _name_="_pix_"> Pix data </param>
    /// <returns> Object containing endToEndId, etc. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Pix-Pagamento/operation/realizarPagamentoPix">Include Pix</see>
    /// <exception cref="SdkException"> If there is an error during the Pix payment process. </exception>
    public IncludePixResponse IncludePix(BankingPix pix)
    {
        if (bankingPixClient == null)
        {
            bankingPixClient = new BankingPixClient();
        }

        return bankingPixClient.Include(config, pix);
    }

    /// <summary>
    /// Method for retrieving a Pix payment/transfer.
    /// </summary>
    /// <param _name_="_requestCode_"> Pix data </param>
    /// <returns> Object containing endToEndId, etc. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Pix-Pagamento/operation/consultarPagamentoPix">Include Pix</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public RetrievePixResponse RetrievePix(string requestCode)
    {
        if (bankingPixClient == null)
        {
            bankingPixClient = new BankingPixClient();
        }

        return bankingPixClient.Retrieve(config, requestCode);
    }

    /// <summary>
    /// Method intended to create a webhook to receive notifications for confirmation of Pix payments (callbacks).
    /// </summary>
    /// <param _name_="_webhookType_"> The type of webhook. </param>
    /// <param _name_="_webhookUrl_"> The client's HTTPS server URL. </param>
    /// <see href="https://developers.inter.co/references/banking#tag/Webhook/operation/putWebhookBanking">Create Webhook</see>
    /// <exception cref="SdkException"> If there is an error during the webhook creation process. </exception>
    public void IncludeWebhook(string webhookType, string webhookUrl)
    {
        if (bankingWebhookClient == null)
        {
            bankingWebhookClient = new BankingWebhookClient();
        }

        bankingWebhookClient.Include(config, webhookType, webhookUrl);
    }

    /// <summary>
    /// Retrieve the registered webhook.
    /// </summary>
    /// <param _name_="_webhookType_"> The type of webhook. </param>
    /// <returns> Webhook object. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Webhook/operation/getWebhookBanking">Retrieve Registered Webhook</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public Webhook RetrieveWebhook(string webhookType)
    {
        if (bankingWebhookClient == null)
        {
            bankingWebhookClient = new BankingWebhookClient();
        }

        return bankingWebhookClient.Retrieve(config, webhookType);
    }

    /// <summary>
    /// Deletes the webhook.
    /// </summary>
    /// <param _name_="_webhookType_"> The type of webhook to delete. </param>
    /// <see href="https://developers.inter.co/references/banking#tag/Webhook/operation/deleteWebhookBanking">Delete Webhook</see>
    /// <exception cref="SdkException"> If there is an error during the deletion process. </exception>
    public void DeleteWebhook(string webhookType)
    {
        if (bankingWebhookClient == null)
        {
            bankingWebhookClient = new BankingWebhookClient();
        }

        bankingWebhookClient.Delete(config, webhookType);
    }

    /// <summary>
    /// Retrieves a collection of callbacks for a specific period, according to the provided parameters, without pagination.
    /// </summary>
    /// <param _name_="_webhookType_"> The type of webhook. </param>
    /// <param _name_="_initialDateHour_"> Starting date, according to the "filterDateBy" field. Accepted format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDateHour_"> Ending date, according to the "filterDateBy" field. Accepted format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Filters for the query (optional, can be null). </param>
    /// <returns> List of callbacks. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Webhook/operation/callbacksFilter">Retrieve Collection of billets</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public List<RetrieveCallbackResponse> RetrieveCallback(string webhookType, string initialDateHour, string finalDateHour, CallbackRetrieveFilter filter)
    {
        if (bankingWebhookClient == null)
        {
            bankingWebhookClient = new BankingWebhookClient();
        }

        return bankingWebhookClient.Retrieve(config, webhookType, initialDateHour, finalDateHour, filter);
    }

    /// <summary>
    /// Retrieves a collection of billets for a specific period, according to the provided parameters, with pagination.
    /// </summary>
    /// <param _name_="_webhookType_"> The type of webhook. </param>
    /// <param _name_="_initialDateHour_"> Starting date, according to the "filterDateBy" field. Accepted format: YYYY-MM-DD. </param>
    /// <param _name_="_finalDateHour_"> Ending date, according to the "filterDateBy" field. Accepted format: YYYY-MM-DD. </param>
    /// <param _name_="_filter_"> Filters for the query (optional, can be null). </param>
    /// <param _name_="_page_"> Page number for pagination. </param>
    /// <param _name_="_pageSize_"> Size of the page. </param>
    /// <returns> Page with a list of billets. </returns>
    /// <see href="https://developers.inter.co/references/banking#tag/Webhook/operation/callbacksFilter">Retrieve Collection of billets</see>
    /// <exception cref="SdkException"> If there is an error during the retrieval process. </exception>
    public CallbackPage RetrieveCallback(string webhookType, string initialDateHour, string finalDateHour, CallbackRetrieveFilter filter, int page, int pageSize)
    {
        if (bankingWebhookClient == null)
        {
            bankingWebhookClient = new BankingWebhookClient();
        }

        return bankingWebhookClient.Retrieve(config, webhookType, initialDateHour, finalDateHour, page, null, filter);
    }

    /// <summary>
    /// Cancels the scheduling of a payment.
    /// </summary>
    /// <param _name_="_transactionCode_"> Unique transaction code. </param>
    /// <exception cref="SdkException"> If there is an error during the cancellation process. </exception>
    public void PaymentSchedulingCancel(string transactionCode)
    {
        if (bankingPaymentClient == null)
        {
            bankingPaymentClient = new BankingPaymentClient();
        }

        bankingPaymentClient.Cancel(config, transactionCode);
    }
}
