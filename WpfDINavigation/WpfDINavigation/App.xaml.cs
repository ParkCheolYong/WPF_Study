using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfDINavigation.Services;
using WpfDINavigation.Stores;
using WpfDINavigation.ViewModels;
using WpfDINavigation.Views;

namespace WpfDINavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // stores
            services.AddSingleton<MainNavigationStore>();
            services.AddSingleton<SignupStore>();
            services.AddSingleton<LeftStore>();
            services.AddSingleton<RightStore>();

            // services
            services.AddSingleton<INavigationService, NavigationService>();

            // ViewModels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<SignupViewModel>();
            services.AddSingleton<TestViewModel>();
            services.AddSingleton<LeftViewModel>();
            services.AddSingleton<RightViewModel>();

            // Views
            services.AddSingleton(s => new MainView() 
            { 
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            return services.BuildServiceProvider();
        }

        public App()
        {
            Services = ConfigureServices();

            var mainView = Services.GetRequiredService<MainView>();
            mainView.Show();
        }

        public IServiceProvider Services { get; }
    }
}
