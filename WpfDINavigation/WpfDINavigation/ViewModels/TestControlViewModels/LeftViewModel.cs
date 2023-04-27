using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDINavigation.Commands;
using WpfDINavigation.Models;
using WpfDINavigation.Stores;

namespace WpfDINavigation.ViewModels
{
    public class LeftViewModel : ViewModelBase
    {
        private readonly LeftStore _leftStore;
        private readonly RightStore _rightStore;
        private string _id = "";
        private string _password = "";
        private string _name = "";
        private string _email = "";

        private Account CurrentAccount => _leftStore.CurrentAccount!;

        private void Initialize()
        {
            Id = CurrentAccount.Id;
            Password = CurrentAccount.Password;
            Name = CurrentAccount.Name;
            Email = CurrentAccount.Email;
        }

        private void SendAccountToRight(object _)
        {
            _rightStore.CurrentAccount = new Account
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

        public LeftViewModel(LeftStore leftStore, RightStore rightStore)
        {
            _leftStore = leftStore;
            _rightStore = rightStore;
            SendAccountToRightCommand = new RelayCommand<object>(SendAccountToRight);
            Initialize();

            _leftStore.CurrentAccountChanged += CurrentAccountChanged;
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

        public ICommand SendAccountToRightCommand { get; set; }
    }
}
