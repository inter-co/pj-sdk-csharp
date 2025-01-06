using inter_sdk_library;

namespace inter_sdk_functional_tests;

public class BillingMenu
{
    private const int ISSUE_BILLING = 1;
    private const int RETRIEVE_BILLINGS = 2;
    private const int RETRIEVE_BILLING_PAGINATION = 3;
    private const int RETRIEVE_BILLING_SUMMARY = 4;
    private const int RETRIEVE_DETAILED_BILLING = 5;
    private const int RETRIEVE_BILLING_PDF = 6;
    private const int CANCEL_BILLING = 7;
    private const int CREATE_WEBHOOK = 8;
    private const int GET_WEBHOOK = 9;
    private const int DELETE_WEBHOOK = 10;
    private const int RETRIEVE_CALLBACKS = 11;
    private const int RETRIEVE_CALLBACKS_PAGINATION = 12;

    public static int ShowMenu(string environment)
    {
        Console.WriteLine("ENVIRONMENT " + environment);
        Console.WriteLine(ISSUE_BILLING + " - Issue Billing");
        Console.WriteLine(RETRIEVE_BILLINGS + " - Retrieve Billings");
        Console.WriteLine(RETRIEVE_BILLING_PAGINATION + " - Retrieve Billing with pagination");
        Console.WriteLine(RETRIEVE_BILLING_SUMMARY + " - Retrieve Billing Summary");
        Console.WriteLine(RETRIEVE_DETAILED_BILLING + " - Retrieve Detailed Billing");
        Console.WriteLine(RETRIEVE_BILLING_PDF + " - Retrieve Billing PDF");
        Console.WriteLine(CANCEL_BILLING + " - Cancel Billing");
        Console.WriteLine(CREATE_WEBHOOK + " - Create Webhook");
        Console.WriteLine(GET_WEBHOOK + " - Get Webhook");
        Console.WriteLine(DELETE_WEBHOOK + " - Delete Webhook");
        Console.WriteLine(RETRIEVE_CALLBACKS + " - Retrieve callbacks");
        Console.WriteLine(RETRIEVE_CALLBACKS_PAGINATION + " - Retrieve callbacks with pagination");
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
        BillingFunctionalTests billingFunctionalTests = new BillingFunctionalTests(interSdk);
        
        switch (op)
        {
            case ISSUE_BILLING:
                billingFunctionalTests.TestBillingIssueBilling();
                break;
            case RETRIEVE_BILLINGS:
                billingFunctionalTests.TestBillingRetrieveBillingCollection();
                break;
            case RETRIEVE_BILLING_PAGINATION:
                billingFunctionalTests.TestBillingRetrieveBillingCollectionPage();
                break;
            case RETRIEVE_BILLING_SUMMARY:
                billingFunctionalTests.TestBillingRetrieveBillingSummary();
                break;
            case RETRIEVE_DETAILED_BILLING:
                billingFunctionalTests.TestBillingRetrieveBilling();
                break;
            case RETRIEVE_BILLING_PDF:
                billingFunctionalTests.TestBillingRetrieveBillingPdf();
                break;
            case CANCEL_BILLING:
                billingFunctionalTests.TestBillingCancelBilling();
                break;
            case CREATE_WEBHOOK:
                billingFunctionalTests.TestBillingIncludeWebhook();
                break;
            case GET_WEBHOOK:
                billingFunctionalTests.TestBillingRetrieveWebhook();
                break;
            case DELETE_WEBHOOK:
                billingFunctionalTests.TestBillingDeleteWebhook();
                break;
            case RETRIEVE_CALLBACKS:
                billingFunctionalTests.TestBillingRetrieveCallbacks();
                break;
            case RETRIEVE_CALLBACKS_PAGINATION:
                billingFunctionalTests.TestBillingRetrieveCallbacksPage();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
        
        Console.WriteLine();
    }
}
