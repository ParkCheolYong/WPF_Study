using System.Windows.Input;
using WpfDINavigation.Commands;
using WpfDINavigation.Services;
using WpfDINavigation.Stores;

namespace WpfDINavigation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly SignupStore _signupStore;
        private string _id = "";
        private string _password = "";

        private void ToSignup(object _)
        {
            _signupStore.CurrentAccount = new Models.Account { Id = Id , Password = Password};
            _navigationService.Navigate(NaviType.SignupView);
        }

        private void ToTest(object _)
        {
            _navigationService.Navigate(NaviType.TestView);
        }

        public LoginViewModel(INavigationService navigationService, SignupStore signupStore)
        {
            _navigationService = navigationService;
            _signupStore = signupStore;

            ToSignupCommand = new RelayCommand<object>(ToSignup);
            ToTestCommand = new RelayCommand<object>(ToTest);
        }

        public ICommand ToSignupCommand { get; set; }
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
    }
}
