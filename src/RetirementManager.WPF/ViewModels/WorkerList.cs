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
    private List<WorkerStatusViewModel> _allWorkers;

    public ICommand DeleteWorkerCommand { get; set; }

    public ICommand OpenWorkerWindowCommand { get; set; }

    public ICommand GetAll { get; set; }

    private WorkerStatusViewModel? _selectedWorker;

    private string? _searchText;

    public string? SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            OnPropertyChanged(nameof(SearchText));
            FilterWorkers();
        }
    }

    public ICommand SortByTown1 { get; set; }
    public ICommand SortByTown2 { get; set; }
    public ICommand SortByTown3 { get; set; }

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
        _allWorkers = new List<WorkerStatusViewModel>();

        SaveWorkerCommand.WorkersUpdated += UpdateWorkerListUI;
        SaveAssignmentCommand.UpdateAssignmentUI += UpdateWorkerListUI;
        DeleteAssignmentCommand.UpdateAssignmentUI += UpdateWorkerListUI;

        foreach (Worker worker in Data.Workers.GetAll())
        {
            WorkerStatusViewModel workerVM = new WorkerStatusViewModel(worker);
            Workers.Add(workerVM);
            _allWorkers.Add(workerVM);
        }

        DeleteWorkerCommand = new DeleteWorkerCommand(this);
        OpenWorkerWindowCommand = new OpenWorkerWindowCommand();

        SortByTown1 = new SortByTown<Worker>(Workers, "Town1");
        SortByTown2 = new SortByTown<Worker>(Workers, "Town2");
        SortByTown3 = new SortByTown<Worker>(Workers, "Town3");
        GetAll = new SortByTown<Worker>(Workers, "GetAll");
    }

    public void UpdateWorkerListUI()
    {
        _allWorkers.Clear();
        foreach (Worker worker in Data.Workers.GetAll())
        {
            _allWorkers.Add(new WorkerStatusViewModel(worker));
        }
        FilterWorkers();
    }

    private void FilterWorkers()
    {
        var filteredWorkers = string.IsNullOrWhiteSpace(SearchText)
            ? _allWorkers
            : _allWorkers.Where(w => w.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();

        Workers.Clear();
        foreach (var worker in filteredWorkers)
        {
            Workers.Add(worker);
        }
    }
}