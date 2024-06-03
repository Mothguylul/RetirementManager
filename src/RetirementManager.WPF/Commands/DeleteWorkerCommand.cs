using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.Commands;

public class DeleteWorkerCommand : CommandBase
{

    private WorkerList _workerList;

    public DeleteWorkerCommand(WorkerList workerList)
    {
        _workerList = workerList;

    }

    public override void Execute(object? parameter)
    {
        // This only runs if CanExecute() is true

        WorkerStatusViewModel workerToDelete = (parameter as WorkerStatusViewModel)!;

        Data.Workers.Delete(workerToDelete.Worker.Id);

        _workerList.Workers.Remove(workerToDelete);
        _workerList.SelectedWorker = null;

    }

    public override bool CanExecute(object? parameter)
    {
        return parameter as WorkerStatusViewModel is not null;
    }
}

