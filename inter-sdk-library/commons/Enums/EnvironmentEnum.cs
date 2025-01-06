namespace inter_sdk_library;

using System;

/// <summary>
/// Enum representing the different environments for the client integration.
/// </summary>
public enum EnvironmentEnum
{
    /// <summary>
    /// Production environment URL.
    /// </summary>
    PRODUCTION = 0,

    /// <summary>
    /// UAT (User Acceptance Testing) environment URL.
    /// </summary>
    UAT = 1,

    /// <summary>
    /// Sandbox environment URL.
    /// </summary>
    SANDBOX = 2
}

public static class EnvironmentEnumExtensions
{
    /// <summary>
    /// Gets the label for the specified environment.
    /// </summary>
    /// <param name="environment">The environment enum value.</param>
    /// <returns>The label of the environment.</returns>
    public static string GetLabel(this EnvironmentEnum environment)
    {
        switch (environment)
        {
            case EnvironmentEnum.PRODUCTION:
                return "PRODUCTION";
            case EnvironmentEnum.UAT:
                return "UAT";
            case EnvironmentEnum.SANDBOX:
                return "SANDBOX";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Gets the base URL for the specified environment.
    /// </summary>
    /// <param name="environment">The environment enum value.</param>
    /// <returns>The base URL of the environment.</returns>
    public static string GetUrlBase(this EnvironmentEnum environment)
    {
        switch (environment)
        {
            case EnvironmentEnum.PRODUCTION:
                return "https://cdpj.partners.bancointer.com.br";
            case EnvironmentEnum.UAT:
                return "https://cdpj.partners.uatbi.com.br";
            case EnvironmentEnum.SANDBOX:
                return "https://cdpj-sandbox.partners.uatinter.co";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
