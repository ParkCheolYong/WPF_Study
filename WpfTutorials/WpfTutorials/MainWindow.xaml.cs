using System.Windows;
using WpfTutorials.DesignPattern.Models;
using WpfTutorials.DesignPattern.MVC.Controllers;
using WpfTutorials.DesignPattern.MVC.Views;

namespace WpfTutorials
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MVCBtn_Click(object sender, RoutedEventArgs e)
        {
            var mainView = new MainView();
            var personRepository = new PersonRepository();
            _ = new MainController(mainView, personRepository);
            mainView.Show();
        }
    }
}
