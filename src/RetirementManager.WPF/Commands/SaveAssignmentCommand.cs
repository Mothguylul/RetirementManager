using RetirementManager.Database;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows;

namespace RetirementManager.WPF.Commands;

public class SaveAssignmentCommand : CommandBase
{
    public static event Action? UpdateAssignmentUI;

    private Window _assignmentWindow;

    public SaveAssignmentCommand(Window assignmentWindow)
    {
        _assignmentWindow = assignmentWindow;
    }

    public override void Execute(object? parameter)
    {
        Assignment assignment = (parameter as Assignment)!;

        if (assignment.Id == 0)
        {
            Data.Assignments.Create(assignment);
        }

        else
        {
            Data.Assignments.Update(assignment);
        }

        UpdateAssignmentUI?.Invoke();
        _assignmentWindow.Close();
    }
}

