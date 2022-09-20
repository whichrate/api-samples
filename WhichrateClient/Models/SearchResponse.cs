using Newtonsoft.Json;

namespace WhichrateClient.Models;

/// <summary>
/// A search response from the WhichRate API.
/// </summary>
public sealed class SearchResponse
{
    /// <summary>
    /// Gets or sets the from date for the search results.
    /// </summary>
    [JsonProperty("date_from")]
    public string DateFrom { get; set; }
    
    /// <summary>
    /// Gets or sets the one day hire price.
    /// </summary>
    [JsonProperty("price_1")]
    public decimal Price1 { get; set; }
    
    /// <summary>
    /// Gets or sets the seven day hire price.
    /// </summary>
    [JsonProperty("price_7")]
    public decimal Price7 { get; set; }
    
    /// <summary>
    /// Gets or sets the provider name.
    /// </summary>
    [JsonProperty("provider_name")]
    public string ProviderName { get; set; }
    
    /// <summary>
    /// Gets or sets the vehicle model.
    /// </summary>
    [JsonProperty("model")]
    public string Model { get; set; }
    
    /// <summary>
    /// Gets or sets the vehicle transmission.
    /// </summary>
    [JsonProperty("transmission")]
    public string Transmission { get; set; }
    
    /// <summary>
    /// Gets or sets the vehicle body type.
    /// </summary>
    [JsonProperty("body_type")]
    public string BodyType { get; set; }
    
    /// <summary>
    /// Gets or sets the ABI.
    /// </summary>
    [JsonProperty("abi")]
    public string Abi { get; set; }
    
    /// <summary>
    /// Gets or sets the location name.
    /// </summary>
    [JsonProperty("location_name")]
    public string LocationName { get; set; }
    
    /// <summary>
    /// Gets or sets the postcode.
    /// </summary>
    [JsonProperty("postcode")]
    public string Postcode { get; set; }
    
    /// <summary>
    /// Gets or sets the premium location e.g. airports, train stations.
    /// </summary>
    [JsonProperty("is_premium")]
    public int IsPremium { get; set; }
    
    /// <summary>
    /// Gets or sets the distance in miles.
    /// </summary>
    [JsonProperty("distance")]
    public double Distance { get; set; }
    
    /// <summary>
    /// Gets or sets number of days.
    /// </summary>
    [JsonProperty("days")]
    public int Days { get; set; }
    
    /// <summary>
    /// Gets or sets the standard driver minimum age.
    /// </summary>
    [JsonProperty("std_min_age")]
    public int? StdMinAge { get; set; }
    
    /// <summary>
    /// Gets or sets the young driver minimum age.
    /// </summary>
    [JsonProperty("yng_min_age")]
    public int? YngMinAge { get; set; }
    
    /// <summary>
    /// Gets or sets the young driver charge per day.
    /// </summary>
    [JsonProperty("yng_day_charge")]
    public decimal? YngDayCharge { get; set; }
    
    /// <summary>
    /// Gets or sets the young driver chargeable days cap per hire cycle.
    /// </summary>
    [JsonProperty("yng_days_cap")]
    public int? YngDaysCap { get; set; }
    
    /// <summary>
    /// Gets or sets the young driver maximum charge per hire cycle.
    /// </summary>
    [JsonProperty("yng_max_charge")]
    public decimal? YngMaxCharge { get; set; }
    
    /// <summary>
    /// Gets or sets the young driver chargeable days cap per hire.
    /// </summary>
    [JsonProperty("yng_days_cap_full")]
    public int? YngDaysCapFull { get; set; }
    
    /// <summary>
    /// Gets or sets the additional driver day charge.
    /// </summary>
    [JsonProperty("add_days_charge")]
    public decimal? AddDaysCharge { get; set; }
    
    /// <summary>
    /// Gets or sets the additional driver chargeable days cap per hire cycle.
    /// </summary>
    [JsonProperty("add_days_cap")]
    public int? AddDaysCap { get; set; }
    
    /// <summary>
    /// Gets or sets the additional driver max charge per hire cycle.
    /// </summary>
    [JsonProperty("add_max_charge")]
    public decimal? AddMaxCharge { get; set; }
    
    /// <summary>
    /// Gets or sets the additional driver chargeable days cap per hire.
    /// </summary>
    [JsonProperty("add_days_cap_full")]
    public int? AddDaysCapFull { get; set; }
    
    /// <summary>
    /// Gets or sets the excess reduction minimum age.
    /// </summary>
    [JsonProperty("reduce_min_age")]
    public int? ReduceMinAge { get; set; }
    
    /// <summary>
    /// Gets or sets the excess reduction max charge per hire cycle.
    /// </summary>
    [JsonProperty("reduce_max_charge")]
    public decimal? ReduceMaxCharge { get; set; }
    
    /// <summary>
    /// Gets or sets the excess reduction day charge.
    /// </summary>
    [JsonProperty("reduce_day_charge")]
    public decimal? ReduceDayCharge { get; set; }
    
    /// <summary>
    /// Gets or sets the excess reduction chargeable days cap per hire cycle.
    /// </summary>
    [JsonProperty("reduce_days_cap")]
    public int? ReduceDaysCap { get; set; }
    
    /// <summary>
    /// Gets or sets the excess value lower limit.
    /// </summary>
    [JsonProperty("reduce_excess_from")]
    public decimal? ReduceExcessFrom { get; set; }
    
    /// <summary>
    /// Gets or sets the excess value upper limit.
    /// </summary>
    [JsonProperty("reduce_excess_to")]
    public decimal? ReduceExcessTo { get; set; }
    
    /// <summary>
    /// Gets or sets the length of the hire cycle.
    /// </summary>
    [JsonProperty("days_in_term")]
    public int DaysInTerm { get; set; }
}