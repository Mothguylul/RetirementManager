using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.Commands
{
    public class DeleteClientCommand : CommandBase
    {
        private ClientList _clientList;

        public DeleteClientCommand(ClientList clientlist) 
        { 
            _clientList = clientlist;
        }

        public override void Execute(object? parameter)
        {
            Client clientToDelete = (parameter as Client)!;

            Data.Clients.Delete(clientToDelete.Id);

            _clientList.Clients.Remove(clientToDelete);
            _clientList.SelectedClient = null;
        }

        public override bool CanExecute(object? parameter)
        {
            return parameter as Client is not null;
        }
    }
}
