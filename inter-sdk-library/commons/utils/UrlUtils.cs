namespace inter_sdk_library;

public class UrlUtils
{
    /// <summary>
    /// Builds a complete URL using the base URL from the Config and the specified URL path.
    /// </summary>
    /// <param _name_="_config_"> The configuration containing the base URL </param>
    /// <param _name_="_url_"> The URL path to append to the base URL </param>
    /// <returns> The complete URL as a string </returns>
    public static string BuildUrl(Config config, string url)
    {
        return config.Environment.GetUrlBase() + url;
    }
}
