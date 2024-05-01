using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RetirementManager.WPF.Commands
{
    public class SaveWorkerCommand : CommandBase
    {
        public static event Action? WorkersUpdated;

        private IRepository<Worker> _repository;

        private Window _workerWindow;

        public SaveWorkerCommand(IRepository<Worker> repository, Window workerWindow)
        {
            _repository = repository;
            _workerWindow = workerWindow;
        }

        public override void Execute(object? parameter)
        {

            if (parameter is "Cancel")
            {
                _workerWindow.Close();
                return;
            }

            WorkerStatusViewModel worker = (parameter as WorkerStatusViewModel)!;

            if (worker.Worker.Id == 0)
            {
                _repository.Create(worker.Worker);
            }

            else
            {
                _repository.Update(worker.Worker);
            }

            _workerWindow.Close();
            WorkersUpdated?.Invoke();
        }
    }
}

