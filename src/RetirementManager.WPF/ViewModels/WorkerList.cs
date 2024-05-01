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

    private IRepository<Worker> _workerRepository;
    private IRepository<Assignment> _repoAssignment;

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
    public WorkerList(IRepository<Worker> iRepository, IRepository<Assignment> repoAsignment)
    {
        _workerRepository = iRepository;
        _repoAssignment = repoAsignment;
        Workers = new ObservableCollection<WorkerStatusViewModel>();

        SaveWorkerCommand.WorkersUpdated += UpdateWorkerListUI;

        foreach (Worker worker in iRepository.GetAll())
        {
            Workers.Add(new WorkerStatusViewModel(worker, repoAsignment));
        }

        DeleteWorkerCommand = new DeleteWorkerCommand(this, iRepository);
        OpenWorkerWindowCommand = new OpenWorkerWindowCommand(iRepository);
    }

    public void UpdateWorkerListUI()
    {
        Workers.Clear();

        foreach (Worker worker in _workerRepository.GetAll())
        {
            Workers.Add(new WorkerStatusViewModel(worker, _repoAssignment));
        }
    }
}

