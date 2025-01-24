using inter_sdk_library;

namespace inter_sdk_functional_tests;

public class BillingFunctionalTests
{
    private static BillingSdk billingSdk;

    public BillingFunctionalTests(InterSdk interSdk) {
        billingSdk = interSdk.Billing();
    }

    public void TestBillingIssueBilling()
    {
        Console.WriteLine("Include billing:");

        string personType = PersonType.FISICA;

        string yourNumber = FuncTestUtils.GetString("yourNumber");
        string dueDate = FuncTestUtils.GetString("dueDate(YYYY-MM-DD)");
        decimal value = FuncTestUtils.GetBigDecimal("value(99.99)");

        Console.WriteLine("Payer data:");
        string document = FuncTestUtils.GetString("cpf");
        string name = FuncTestUtils.GetString("name");
        string street = FuncTestUtils.GetString("street");
        string city = FuncTestUtils.GetString("city");
        string state = FuncTestUtils.GetString("state").ToUpper();
        string cep = FuncTestUtils.GetString("cep");

        Person payer = new Person
        {
            CpfCnpj = document,
            PersonType = personType,
            Name = name,
            Address = street,
            City = city,
            State = state,
            ZipCode = cep
        };

        BillingIssueRequest billing = new BillingIssueRequest
        {
            YourNumber = yourNumber,
            NominalValue = value,
            DueDate = dueDate,
            ScheduledDays = 0,
            Payer = payer
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(billing, Newtonsoft.Json.Formatting.Indented));

        BillingIssueResponse billingIssueResponse = billingSdk.IssueBilling(billing);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(billingIssueResponse, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingCancelBilling()
    {
        Console.WriteLine("Cancel billing:");

        string requestCode = FuncTestUtils.GetString("requestCode");
        string cancellationReason = FuncTestUtils.GetString("cancellationReason");

        billingSdk.CancelBilling(requestCode, cancellationReason);
        Console.WriteLine("Billing canceled.");
    }

    public void TestBillingRetrieveBilling()
    {
        Console.WriteLine("Retrieving billing...");

        string requestCode = FuncTestUtils.GetString("requestCode");

        RetrievedBilling retrieveBilling = billingSdk.RetrieveBilling(requestCode);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieveBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingRetrieveBillingCollection()
    {
        Console.WriteLine("Retrieving billing collection...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DD)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DD)");
        BillingRetrievalFilter billingRetrievalFilter = new BillingRetrievalFilter();
        Sorting sorting = new Sorting();

        List<RetrievedBillingCollectionUnit> retrieveBilling = billingSdk.RetrieveBillingCollectionInRange(initialDate, finalDate, billingRetrievalFilter, sorting);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieveBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingRetrieveBillingCollectionPage()
    {
        Console.WriteLine("Retrieving billing collection page...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DD)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DD)");
        BillingRetrievalFilter billingRetrievalFilter = new BillingRetrievalFilter();
        int page = 0;
        int pageSize = 10;
        Sorting sorting = new Sorting();

        BillingPage retrieveBilling = billingSdk.RetrieveBillingCollectionPage(initialDate, finalDate, page, pageSize, billingRetrievalFilter, sorting);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieveBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingRetrieveBillingPdf()
    {
        Console.WriteLine("Retrieving billing in pdf...");

        string requestCode = FuncTestUtils.GetString("requestCode");
        string file = "file_" + requestCode + ".pdf";

        billingSdk.RetrieveBillingPdf(requestCode, file);
        Console.WriteLine("Generated file: " + file);
    }

    public void TestBillingRetrieveBillingSummary()
    {
        Console.WriteLine("Retrieving billing summary...");

        string initialDate = FuncTestUtils.GetString("initialDate");
        string finalDate = FuncTestUtils.GetString("finalDate");
        BillingRetrievalFilter billingRetrievalFilter = new BillingRetrievalFilter();

        Summary summary = billingSdk.RetrieveBillingSummary(initialDate, finalDate, billingRetrievalFilter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(summary, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingRetrieveCallbacks()
    {
        Console.WriteLine("Retrieving callbacks...");

        string initialDateHour = FuncTestUtils.GetString("initialDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDateHour = FuncTestUtils.GetString("finalDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        BillingRetrieveCallbacksFilter filter = new BillingRetrieveCallbacksFilter();

        List<BillingRetrieveCallbackResponse> callbacks = billingSdk.RetrieveCallbacksInRange(initialDateHour, finalDateHour, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(callbacks, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingRetrieveCallbacksPage()
    {
        Console.WriteLine("Retrieving callback page...");

        string initialDateHour = FuncTestUtils.GetString("initialDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDateHour = FuncTestUtils.GetString("finalDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        BillingRetrieveCallbacksFilter filter = new BillingRetrieveCallbacksFilter();
        int page = 0;
        int pageSize = 10;

        BillingCallbackPage callbacks = billingSdk.RetrieveCallbacksPage(initialDateHour, finalDateHour, page, pageSize, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(callbacks, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingIncludeWebhook()
    {
        Console.WriteLine("Include webhook:");

        string webhookUrl = FuncTestUtils.GetString("webhookUrl");

        billingSdk.IncludeWebhook(webhookUrl);
        Console.WriteLine("Webhook included.");
    }

    public void TestBillingRetrieveWebhook()
    {
        Console.WriteLine("Retrieving webhook...");

        Webhook webhook = billingSdk.RetrieveWebhook();
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(webhook, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingDeleteWebhook()
    {
        Console.WriteLine("Deleting webhook...");

        billingSdk.DeleteWebhook();
        Console.WriteLine("Webhook deleted.");
    }
}
