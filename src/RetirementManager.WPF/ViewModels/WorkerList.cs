using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
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
    public ObservableCollection<WorkerStatusViewModel> Workers { get; private set; }

    public ICommand DeleteWorkerCommand { get; set; }
    public ICommand OpenWorkerWindowCommand { get; set; }

    private WorkerStatusViewModel? _selectedWorker;

    public WorkerStatusViewModel? SelectedWorker
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
        Workers = new ObservableCollection<WorkerStatusViewModel>();

        SaveWorkerCommand.WorkersUpdated += UpdateWorkerListUI;
        SaveAssignmentCommand.UpdateAssignmentUI += UpdateWorkerListUI;

        foreach (Worker worker in Data.Workers.GetAll())
        {
            Workers.Add(new WorkerStatusViewModel(worker));
        }
        
        DeleteWorkerCommand = new DeleteWorkerCommand(this);
        OpenWorkerWindowCommand = new OpenWorkerWindowCommand();
    }

    public void UpdateWorkerListUI()
    {
        Workers.Clear();

        foreach (Worker worker in Data.Workers.GetAll())
        {
            Workers.Add(new WorkerStatusViewModel(worker));
        }
    }
}

