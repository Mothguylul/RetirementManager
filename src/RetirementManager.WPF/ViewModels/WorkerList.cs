using RetirementManager.Domain.Models;
using RetirementManager.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RetirementManager.WPF.ViewModels;

public class WorkerList : ViewModelBase
{
    public ObservableCollection<Worker> Workers { get; private set; }

    public ICommand DeleteWorkerCommand { get; set; }

    private Worker? _selectedWorker;

    public Worker? SelectedWorker
    {
        get => _selectedWorker;
        set
        {
            _selectedWorker = value;
            OnPropertyChanged(nameof(SelectedWorker));
        }
    }

    public WorkerList()
    {
        Workers = new ObservableCollection<Worker>();
        DeleteWorkerCommand = new DeleteWorkerCommand(this);

        foreach (Worker worker in DataAccess.Repository.GetWorkers())
        {
            Workers.Add(worker);
        }
    }
}

