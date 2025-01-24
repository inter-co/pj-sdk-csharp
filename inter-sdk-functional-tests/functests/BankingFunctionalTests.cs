using inter_sdk_library;

namespace inter_sdk_functional_tests;

public class BankingFunctionalTests
{
    private static BankingSdk bankingSdk;

    public BankingFunctionalTests(InterSdk interSdk) {
        bankingSdk = interSdk.Banking();
    }

    public void TestBankingStatement()
    {
        Console.WriteLine("Retrieving statement...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DD)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DD)");

        BankStatement statement = bankingSdk.RetrieveStatement(initialDate, finalDate);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(statement, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingStatementPdf()
    {
        Console.WriteLine("Retrieving statement in pdf...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DD)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DD)");
        string file = "statement.pdf";

        bankingSdk.RetrieveStatementInPdf(initialDate, finalDate, file);
        Console.WriteLine("Generated file: " + file);
    }

    public void TestBankingEnrichedStatement()
    {
        Console.WriteLine("Retrieving enriched statement...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DD)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DD)");
        FilterRetrieveEnrichedStatement filter = new FilterRetrieveEnrichedStatement
        {
            OperationType = OperationType.C
        };

        List<EnrichedTransaction> enrichedTransactions = bankingSdk.RetrieveEnrichedStatementInRange(initialDate, finalDate, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(enrichedTransactions, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingEnrichedStatementPage()
    {
        Console.WriteLine("Retrieving enriched statement page...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DD)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DD)");
        FilterRetrieveEnrichedStatement filter = new FilterRetrieveEnrichedStatement
        {
            OperationType = OperationType.C
        };
        int page = 0;

        EnrichedBankStatementPage enrichedTransactions = bankingSdk.RetrieveEnrichedStatementPage(initialDate, finalDate, filter, page);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(enrichedTransactions, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingBalance()
    {
        Console.WriteLine("Retrieving balance...");
        string balanceDate = null;
        
        Balance balance = bankingSdk.RetrieveBalance(balanceDate);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(balance, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingIncludePayment()
    {
        Console.WriteLine("Include payment:");

        string barCode = FuncTestUtils.GetString("barCode");
        decimal value = FuncTestUtils.GetBigDecimal("value(99.99)");
        string dueDate = FuncTestUtils.GetString("dueDate(YYYY-MM-DD)");

        BilletPayment payment = new BilletPayment
        {
            Barcode = barCode,
            AmountToPay = value,
            DueDate = dueDate
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(payment, Newtonsoft.Json.Formatting.Indented));

        IncludePaymentResponse paymentResponse = bankingSdk.IncludePayment(payment);
        Console.WriteLine("Response: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(paymentResponse, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingCancelPayment()
    {
        Console.WriteLine("Cancel payment:");

        string requestCode = FuncTestUtils.GetString("requestCode");

        bankingSdk.PaymentSchedulingCancel(requestCode);

        Console.WriteLine("Payment canceled.");
    }

    public void TestBankingRetrievePaymentList()
    {
        Console.WriteLine("Retrieving payment list...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DD)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DD)");
        PaymentSearchFilter filter = new PaymentSearchFilter
        {
            FilterDateBy = PaymentDateType.PAGAMENTO
        };

        List<Payment> payments = bankingSdk.RetrievePaymentsInRange(initialDate, finalDate, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(payments, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingIncludeDarfPayment()
    {
        Console.WriteLine("Include DARF payment:");

        string document = FuncTestUtils.GetString("document");
        string codigoReceita = FuncTestUtils.GetString("codigoReceita");
        string dueDate = FuncTestUtils.GetString("dueDate(YYYY-MM-DD)");
        string description = FuncTestUtils.GetString("description");
        string enterprise = FuncTestUtils.GetString("enterprise");
        string calculationPeriod = FuncTestUtils.GetString("calculationPeriod(YYYY-MM-DD)");
        string principalValue = FuncTestUtils.GetString("principalValue(99.99)");
        string reference = FuncTestUtils.GetString("reference");

        DarfPayment darfPayment = new DarfPayment
        {
            CnpjOrCpf = document,
            RevenueCode = codigoReceita,
            DueDate = dueDate,
            Description = description,
            EnterpriseName = enterprise,
            AssessmentPeriod = calculationPeriod,
            PrincipalValue = principalValue,
            Reference = reference
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(darfPayment, Newtonsoft.Json.Formatting.Indented));

        IncludeDarfPaymentResponse darfPaymentResponse = bankingSdk.IncludeDarfPayment(darfPayment);
        Console.WriteLine("Response: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(darfPaymentResponse, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingRetrieveDarfPayment()
    {
        Console.WriteLine("Retrieving DARF payment...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DD)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DD)");
        DarfPaymentSearchFilter filter = new DarfPaymentSearchFilter
        {
            FilterDateBy = DarfPaymentDateType.PAGAMENTO
        };

        List<DarfPaymentResponse> retrieveDarfPayments = bankingSdk.RetrieveDarfPaymentsInRange(initialDate, finalDate, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieveDarfPayments, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingIncludePaymentBatch()
    {
        Console.WriteLine("Include batch of payments:");

        // Billet payment
        Console.WriteLine("Billet payment: ");
        string barCode = FuncTestUtils.GetString("barCode");
        decimal billetValue = FuncTestUtils.GetBigDecimal("billetValue");
        string billetDueDate = FuncTestUtils.GetString("billetDueDate(YYYY-MM-DD)");

        // DARF payment
        Console.WriteLine("DARF payment: ");
        string document = FuncTestUtils.GetString("document(cpf)");
        string codigoReceita = FuncTestUtils.GetString("codigoReceita");
        string dafDueDate = FuncTestUtils.GetString("darfDueDate(YYYY-MM-DD)");
        string description = FuncTestUtils.GetString("description");
        string enterprise = FuncTestUtils.GetString("enterprise");
        string calculationPeriod = FuncTestUtils.GetString("calculationPeriod");
        string darfValue = FuncTestUtils.GetString("darfValue(99.99)");
        string reference = FuncTestUtils.GetString("reference");
        string myIdentifier = FuncTestUtils.GetString("batch identifier");

        BatchItem billetBatch = new BatchItem
        {
            PaymentType = "BOLETO",
            Barcode = barCode,
            AmountToPay = billetValue,
            DueDate = billetDueDate
        };

        BatchItem darfBatch = new BatchItem
        {
            PaymentType = "DARF",
            CnpjOrCpf = document,
            RevenueCode = codigoReceita,
            DueDate = dafDueDate,
            Description = description,
            EnterpriseName = enterprise,
            AssessmentPeriod = calculationPeriod,
            PrincipalValue = darfValue,
            Reference = reference
        };

        List<BatchItem> payments = new List<BatchItem> { billetBatch, darfBatch };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(payments, Newtonsoft.Json.Formatting.Indented));

        IncludeBatchPaymentResponse batchPaymentResponse = bankingSdk.IncludeBatchPayment(myIdentifier, payments);
        Console.WriteLine("Response: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(batchPaymentResponse, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingRetrievePaymentBatch()
    {
        Console.WriteLine("Retrieving batch of payments...");

        string batchId = FuncTestUtils.GetString("batchId");

        BatchProcessing batchProcessing = bankingSdk.RetrievePaymentBatch(batchId);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(batchProcessing, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingIncludePix()
    {
        Console.WriteLine("Include pix:");

        string key = FuncTestUtils.GetString("key");
        string value = FuncTestUtils.GetString("value(99.99)");

        Recipient recipient = new Recipient
        {
            Type = "CHAVE",
            KeyValue = key
        };

        BankingPix pix = new BankingPix
        {
            Amount = value,
            Recipient = recipient
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(pix, Newtonsoft.Json.Formatting.Indented));

        IncludePixResponse includePixResponse = bankingSdk.IncludePix(pix);
        Console.WriteLine("Response: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(includePixResponse, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingRetrievePix()
    {
        Console.WriteLine("Retrieving pix...");

        string requestCode = FuncTestUtils.GetString("requestCode");

        RetrievePixResponse retrievePixResponse = bankingSdk.RetrievePix(requestCode);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrievePixResponse, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingIncludeWebhook()
    {
        Console.WriteLine("Include webhook:");

        string webhookType = FuncTestUtils.GetString("webhookType (pix-pagamento,boleto-pagamento)");
        string webhookUrl = FuncTestUtils.GetString("webhookUrl");

        bankingSdk.IncludeWebhook(webhookType, webhookUrl);
        Console.WriteLine("Webhook included.");
    }

    public void TestBankingRetrieveWebhook()
    {
        Console.WriteLine("Retrieving webhook...");

        string webhookType = FuncTestUtils.GetString("webhookType (pix-pagamento,boleto-pagamento)");

        Webhook webhook = bankingSdk.RetrieveWebhook(webhookType);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(webhook, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingDeleteWebhook()
    {
        Console.WriteLine("Deleting webhook...");

        string webhookType = FuncTestUtils.GetString("webhookType (pix-pagamento,boleto-pagamento)");

        bankingSdk.DeleteWebhook(webhookType);
        Console.WriteLine("Webhook deleted.");
    }

    public void TestBankingRetrieveCallbacks()
    {
        Console.WriteLine("Retrieving callbacks...");

        string webhookType = FuncTestUtils.GetString("webhookType (pix-pagamento,boleto-pagamento)");
        string initialDateHour = FuncTestUtils.GetString("initialDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDateHour = FuncTestUtils.GetString("finalDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        CallbackRetrieveFilter filter = new CallbackRetrieveFilter();

        List<RetrieveCallbackResponse> callbacks = bankingSdk.RetrieveCallbackInRange(webhookType, initialDateHour, finalDateHour, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(callbacks, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBankingRetrieveCallback()
    {
        Console.WriteLine("Retrieving callback...");

        string webhookType = FuncTestUtils.GetString("webhookType (pix-pagamento,boleto-pagamento)");
        string initialDateHour = FuncTestUtils.GetString("initialDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDateHour = FuncTestUtils.GetString("finalDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        CallbackRetrieveFilter filter = new CallbackRetrieveFilter();
        int page = 0;
        int pageSize = 10;

        CallbackPage callbacks = bankingSdk.RetrieveCallbacksPage(webhookType, initialDateHour, finalDateHour, filter, page, pageSize);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(callbacks, Newtonsoft.Json.Formatting.Indented));
    }
}
