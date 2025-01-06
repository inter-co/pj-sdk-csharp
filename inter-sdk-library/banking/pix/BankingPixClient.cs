namespace inter_sdk_library;

using System.Text.Json;
using System.Text.Json.Serialization;
public class BankingPixClient
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions 
    { 
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    /// <summary>
    /// Includes a new PIX payment request in the banking system.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_pix_"> The {@link Pix} object containing details of the PIX payment to be included. </param>
    /// <returns> An {@link IncludePixResponse} object containing the response from the banking system
    /// after including the PIX payment request. </returns>
    /// <exception cref="SdkException"> If there is an error during the inclusion process, such as
    ///                      network issues or API response errors. </exception>
    public IncludePixResponse Include(Config config, BankingPix pix)
    {
        InterSdk.LogInfo($"IncludePix {config.ClientId} {pix.Description}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_PAYMENT_PIX);
        
        try
        {
            string json = JsonSerializer.Serialize(pix, jsonOptions);
            json = HttpUtils.CallPost(config, url, Constants.PIX_PAYMENT_WRITE_SCOPE, "Error including pix", json);
            return JsonSerializer.Deserialize<IncludePixResponse>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves the details of a PIX payment request based on the given request code.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_requestCode_"> The unique code of the PIX payment request to retrieve. </param>
    /// <returns> An {@link RetrievePixResponse} object containing the details of the
    /// requested PIX payment. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as
    ///                      network issues or API response errors. </exception>
    public RetrievePixResponse Retrieve(Config config, string requestCode)
    {
        InterSdk.LogInfo($"RetrievePix {config.ClientId} {requestCode}");
        string url = UrlUtils.BuildUrl(config, Constants.URL_BANKING_PAYMENT_PIX) + "/" + requestCode;
        string json = HttpUtils.CallGet(config, url, Constants.PIX_PAYMENT_READ_SCOPE, "Error retrieving pix");
        
        try
        {
            return JsonSerializer.Deserialize<RetrievePixResponse>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }
}
