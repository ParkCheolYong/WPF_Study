using KabulTalk.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KabulTalk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            var mainView = App.Current.Services.GetService<MainView>();
            mainView?.Show();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }
 
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Services
            //services.AddSingleton<ITestService, TestServices>();

            // Views
            services.AddSingleton<MainView>();

            return services.BuildServiceProvider();
        }
    }
}
