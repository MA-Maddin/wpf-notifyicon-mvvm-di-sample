using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotifyIconMvvmDISample.Services;

namespace NotifyIconMvvmDISample.ViewModels
{
    public partial class PopupViewModel : ObservableObject
    {
        private readonly INotifyIconService _notifyIconService;

        [ObservableProperty]
        private string title = "Popup Title";
        [ObservableProperty]
        private string message = "This is a popup message.";

        public PopupViewModel(INotifyIconService notifyIconService)
        {
            _notifyIconService = notifyIconService;
        }

        [RelayCommand]
        private void Close()
        {
            _notifyIconService.ClosePopup();
        }
    }
}
