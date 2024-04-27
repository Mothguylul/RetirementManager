using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RetirementManager.WPF.Commands
{
    public class SaveClientCommand : CommandBase
    {
        private IRepository<Client> _repository;
        private Window _workerwindow;

        public SaveClientCommand(IRepository<Client> repository, Window workerwindow)
        {
            _repository = repository;
            _workerwindow = workerwindow;

        }

        public override void Execute(object? parameter)
        {
            Client client = (parameter as Client)!;

            if(client.Id == 0)
            {
                _repository.Create(client);
            }
            else
            {
                _repository.Update(client);
            }

            _workerwindow.Close();
        }
    }
}
