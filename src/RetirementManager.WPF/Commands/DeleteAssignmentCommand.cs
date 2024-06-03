using RetirementManager.Database;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RetirementManager.WPF.Commands
{
    public class DeleteAssignmentCommand : CommandBase
    {
        public static event Action? UpdateAssignmentUI;

        private Window _assignmentWindow;

        public DeleteAssignmentCommand(Window assignmentWindow)
        {
            _assignmentWindow = assignmentWindow;
        }

        public override void Execute(object? parameter)
        {
            Assignment assignmentToDelete = (parameter as Assignment)!;


            assignmentToDelete.IsDeleted = true;
            Data.Assignments.Update(assignmentToDelete);
            UpdateAssignmentUI?.Invoke();
            _assignmentWindow.Close();

        }

        public override bool CanExecute(object? parameter)
        {
            Assignment assignment = (parameter as Assignment)!;

            if(assignment.Id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
