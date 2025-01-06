namespace inter_sdk_library;

/// <summary>
/// This class represents the necessary configurations
/// for integration with the system. This class contains sensitive
/// information and crucial operating parameters for the client's
/// functionality.
/// </summary>
public class Config
{
    /// <summary>
    /// The environment in which the client is operating.
    /// </summary>
    public EnvironmentEnum Environment { get; set;}

    /// <summary>
    /// The client ID for authentication with the system.
    /// </summary>
    public string ClientId { get; set;}

    /// <summary>
    /// The client secret for authentication with the system.
    /// </summary>
    public string ClientSecret { get; set;}

    /// <summary>
    /// The certificate used for secure communication with the system.
    /// </summary>
    public string Certificate { get; set;}

    /// <summary>
    /// The password for accessing the client's certificate.
    /// </summary>
    public string Password { get; set;}

    /// <summary>
    /// Indicates whether debug mode is enabled.
    /// </summary>
    public bool Debug { get; set; }

    /// <summary>
    /// The account identifier associated with the client's integration.
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// Control for rate limit enforcement.
    /// </summary>
    public bool RateLimitControl { get; set; }

    /// <summary>
    /// Constructs a new Config with specified values.
    /// </summary>
    /// <param name="environment">The environment of the client</param>
    /// <param name="clientId">The client ID</param>
    /// <param name="clientSecret">The client secret</param>
    /// <param name="certificate">The client certificate</param>
    /// <param name="password">The password for the client certificate</param>
    public Config(EnvironmentEnum environment, string clientId, string clientSecret, string certificate, string password)
    {
        Environment = environment;
        ClientId = clientId;
        ClientSecret = clientSecret;
        Certificate = certificate;
        Password = password;
    }
}
