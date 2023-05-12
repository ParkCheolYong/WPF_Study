using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfDIShowViews.Models;

namespace WpfDIShowViews.Services
{
    public interface IViewService
    {
        void ShowView<TView, TViewModel>(object? parameter = null) 
            where TView : Window 
            where TViewModel : INotifyPropertyChanged;

        void ShowMainView();

        void ShowSubView(SubData subData);
    }
}
