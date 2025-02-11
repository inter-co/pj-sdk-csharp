namespace inter_sdk_library;

/// <summary>
/// The {@code BillingSituation} class represents different situations for billing.
/// </summary>
public class BillingSituation
{
    public static string RECEBIDO = "RECEBIDO"; // Received
    public static string A_RECEBER = "A_RECEBER"; // To be received
    public static string MARCADO_RECEBIDO = "MARCADO_RECEBIDO"; // Marked as received
    public static string ATRASADO = "ATRASADO"; // Overdue
    public static string CANCELADO = "CANCELADO"; // Canceled
    public static string EXPIRADO = "EXPIRADO"; // Expired
    public static string FALHA_EMISSAO = "FALHA_EMISSAO"; // Emission failure
    public static string EM_PROCESSAMENTO = "EM_PROCESSAMENTO"; // In processing
    public static string PROTESTO = "PROTESTO"; // Protest
}
