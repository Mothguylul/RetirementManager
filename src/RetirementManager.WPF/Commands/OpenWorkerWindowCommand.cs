using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using RetirementManager.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace RetirementManager.WPF.Commands
{
    public class OpenWorkerWindowCommand : CommandBase
    {

        public override void Execute(object? parameter)
        {
            AddOrEditWorker addoreditworker = new AddOrEditWorker();

            Worker? worker = parameter as Worker;
            addoreditworker.DataContext = new EditableWorker(worker);
            addoreditworker.Show();
        }

        public override bool CanExecute(object? parameter)
        {
            return parameter is "Add" || parameter as Worker is not null;  
        }
    }
}
