using RetirementManager.Database;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.ViewModels
{
    public class AssignmentHistory
    {
        public ObservableCollection<AssignmentHistoryViewModel> Assignments { get; private set; }

        public AssignmentHistory()
        {
            Assignments = new ObservableCollection<AssignmentHistoryViewModel>();

            List<Assignment> assignments = Data.Assignments.GetAll().ToList();

            foreach (Assignment assignment in assignments)
            {
                AssignmentHistoryViewModel viewModel = new AssignmentHistoryViewModel(assignment);
                Assignments.Add(viewModel);
            }
        }
    }
}
