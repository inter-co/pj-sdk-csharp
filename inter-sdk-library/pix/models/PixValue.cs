namespace inter_sdk_library;

using System.Text.Json.Serialization;
using Newtonsoft.Json;

//// <summary>
/// The {@code PixValue} class represents the amount involved in a
/// transaction. It includes the original value, modification modality,
/// and withdrawal transaction details.
/// </summary>
/// <see _cref_="AbstractModel"/>
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class PixValue : AbstractModel
{
    /// <summary> The original value of the transaction. </summary>
    [JsonPropertyName("original")]
    public string Original { get; set; }

    /// <summary> The modality of modification applied to the transaction's value. </summary>
    [JsonPropertyName("modalidadeAlteracao")]
    public int? ModificationModality { get; set; } // Changed to int? to allow nulls

    /// <summary> Details of the withdrawal transaction, if applicable. </summary>
    [JsonPropertyName("retirada")]
    public WithdrawalTransaction WithdrawalTransaction { get; set; }

    /// <summary> Constructs a new PixValue with specified values. </summary>
    /// <param _name_="_original_"> The original value of the transaction </param>
    /// <param _name_="_modificationModality_"> The modality of modification applied to the transaction's value </param>
    /// <param _name_="_withdrawalTransaction_"> Details of the withdrawal transaction, if applicable </param>
    public PixValue(string original, int? modificationModality, WithdrawalTransaction withdrawalTransaction) : base()
    {
        Original = original;
        ModificationModality = modificationModality;
        WithdrawalTransaction = withdrawalTransaction;
    }

    /// <summary> Default constructor </summary>
    public PixValue() { }
}
