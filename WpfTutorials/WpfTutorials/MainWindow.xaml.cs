using System.Windows;
using WpfTutorials.DesignPattern.MVC.Controllers;
using WpfTutorials.DesignPattern.MVP.Presenters;

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

        /// <summary>
        /// MVC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MVCBtn_Click(object sender, RoutedEventArgs e)
        {
            var mainView = new DesignPattern.MVC.Views.MainView();
            var personRepository = new DesignPattern.Models.PersonRepository();
            _ = new MainController(mainView, personRepository);
            mainView.Show();
        }

        /// <summary>
        /// MVP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MVPBtn_Click(object sender, RoutedEventArgs e)
        {
            var mainView = new DesignPattern.MVP.Views.MainView();
            var personRepository = new DesignPattern.Models.PersonRepository();
            _ = new MainPresenter(mainView, personRepository);
            mainView.Show();
        }

        /// <summary>
        /// MVVM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MVVMBtn_Click(object sender, RoutedEventArgs e)
        {
            var personRepository = new DesignPattern.Models.PersonRepository();

            var mainView = new DesignPattern.MVVM.Views.MainView()
            {
                DataContext = new DesignPattern.MVVM.ViewModels.MainViewModel(personRepository)
            };

            mainView.Show();
        }
    }
}
