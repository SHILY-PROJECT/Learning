using System.Net;
using System.Text.Json;
using DefinerIpDataDemo.Core.Models;

namespace DefinerIpDataDemo.Core;

internal class Definer
{
    public static bool TryDefineIpData(out IpData userData)
        => (userData = DefineIpDataAsync("").Result).IsSuccess;

    public static bool TryDefineIpData(string ip, out IpData userData)
        => (userData = DefineIpDataAsync(ip).Result).IsSuccess;

    public static async Task<IpData> DefineIpDataAsync()
        => await DefineIpDataAsync("");

    public static async Task<IpData> DefineIpDataAsync(string ip)
    {
        try
        {
            if (!string.IsNullOrEmpty(ip) && !IPAddress.TryParse(ip, out _))
                throw new ArgumentException("Invalid ip address.");

            using var httpClient = new HttpClient();
            var response = await (await httpClient.GetAsync($"http://ip-api.com/json/{ip}")).Content.ReadAsStringAsync();

            if (JsonSerializer.Deserialize<IpData>(response) is IpData res && res.Status.Contains("success", StringComparison.OrdinalIgnoreCase))
            {
                return res with { IsSuccess = true };
            }
            else throw new InvalidOperationException("Failed to receive data from the service.");
        }
        catch (Exception ex)
        {
            return new IpData { ErrorMessage = ex.Message, IsSuccess = false };
        }
    }
}