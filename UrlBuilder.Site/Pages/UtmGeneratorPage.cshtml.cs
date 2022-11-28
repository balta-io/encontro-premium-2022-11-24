using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UtmBuilder;

namespace UrlBuilder.Site.Pages;

public class UtmGeneratorPage : PageModel
{
    [BindProperty]
    public Model Input { get; set; } = new();

    public class Model
    {
        [Required(ErrorMessage = "Website URL is required")]
        [DataType(DataType.Url, ErrorMessage = "Invalid URL")]
        [MinLength(11, ErrorMessage = "URL min chars: 11")]
        public string WebsiteUrl { get; set; } = "https://go.balta.io";

        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; } = string.Empty;

        [Required(ErrorMessage = "Medium is required")]
        public string Medium { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        public string Term { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        try
        {
            var url = new Utm(
                Input.WebsiteUrl,
                Input.Source,
                Input.Medium,
                Input.Name,
                Input.Id,
                Input.Term,
                Input.Content);
            Input.Url = url.ToString();
        }
        catch (Exception ex)
        {
            Input.Url = ex.Message;
        }
    }
}