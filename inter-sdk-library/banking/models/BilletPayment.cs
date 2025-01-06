namespace inter_sdk_library;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Represents payment information for a ticket (boleto), including details such as barcode,
/// amount to be paid, payment date, due date, and any additional fields for flexibility.
/// <para>
/// This class extends AbstractModel and is designed to map data from JSON,
/// allowing the deserialization of received information. It uses System.Text.Json
/// for JSON mapping.
/// <para>
/// The class includes fields for barcode, amount to be paid, payment date, due date,
/// beneficiary's document, and additional fields for flexibility. It overrides equals,
/// hashCode, and toString methods to include both its own fields and those of the superclass.
/// </summary>
/// <see cref="AbstractModel"/>
/// <since>1.0</since>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BilletPayment : AbstractModel
{
    /// <summary> The barcode of the ticket. </summary>
    [JsonPropertyName("codBarraLinhaDigitavel")]
    public string Barcode { get; set; }

    /// <summary> The amount to be paid. </summary>
    [JsonPropertyName("valorPagar")]
    public decimal AmountToPay { get; set; }

    /// <summary> The payment date. </summary>
    [JsonPropertyName("dataPagamento")]
    public string PaymentDate { get; set; }

    /// <summary> The due date. </summary>
    [JsonPropertyName("dataVencimento")]
    public string DueDate { get; set; }

    /// <summary> The beneficiary's document (CPF/CNPJ). </summary>
    [JsonPropertyName("cpfCnpjBeneficiario")]
    public string BeneficiaryDocument { get; set; }

    /// <summary> Default constructor </summary>
    public BilletPayment() { }

    /// <summary> Constructs a new BilletPayment with specified values. </summary>
    /// <param name="barcode"> The barcode of the ticket </param>
    /// <param name="amountToPay"> The amount to be paid </param>
    /// <param name="paymentDate"> The payment date </param>
    /// <param name="dueDate"> The due date </param>
    /// <param name="beneficiaryDocument"> The beneficiary's document (CPF/CNPJ) </param>
    public BilletPayment(string barcode, decimal amountToPay, string paymentDate, string dueDate, string beneficiaryDocument)
    {
        Barcode = barcode;
        AmountToPay = amountToPay;
        PaymentDate = paymentDate;
        DueDate = dueDate;
        BeneficiaryDocument = beneficiaryDocument;
    }
}
