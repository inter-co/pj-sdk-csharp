namespace inter_sdk_library;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

/// <summary>
/// Abstract base class for all model classes in the banking SDK.
/// Provides common functionality for handling additional fields and
/// implements robust Equals, GetHashCode, and ToString methods.
/// <para />
/// This class uses System.Text.Json for JSON serialization/deserialization
/// and reduces boilerplate code.
/// </summary>
/// <since>1.0</since>
public abstract class AbstractModel
{
    /// <summary>
    /// A dictionary to store any additional fields not explicitly defined in subclasses.
    /// </summary>
    [JsonPropertyName("additionalFields")]
    public Dictionary<string, string> AdditionalFields { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Returns a dictionary of additional fields not explicitly defined in this class.
    /// </summary>
    /// <returns>An unmodifiable dictionary containing any additional fields.</returns>
    public IReadOnlyDictionary<string, string> GetAdditionalFields() => AdditionalFields;

    /// <summary>
    /// Adds an additional field to the model object.
    /// </summary>
    /// <param name="name">The name of the additional field</param>
    /// <param name="value">The value of the additional field</param>
    public void SetAdditionalField(string name, string value)
    {
        AdditionalFields[name] = value;
    }

    /// <summary>
    /// Sets the entire dictionary of additional fields.
    /// </summary>
    /// <param name="additionalFields">The dictionary of additional fields to set</param>
    public void SetAdditionalFields(Dictionary<string, string> additionalFields)
    {
        AdditionalFields = new Dictionary<string, string>(additionalFields);
    }

    /// <summary>
    /// Calculates the hash code for this AbstractModel object.
    /// Includes detailed hash code calculation for additionalFields.
    /// </summary>
    /// <returns>The hash code value for this object.</returns>
    public override int GetHashCode()
    {
        int result = 17;
        foreach (var entry in AdditionalFields)
        {
            result = 31 * result + entry.Key.GetHashCode();
            result = 31 * result + (entry.Value != null ? entry.Value.GetHashCode() : 0);
        }
        return result;
    }

    /// <summary>
    /// Indicates whether some other object is "equal to" this one.
    /// </summary>
    /// <param name="obj">The reference object with which to compare</param>
    /// <returns>True if this object is the same as the obj argument; false otherwise.</returns>
    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        var that = (AbstractModel)obj;
        if (AdditionalFields.Count != that.AdditionalFields.Count)
        {
            return false;
        }
        return AdditionalFields.All(entry =>
            that.AdditionalFields.TryGetValue(entry.Key, out var value) && 
            entry.Value == value
        );
    }

    /// <summary>
    /// Returns a string representation of this AbstractModel object.
    /// </summary>
    /// <returns>A string representation of the object.</returns>
    public override string ToString()
    {
        var joiner = string.Join(", ", AdditionalFields.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        return $"AbstractModel[{joiner}]";
    }
}
