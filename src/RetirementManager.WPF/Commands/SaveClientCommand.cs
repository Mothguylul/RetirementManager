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
        public static event Action? ClientsUpdated; 

        private IRepository<Client> _repository;
        private Window _clientwindow;

        public SaveClientCommand(IRepository<Client> repository, Window clientwindow)
        {
            _repository = repository;
            _clientwindow = clientwindow;

        }

        public override void Execute(object? parameter)
        {

            Client client = (parameter as Client)!;

            if (parameter is "Cancel")
            {
                _clientwindow.Close();
                return;
            }

            if(client.Id == 0)
            {
                _repository.Create(client);
            }
            else
            {
                _repository.Update(client);
            }

            _clientwindow.Close();
            ClientsUpdated?.Invoke();
        }
    }
}
