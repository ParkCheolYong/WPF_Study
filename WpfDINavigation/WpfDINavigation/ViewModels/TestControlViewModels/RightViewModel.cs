using System.Windows.Input;
using WpfDINavigation.Commands;
using WpfDINavigation.Models;
using WpfDINavigation.Stores;

namespace WpfDINavigation.ViewModels
{
    public class RightViewModel : ViewModelBase
    {
        private string _id = "";
        private string _password = "";
        private string _name = "";
        private string _email = "";
        private readonly RightStore _rightStore;
        private readonly LeftStore _leftStore;

        private Account CurrentAccount => _rightStore.CurrentAccount!;

        private void SendAccountToLeft(object _)
        {
            _leftStore.CurrentAccount = new Account
            {
                Id = Id,
                Password = Password,
                Name = Name,
                Email = Email
            };
        }

        private void CurrentAccountChanged(Account account)
        {
            Id = account.Id;
            Password = account.Password;
            Name = account.Name;
            Email = account.Email;
        }

        public RightViewModel(RightStore rightStore, LeftStore leftStore)
        {
            _rightStore = rightStore;
            _leftStore = leftStore;
            _rightStore.CurrentAccountChanged += CurrentAccountChanged;

            SendAccountToLeftCommand = new RelayCommand<object>(SendAccountToLeft);
        }

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

        public ICommand SendAccountToLeftCommand { get; set; }
    }
}
