namespace ServiceLib.Common;

/// <summary>
/// Extension methods for country code utilities
/// </summary>
public static class CountryExtension
{
    /// <summary>
    /// Country code to emoji flag mapping for common countries
    /// </summary>
    private static readonly Dictionary<string, string> CountryEmojiMap = new(StringComparer.OrdinalIgnoreCase)
    {
        // Asia
        { "CN", "🇨🇳" }, // China
        { "HK", "🇭🇰" }, // Hong Kong
        { "TW", "🇹🇼" }, // Taiwan
        { "JP", "🇯🇵" }, // Japan
        { "SG", "🇸🇬" }, // Singapore
        { "KR", "🇰🇷" }, // South Korea
        { "TH", "🇹🇭" }, // Thailand
        { "VN", "🇻🇳" }, // Vietnam
        { "ID", "🇮🇩" }, // Indonesia
        { "PH", "🇵🇭" }, // Philippines
        { "MY", "🇲🇾" }, // Malaysia
        { "IN", "🇮🇳" }, // India
        { "PK", "🇵🇰" }, // Pakistan
        { "BD", "🇧🇩" }, // Bangladesh
        { "LK", "🇱🇰" }, // Sri Lanka
        { "KH", "🇰🇭" }, // Cambodia
        { "LA", "🇱🇦" }, // Laos
        { "MM", "🇲🇲" }, // Myanmar

        // Americas
        { "US", "🇺🇸" }, // United States
        { "CA", "🇨🇦" }, // Canada
        { "MX", "🇲🇽" }, // Mexico
        { "BR", "🇧🇷" }, // Brazil
        { "AR", "🇦🇷" }, // Argentina
        { "CL", "🇨🇱" }, // Chile
        { "CO", "🇨🇴" }, // Colombia

        // Europe
        { "GB", "🇬🇧" }, // United Kingdom
        { "DE", "🇩🇪" }, // Germany
        { "FR", "🇫🇷" }, // France
        { "IT", "🇮🇹" }, // Italy
        { "ES", "🇪🇸" }, // Spain
        { "RU", "🇷🇺" }, // Russia
        { "NL", "🇳🇱" }, // Netherlands
        { "CH", "🇨🇭" }, // Switzerland
        { "SE", "🇸🇪" }, // Sweden
        { "NO", "🇳🇴" }, // Norway
        { "DK", "🇩🇰" }, // Denmark
        { "FI", "🇫🇮" }, // Finland
        { "PL", "🇵🇱" }, // Poland
        { "CZ", "🇨🇿" }, // Czech Republic
        { "AT", "🇦🇹" }, // Austria
        { "GR", "🇬🇷" }, // Greece
        { "PT", "🇵🇹" }, // Portugal
        { "TR", "🇹🇷" }, // Turkey
        { "UA", "🇺🇦" }, // Ukraine
        { "RO", "🇷🇴" }, // Romania

        // Middle East & Central Asia
        { "AE", "🇦🇪" }, // United Arab Emirates
        { "SA", "🇸🇦" }, // Saudi Arabia
        { "IL", "🇮🇱" }, // Israel
        { "KZ", "🇰🇿" }, // Kazakhstan

        // Oceania
        { "AU", "🇦🇺" }, // Australia
        { "NZ", "🇳🇿" }, // New Zealand

        // Africa
        { "ZA", "🇿🇦" }, // South Africa
        { "EG", "🇪🇬" }, // Egypt
    };

    /// <summary>
    /// Converts country code to flag emoji using predefined mapping
    /// Example: "US" -> "🇺🇸", "CN" -> "🇨🇳"
    /// </summary>
    public static string? CountryToEmoji(this string? countryCode)
    {
        if (countryCode.IsNullOrEmpty())
        {
            return null;
        }

        return CountryEmojiMap.GetValueOrDefault(countryCode);
    }

    /// <summary>
    /// 国家代码(ISO 3166-1 alpha-2)到中文名称映射,用于在节点列表里显示中文归属地。
    /// </summary>
    private static readonly Dictionary<string, string> CountryZhMap = new(StringComparer.OrdinalIgnoreCase)
    {
        { "CN", "中国" },
        { "HK", "中国香港" },
        { "TW", "中国台湾" },
        { "MO", "中国澳门" },
        { "JP", "日本" },
        { "SG", "新加坡" },
        { "KR", "韩国" },
        { "TH", "泰国" },
        { "VN", "越南" },
        { "ID", "印度尼西亚" },
        { "PH", "菲律宾" },
        { "MY", "马来西亚" },
        { "IN", "印度" },
        { "US", "美国" },
        { "CA", "加拿大" },
        { "MX", "墨西哥" },
        { "BR", "巴西" },
        { "GB", "英国" },
        { "DE", "德国" },
        { "FR", "法国" },
        { "IT", "意大利" },
        { "ES", "西班牙" },
        { "RU", "俄罗斯" },
        { "NL", "荷兰" },
        { "CH", "瑞士" },
        { "SE", "瑞典" },
        { "NO", "挪威" },
        { "DK", "丹麦" },
        { "FI", "芬兰" },
        { "PL", "波兰" },
        { "TR", "土耳其" },
        { "AE", "阿联酋" },
        { "SA", "沙特阿拉伯" },
        { "IL", "以色列" },
        { "AU", "澳大利亚" },
        { "NZ", "新西兰" },
        { "ZA", "南非" },
        { "EG", "埃及" },
    };

    /// <summary>
    /// 国家代码转中文名称;找不到则返回原始代码。
    /// Example: "US" -> "美国", "DE" -> "德国"
    /// </summary>
    public static string CountryToZh(this string? countryCode)
    {
        if (countryCode.IsNullOrEmpty())
        {
            return string.Empty;
        }

        return CountryZhMap.GetValueOrDefault(countryCode, countryCode);
    }
}
