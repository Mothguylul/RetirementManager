using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using RetirementManager.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RetirementManager.WPF.Commands
{
    public class OpenAssignmentWindow : CommandBase
    {
        private Worker _worker;

        public OpenAssignmentWindow(Worker worker)
        {
            _worker = worker;
        }

        public override void Execute(object? parameter)
        {
            AddOrEditAssignment addoreditassignment = new AddOrEditAssignment();

            Assignment? assignment = parameter as Assignment;
            addoreditassignment.DataContext = new EditableAssignment(assignment, addoreditassignment, _worker);
            addoreditassignment.Show();
        }
    }
}
