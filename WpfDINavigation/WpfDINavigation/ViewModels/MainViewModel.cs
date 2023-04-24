using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WpfDINavigation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
		private INotifyPropertyChanged? _currentViewModel;

		public MainViewModel()
		{
            CurrentViewModel = new LoginViewModel();
		}

		public INotifyPropertyChanged? CurrentViewModel
		{
			get { return _currentViewModel; }
			set 
			{
				if(_currentViewModel != value)
				{
                    _currentViewModel = value;
					OnPropertyChanged();

                }
			}
		}

	}
}
