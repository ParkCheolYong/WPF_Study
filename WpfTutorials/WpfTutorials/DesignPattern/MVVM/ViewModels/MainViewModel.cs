using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfTutorials.DesignPattern.Models;
using WpfTutorials.DesignPattern.MVVM.Commands;

namespace WpfTutorials.DesignPattern.MVVM.ViewModels
{
    public class MainViewModel
    {
        private readonly IPersonRepository _personRepository;

        public MainViewModel(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

            SaveCommand = new SaveCommand(this, personRepository);
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
    }
}
