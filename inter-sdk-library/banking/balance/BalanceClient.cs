namespace inter_sdk_library;

using System.Text.Json;


/// <summary>
/// The BalanceClient class provides methods to retrieve banking balance information.
/// <para />
/// This class manages the HTTP communication required to obtain the balance for a specified date,
/// and processes the response from the server to return the balance details encapsulated in a Balance object.
/// </para>
/// </summary>
public class BalanceClient
{

    public Balance Retrieve(Config config, string balanceDate) {
        InterSdk.LogInfo("RetrieveBalance {0} {1}", config.ClientId, balanceDate);
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_BALANCE);
        if (balanceDate != null ) {
            url = url + "?dataSaldo=" + balanceDate;
        }
        string json = HttpUtils.CallGet(config, url, Constants.READ_BALANCE_SCOPE, "Error retrieving balance");
        return JsonSerializer.Deserialize<Balance>(json)!;
    }
}
