using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.Commands
{
    public class DeleteWorkerCommand : CommandBase
    {

        private WorkerList workerList;

        public DeleteWorkerCommand(WorkerList workerList)
        {
            this.workerList = workerList;
        }

        public override void Execute(object? parameter)
        {
            // This only runs if CanExecute() is true

            Worker workerToDelete = (parameter as Worker)!;

            DataAccess.Repository.DeleteWorker(workerToDelete.Id);

            workerList.Workers.Remove(workerToDelete);
            workerList.SelectedWorker = null;

        }

        public override bool CanExecute(object? parameter)
        {
            return parameter as Worker is not null;
        }
    }
}
