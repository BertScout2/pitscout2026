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

    private async void AirtableSend_Clicked(object? sender, EventArgs e)
    {
        try
        {
            AirtableDoneLabel.Text = "";
            ErrorLabel.IsVisible = false;
            _global.AirtableUploadCount = 0;
            AirtableSend.IsEnabled = false;
            var pitRecords = await db.GetPitItemsAsync();
            _global.AirtableUploadCount = await AirtableDatabase.AirtableSendRecords(pitRecords);
            foreach (var item in pitRecords)
            {
                if (item.Changed)
                {
                    item.Changed = false;
                    await db.SavePitScoutItemAsync(item);
                }
            }
            AirtableDoneLabel.Text = "Done!";
            AirtableSend.IsEnabled = true;
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = ex.Message;
            ErrorLabel.IsVisible = true;
        }
    }
}