using inter_sdk_library;

namespace inter_sdk_functional_tests;

public class BankingMenu
{
    private const int RETRIEVE_STATEMENT = 1;
    private const int RETRIEVE_STATEMENT_PDF = 2;
    private const int RETRIEVE_ENRICHED_STATEMENT = 3;
    private const int RETRIEVE_ENRICHED_STATEMENT_PAGINATION = 4;
    private const int RETRIEVE_BALANCE = 5;
    private const int INCLUDE_PAYMENT = 6;
    private const int SEARCH_PAYMENTS = 7;
    private const int INCLUDE_DARF_PAYMENT = 8;
    private const int SEARCH_DARF_PAYMENTS = 9;
    private const int INCLUDE_PAYMENT_BATCH = 10;
    private const int SEARCH_PAYMENT_BATCH = 11;
    private const int CANCEL_SCHEDULING = 12;
    private const int INCLUDE_PIX_KEY = 13;
    private const int GET_PIX = 14;
    private const int CREATE_WEBHOOK = 15;
    private const int GET_WEBHOOK = 16;
    private const int DELETE_WEBHOOK = 17;
    private const int RETRIEVE_CALLBACKS = 18;
    private const int RETRIEVE_CALLBACKS_PAGINATION = 19;

    public static int ShowMenu(string environment)
    {
        Console.WriteLine("ENVIRONMENT " + environment);
        Console.WriteLine(RETRIEVE_STATEMENT + " - Retrieve Bank Statement");
        Console.WriteLine(RETRIEVE_STATEMENT_PDF + " - Retrieve Bank Statement PDF");
        Console.WriteLine(RETRIEVE_ENRICHED_STATEMENT + " - Retrieve Enriched Bank Statement");
        Console.WriteLine(RETRIEVE_ENRICHED_STATEMENT_PAGINATION + " - Retrieve Enriched Bank Statement with pagination");
        Console.WriteLine(RETRIEVE_BALANCE + " - Retrieve Balance (current day)");
        Console.WriteLine(INCLUDE_PAYMENT + " - Include Payment for billet");
        Console.WriteLine(SEARCH_PAYMENTS + " - Search Payments for billet");
        Console.WriteLine(INCLUDE_DARF_PAYMENT + " - Include DARF Payment");
        Console.WriteLine(SEARCH_DARF_PAYMENTS + " - Search DARF Payments");
        Console.WriteLine(INCLUDE_PAYMENT_BATCH + " - Include Payments in Batch");
        Console.WriteLine(SEARCH_PAYMENT_BATCH + " - Search Payment Batch");
        Console.WriteLine(CANCEL_SCHEDULING + " - Cancel payment scheduling");
        Console.WriteLine(INCLUDE_PIX_KEY + " - Include Pix payment by Key");
        Console.WriteLine(GET_PIX + " - Get Pix payment details");
        Console.WriteLine(CREATE_WEBHOOK + " - Create Webhook");
        Console.WriteLine(GET_WEBHOOK + " - Get Webhook");
        Console.WriteLine(DELETE_WEBHOOK + " - Delete Webhook");
        Console.WriteLine(RETRIEVE_CALLBACKS + " - Retrieve callbacks");
        Console.WriteLine(RETRIEVE_CALLBACKS_PAGINATION + " - Retrieve callbacks with pagination");
        Console.WriteLine("0 - Exit");
        Console.Write("=> ");

        try
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        catch (FormatException)
        {
            Console.WriteLine("invalid option");
            return ShowMenu(environment);
        }
    }

    public static void Execute(int op, InterSdk interSdk)
    {
        BankingFunctionalTests bankingFunctionalTests = new BankingFunctionalTests(interSdk);
        
        switch (op)
        {
            case RETRIEVE_STATEMENT:
                bankingFunctionalTests.TestBankingStatement();
                break;
            case RETRIEVE_STATEMENT_PDF:
                bankingFunctionalTests.TestBankingStatementPdf();
                break;
            case RETRIEVE_ENRICHED_STATEMENT:
                bankingFunctionalTests.TestBankingEnrichedStatement();
                break;
            case RETRIEVE_ENRICHED_STATEMENT_PAGINATION:
                bankingFunctionalTests.TestBankingEnrichedStatementPage();
                break;
            case RETRIEVE_BALANCE:
                bankingFunctionalTests.TestBankingBalance();
                break;
            case INCLUDE_PAYMENT:
                bankingFunctionalTests.TestBankingIncludePayment();
                break;
            case SEARCH_PAYMENTS:
                bankingFunctionalTests.TestBankingRetrievePaymentList();
                break;
            case INCLUDE_DARF_PAYMENT:
                bankingFunctionalTests.TestBankingIncludeDarfPayment();
                break;
            case SEARCH_DARF_PAYMENTS:
                bankingFunctionalTests.TestBankingRetrieveDarfPayment();
                break;
            case INCLUDE_PAYMENT_BATCH:
                bankingFunctionalTests.TestBankingIncludePaymentBatch();
                break;
            case CANCEL_SCHEDULING:
                bankingFunctionalTests.TestBankingCancelPayment();
                break;
            case SEARCH_PAYMENT_BATCH:
                bankingFunctionalTests.TestBankingRetrievePaymentBatch();
                break;
            case INCLUDE_PIX_KEY:
                bankingFunctionalTests.TestBankingIncludePix();
                break;
            case GET_PIX:
                bankingFunctionalTests.TestBankingRetrievePix();
                break;
            case CREATE_WEBHOOK:
                bankingFunctionalTests.TestBankingIncludeWebhook();
                break;
            case GET_WEBHOOK:
                bankingFunctionalTests.TestBankingRetrieveWebhook();
                break;
            case DELETE_WEBHOOK:
                bankingFunctionalTests.TestBankingDeleteWebhook();
                break;
            case RETRIEVE_CALLBACKS:
                bankingFunctionalTests.TestBankingRetrieveCallbacks();
                break;
            case RETRIEVE_CALLBACKS_PAGINATION:
                bankingFunctionalTests.TestBankingRetrieveCallback();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
        
        Console.WriteLine();
    }
}
