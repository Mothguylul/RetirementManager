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

        private Client? selectedclient { get; set; }

        public Client? SelectedClient
        {
            get => selectedclient;
            set
            {
                selectedclient = value;
                if (selectedclient != null)
                {
                    Assignment.ClientId = selectedclient.Id;
                }
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        public ICommand SaveAssignmentCommand { get; set; }
        public ICommand DeleteAssignmentCommand { get; set; }

        public string HeaderStatus => GetHeaderStatusText();

        private Worker _worker;

        private Assignment _assignment;

        public Assignment Assignment => _assignment;

        public List<Client> ClientList { get; set; }

        public EditableAssignment(Window assignmentWindow, Worker worker)
        {
            _worker = worker;
            ClientList = (List<Client>)Data.Clients.GetAll();

            Assignment? assignment = Data.Assignments.GetAll().FirstOrDefault(a => a.WorkerId == _worker.Id && !a.IsDeleted && !a.IsCompleted);

            SaveAssignmentCommand = new SaveAssignmentCommand(assignmentWindow);
            DeleteAssignmentCommand = new DeleteAssignmentCommand(assignmentWindow);

            if (assignment == null)
            {
                _assignment = new Assignment();
                _assignment.WorkerId = _worker.Id;
                SelectedClient = null;
            }
            else
            {
                _assignment = assignment;

                if (!_assignment.IsDeleted && !_assignment.IsCompleted)
                {

                    SelectedClient = ClientList.Where(c => c.Id == assignment.ClientId).FirstOrDefault();

                    StartDate = assignment.StartDate;
                    EndDate = assignment.EndDate;
                    IsPaused = assignment.Paused;  
                    Notes = assignment.Notes;
                }
            }
        }

        private string GetHeaderStatusText()
        {
            Assignment? workerAssignment = Data.Assignments.GetAll().FirstOrDefault(a => a.WorkerId == _worker.Id && !a.IsDeleted && !a.IsCompleted);

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
