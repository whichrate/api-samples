using Newtonsoft.Json;

namespace WhichrateClient.Models;

/// <summary>
/// A search request made to the WhichRate API.
/// </summary>
public sealed class SearchRequest
{
    /// <summary>
    /// Default value for the <see cref="Dob"/> property.
    /// </summary>
    public const string DefaultDob = "standard driver";
        
    /// <summary>
    /// Gets or sets the start of hire.
    /// </summary>
    [JsonProperty("hire_date")]
    public string HireDate { get; set; }
        
    /// <summary>
    /// Gets or sets the postcode.
    /// </summary>
    [JsonProperty("postcode")]
    public string Postcode { get; set; }
        
    /// <summary>
    /// Gets or sets the length of hire in days.
    /// </summary>
    [JsonProperty("hire_duration")]
    public int HireDuration { get; set; }
        
    /// <summary>
    /// Gets or sets the vehicle registration number.
    /// </summary>
    [JsonProperty("vrn")]
    public string Vrn { get; set; }
        
    /// <summary>
    /// Gets or sets an optional email address to receive a report.
    /// </summary>
    [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }
        
    /// <summary>
    /// Gets or sets a value indicating whether to search for automatic vehicles only.
    /// </summary>
    [JsonProperty("automatic")]
    public bool Automatic { get; set; }
        
    /// <summary>
    /// Gets or sets the date of birth of the youngest driver.
    /// </summary>
    [JsonProperty("DOB", NullValueHandling = NullValueHandling.Ignore)]
    public string Dob { get; set; }
        
    /// <summary>
    /// Gets or sets the number of additional drivers.
    /// </summary>
    [JsonProperty("additional_drivers")]
    public int AdditionalDrivers { get; set; }
}