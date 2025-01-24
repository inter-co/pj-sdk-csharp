using inter_sdk_library;

namespace inter_sdk_functional_tests;

public class FunctionalTestRunner
{
    public static void Main(string[] args)
    {
        try
        {
            string environment = FuncTestUtils.GetString("Environment (PRODUCTION, SANDBOX)");

            ValidateEnvironment(environment);

            InterSdk interSdk = GetInterSdkData(environment);
            int op;

            while ((op = Menu(environment)) != 0)
            {
                try
                {
                    switch (op)
                    {
                        case 1:
                            while ((op = BillingMenu.ShowMenu(environment)) != 0)
                            {
                                BillingMenu.Execute(op, interSdk);
                            }
                            break;
                        case 2:
                            while ((op = BankingMenu.ShowMenu(environment)) != 0)
                            {
                                BankingMenu.Execute(op, interSdk);
                            }
                            break;
                        case 3:
                            while ((op = PixMenu.ShowMenu(environment)) != 0)
                            {
                                PixMenu.Execute(op, interSdk);
                            }
                            break;
                    }
                }
                catch (SdkException e)
                {
                    Error error = e.Error;
                    Console.WriteLine("An error occurred: ");
                    Console.WriteLine(error.Title);
                    Console.WriteLine(error.Detail);
                    if (!string.IsNullOrEmpty(error.Message)) {
                        Console.WriteLine(error.Message);
                    }
                    PrintViolations(error.Violations);
                }
            }
        }
        catch (SdkException e)
        {
            Console.WriteLine("An error occurred: "); 
            Console.WriteLine(e.Message);
        }
    }
    private static void ValidateEnvironment(string environment)
    {
        var environments = new List<string> { "PRODUCTION", "SANDBOX", "UAT" };

        if (!environments.Contains(environment))
        {   
            throw new InvalidEnvironmentException();
        }
    }

    private static InterSdk GetInterSdkData(string environment)
    {
        string clientId = FuncTestUtils.GetString("Integration clientId");
        string clientSecret = FuncTestUtils.GetString("Integration clientSecret");
        string certificate = FuncTestUtils.GetString("Path of the file with the pfx certificate (ex: src/sdk/certificates/production.pfx)");
        string password = FuncTestUtils.GetString("Password of the file with the pfx certificate");
        string account = FuncTestUtils.GetString("Account");

        InterSdk interSdk = new InterSdk(environment, clientId, clientSecret, certificate, password);
        interSdk.SetAccount(account);
        return interSdk;
    }

    private static int Menu(string environment)
    {
        Console.WriteLine("ENVIRONMENT " + environment);
        Console.WriteLine("1 - API Billing");
        Console.WriteLine("2 - API Banking");
        Console.WriteLine("3 - API Pix");
        Console.WriteLine("0 - Exit");
        Console.Write("=> ");

        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid option");
            return Menu(environment);
        }
    }

    private static void PrintViolations(List<Violation> violations) {
        if (violations == null || violations.Count == 0) {
            return;
        }
        foreach (var violation in violations)
        {
            Console.WriteLine(violation.Reason);
            Console.WriteLine(violation.Property);
            Console.WriteLine(violation.Value);
        }
    }
}
