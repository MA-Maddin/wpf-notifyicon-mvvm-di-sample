using Hardcodet.Wpf.TaskbarNotification;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotifyIconMvvmDISample.Services;
using NotifyIconMvvmDISample.ViewModels;
using NotifyIconMvvmDISample.Views;
using System.Windows;

namespace NotifyIconMvvmDISample
{
    public partial class App : Application
    {
        private IHost? _host;

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INotifyIconService, NotifyIconService>();

                    services.AddTransient<NotifyIconViewModel>();

                    services.AddTransient<PopupViewModel>();
                    services.AddTransient<PopupView>();
                })
                .Build();

            // Uncomment the following line if you have any IHostedService that need to be started (if you have used services.AddHostedService)
            //await _host.StartAsync();

            var taskbarIcon = (TaskbarIcon)Current.FindResource("NotifyIcon");
            taskbarIcon.DataContext = _host.Services.GetRequiredService<NotifyIconViewModel>();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (_host != null)
            {
                await _host.StopAsync();

                if (_host is IAsyncDisposable asyncDisposable)
                    await asyncDisposable.DisposeAsync();
                else
                    _host.Dispose();
            }

            base.OnExit(e);
        }
    }
}
