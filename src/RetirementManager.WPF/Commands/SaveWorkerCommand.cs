using RetirementManager.Database;
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

        private Window _workerWindow;

        public SaveWorkerCommand(Window workerWindow)
        {
            _workerWindow = workerWindow;
        }

        public override void Execute(object? parameter)
        {

            if (parameter is "Cancel")
            {
                _workerWindow.Close();
                WorkersUpdated?.Invoke();
                return;
            }

            WorkerStatusViewModel worker = (parameter as WorkerStatusViewModel)!;

            if (worker.Worker.Id == 0)
            {
                Data.Workers.Create(worker.Worker);
            }

            else
            {
                Data.Workers.Update(worker.Worker);
            }

            _workerWindow.Close();
            WorkersUpdated?.Invoke();
        }
    }
}

