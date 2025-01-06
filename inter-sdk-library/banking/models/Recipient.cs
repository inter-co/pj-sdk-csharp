namespace inter_sdk_library;

using Newtonsoft.Json;
using System.Text.Json.Serialization;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Recipient
{
    /// <summary> The type of the key, fixed as "CHAVE". </summary>
    [JsonPropertyName("tipo")]
    public string Type { get; set; }

    /// <summary> The actual key used for payment transfer. </summary>
    [JsonPropertyName("chave")]
    public string KeyValue { get; set; }

    /// <summary> The copy and paste code for the transaction. </summary>
    [JsonPropertyName("pixCopiaECola")]
    public string CopyAndPasteCode { get; set; }

    /// <summary>
    /// The bank account number of the recipient.
    /// <p> This field holds the account number associated with the
    /// recipient's bank account for transaction purposes.
    /// </summary>
    [JsonPropertyName("contaCorrente")]
    public string Account { get; set; }
    /// <summary>
    /// The type of the bank account.
    /// <p> This specifies whether the account is a checking, savings,
    /// or other kind of account, represented by the AccountType enum.
    /// </summary>
    [JsonPropertyName("tipoConta")]
    public AccountType AccountType { get; set; }
    /// <summary>
    /// The CPF or CNPJ of the recipient.
    /// <p> This field is used to store the CPF (Brazilian Individual Taxpayer
    /// Registry) or CNPJ (National Registry of Legal Entities) of the recipient for
    /// identification and tax purposes.
    /// </summary>
    [JsonPropertyName("cpfCnpj")]
    public string CpfCnpj { get; set; }
    /// <summary>
    /// The agency number of the recipient's bank.
    /// <p> This field holds the bank agency number where the account is maintained.
    /// </summary>
    [JsonPropertyName("agencia")]
    public string Agency { get; set; }
    /// <summary>
    /// The name of the account holder.
    /// <p> This field contains the full name of the individual
    /// or entity that holds the bank account.
    /// </summary>
    [JsonPropertyName("nome")]
    public string Name { get; set; }
    /// <summary>
    /// The financial institution where the account is held.
    /// <p> This field contains details about the financial institution,
    /// typically represented as an instance of FinancialInstitution.
    /// </summary>
    [JsonPropertyName("instituicaoFinanceira")]
    public FinancialInstitution FinancialInstitution { get; set; }

    /// <summary> Constructs a new Recipient with the specified values. </summary>
    /// <param name="key"> The actual key used for payment transfer </param>
    /// <param name="copyAndPasteCode"> The copy and paste code for the transaction </param>
    /// <param name="account"> The bank account number of the recipient </param>
    /// <param name="accountType"> The type of the bank account </param>
    /// <param name="cpfCnpj"> The CPF or CNPJ of the recipient </param>
    /// <param name="agency"> The agency number of the recipient's bank </param>
    /// <param name="name"> The name of the account holder </param>
    /// <param name="financialInstitution"> The financial institution where the account is held </param>
    public Recipient(string type, string key, string copyAndPasteCode, string account, AccountType accountType, string cpfCnpj, string agency, string name, FinancialInstitution financialInstitution)
    {
        Type = type;
        KeyValue = key;
        CopyAndPasteCode = copyAndPasteCode;
        Account = account;
        AccountType = accountType;
        CpfCnpj = cpfCnpj;
        Agency = agency;
        Name = name;
        FinancialInstitution = financialInstitution;
    }

    /// <summary> Default constructor </summary>
    public Recipient() { }
}
