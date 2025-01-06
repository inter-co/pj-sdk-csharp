namespace inter_sdk_library;

/// <summary>
/// The {@code ClientException} class is a custom exception that extends {@link SdkException}.
/// <p>
/// This exception is thrown to indicate specific errors related to client operations
/// within the SDK. It can be used to handle exceptions that arise during client interactions,
/// providing a way to include additional error information.
/// </p>
/// </summary>
public class ClientException : SdkException
{
    /// <summary>
    /// Constructs a new {@code ClientException} with the specified detail message and
    /// error information.
    /// </summary>
    /// <param name="message">The detail message that explains the reason for the exception.</param>
    /// <param name="error">An {@link Error} object containing additional error details.</param>
    public ClientException(string message, Error error) 
        : base(message, error)
    {
    }
}
