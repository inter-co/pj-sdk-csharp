namespace inter_sdk_library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
/// <summary>
/// Represents a financial transaction with details about payment status, amounts, dates,
/// and beneficiary information.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para>
/// The class includes fields for transaction code, barcode, type, entered due date,
/// title due date, inclusion date, payment date, amount paid, nominal amount, payment status,
/// required approvals, completed approvals, beneficiary CPF/CNPJ, beneficiary name,
/// authentication, and additional fields.
/// </para>
/// </summary>
/// <see cref="AbstractModel"/>
/// <since>1.0</since>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Payment : AbstractModel
{
    /// <summary> The unique code for the transaction. </summary>
    [JsonPropertyName("codigoTransacao")]
    public string TransactionCode { get; set; }
    /// <summary> The barcode associated with the payment. </summary>
    [JsonPropertyName("codigoBarra")]
    public string Barcode { get; set; }
    /// <summary> The type of the payment. </summary>
    [JsonPropertyName("tipo")]
    public string Type { get; set; }
    /// <summary> The due date entered for the payment. </summary>
    [JsonPropertyName("dataVencimentoDigitada")]
    public string EnteredDueDate { get; set; }
    /// <summary> The due date of the title. </summary>
    [JsonPropertyName("dataVencimentoTitulo")]
    public string TitleDueDate { get; set; }
    /// <summary> The date the payment was included in the system. </summary>
    [JsonPropertyName("dataInclusao")]
    public string InclusionDate { get; set; }
    /// <summary> The date the payment was made. </summary>
    [JsonPropertyName("dataPagamento")]
    public string PaymentDate { get; set; }
    /// <summary> The amount that has been paid. </summary>
    [JsonPropertyName("valorPago")]
    public decimal AmountPaid { get; set; }
    /// <summary> The nominal amount of the payment. </summary>
    [JsonPropertyName("valorNominal")]
    public decimal NominalAmount { get; set; }
    /// <summary> The current status of the payment. </summary>
    [JsonPropertyName("statusPagamento")]
    public string PaymentStatus { get; set; }
    /// <summary> The number of approvals required for the payment. </summary>
    [JsonPropertyName("aprovacoesNecessarias")]
    public int? RequiredApprovals { get; set; } // Use nullable int
    /// <summary> The number of approvals that have been completed. </summary>
    [JsonPropertyName("aprovacoesRealizadas")]
    public int? CompletedApprovals { get; set; } // Use nullable int
    /// <summary> The CPF or CNPJ of the beneficiary. </summary>
    [JsonPropertyName("cpfCnpjBeneficiario")]
    public string BeneficiaryCpfCnpj { get; set; }
    /// <summary> The name of the beneficiary. </summary>
    [JsonPropertyName("nomeBeneficiario")]
    public string BeneficiaryName { get; set; }
    /// <summary> The authentication code for the payment. </summary>
    [JsonPropertyName("autenticacao")]
    public string Authentication { get; set; }
    /// <summary> Constructs a new Payment with specified values. </summary>
    /// <param name="transactionCode"> The unique code for the transaction </param>
    /// <param name="barcode"> The barcode associated with the payment </param>
    /// <param name="type"> The type of the payment </param>
    /// <param name="enteredDueDate"> The due date entered for the payment </param>
    /// <param name="titleDueDate"> The due date of the title </param>
    /// <param name="inclusionDate"> The date the payment was included in the system </param>
    /// <param name="paymentDate"> The date the payment was made </param>
    /// <param name="amountPaid"> The amount that has been paid </param>
    /// <param name="nominalAmount"> The nominal amount of the payment </param>
    /// <param name="paymentStatus"> The current status of the payment </param>
    /// <param name="requiredApprovals"> The number of approvals required for the payment </param>
    /// <param name="completedApprovals"> The number of approvals that have been completed </param>
    /// <param name="beneficiaryCpfCnpj"> The CPF or CNPJ of the beneficiary </param>
    /// <param name="beneficiaryName"> The name of the beneficiary </param>
    /// <param name="authentication"> The authentication code for the payment </param>
    public Payment(string transactionCode, string barcode, string type, string enteredDueDate,
                   string titleDueDate, string inclusionDate, string paymentDate, decimal amountPaid,
                   decimal nominalAmount, string paymentStatus, int? requiredApprovals,
                   int? completedApprovals, string beneficiaryCpfCnpj, string beneficiaryName,
                   string authentication)
    {
        TransactionCode = transactionCode;
        Barcode = barcode;
        Type = type;
        EnteredDueDate = enteredDueDate;
        TitleDueDate = titleDueDate;
        InclusionDate = inclusionDate;
        PaymentDate = paymentDate;
        AmountPaid = amountPaid;
        NominalAmount = nominalAmount;
        PaymentStatus = paymentStatus;
        RequiredApprovals = requiredApprovals;
        CompletedApprovals = completedApprovals;
        BeneficiaryCpfCnpj = beneficiaryCpfCnpj;
        BeneficiaryName = beneficiaryName;
        Authentication = authentication;
    }
    /// <summary> Default constructor </summary>
    public Payment() { }
}
