namespace UtmBuilder.Mobile;

public partial class MainPage : ContentPage
{
    public MainPageViewModel ViewModel { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        this.BindingContext = ViewModel;
    }
}

