using System;
using WpfTutorials.DesignPattern.Models;
using WpfTutorials.DesignPattern.MVC.Views;

namespace WpfTutorials.DesignPattern.MVC.Controllers
{
    public class MainController
    {
        private readonly IMainView _view;
        private readonly IPersonRepository _personRepository;

        private Person GetPersonFromView()
        {
            return new Person
            {
                Id = _view.Id,
                Name = _view.Name,
                Sex = _view.Sex,
                Age = _view.Age
            };
        }

        private bool IsValidSave(Person person) => person switch
        {
            { Id: int id } when id <= 0 => false,
            { Name: string name } when string.IsNullOrEmpty(name) => false,
            { Sex: string sex } when string.IsNullOrEmpty(sex) => false,
            { Age: int age } when age <= 0 => false,
            _ => true
        };

        public MainController(IMainView view, IPersonRepository personRepository)
        {
            _view = view;
            _personRepository = personRepository;
            _view.SetController(this);
        }

        internal bool Save()
        {
            Person person = GetPersonFromView();

            if (!IsValidSave(person)) return false;

            return _personRepository.SaveOne(person);
        }

        internal void Cancel()
        {
            _view.Id = 0;
            _view.Name = string.Empty;
            _view.Sex = string.Empty;
            _view.Age = 0;
        }

        internal bool Delete()
        {
            return _personRepository.DeleteOne(_view.Id);
        }

        internal void Display()
        {
            _view.ItemSource = _personRepository.GetAll()!;
        }
    }
}
