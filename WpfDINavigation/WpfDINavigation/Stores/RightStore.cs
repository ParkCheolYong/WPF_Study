using System;
using WpfDINavigation.Models;

namespace WpfDINavigation.Stores
{
    public class RightStore
    {
        private Account? _currentAccount;

        public Account? CurrentAccount 
        { 
            get => _currentAccount; 
            set
            {
                _currentAccount = value;
                CurrentAccountChanged?.Invoke(_currentAccount!);
                _currentAccount = null;
            }
        }

        public Action<Account>? CurrentAccountChanged { get; set; }
    }
}
