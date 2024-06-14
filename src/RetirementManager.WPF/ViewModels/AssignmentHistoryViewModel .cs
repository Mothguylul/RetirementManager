using RetirementManager.Database;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.ViewModels
{
    public class AssignmentHistoryViewModel : ViewModelBase
    {
        private Assignment _assignment;

        public string Nr => _assignment.Id.ToString();

        public string Client => GetClient();

        public string DatePeriod => GetDate();

        public string Notes => _assignment.Notes;

        public string MainStatus => GetAssignmentStatus();

        public string Worker => GetWorker();

        public AssignmentHistoryViewModel(Assignment assignment) 
        { 
            _assignment = assignment;
        }

        private string GetClient()
        {
            Client? showClient = Data.Clients.GetAll().FirstOrDefault(c => c.Id == _assignment.ClientId);
            return showClient is null ? "None" : $"{showClient.Name}";
        }

        private string GetWorker()
        {
            Worker? showWorker = Data.Workers.GetAll().FirstOrDefault(w => w.Id == _assignment.WorkerId);
            return showWorker is null ? "None" : $"{showWorker.Name}";
        }

        private string GetDate()
        {
            string startDate = _assignment.StartDate.ToString();
            string endDate = _assignment.EndDate.ToString();

            return startDate + " - " + endDate;
        }

        private string GetAssignmentStatus()
        {
            if (_assignment.IsCompleted)
            {
                return "Completed";
            }

            if (_assignment.IsDeleted) 
            {
                return "Deleted";
            }

            if (!_assignment.IsCompleted && !_assignment.IsDeleted && !_assignment.Paused)
            {
                return "Busy";
            }

            if (_assignment.Paused && !_assignment.IsCompleted && !_assignment.IsDeleted)
            {
                return "Paused";
            }

            return string.Empty;
        }
    }
}
