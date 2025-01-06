using inter_sdk_library;

namespace inter_sdk_functional_tests;

public class PixFunctionalTests
{
    private static PixSdk pixSdk;

    public PixFunctionalTests(InterSdk interSdk) {
        pixSdk = interSdk.Pix();
    }

    public void TestPixIncludeDueBilling()
    {
        Console.WriteLine("Include due billing:");

        string document = FuncTestUtils.GetString("cnpj");
        string name = FuncTestUtils.GetString("name");
        string city = FuncTestUtils.GetString("city");
        string street = FuncTestUtils.GetString("street");
        string cep = FuncTestUtils.GetString("cep");
        string email = FuncTestUtils.GetString("email");
        string state = FuncTestUtils.GetString("state").ToUpper();
        string value = FuncTestUtils.GetString("value(99.99)");
        string key = FuncTestUtils.GetString("key");
        string txId = FuncTestUtils.GetString("txId");
        string dueDate = FuncTestUtils.GetString("dueDate (yyyy-MM-dd)");
        string validity = FuncTestUtils.GetString("validity (days)");

        Debtor debtor = new Debtor
        {
            Cnpj = document,
            Name = name,
            City = city,
            Address = street,
            PostalCode = cep,
            State = state,
            Email = email
        };

        int validityAfterExpiration = int.Parse(validity);

        DueBillingValue dueBillingValue = new DueBillingValue
        {
            OriginalValue = value
        };

        DueBillingCalendar calendar = new DueBillingCalendar
        {
            DueDate = dueDate,
            ValidityAfterExpiration = validityAfterExpiration
        };

        DueBilling dueBilling = new DueBilling
        {
            Debtor = debtor,
            Value = dueBillingValue,
            Key = key,
            Calendar = calendar
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(dueBilling, Newtonsoft.Json.Formatting.Indented));

        GeneratedDueBilling generatedDueBilling = pixSdk.IncludeDuePixBilling(txId, dueBilling);
        Console.WriteLine("Response: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(generatedDueBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveDueBilling()
    {
        Console.WriteLine("Retrieving due billing:");

        string txId = FuncTestUtils.GetString("txId");

        DetailedDuePixBilling detailedDuePixBilling = pixSdk.RetrieveDuePixBilling(txId);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(detailedDuePixBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveDueBillingCollection()
    {
        Console.WriteLine("Retrieving due billing collection:");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        RetrieveDueBillingFilter retrieveDueBillingFilter = new RetrieveDueBillingFilter(); // Inicializador de objeto

        List<DetailedDuePixBilling> duePixBillingList = pixSdk.RetrieveBillingCollection(initialDate, finalDate, retrieveDueBillingFilter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(duePixBillingList, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveDueBillingCollectionPage()
    {
        Console.WriteLine("Retrieving due billing collection page:");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        RetrieveDueBillingFilter retrieveDueBillingFilter = new RetrieveDueBillingFilter(); // Inicializador de objeto
        int page = 0;
        int pageSize = 10;

        DueBillingPage dueBillingPage = pixSdk.RetrieveBillingCollection(initialDate, finalDate, page, pageSize, retrieveDueBillingFilter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dueBillingPage, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixReviewDueBilling()
    {
        Console.WriteLine("Review due billing:");

        string txId = FuncTestUtils.GetString("txId");

        string document = FuncTestUtils.GetString("cnpj");
        string name = FuncTestUtils.GetString("debtor name");
        string value = FuncTestUtils.GetString("value(99.99)");

        Debtor debtor = new Debtor
        {
            Cnpj = document,
            Name = name
        };

        DueBillingValue dueBillingValue = new DueBillingValue
        {
            OriginalValue = value
        };

        DueBilling dueBilling = new DueBilling
        {
            Debtor = debtor,
            Value = dueBillingValue
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(dueBilling, Newtonsoft.Json.Formatting.Indented));

        GeneratedDueBilling generatedDueBilling = pixSdk.ReviewDuePixBilling(txId, dueBilling);
        Console.WriteLine("Response: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(generatedDueBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixIncludeDueBillingBatch()
    {
        Console.WriteLine("Include due billing batch:");

        string batchDescription = FuncTestUtils.GetString("batch description");
        string batchId = FuncTestUtils.GetString("batchId");

        string document = FuncTestUtils.GetString("cnpj");
        string name = FuncTestUtils.GetString("debtor name");

        string firstTxId = FuncTestUtils.GetString("First billing txId");
        string firstValue = FuncTestUtils.GetString("First billing value(99.99)");
        string firstKey = FuncTestUtils.GetString("First billing key");
        DueBillingValue firstDueBillingValue = new DueBillingValue
        {
            OriginalValue = firstValue
        };

        DueBillingCalendar firstCalendar = new DueBillingCalendar
        {
            DueDate = FuncTestUtils.GetString("First billing dueDate (yyyy-MM-dd)")
        };

        string secondTxId = FuncTestUtils.GetString("Second billing txId");
        string secondValue = FuncTestUtils.GetString("Second billing value(99.99)");
        string secondKey = FuncTestUtils.GetString("Second billing key");
        DueBillingValue secondDueBillingValue = new DueBillingValue
        {
            OriginalValue = secondValue
        };

        DueBillingCalendar secondCalendar = new DueBillingCalendar
        {
            DueDate = FuncTestUtils.GetString("Second billing dueDate (yyyy-MM-dd)")
        };

        Debtor debtor = new Debtor
        {
            Cnpj = document,
            Name = name
        };

        DueBilling dueBilling1 = new DueBilling
        {
            Txid = firstTxId,
            Calendar = firstCalendar,
            Debtor = debtor,
            Value = firstDueBillingValue,
            Key = firstKey
        };

        DueBilling dueBilling2 = new DueBilling
        {
            Txid = secondTxId,
            Calendar = secondCalendar,
            Debtor = debtor,
            Value = secondDueBillingValue,
            Key = secondKey
        };

        List<DueBilling> list = new List<DueBilling>
        {
            dueBilling1,
            dueBilling2
        };

        IncludeDueBillingBatchRequest batch = new IncludeDueBillingBatchRequest
        {
            Description = batchDescription,
            DueBillings = list
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(batch, Newtonsoft.Json.Formatting.Indented));

        pixSdk.IncludeDueBillingBatch(batchId, batch);
        Console.WriteLine("Batch included: " + batchId);
    }

    public void TestPixRetrieveDueBillingBatch()
    {
        Console.WriteLine("Retrieving due billing batch...");

        string batchId = FuncTestUtils.GetString("batchId");

        DueBillingBatch dueBillingBatch = pixSdk.RetrieveDueBillingBatch(batchId);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dueBillingBatch, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveDueBillingBatchCollectionPage()
    {
        Console.WriteLine("Retrieving due billing batch collection...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        int page = 0;
        int pageSize = 10;

        DueBillingBatchPage dueBillingBatchPage = pixSdk.RetrieveDueBillingBatchCollection(initialDate, finalDate, page, pageSize);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dueBillingBatchPage, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveDueBillingBatchCollection()
    {
        Console.WriteLine("Retrieving due billing batch collection...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");

        List<DueBillingBatch> dueBillingBatchCollection = pixSdk.RetrieveDueBillingBatchCollection(initialDate, finalDate);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dueBillingBatchCollection, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveDueBillingBatchBySituation()
    {
        Console.WriteLine("Retrieving due billing batch by situation...");

        string batchId = FuncTestUtils.GetString("batchId");
        string situation = FuncTestUtils.GetString("batch situation: (EM_PROCESSAMENTO, CRIADA, NEGADA)");

        DueBillingBatch dueBillingBatch = pixSdk.RetrieveDueBillingBatchBySituation(batchId, situation);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dueBillingBatch, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveDueBillingBatchSummary()
    {
        Console.WriteLine("Retrieving due billing batch summary...");

        string batchId = FuncTestUtils.GetString("batchId");

        DueBillingBatchSummary dueBillingBatchSummary = pixSdk.RetrieveDueBillingBatchSummary(batchId);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dueBillingBatchSummary, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixReviewDueBillingBatch()
    {
        Console.WriteLine("Reviewing due billing batch...");

        string batchDescription = FuncTestUtils.GetString("batch description");
        string batchId = FuncTestUtils.GetString("batchId");

        string document = FuncTestUtils.GetString("cnpj");
        string name = FuncTestUtils.GetString("debtor name");

        string firstTxId = FuncTestUtils.GetString("First billing txId");
        string firstValue = FuncTestUtils.GetString("First billing value(99.99)");
        string firstKey = FuncTestUtils.GetString("First billing key");
        DueBillingValue firstDueBillingValue = new DueBillingValue
        {
            OriginalValue = firstValue
        };
        
        DueBillingCalendar firstCalendar = new DueBillingCalendar
        {
            DueDate = FuncTestUtils.GetString("First billing dueDate (yyyy-MM-dd)")
        };

        string secondTxId = FuncTestUtils.GetString("Second billing txId");
        string secondValue = FuncTestUtils.GetString("Second billing value(99.99)");
        string secondKey = FuncTestUtils.GetString("Second billing key");
        DueBillingValue secondDueBillingValue = new DueBillingValue
        {
            OriginalValue = secondValue
        };

        DueBillingCalendar secondCalendar = new DueBillingCalendar
        {
            DueDate = FuncTestUtils.GetString("Second billing dueDate (yyyy-MM-dd)")
        };

        Debtor debtor = new Debtor
        {
            Cnpj = document,
            Name = name
        };

        DueBilling dueBilling1 = new DueBilling
        {
            Txid = firstTxId,
            Calendar = firstCalendar,
            Debtor = debtor,
            Value = firstDueBillingValue,
            Key = firstKey
        };

        DueBilling dueBilling2 = new DueBilling
        {
            Txid = secondTxId,
            Calendar = secondCalendar,
            Debtor = debtor,
            Value = secondDueBillingValue,
            Key = secondKey
        };

        List<DueBilling> list = new List<DueBilling>
        {
            dueBilling1,
            dueBilling2
        };

        IncludeDueBillingBatchRequest batch = new IncludeDueBillingBatchRequest
        {
            Description = batchDescription,
            DueBillings = list
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(batch, Newtonsoft.Json.Formatting.Indented));

        pixSdk.ReviewDueBillingBatch(batchId, batch);
        Console.WriteLine("Due billing batch reviewed.");
    }

    public void TestPixIncludeImmediateBilling()
    {
        Console.WriteLine("Include immediate billing:");

        string document = FuncTestUtils.GetString("cnpj");
        string name = FuncTestUtils.GetString("name");
        string value = FuncTestUtils.GetString("value(99.99)");
        string key = FuncTestUtils.GetString("key");
        int expiration = 86400;

        Debtor debtor = new Debtor
        {
            Cnpj = document,
            Name = name
        };

        PixValue pixValue = new PixValue
        {
            Original = value
        };

        Calendar calendar = new Calendar
        {
            Expiration = expiration
        };

        PixBilling pixBilling = new PixBilling
        {
            Debtor = debtor,
            Value = pixValue,
            Key = key,
            Calendar = calendar
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(pixBilling, Newtonsoft.Json.Formatting.Indented));

        GeneratedImmediateBilling generatedImmediateBilling = pixSdk.IncludeImmediateBilling(pixBilling);
        Console.WriteLine("Response: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(generatedImmediateBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixIncludeImmediateBillingTxId()
    {
        Console.WriteLine("Include immediate billing:");

        string txId = FuncTestUtils.GetString("txId");
        string document = FuncTestUtils.GetString("cnpj");
        string name = FuncTestUtils.GetString("name");
        string value = FuncTestUtils.GetString("value(99.99)");
        string key = FuncTestUtils.GetString("key");
        int expiration = 86400;

        Debtor debtor = new Debtor
        {
            Cnpj = document,
            Name = name
        };

        PixValue pixValue = new PixValue
        {
            Original = value
        };

        Calendar calendar = new Calendar
        {
            Expiration = expiration
        };

        PixBilling pixBilling = new PixBilling
        {
            Txid = txId,
            Debtor = debtor,
            Value = pixValue,
            Key = key,
            Calendar = calendar
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(pixBilling, Newtonsoft.Json.Formatting.Indented));

        GeneratedImmediateBilling generatedImmediateBilling = pixSdk.IncludeImmediateBilling(pixBilling);
        Console.WriteLine("Response: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(generatedImmediateBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveImmediateBilling()
    {
        Console.WriteLine("Retrieving immediate billing...");

        string txId = FuncTestUtils.GetString("txId");

        DetailedImmediatePixBilling detailedImmediatePixBilling = pixSdk.RetrieveImmediateBilling(txId);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(detailedImmediatePixBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveImmediateBillingCollection()
    {
        Console.WriteLine("Retrieving immediate billing list...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        RetrieveImmediateBillingsFilter filter = new RetrieveImmediateBillingsFilter(); // Inicializador de objeto

        List<DetailedImmediatePixBilling> detailedImmediatePixBilling = pixSdk.RetrieveImmediateBillingList(initialDate, finalDate, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(detailedImmediatePixBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveImmediateBillingCollectionPage()
    {
        Console.WriteLine("Retrieving immediate billing list...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        RetrieveImmediateBillingsFilter filter = new RetrieveImmediateBillingsFilter(); // Inicializador de objeto
        int page = 0;
        int pageSize = 10;

        PixBillingPage detailedImmediatePixBilling = pixSdk.RetrieveImmediateBillingList(initialDate, finalDate, page, pageSize, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(detailedImmediatePixBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixReviewImmediateBilling()
    {
        Console.WriteLine("Review immediate billing list:");

        string txId = FuncTestUtils.GetString("txId");
        string document = FuncTestUtils.GetString("cnpj");
        string name = FuncTestUtils.GetString("name");
        string value = FuncTestUtils.GetString("value(99.99)");
        string key = FuncTestUtils.GetString("key");
        int expiration = 86400;

        Debtor debtor = new Debtor
        {
            Cnpj = document,
            Name = name
        };

        PixValue pixValue = new PixValue
        {
            Original = value
        };

        Calendar calendar = new Calendar
        {
            Expiration = expiration
        };

        PixBilling pixBilling = new PixBilling
        {
            Txid = txId,
            Debtor = debtor,
            Value = pixValue,
            Key = key,
            Calendar = calendar
        };

        Console.WriteLine("Request: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(pixBilling, Newtonsoft.Json.Formatting.Indented));

        GeneratedImmediateBilling generatedImmediateBilling = pixSdk.ReviewImmediateBilling(pixBilling);
        Console.WriteLine("Response: \n" + Newtonsoft.Json.JsonConvert.SerializeObject(generatedImmediateBilling, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixIncludeLocation()
    {
        Console.WriteLine("Including location...");

        string cobType = ImmediateBillingType.cob;

        Location location = pixSdk.IncludeLocation(cobType);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(location, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveLocation()
    {
        Console.WriteLine("Retrieving location...");

        string locationId = FuncTestUtils.GetString("locationId");

        Location location = pixSdk.RetrieveLocation(locationId);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(location, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveLocationList()
    {
        Console.WriteLine("Retrieving location list...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        RetrieveLocationFilter filter = new RetrieveLocationFilter();

        List<Location> location = pixSdk.RetrieveLocationsList(initialDate, finalDate, filter);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(location, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveLocationListPage()
    {
        Console.WriteLine("Retrieving location list page...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        RetrieveLocationFilter filter = new RetrieveLocationFilter();
        int page = 0;
        int pageSize = 10;

        LocationPage locationPage = pixSdk.RetrieveLocationsList(initialDate, finalDate, page, pageSize, filter);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(locationPage, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixUnlinkLocation()
    {
        Console.WriteLine("Unlink location:");

        string locationId = FuncTestUtils.GetString("locationId");

        Location location = pixSdk.UnlinkLocation(locationId);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(location, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRequestDevolution()
    {
        Console.WriteLine("Request devolution:");

        string e2eId = FuncTestUtils.GetString("e2eId");
        string devolutionIdentifier = FuncTestUtils.GetString("devolutionIdentifier");
        string value = FuncTestUtils.GetString("value(99.99)");
        string description = FuncTestUtils.GetString("description");
        string devolutionNature = DevolutionNature.ORIGINAL;

        DevolutionRequestBody devolution = new DevolutionRequestBody
        {
            Value = value,
            Nature = devolutionNature,
            Description = description
        };

        DetailedDevolution detailedDevolution = pixSdk.RequestDevolution(e2eId, devolutionIdentifier, devolution);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(detailedDevolution, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrieveDevolution()
    {
        Console.WriteLine("Retrieving devolution...");

        string e2eId = FuncTestUtils.GetString("e2eId");
        string devolutionIdentifier = FuncTestUtils.GetString("devolutionIdentifier");

        DetailedDevolution detailedDevolution = pixSdk.RetrieveDevolution(e2eId, devolutionIdentifier);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(detailedDevolution, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrievePixList()
    {
        Console.WriteLine("Retrieving pix list...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        RetrievedPixFilter filter = new RetrievedPixFilter();

        List<Pix> detailedDevolution = pixSdk.RetrievePixList(initialDate, finalDate, filter);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(detailedDevolution, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrievePixListPage()
    {
        Console.WriteLine("Retrieving pix list page...");

        string initialDate = FuncTestUtils.GetString("initialDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDate = FuncTestUtils.GetString("finalDate(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        RetrievedPixFilter filter = new RetrievedPixFilter(); // Inicializador de objeto
        int page = 0;
        int pageList = 10;

        PixPage pix = pixSdk.RetrievePixList(initialDate, finalDate, page, pageList, filter);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(pix, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestPixRetrievePix()
    {
        Console.WriteLine("Retrieving pix...");

        string e2eId = FuncTestUtils.GetString("e2eId");

        Pix pix = pixSdk.RetrievePix(e2eId);

        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(pix, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingRetrieveCallbacks()
    {
        Console.WriteLine("Retrieving callbacks...");

        string initialDateHour = FuncTestUtils.GetString("initialDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDateHour = FuncTestUtils.GetString("finalDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        PixCallbackRetrieveFilter filter = new PixCallbackRetrieveFilter();

        List<RetrieveCallbackResponse> callbacks = pixSdk.RetrieveCallbacks(initialDateHour, finalDateHour, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(callbacks, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingRetrieveCallbacksPage()
    {
        Console.WriteLine("Retrieving callback page...");

        string initialDateHour = FuncTestUtils.GetString("initialDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        string finalDateHour = FuncTestUtils.GetString("finalDateHour(YYYY-MM-DDTHH:MM:SSZ ex:2022-04-01T10:30:00Z)");
        PixCallbackRetrieveFilter filter = new PixCallbackRetrieveFilter();
        int page = 0;
        int pageSize = 10;

        PixCallbackPage callbacks = pixSdk.RetrieveCallbacks(initialDateHour, finalDateHour, page, pageSize, filter);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(callbacks, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingIncludeWebhook()
    {
        Console.WriteLine("Include webhook:");

        string webhookUrl = FuncTestUtils.GetString("webhookUrl");
        string key = FuncTestUtils.GetString("key");

        pixSdk.IncludeWebhook(key, webhookUrl);
        Console.WriteLine("Webhook included.");
    }

    public void TestBillingRetrieveWebhook()
    {
        Console.WriteLine("Retrieving webhook...");

        string key = FuncTestUtils.GetString("key");

        Webhook webhook = pixSdk.RetrieveWebhook(key);
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(webhook, Newtonsoft.Json.Formatting.Indented));
    }

    public void TestBillingDeleteWebhook()
    {
        Console.WriteLine("Deleting webhook...");

        string key = FuncTestUtils.GetString("key");

        pixSdk.DeleteWebhook(key);
        Console.WriteLine("Webhook deleted.");
    }
}
