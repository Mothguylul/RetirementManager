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
        private IRepository<Worker> _repository;

        public SaveWorkerCommand(IRepository<Worker> repository)
        {
            _repository = repository;
        }

        public override void Execute(object? parameter)
        {
            Worker worker = (parameter as Worker)!;

            if (worker.Id == 0)
            {
                _repository.Create(worker);
            }
            
            else
            {
                _repository.Update(worker);
            }

        }
    }
}
