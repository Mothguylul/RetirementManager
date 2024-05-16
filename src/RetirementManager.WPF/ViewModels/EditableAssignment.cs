using RetirementManager.Database;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RetirementManager.WPF.ViewModels
{
    public class EditableAssignment : ViewModelBase
    {

        private string startDate { get; set; } = string.Empty;

        public string StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                Assignment.StartDate = startDate;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private string endDate { get; set; } = string.Empty;

        public string EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                Assignment.EndDate = endDate;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private string notes { get; set; } = string.Empty;

        public string Notes
        {
            get => notes;
            set
            {
                notes = value;
                Assignment.Notes = notes;
                OnPropertyChanged(nameof(Notes));
            }
        }

        private bool ispaused { get; set; }
        public bool IsPaused
        {
            get => ispaused;
            set
            {
                ispaused = value;
                Assignment.Paused = ispaused;
                OnPropertyChanged(nameof(IsPaused));
            }
        }

        public ICommand SaveAssignmentCommand { get; set; }

        public string HeaderStatus => GetHeaderStatusText();

        private Worker _worker;

        private Assignment _assignment; 

        public Assignment Assignment => _assignment;

        public EditableAssignment(Window assignmentWindow, Worker worker)
        {
            _worker = worker;

            Assignment? assignment = Data.Assignments.GetAll().FirstOrDefault(a => a.WorkerId == _worker.Id);

            SaveAssignmentCommand = new SaveAssignmentCommand(assignmentWindow);

            if (assignment == null )
            {
                _assignment = new Assignment();
                _assignment.WorkerId = _worker.Id;
            }
            else
            {
                _assignment = assignment;
                StartDate = assignment.StartDate;
                EndDate = assignment.EndDate; 
                IsPaused = assignment.Paused;
                Notes = assignment.Notes;
            }
        }

        private string GetHeaderStatusText()
        {
            Assignment? workerAssignment = Data.Assignments.GetAll().FirstOrDefault(a => a.WorkerId == _worker.Id);

            if (workerAssignment == null)
            {
                return "Add Assignment";
            }
            else
            {
                return "Edit Assignment";
            }
        }
    }
}
