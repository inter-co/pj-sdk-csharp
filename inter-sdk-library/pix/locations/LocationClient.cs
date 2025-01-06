namespace inter_sdk_library;

using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Text.Json.Serialization;
public class LocationClient
{
    private JsonSerializerOptions jsonOptions = new JsonSerializerOptions 
    { 
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    /// <summary>
    /// Includes a new location based on the provided configuration and immediate billing type.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_immediateBillingType_"> The {@link ImmediateBillingType} indicating the type of immediate billing. </param>
    /// <returns> A {@link Location} object containing the details of the included location. </returns>
    /// <exception cref="SdkException"> If there is an error during the inclusion process, such as network issues
    ///                      or API response errors. </exception>
    public Location Include(Config config, string immediateBillingType)
    {
        InterSdk.LogInfo($"IncludeLocation pix {config.ClientId} {immediateBillingType}");
        
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_LOCATIONS);
        var request = new IncludeLocationRequest { ImmediateBillingType = immediateBillingType };

        try
        {
            string json = JsonSerializer.Serialize(request, jsonOptions);
            json = HttpUtils.CallPost(config, url, Constants.PIX_LOCATION_WRITE_SCOPE, "Error including location", json);
            
            return JsonSerializer.Deserialize<Location>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves the details of a location based on the provided configuration and location ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_id_"> The unique identifier for the location to be retrieved. </param>
    /// <returns> A {@link Location} object containing the details of the retrieved location. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public Location Retrieve(Config config, string id)
    {
        InterSdk.LogInfo($"RetrieveLocation {config.ClientId} id={id}");
        
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_LOCATIONS) + "/" + id;
        string json = HttpUtils.CallGet(config, url, Constants.PIX_LOCATION_READ_SCOPE, "Error retrieving location");
        
        try
        {
            return JsonSerializer.Deserialize<Location>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a paginated list of locations based on the specified date range, page number, and filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> A {@link RetrieveLocationFilter} object containing filter criteria. </param>
    /// <returns> A {@link LocationPage} object containing the requested page of locations. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public LocationPage Retrieve(Config config, string initialDate, string finalDate, int page, int? pageSize, RetrieveLocationFilter filter)
    {
        InterSdk.LogInfo($"RetrieveLocationsList {config.ClientId} {initialDate}-{finalDate} pagina={page}");
        
        return GetPage(config, initialDate, finalDate, page, pageSize, filter);
    }

    /// <summary>
    /// Retrieves all locations within the specified date range and filters.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_filter_"> A {@link RetrieveLocationFilter} object containing filter criteria. </param>
    /// <returns> A list of {@link Location} objects containing all retrieved locations. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    public List<Location> Retrieve(Config config, string initialDate, string finalDate, RetrieveLocationFilter filter)
    {
        InterSdk.LogInfo($"RetrieveLocationsList {config.ClientId} {initialDate}-{finalDate}");
        
        int page = 0;
        LocationPage locationPage;
        var locs = new List<Location>();

        do
        {
            locationPage = GetPage(config, initialDate, finalDate, page, null, filter);
            locs.AddRange(locationPage.Locations);
            page++;
        } while (page < locationPage.TotalPages);

        return locs;
    }

    /// <summary>
    /// Unlinks a location based on the provided configuration and location ID.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_id_"> The unique identifier for the location to be unlinked. </param>
    /// <returns> A {@link Location} object confirming the unlinking of the location. </returns>
    /// <exception cref="SdkException"> If there is an error during the unlinking process, such as network issues
    ///                      or API response errors. </exception>
    public Location Unlink(Config config, string id)
    {
        InterSdk.LogInfo($"UnlinkLocation {config.ClientId} id={id}");
        
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_LOCATIONS) + "/" + id + "/txid";
        string json = HttpUtils.CallDelete(config, url, Constants.PIX_LOCATION_WRITE_SCOPE, "Error unlinking location");

        try
        {
            return JsonSerializer.Deserialize<Location>(json)!;
        }
        catch (SdkException exception)
        {   
            InterSdk.LogInfo(Constants.GENERIC_EXCEPTION_MESSAGE, exception.Message);
            throw new SdkException(exception.Message, exception.Error);
        }
    }

    /// <summary>
    /// Retrieves a specific page of locations based on the provided criteria.
    /// </summary>
    /// <param _name_="_config_"> The configuration object containing client information. </param>
    /// <param _name_="_initialDate_"> The start date for the retrieval range (inclusive). </param>
    /// <param _name_="_finalDate_"> The end date for the retrieval range (inclusive). </param>
    /// <param _name_="_page_"> The page number to retrieve. </param>
    /// <param _name_="_pageSize_"> The number of items per page (optional). </param>
    /// <param _name_="_filter_"> A {@link RetrieveLocationFilter} object containing filter criteria. </param>
    /// <returns> A {@link LocationPage} object containing the requested page of locations. </returns>
    /// <exception cref="SdkException"> If there is an error during the retrieval process, such as network issues
    ///                      or API response errors. </exception>
    private LocationPage GetPage(Config config, string initialDate, string finalDate, int page, int? pageSize, RetrieveLocationFilter filter)
    {
        string url = UrlUtils.BuildUrl(config, Constants.URL_PIX_LOCATIONS) + "?inicio=" + initialDate + 
                    "&fim=" + finalDate + 
                    "&paginacao.paginaAtual=" + page + 
                    (pageSize.HasValue ? "&paginacao.itensPorPagina=" + pageSize.Value : "") + 
                    AddFilters(filter);
                    
        string json = HttpUtils.CallGet(config, url, Constants.PIX_LOCATION_READ_SCOPE, "Error retrieving locations");

        try
        {
            return JsonSerializer.Deserialize<LocationPage>(json)!;
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
    /// <param _name_="_filter_"> A {@link RetrieveLocationFilter} object containing filter criteria. </param>
    /// <returns> A string containing the appended filter parameters for the URL. </returns>
    private string AddFilters(RetrieveLocationFilter filter)
    {
        if (filter == null)
        {
            return string.Empty;
        }

        var stringFilter = new StringBuilder();
        
        if (filter.TxIdPresent != null)
        {
            stringFilter.Append("&txIdPresente").Append("=").Append(filter.TxIdPresent);
        }
        if (filter.BillingType != null)
        {
            stringFilter.Append("&tipoCob").Append("=").Append(filter.BillingType.ToString());
        }

        return stringFilter.ToString();
    }
}
