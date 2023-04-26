﻿using System.ComponentModel;
using WpfDINavigation.Services;
using WpfDINavigation.Stores;

namespace WpfDINavigation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly MainNavigationStore _mainNavigationStore;
        private INotifyPropertyChanged? _currentViewModel;

		private void CurrentViewModelChanged()
		{
			CurrentViewModel = _mainNavigationStore.CurrentViewModel;
		}

		public MainViewModel(MainNavigationStore mainNavigationStore, INavigationService navigationService)
		{
            _mainNavigationStore = mainNavigationStore;
            _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
			navigationService.Navigate(NaviType.LoginView);
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
