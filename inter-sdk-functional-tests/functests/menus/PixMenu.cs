using inter_sdk_library;

namespace inter_sdk_functional_tests;

public class PixMenu
{
    private const int CREATE_IMMEDIATE_BILLING = 1;
    private const int CREATE_IMMEDIATE_BILLING_TXID = 2;
    private const int REVIEW_IMMEDIATE_BILLING = 3;
    private const int RETRIEVE_IMMEDIATE_BILLING = 4;
    private const int RETRIEVE_IMMEDIATE_BILLINGS = 5;
    private const int RETRIEVE_IMMEDIATE_BILLINGS_PAGINATION = 6;
    private const int CREATE_DUE_BILLING = 7;
    private const int REVIEW_DUE_BILLING = 8;
    private const int RETRIEVE_DUE_BILLING = 9;
    private const int RETRIEVE_DUE_BILLINGS = 10;
    private const int RETRIEVE_DUE_BILLINGS_PAGINATION = 11;
    private const int CREATE_LOCATION = 12;
    private const int RETRIEVE_LOCATION = 13;
    private const int UNLINK_LOCATION = 14;
    private const int RETRIEVE_REGISTERED_LOCATIONS = 15;
    private const int RETRIEVE_REGISTERED_LOCATIONS_PAGINATION = 16;
    private const int RETRIEVE_PIX = 17;
    private const int RETRIEVE_RECEIVED_PIX = 18;
    private const int RETRIEVE_RECEIVED_PIX_PAGINATION = 19;
    private const int REQUEST_PIX_DEVOLUTION = 20;
    private const int RETRIEVE_PIX_DEVOLUTION = 21;
    private const int CREATE_WEBHOOK = 22;
    private const int GET_WEBHOOK = 23;
    private const int DELETE_WEBHOOK = 24;
    private const int RETRIEVE_CALLBACKS = 25;
    private const int RETRIEVE_CALLBACKS_PAGINATION = 26;
    private const int RETRIEVE_DUE_BILLING_BATCH = 27;
    private const int RETRIEVE_DUE_BILLING_BATCH_PAGINATION = 28;
    private const int RETRIEVE_DUE_BILLING_BATCHES = 29;
    private const int RETRIEVE_DUE_BILLING_BATCH_SUMMARY = 30;
    private const int RETRIEVE_DUE_BILLING_BATCH_SITUATION = 31;
    private const int CREATE_DUE_BILLING_BATCH = 32;
    private const int REVIEW_DUE_BILLING_BATCH = 33;

