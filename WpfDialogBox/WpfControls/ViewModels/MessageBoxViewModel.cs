using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfControls.Enums;

namespace WpfControls.ViewModels
{
    public partial class MessageBoxViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = string.Empty;

        [ObservableProperty]
        private string _message = string.Empty;

        [ObservableProperty]
        private string _okText = string.Empty;

        [ObservableProperty]
        private string? _noText;

        [ObservableProperty]
        private string? _cancelText;

        [ObservableProperty]
        private Visibility _noVisibility;

        [ObservableProperty]
        private Visibility _cancelVisibility;

        public MessageBoxExResult MessageBoxExResult { get; set; } = MessageBoxExResult.Cancel;

        [RelayCommand]
        private void Ok(Window window)
        {
            MessageBoxExResult = MessageBoxExResult.Ok;
            window.DialogResult = true;
        }

        [RelayCommand]
        private void No(Window window)
        {
            MessageBoxExResult = MessageBoxExResult.No;
            window.DialogResult = false;
        }

        public MessageBoxViewModel(string title, string message, string okText, string? noText, string? cancelText)
        {
            Title = title;
            Message = message;
            OkText = okText;
            NoText = noText;
            CancelText = cancelText;

            NoVisibility = string.IsNullOrEmpty(noText) ? Visibility.Collapsed : Visibility.Visible;
            CancelVisibility = string.IsNullOrEmpty(cancelText) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
