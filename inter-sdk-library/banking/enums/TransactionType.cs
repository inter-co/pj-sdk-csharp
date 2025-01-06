namespace inter_sdk_library;

/// <summary>
/// The {@code TransactionType} class represents the types of transactions.
/// </summary>
public class TransactionType
{
    public static string PIX = "PIX"; // PIX transaction type
    public static string CAMBIO = "CAMBIO"; // Currency exchange transaction type
    public static string ESTORNO = "ESTORNO"; // Refund transaction type
    public static string INVESTIMENTO = "INVESTIMENTO"; // Investment transaction type
    public static string TRANSFERENCIA = "TRANSFERENCIA"; // Transfer transaction type
    public static string PAGAMENTO = "PAGAMENTO"; // Payment transaction type
    public static string BOLETO_COBRANCA = "BOLETO_COBRANCA"; // Invoice collection transaction type
    public static string OUTROS = "OUTROS"; // Other transaction type
}
