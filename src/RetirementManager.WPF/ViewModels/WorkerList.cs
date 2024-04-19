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
    public ObservableCollection<Worker> Workers { get; private set; }

    public ICommand DeleteWorkerCommand { get; set; }
    public ICommand OpenWorkerWindowCommand { get; set; }

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
    public WorkerList(IRepository iRepository)
    {
        Workers = new ObservableCollection<Worker>();

        foreach (Worker worker in iRepository.GetWorkers())
        {
            Workers.Add(worker);
        }

        DeleteWorkerCommand = new DeleteWorkerCommand(this, iRepository);
        OpenWorkerWindowCommand = new OpenWorkerWindowCommand();
    }
}

