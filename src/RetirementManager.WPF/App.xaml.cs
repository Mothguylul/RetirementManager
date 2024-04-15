using Microsoft.Extensions.DependencyInjection;
using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
using RetirementManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RetirementManager.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<MainViewModel>();
            }

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IRepository, Repository>();
            services.AddScoped<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
