namespace inter_sdk_library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json.Serialization;
/// <summary>
/// The {@code BillingRetrievingResponse} class represents the response received
/// when retrieving billing information.
/// <para>
/// It contains various details including the request code, issue number,
/// issue and due dates, nominal value, billing type, billing situation, total amount
/// received, discounts, fines, interest, and payer information.
/// </para>
/// </summary>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class BillingRetrievingResponse : AbstractModel
{
    /// <summary> The request code associated with the billing retrieval. </summary>
    [JsonPropertyName("codigoSolicitacao")]
    public string RequestCode { get; set; }
    /// <summary> A custom identifier for the billing statement. </summary>
    [JsonPropertyName("seuNumero")]
    public string YourNumber { get; set; }
    /// <summary> The date when the billing was issued. </summary>
    [JsonPropertyName("dataEmissao")]
    public string IssueDate { get; set; }
    /// <summary> The due date for the payment. </summary>
    [JsonPropertyName("dataVencimento")]
    public string DueDate { get; set; }
    /// <summary> The nominal value of the billing statement. </summary>
    [JsonPropertyName("valorNominal")]
    public decimal NominalValue { get; set; }
    /// <summary> The type of billing being retrieved. </summary>
    [JsonPropertyName("tipoCobranca")]
    public string BillingType { get; set; }
    /// <summary> The current situation of the billing. </summary>
    [JsonPropertyName("situacao")]
    public string Situation { get; set; }
    /// <summary> The date associated with the current situation of the billing. </summary>
    [JsonPropertyName("dataSituacao")]
    public string SituationDate { get; set; }
    /// <summary> The total amount received for the billing. </summary>
    [JsonPropertyName("valorTotalRecebido")]
    public string TotalAmountReceived { get; set; }
    /// <summary> The origin of the payment reception. </summary>
    [JsonPropertyName("origemRecebimento")]
    public string ReceivingOrigin { get; set; }
    /// <summary> The reason for cancellation, if applicable. </summary>
    [JsonPropertyName("motivoCancelamento")]
    public string CancellationReason { get; set; }
    /// <summary> Indicates whether the billing statement has been archived. </summary>
    [JsonPropertyName("arquivada")]
    public bool? Archived { get; set; } // Nullable to match Boolean in Java
    /// <summary> A list of applicable discounts on the billing statement. </summary>
    [JsonPropertyName("descontos")]
    public List<Discount> Discounts { get; set; }
    /// <summary> The fine applicable for late payments. </summary>
    [JsonPropertyName("multa")]
    public Fine Fine { get; set; }
    /// <summary> The interest applicable for late payments. </summary>
    [JsonPropertyName("mora")]
    public Mora Interest { get; set; }
    /// <summary> The payer's information. </summary>
    [JsonPropertyName("pagador")]
    public Person Payer { get; set; }
/// <summary> Constructs a new BillingRetrievingResponse with specified values. </summary>
    /// <param name="requestCode"> The request code associated with the billing retrieval </param>
    /// <param name="yourNumber"> A custom identifier for the billing statement </param>
    /// <param name="issueDate"> The date when the billing was issued </param>
    /// <param name="dueDate"> The due date for the payment </param>
    /// <param name="nominalValue"> The nominal value of the billing statement </param>
    /// <param name="billingType"> The type of billing being retrieved </param>
    /// <param name="situation"> The current situation of the billing </param>
    /// <param name="situationDate"> The date associated with the current situation of the billing </param>
    /// <param name="totalAmountReceived"> The total amount received for the billing </param>
    /// <param name="receivingOrigin"> The origin of the payment reception </param>
    /// <param name="cancellationReason"> The reason for cancellation, if applicable </param>
    /// <param name="archived"> Indicates whether the billing statement has been archived </param>
    /// <param name="discounts"> A list of applicable discounts on the billing statement </param>
    /// <param name="fine"> The fine applicable for late payments </param>
    /// <param name="interest"> The interest applicable for late payments </param>
    /// <param name="payer"> The payer's information </param>
    public BillingRetrievingResponse(string requestCode,
                                     string yourNumber,
                                     string issueDate,
                                     string dueDate,
                                     decimal nominalValue,
                                     string billingType,
                                     string situation,
                                     string situationDate,
                                     string totalAmountReceived,
                                     string receivingOrigin,
                                     string cancellationReason,
                                     bool? archived,
                                     List<Discount> discounts,
                                     Fine fine,
                                     Mora interest,
                                     Person payer)
    {
        RequestCode = requestCode;
        YourNumber = yourNumber;
        IssueDate = issueDate;
        DueDate = dueDate;
        NominalValue = nominalValue;
        BillingType = billingType;
        Situation = situation;
        SituationDate = situationDate;
        TotalAmountReceived = totalAmountReceived;
        ReceivingOrigin = receivingOrigin;
        CancellationReason = cancellationReason;
        Archived = archived;
        Discounts = discounts;
        Fine = fine;
        Interest = interest;
        Payer = payer;
    }
    /// <summary> Default constructor </summary>
    public BillingRetrievingResponse() { }
}
