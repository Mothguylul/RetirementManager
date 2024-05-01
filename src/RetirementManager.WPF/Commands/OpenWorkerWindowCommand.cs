using RetirementManager.Domain.Interfaces;
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

        private IRepository<Worker> _repository;
        public OpenWorkerWindowCommand(IRepository<Worker> repository) 
        {
            _repository = repository;
        }

        public override void Execute(object? parameter)
        {
            AddOrEditWorker addoreditworker = new AddOrEditWorker();

            WorkerStatusViewModel? worker = parameter as WorkerStatusViewModel;
            addoreditworker.DataContext = new EditableWorker(worker, _repository, addoreditworker);
            addoreditworker.Show();
        }

        public override bool CanExecute(object? parameter)
        {
            return parameter is "Add" || parameter as WorkerStatusViewModel is not  null;  
        }
    }
}
