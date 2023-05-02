using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfTutorials.DesignPattern.Models;
using WpfTutorials.DesignPattern.MVVM.ViewModels;

namespace WpfTutorials.DesignPattern.MVVM.Commands
{
    public class SaveCommand : CommandBase
    {
        private MainViewModel _mainViewModel;
        private IPersonRepository _personRepository;

        private Person GetPerson()
        {
            var person =  new Person
            {
                Name = _mainViewModel.Name,
                Sex = _mainViewModel.Sex,
            };

            int.TryParse(_mainViewModel.Id, out int id);
            int.TryParse(_mainViewModel.Age, out int age);
            person.Id = id;
            person.Age = age;

            return person;
        }

        private bool IsValidSave(Person person) => person switch
        {
            { Id: int id } when id <= 0 => false,
            { Name: string name } when string.IsNullOrEmpty(name) => false,
            { Sex: string sex } when string.IsNullOrEmpty(sex) => false,
            { Age: int age } when age <= 0 => false,
            _ => true
        };

        private void Save()
        {
            var person = GetPerson();
            _personRepository.SaveOne(person);
        }

        public SaveCommand(MainViewModel mainViewModel, IPersonRepository personRepository)
        {
            _mainViewModel = mainViewModel;
            _personRepository = personRepository;
        }

        public override bool CanExecute(object? parameter)
        {
            return IsValidSave(GetPerson());
        }

        public override void Execute(object? parameter)
        {
            Save();
        }
    }
}

