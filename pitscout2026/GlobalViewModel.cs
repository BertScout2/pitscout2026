using System.ComponentModel;

namespace pitscout2026;

public partial class GlobalViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public int AirtableUploadCount
    {
        get
        {
            return Global.AirtableUploadCount;
        }
        set
        {
            if ((Global.AirtableUploadCount != value) && (value >= 0))
            {
                Global.AirtableUploadCount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AirtableUploadCount)));
            }
        }
    }
}
