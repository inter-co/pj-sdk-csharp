namespace inter_sdk_library;

public class InvalidEnvironmentException : ClientException
{

    public InvalidEnvironmentException() 
        : base("Invalid environment", new Error{
            Title = "Invalid environment",
            Detail = "The environment must be one of the following: SANDBOX, PRODUCTION"
        })
    {
    }
}
