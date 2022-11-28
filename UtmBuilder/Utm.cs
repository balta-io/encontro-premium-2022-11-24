using System.Text.RegularExpressions;
using UtmBuilder.Exceptions;

namespace UtmBuilder;

// Urchin Traffic Monitor
public class Utm
{
    private const string UrlRegexPattern =
        @"^(http|https):(\/\/www\.|\/\/www\.|\/\/|\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$|(http|https):(\/\/localhost:\d*|\/\/127\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\/.*)?$";

    /// <summary>
    /// Generate a new UTM
    /// </summary>
    /// <param name="url">Website URL</param>
    /// <param name="source">The referrer (e.g. google, newsletter)</param>
    /// <param name="medium">Marketing medium (e.g. cpc, banner, email)</param>
    /// <param name="name">Product, promo code, or slogan (e.g. spring_sale) One of campaign name or campaign id are required.</param>
    public Utm(string url,
        string source,
        string medium,
        string name)
    {
        Url = url;
        Campaign = new Campaign(source, medium, name);

        if (!Regex.IsMatch(Url, UrlRegexPattern))
            throw new InvalidUtmException("Invalid URL");
    }

    /// <summary>
    /// Generate a new UTM
    /// </summary>
    /// <param name="url">Website URL</param>
    /// <param name="source">The referrer (e.g. google, newsletter)</param>
    /// <param name="medium">Marketing medium (e.g. cpc, banner, email)</param>
    /// <param name="name">Product, promo code, or slogan (e.g. spring_sale) One of campaign name or campaign id are required.</param>
    /// <param name="id">The ads campaign id.</param>
    /// <param name="term">Identify the paid keywords</param>
    /// <param name="content">Use to differentiate ads</param>
    public Utm(string url,
        string source,
        string medium,
        string name,
        string? id = null,
        string? term = null,
        string? content = null)
    {
        Url = url;
        Campaign = new Campaign(source, medium, name, id, term, content);
        
        if (!Regex.IsMatch(Url, UrlRegexPattern))
            throw new InvalidUtmException("Invalid URL");
    }

    public string Url { get; }
    public Campaign Campaign { get; }

    public override string ToString() =>
        $"{Url}?utm_source={Campaign.Source}&utm_medium={Campaign.Medium}&utm_campaign={Campaign.Name}&utm_id={Campaign.Id}&utm_term={Campaign.Term}&utm_content={Campaign.Content}";
}