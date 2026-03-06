using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotifyIconMvvmDISample.Services;
using System.Windows;

namespace NotifyIconMvvmDISample.ViewModels
{
    public partial class NotifyIconViewModel : ObservableObject
    {
        private readonly INotifyIconService _notifyIconService;

        public NotifyIconViewModel(INotifyIconService notifyIconService)
        {
            _notifyIconService = notifyIconService;
        }

        [RelayCommand]
        private void Show()
        {
            _notifyIconService.ShowPopup();
        }

        [RelayCommand]
        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
