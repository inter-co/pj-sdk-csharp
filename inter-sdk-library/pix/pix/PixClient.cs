namespace inter_sdk_library;

using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Text.Json.Serialization;
public class PixClient
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions 
    { 
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    /// <summary>
    /// Requests a devolution for a transaction identified by its end-to-end ID and the specific ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_e2eId_"> The end-to-end ID of the transaction for which the devolution is being requested. </param>
    /// <param _name_="_id_"> The unique identifier for the devolution request. </param>
    /// <param _name_="_devolutionRequestBody_"> The {@link DevolutionRequestBody} containing details for the devolution request. </param>
    /// <returns> A {@link DetailedDevolution} object containing details about the requested devolution. </returns>
    /// <exception cref="SdkException"> If there is an error during the request process, such as network issues
    ///                      or API response errors. </exception>
    public DetailedDevolution RequestDevolution(Config config, string e2eId, string id, DevolutionRequestBody devolutionRequestBody)
    {
        InterSdk.LogInfo($"RequestDevolution {config.ClientId} e2eId={e2eId} id={id}");
        
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_PIX) + "/" + e2eId + "/devolucao/" + id;

        try
        {
            string json = JsonSerializer.Serialize(devolutionRequestBody, jsonOptions);
            json = HttpUtils.CallPut(config, url, Constants.PIX_WRITE_SCOPE, "Error requesting devolution", json);
            return JsonSerializer.Deserialize<DetailedDevolution>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves the details of a devolution based on the provided end-to-end ID and specific ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_e2eId_"> The end-to-end ID of the transaction for which the devolution details are requested. </param>
    /// <param _name_="_id_"> The unique identifier for the devolution to be retrieved. </param>
    /// <returns> A {@link DetailedDevolution} object containing the details of the retrieved devolution. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public DetailedDevolution RetrieveDevolution(Config config, string e2eId, string id)
    {
        InterSdk.LogInfo($"RetrieveDevolution {config.ClientId} e2eId={e2eId} id={id}");
        
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_PIX) + "/" + e2eId + "/devolucao/" + id;
        string json = HttpUtils.CallGet(config, url, Constants.PIX_READ_SCOPE, "Error retrieving devolution");

        try
        {
            return JsonSerializer.Deserialize<DetailedDevolution>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves the details of a Pix transaction based on the provided end-to-end ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_e2eId_"> The end-to-end ID of the Pix transaction to be retrieved. </param>
    /// <returns> A {@link Pix} object containing the details of the retrieved Pix transaction. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public Pix RetrievePix(Config config, string e2eId)
    {
        InterSdk.LogInfo($"RetrievePix {config.ClientId} e2eId={e2eId}");
        
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_PIX) + "/" + e2eId;
        string json = HttpUtils.CallGet(config, url, Constants.PIX_READ_SCOPE, "Error retrieving pix");

        try
        {
            return JsonSerializer.Deserialize<Pix>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a paginated list of Pix transactions based on the specified date range, page number, and filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> A {@link RetrievedPixFilter} object containing filter criteria. </param>
    /// <returns> A {@link PixPage} object containing the requested page of Pix transactions. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public PixPage RetrievePixPage(Config config, string initialDate, string finalDate, int page, int? pageSize, RetrievedPixFilter filter)
    {
        InterSdk.LogInfo($"RetrievePixList {config.ClientId} {initialDate}-{finalDate} page={page}");
        
        return GetPage(config, initialDate, finalDate, page, pageSize, filter);
    }

    /// <summary>
    /// Retrieves all Pix transactions within the specified date range and filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_filter_"> A {@link RetrievedPixFilter} object containing filter criteria. </param>
    /// <returns> A list of {@link Pix} objects containing all retrieved Pix transactions. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public List<Pix> RetrievePixInRange(Config config, string initialDate, string finalDate, RetrievedPixFilter filter)
    {
        InterSdk.LogInfo($"RetrievePixList {config.ClientId} {initialDate}-{finalDate}");
        
        int page = 0;
        PixPage pixPage;
        var listaPix = new List<Pix>();

        do
        {
            pixPage = GetPage(config, initialDate, finalDate, page, null, filter);
            listaPix.AddRange(pixPage.PixList);
            page++;
        } while (page < pixPage.TotalPages);

        return listaPix;
    }

    /// <summary>
    /// Retrieves a specific page of Pix transactions based on the provided criteria.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> A {@link RetrievedPixFilter} object containing filter criteria. </param>
    /// <returns> A {@link PixPage} object containing the requested page of Pix transactions. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    private PixPage GetPage(Config config, string initialDate, string finalDate, int page, int? pageSize, RetrievedPixFilter filter)
    {
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_PIX) + "?inicio=" + initialDate + 
                    "&fim=" + finalDate + 
                    "&paginacao.paginaAtual=" + page + 
                    (pageSize.HasValue ? "&paginacao.itensPorPagina=" + pageSize.Value : "") + 
                    AddFilters(filter);
        
        string json = HttpUtils.CallGet(config, url, Constants.PIX_READ_SCOPE, "Error retrieving pix");

        try
        {
            return JsonSerializer.Deserialize<PixPage>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Adds filter parameters to the URL based on the provided filter criteria.
    /// </summary>
    /// <param _name_="_filter_"> A {@link RetrievedPixFilter} object containing filter criteria. </param>
    /// <returns> A string containing the appended filter parameters for the URL. </returns>
    private string AddFilters(RetrievedPixFilter filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }

        var stringFilter = new StringBuilder();

        if (filter.TxId != null)
        {
            stringFilter.Append("&txId").Append("=").Append(filter.TxId);
        }
        if (filter.TxIdPresent != null)
        {
            stringFilter.Append("&txIdPresente").Append("=").Append(filter.TxIdPresent);
        }
        if (filter.DevolutionPresent != null)
        {
            stringFilter.Append("&devolucaoPresente").Append("=").Append(filter.DevolutionPresent);
        }
        if (filter.Cpf != null)
        {
            stringFilter.Append("&cpf").Append("=").Append(filter.Cpf);
        }
        if (filter.Cnpj != null)
        {
            stringFilter.Append("&cnpj").Append("=").Append(filter.Cnpj);
        }

        return stringFilter.ToString();
    }
}
