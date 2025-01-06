namespace inter_sdk_library;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// The {@code Summary} class represents a collection of SummaryItem objects.
/// </summary>

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class Summary : List<SummaryItem>
{
    // A class derived from List<SummaryItem> does not require any additional implementation.
}