    public static int ShowMenu(string environment)
    {
        Console.WriteLine("ENVIRONMENT " + environment);
        Console.WriteLine(CREATE_IMMEDIATE_BILLING + " - Create Immediate Billing");
        Console.WriteLine(CREATE_IMMEDIATE_BILLING_TXID + " - Create Immediate Billing TxId");
        Console.WriteLine(REVIEW_IMMEDIATE_BILLING + " - Review Immediate Billing");
        Console.WriteLine(RETRIEVE_IMMEDIATE_BILLING + " - Retrieve Immediate Billing by TxId");
        Console.WriteLine(RETRIEVE_IMMEDIATE_BILLINGS + " - Retrieve Immediate Billings");
        Console.WriteLine(RETRIEVE_IMMEDIATE_BILLINGS_PAGINATION + " - Retrieve Immediate Billings with pagination");
        Console.WriteLine(CREATE_DUE_BILLING + " - Create Due Billing");
        Console.WriteLine(REVIEW_DUE_BILLING + " - Review Due Billing");
        Console.WriteLine(RETRIEVE_DUE_BILLING + " - Retrieve Due Billing by TxId");
        Console.WriteLine(RETRIEVE_DUE_BILLINGS + " - Retrieve Due Billings");
        Console.WriteLine(RETRIEVE_DUE_BILLINGS_PAGINATION + " - Retrieve Due Billings with pagination");
        Console.WriteLine(CREATE_LOCATION + " - Create Location");
        Console.WriteLine(RETRIEVE_LOCATION + " - Retrieve Location");
        Console.WriteLine(UNLINK_LOCATION + " - Unlink Location");
        Console.WriteLine(RETRIEVE_REGISTERED_LOCATIONS + " - Retrieve Registered Locations");
        Console.WriteLine(RETRIEVE_REGISTERED_LOCATIONS_PAGINATION + " - Retrieve Registered Locations with pagination");
        Console.WriteLine(RETRIEVE_PIX + " - Retrieve Pix by e2eId");
        Console.WriteLine(RETRIEVE_RECEIVED_PIX + " - Retrieve Received Pix");
        Console.WriteLine(RETRIEVE_RECEIVED_PIX_PAGINATION + " - Retrieve Received Pix with pagination");
        Console.WriteLine(REQUEST_PIX_DEVOLUTION + " - Request Devolution");
        Console.WriteLine(RETRIEVE_PIX_DEVOLUTION + " - Retrieve Devolution");
        Console.WriteLine(CREATE_WEBHOOK + " - Create Webhook");
        Console.WriteLine(GET_WEBHOOK + " - Get Webhook");
        Console.WriteLine(DELETE_WEBHOOK + " - Delete Webhook");
        Console.WriteLine(RETRIEVE_CALLBACKS + " - Retrieve callbacks");
        Console.WriteLine(RETRIEVE_CALLBACKS_PAGINATION + " - Retrieve callbacks with pagination");
        Console.WriteLine(RETRIEVE_DUE_BILLING_BATCH + " - Retrieve Due Billing Batch");
        Console.WriteLine(RETRIEVE_DUE_BILLING_BATCH_PAGINATION + " - Retrieve Due Billing Batch - Pagination");
        Console.WriteLine(RETRIEVE_DUE_BILLING_BATCHES + " - Retrieve Due Billing Batches");
        Console.WriteLine(RETRIEVE_DUE_BILLING_BATCH_SUMMARY + " - Retrieve Due Billing Batch - Summary");
        Console.WriteLine(RETRIEVE_DUE_BILLING_BATCH_SITUATION + " - Retrieve Due Billing Batch - Situation");
        Console.WriteLine(CREATE_DUE_BILLING_BATCH + " - Create Due Billing Batch");
        Console.WriteLine(REVIEW_DUE_BILLING_BATCH + " - Review Due Billing Batch");
        Console.WriteLine("0 - Exit");
        Console.Write("=> ");

        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid option");
            return ShowMenu(environment);
        }
    }

    public static void Execute(int op, InterSdk interSdk)
    {
        PixFunctionalTests pixFunctionalTests = new PixFunctionalTests(interSdk);
        switch (op)
        {
            case CREATE_IMMEDIATE_BILLING:
                pixFunctionalTests.TestPixIncludeImmediateBilling();
                break;
            case REVIEW_IMMEDIATE_BILLING:
                pixFunctionalTests.TestPixReviewImmediateBilling();
                break;
            case RETRIEVE_IMMEDIATE_BILLING:
                pixFunctionalTests.TestPixRetrieveImmediateBilling();
                break;
            case CREATE_IMMEDIATE_BILLING_TXID:
                pixFunctionalTests.TestPixIncludeImmediateBillingTxId();
                break;
            case RETRIEVE_IMMEDIATE_BILLINGS:
                pixFunctionalTests.TestPixRetrieveImmediateBillingCollection();
                break;
            case RETRIEVE_IMMEDIATE_BILLINGS_PAGINATION:
                pixFunctionalTests.TestPixRetrieveImmediateBillingCollectionPage();
                break;
            case CREATE_DUE_BILLING:
                pixFunctionalTests.TestPixIncludeDueBilling();
                break;
            case REVIEW_DUE_BILLING:
                pixFunctionalTests.TestPixReviewDueBilling();
                break;
            case RETRIEVE_DUE_BILLING:
                pixFunctionalTests.TestPixRetrieveDueBilling();
                break;
            case RETRIEVE_DUE_BILLINGS:
                pixFunctionalTests.TestPixRetrieveDueBillingCollection();
                break;
            case RETRIEVE_DUE_BILLINGS_PAGINATION:
                pixFunctionalTests.TestPixRetrieveDueBillingCollectionPage();
                break;
            case CREATE_LOCATION:
                pixFunctionalTests.TestPixIncludeLocation();
                break;
            case RETRIEVE_REGISTERED_LOCATIONS:
                pixFunctionalTests.TestPixRetrieveLocationList();
                break;
            case RETRIEVE_REGISTERED_LOCATIONS_PAGINATION:
                pixFunctionalTests.TestPixRetrieveLocationListPage();
                break;
            case RETRIEVE_LOCATION:
                pixFunctionalTests.TestPixRetrieveLocation();
                break;
            case UNLINK_LOCATION:
                pixFunctionalTests.TestPixUnlinkLocation();
                break;
            case RETRIEVE_PIX:
                pixFunctionalTests.TestPixRetrievePix();
                break;
            case RETRIEVE_RECEIVED_PIX:
                pixFunctionalTests.TestPixRetrievePixList();
                break;
            case RETRIEVE_RECEIVED_PIX_PAGINATION:
                pixFunctionalTests.TestPixRetrievePixListPage();
                break;
            case REQUEST_PIX_DEVOLUTION:
                pixFunctionalTests.TestPixRequestDevolution();
                break;
            case RETRIEVE_PIX_DEVOLUTION:
                pixFunctionalTests.TestPixRetrieveDevolution();
                break;
            case CREATE_WEBHOOK:
                pixFunctionalTests.TestBillingIncludeWebhook();
                break;
            case GET_WEBHOOK:
                pixFunctionalTests.TestBillingRetrieveWebhook();
                break;
            case DELETE_WEBHOOK:
                pixFunctionalTests.TestBillingDeleteWebhook();
                break;
            case RETRIEVE_CALLBACKS:
                pixFunctionalTests.TestBillingRetrieveCallbacks();
                break;
            case RETRIEVE_CALLBACKS_PAGINATION:
                pixFunctionalTests.TestBillingRetrieveCallbacksPage();
                break;
            case RETRIEVE_DUE_BILLING_BATCH:
                pixFunctionalTests.TestPixRetrieveDueBillingBatch();
                break;
            case RETRIEVE_DUE_BILLING_BATCH_PAGINATION:
                pixFunctionalTests.TestPixRetrieveDueBillingBatchCollectionPage();
                break;
            case RETRIEVE_DUE_BILLING_BATCHES:
                pixFunctionalTests.TestPixRetrieveDueBillingBatchCollection();
                break;
            case RETRIEVE_DUE_BILLING_BATCH_SUMMARY:
                pixFunctionalTests.TestPixRetrieveDueBillingBatchSummary();
                break;
            case RETRIEVE_DUE_BILLING_BATCH_SITUATION:
                pixFunctionalTests.TestPixRetrieveDueBillingBatchBySituation();
                break;
            case CREATE_DUE_BILLING_BATCH:
                pixFunctionalTests.TestPixIncludeDueBillingBatch();
                break;
            case REVIEW_DUE_BILLING_BATCH:
                pixFunctionalTests.TestPixReviewDueBillingBatch();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
        Console.WriteLine();
    }
}
