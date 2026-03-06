using Hardcodet.Wpf.TaskbarNotification;
using Microsoft.Extensions.DependencyInjection;
using NotifyIconMvvmDISample.Views;
using System.Windows;

namespace NotifyIconMvvmDISample.Services
{
    public interface INotifyIconService
    {
        public void ShowPopup();
        public void ClosePopup();
    }

    public class NotifyIconService : INotifyIconService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly TaskbarIcon _taskbarIcon;

        private bool _isPopupInitialized;

        public NotifyIconService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _taskbarIcon = (TaskbarIcon)Application.Current.FindResource("NotifyIcon");
        }

        public void ClosePopup()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _taskbarIcon.CloseTrayPopup();
            });
        }

        public void ShowPopup()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                EnsurePopupCreated();
                _taskbarIcon.ShowTrayPopup();
            });
        }

        private void EnsurePopupCreated()
        {
            if (_isPopupInitialized)
                return;

            var view = _serviceProvider.GetRequiredService<PopupView>();
            _taskbarIcon.TrayPopup = view;

            _isPopupInitialized = true;
        }
    }
}
