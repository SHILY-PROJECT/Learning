using System.Text.Json.Serialization;

namespace IdentifyUserDataByIp.Core.Models;

internal record IpData
{
    public string ErrorMessage { get; init; } = string.Empty;
    public bool IsSuccess { get; init; }

    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    [JsonPropertyName("query")]
    public string? Query { get; init; }

    [JsonPropertyName("country")]
    public string? Country { get; init; }

    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; init; }

    [JsonPropertyName("region")]
    public string? Region { get; init; }

    [JsonPropertyName("regionName")]
    public string? RegionName { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("zip")]
    public string? Zip { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    [JsonPropertyName("isp")]
    public string? Isp { get; init; }

    [JsonPropertyName("org")]
    public string? Org { get; init; }

    [JsonPropertyName("as")]
    public string? As { get; init; }

    [JsonPropertyName("lat")]
    public float Lat { get; init; }

    [JsonPropertyName("lon")]
    public float Lon { get; init; }
}