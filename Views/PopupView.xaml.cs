using NotifyIconMvvmDISample.ViewModels;
using System.Windows.Controls;

namespace NotifyIconMvvmDISample.Views
{
    public partial class PopupView : UserControl
    {
        public PopupViewModel ViewModel => (PopupViewModel)DataContext;

        public PopupView(PopupViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
