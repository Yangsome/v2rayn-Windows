namespace ServiceLib.Models.Dto;

internal class IPAPIInfo
{
    public string? ip { get; set; }
    public string? clientIp { get; set; }
    public string? ip_addr { get; set; }
    public string? query { get; set; }
    public string? country { get; set; }
    public string? country_name { get; set; }
    public string? country_code { get; set; }
    public string? countryCode { get; set; }
    public LocationInfo? location { get; set; }
}

public class LocationInfo
{
    public string? country_code { get; set; }
}

public readonly record struct IpInfoResult(string Country, string? Ip)
{
    public override string ToString()
    {
        // 节点列表显示中文归属地:如 "美国 104.28.158.90";非 Windows 平台保留国旗 emoji
        var zh = Country.CountryToZh();
        var label = string.IsNullOrEmpty(zh) ? Country : zh;
        if (Utils.IsWindows())
        {
            return $"({label}) {Ip}";
        }

        var emoji = Country.CountryToEmoji();
        var prefix = string.IsNullOrEmpty(emoji) ? label : $"{emoji} {label}";
        return $"({prefix}) {Ip}";
    }
}
