using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UtmBuilder.Mobile;

public sealed partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Url))]
    private string websiteUrl;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Url))]
    private string id;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Url))]
    private string source;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Url))]
    private string medium;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Url))]
    private string name;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Url))]
    private string term;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Url))]
    private string content;

    public string Url
    {
        get
        {
            try
            {
                var utm = new Utm(websiteUrl, source, medium, name, id, term, content);
                return utm.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    [RelayCommand]
    private async Task CopyToClipboard()
    {
        await Clipboard.Default.SetTextAsync(Url);
        await Application.Current.MainPage.DisplayAlert("Copied!!!", "URL copied to clipboard", "OK");
    }
}


