using RetirementManager.Database;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.Commands
{
    public class SortByTown<T> : CommandBase
    {

        private ObservableCollection<WorkerStatusViewModel> _workers;

        private string _currentTown;

        public SortByTown(ObservableCollection<WorkerStatusViewModel> workers, string currentTown)
        {
            _workers = workers;
            _currentTown = currentTown;
        }

        public override void Execute(object? parameter)
        {
            List<Worker> allWorkers = Data.Workers.GetAll().Where(w => w.TownName == $"{_currentTown}").ToList();

            _workers.Clear();

            if (!allWorkers.Any())
            {
                allWorkers = Data.Workers.GetAll().ToList();

                foreach (Worker worker in allWorkers)
                {
                    WorkerStatusViewModel workerVM = new WorkerStatusViewModel(worker);
                    _workers.Add(workerVM);
                }
                return;
            }

            foreach (Worker worker in allWorkers)
            {
                WorkerStatusViewModel workerVM = new WorkerStatusViewModel(worker);
                _workers.Add(workerVM);
            }
        }
    }
}
