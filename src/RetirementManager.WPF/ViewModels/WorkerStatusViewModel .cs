using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    private IRepository<Assignment> _repoAssignment;

    public string Status => GetStatus();

    public WorkerStatusViewModel(Worker worker, IRepository<Assignment> repoAssignment)
    {
        _worker = worker;
        _repoAssignment = repoAssignment;
    }

    private string GetStatus()
    {
        Assignment? workerAssignment = _repoAssignment.GetAll().FirstOrDefault(a => a.WorkerId == _worker.Id);

        if (workerAssignment == null)
        {
            return "free";
        }


        if (workerAssignment.Paused)
        {
            return "paused";
        }

        if (workerAssignment != null)
        {
            return "busy";
        }

        return "free";
    }
}

