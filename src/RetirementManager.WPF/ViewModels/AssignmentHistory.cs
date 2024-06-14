using RetirementManager.Database;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.ViewModels
{
    public class AssignmentHistory : ViewModelBase
    {
        public ObservableCollection<AssignmentHistoryViewModel> Assignments { get; private set; }
        private List<AssignmentHistoryViewModel> _allAssignments;

        private string? _searchText;
        public string? SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterAssignments();
            }
        }

        public AssignmentHistory()
        {
            Assignments = new ObservableCollection<AssignmentHistoryViewModel>();
            _allAssignments = new List<AssignmentHistoryViewModel>();

            List<Assignment> assignments = Data.Assignments.GetAll().ToList();

            foreach (Assignment assignment in assignments)
            {
                AssignmentHistoryViewModel viewModel = new AssignmentHistoryViewModel(assignment);
                Assignments.Add(viewModel);
                _allAssignments.Add(viewModel);
            }

            DeleteAssignmentCommand.UpdateAssignmentUI += UpdateAssignmentHistoryUI;
            SaveAssignmentCommand.UpdateAssignmentUI += UpdateAssignmentHistoryUI;
        }

        private void UpdateAssignmentHistoryUI()
        {
            Assignments.Clear();
            _allAssignments.Clear();

            List<Assignment> assignments = Data.Assignments.GetAll().ToList();

            foreach (Assignment assignment in assignments)
            {
                AssignmentHistoryViewModel viewModel = new AssignmentHistoryViewModel(assignment);
                Assignments.Add(viewModel);
                _allAssignments.Add(viewModel);
            }
        }

        private void FilterAssignments()
        {
            var filteredAssignments = string.IsNullOrWhiteSpace(SearchText)
                ? _allAssignments
                : _allAssignments.Where(a => a.Worker.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();

            Assignments.Clear();
            foreach (var assignment in filteredAssignments)
            {
                Assignments.Add(assignment);
            }
        }
    }
}
