using pitscout2026.Database;

namespace pitscout2026;

public partial class AirtablePage : ContentPage
{
    private readonly PitDataBase db = new();
    private readonly GlobalViewModel _global;

    public AirtablePage(GlobalViewModel global)
    {
        InitializeComponent();
        _global = global;
        BindingContext = _global;
    }
}