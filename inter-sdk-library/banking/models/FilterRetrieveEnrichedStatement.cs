namespace inter_sdk_library;

/// <summary>
/// The {@code FilterRetrieveEnrichedStatement} class represents a filter
/// for retrieving enriched statements.
/// <para> 
/// This class allows users to specify criteria for filtering
/// transactions in enriched statements based on operation and transaction types.
/// </summary>

public class FilterRetrieveEnrichedStatement : AbstractModel
{
    /// <summary> The operation type to filter the retrieved statements. </summary>
    public string OperationType { get; set; }

    /// <summary> The transaction type to filter the retrieved statements. </summary>
    public string TransactionType { get; set; }

    /// <summary> Constructs a new FilterRetrieveEnrichedStatement with specified values. </summary>
    /// <param name="operationType"> The operation type to filter the retrieved statements </param>
    /// <param name="transactionType"> The transaction type to filter the retrieved statements </param>
    public FilterRetrieveEnrichedStatement(string operationType, string transactionType)
    {
        OperationType = operationType;
        TransactionType = transactionType;
    }

    /// <summary> Default constructor </summary>
    public FilterRetrieveEnrichedStatement() { }
}
