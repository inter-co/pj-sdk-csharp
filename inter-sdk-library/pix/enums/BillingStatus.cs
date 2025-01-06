namespace inter_sdk_library;

/// <summary>
/// The {@code BillingStatus} class represents the various statuses of a billing.
/// </summary>
public class BillingStatus
{
    public static string ATIVA = "ATIVA"; // Active
    public static string CONCLUIDA = "CONCLUIDA"; // Completed
    public static string REMOVIDO_PELO_USUARIO_RECEBEDOR = "REMOVIDO_PELO_USUARIO_RECEBEDOR"; // Removed by the receiving user
    public static string REMOVIDO_PELO_PSP = "REMOVIDO_PELO_PSP"; // Removed by the PSP
}