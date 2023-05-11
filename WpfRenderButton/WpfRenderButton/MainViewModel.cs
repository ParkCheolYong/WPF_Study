using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRenderButton
{
    public partial class MainViewModel : ObservableObject
    {
        private int _value = 100;
        private double _opacity = 1;

        [RelayCommand]
        private void Decrease()
        {
            Value -= 1;
        }

        [RelayCommand]
        private void Increase()
        {
            Value += 1;
        }

        public int Value
        {
            get => _value; 
            set
            {
                if (value < 0 || value > 100) return;

                _value = value;
                OnPropertyChanged();
            }
        }

        public double Opacity
        {
            get => _opacity;
            set 
            {
                if (value < 0 || value > 1) return;
                _opacity = value;
                OnPropertyChanged();
            }
        }
    }
}
