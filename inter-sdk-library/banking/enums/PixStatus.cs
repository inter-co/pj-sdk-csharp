namespace inter_sdk_library;

/// <summary>
/// The {@code PixStatus} class represents the status of a PIX transaction.
/// </summary>
public class PixStatus
{
    public static string CRIADO = "CRIADO"; // Created status
    public static string AGUARDANDO_APROVACAO = "AGUARDANDO_APROVACAO"; // Awaiting approval status
    public static string APROVADO = "APROVADO"; // Approved status
    public static string REPROVADO = "REPROVADO"; // Rejected status
    public static string EXPIRADO = "EXPIRADO"; // Expired status
    public static string CANCELADO = "CANCELADO"; // Canceled status
    public static string FALHA = "FALHA"; // Failure status
    public static string AGENDADO = "AGENDADO"; // Scheduled status
    public static string PAGO = "PAGO"; // Paid status
    public static string ENVIADO = "ENVIADO"; // Sent status
    public static string CANCELADO_SEM_SALDO = "CANCELADO_SEM_SALDO"; // Canceled due to insufficient balance status
    public static string DEBITADO = "DEBITADO"; // Debited status
    public static string PARCIALMENTE_DEBITADO = "PARCIALMENTE_DEBITADO"; // Partially debited status
    public static string PARCIALMENTE_PAGO = "PARCIALMENTE_PAGO"; // Partially paid status
    public static string NAO_DEBITADO = "NAO_DEBITADO"; // Not debited status
    public static string AGENDAMENTO_CANCELADO = "AGENDAMENTO_CANCELADO"; // Scheduling canceled status
    public static string TRANSACAO_CRIADA = "TRANSACAO_CRIADA"; // Transaction created status
    public static string TRANSACAO_APROVADA = "TRANSACAO_APROVADA"; // Transaction approved status
    public static string PIX_ENVIADO = "PIX_ENVIADO"; // PIX sent status
    public static string PIX_PAGO = "PIX_PAGO"; // PIX paid status
}
