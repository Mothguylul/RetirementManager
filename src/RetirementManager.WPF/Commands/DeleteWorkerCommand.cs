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

    private WorkerList workerList;
    private IRepository iRepository;


    public DeleteWorkerCommand(WorkerList workerList, IRepository iRepository)
    {
        this.workerList = workerList;
        this.iRepository = iRepository;

    }

    public override void Execute(object? parameter)
    {
        // This only runs if CanExecute() is true

        Worker workerToDelete = (parameter as Worker)!;

        iRepository.DeleteWorker(workerToDelete.Id);

        workerList.Workers.Remove(workerToDelete);
        workerList.SelectedWorker = null;

    }

    public override bool CanExecute(object? parameter)
    {
        return parameter as Worker is not null;
    }
}

