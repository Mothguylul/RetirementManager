using RetirementManager.Database;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.ViewModels
{
    public class AssignmentHistoryViewModel
    {
        private Assignment _assignment;

        public string Nr => _assignment.Id.ToString();

        public string Classification => GetClassification();

        public AssignmentHistoryViewModel(Assignment assignment) 
        { 
            _assignment = assignment;
        }

        public string GetClassification()
        {
            Client? showClient = Data.Clients.GetAll().FirstOrDefault(c => c.Id == _assignment.ClientId);
            string clientString = showClient is null ? "None" : $"{showClient.Name}";

            string showStartDate = _assignment.StartDate.ToString();
            string showEndDate = _assignment.EndDate.ToString();
            
            return clientString + ",                 " +  showStartDate + " - " + showEndDate;
        }
    }
}
