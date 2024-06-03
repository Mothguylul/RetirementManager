using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RetirementManager.WPF.ViewModels;

public class WorkerStatusViewModel : ViewModelBase
{

    public string Name => _worker.Name;
    public string Email => _worker.Email;
    public string BirthDate => _worker.BirthDate;
    public int Mobil => _worker.Mobil;
    public string Notes => _worker.Notes;

    private Worker _worker;
    public Worker Worker => _worker;

    public string Status => GetStatus();
    public string ButtonStatus => GetButtonStatus();

    public ICommand OpenAssignmentWindowCommand { get; set; }

    public WorkerStatusViewModel(Worker worker)
    {
        _worker = worker;

        OpenAssignmentWindowCommand = new OpenAssignmentWindow(_worker);
    }

    private string GetStatus()
    {
        Assignment? workerAssignment = Data.Assignments
            .GetAll()
            .Where(a => a.WorkerId == _worker.Id && !a.IsCompleted && !a.IsDeleted)
            .FirstOrDefault();

        if (workerAssignment == null)
        {
            return "free";
        }

        if (workerAssignment.Paused)
        {
            return "paused";
        }

        if (workerAssignment.IsCompleted)
        {
            return "free";
        }

        if (workerAssignment.IsDeleted)
        {
            return "free";
        }


        if (workerAssignment != null)
        {
            return "busy";
        }


        return "free";
    }

    private string GetButtonStatus()
    {

        Assignment? workerAssignment = Data.Assignments
                    .GetAll()
                    .Where(a => a.WorkerId == _worker.Id && !a.IsCompleted && !a.IsDeleted)
                    .FirstOrDefault();

        if (workerAssignment == null)
        {
            return "Add";
        }

        if (workerAssignment.Paused)
        {
            return "Edit";
        }

        if (workerAssignment != null)
        {
            return "Edit";
        }

        return "Add";
    }

}

