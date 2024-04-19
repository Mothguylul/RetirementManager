using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.Commands
{
    public class SaveWorkerCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            Worker worker = (parameter as Worker)!;
       
        }
    }
}
