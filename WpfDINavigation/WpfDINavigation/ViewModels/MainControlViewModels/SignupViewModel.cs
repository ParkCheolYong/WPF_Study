﻿using System.Windows.Input;
using WpfDINavigation.Commands;
using WpfDINavigation.Models;
using WpfDINavigation.Services;
using WpfDINavigation.Stores;

namespace WpfDINavigation.ViewModels
{
    public class SignupViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly SignupStore _signupStore;
        private readonly LeftStore _leftStore;
        private string _id = "";
        private string _password = "";
        private string _name = "";
        private string _email = "";

        private Account CurrentAccount => _signupStore.CurrentAccount!;

        private void ToLogin(object _)
        {
            _navigationService.Navigate(NaviType.LoginView);
        }

        private void ToTest(object _)
        {
            _leftStore.CurrentAccount = new Account() 
            {
                Id = Id,
                Password = Password,
                Name = Name,
                Email = Email
            };
            _navigationService.Navigate(NaviType.TestView);
        }

        private void Initialize()
        {
            Id = CurrentAccount.Id;
            Password = CurrentAccount.Password;
        }

        public SignupViewModel(INavigationService navigationService, SignupStore signupStore, LeftStore leftStore)
        {
            _navigationService = navigationService;
            _signupStore = signupStore;
            _leftStore = leftStore;

            Initialize();

            ToLoginCommand = new RelayCommand<object>(ToLogin);
            ToTestCommand = new RelayCommand<object>(ToTest);
        }

        public ICommand ToLoginCommand { get; set; }
        public ICommand ToTestCommand { get; set; }

        public string Id
        {
            get { return _id; }
            set
            {
                if (_id != null)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != null)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != null)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != null)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
