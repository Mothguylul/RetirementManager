using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
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
            Worker worker = (parameter as Worker)!;

            if (worker.Id == 0)
            {
                _repository.Create(worker);
            }
            
            else
            {
                _repository.Update(worker);
            }

            WorkersUpdated?.Invoke();
            _workerWindow.Close();
        }
    }
}
