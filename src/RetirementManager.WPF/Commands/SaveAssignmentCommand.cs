using RetirementManager.Database;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.Commands;

public class SaveAssignmentCommand : CommandBase
{
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
    }
}

