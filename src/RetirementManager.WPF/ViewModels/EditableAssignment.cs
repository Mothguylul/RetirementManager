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
        public string HeaderStatus => GetHeaderStatusText();

        private Worker _worker;

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        public bool IsPaused { get; set; }

        public ICommand SaveAssignmentCommand { get; set; }

        public EditableAssignment(Assignment? assignment, Window assignmentWindow, Worker worker)
        {
            _worker = worker;

            SaveAssignmentCommand = new SaveAssignmentCommand();

            if (assignment == null )
            {
                assignment = new Assignment();
            }
            else
            {
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
