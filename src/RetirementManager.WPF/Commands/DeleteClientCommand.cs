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
        private ClientList clientList;
        private IRepository<Client> iRepository;


        public DeleteClientCommand(ClientList clientList, IRepository<Client> iRepository)
        {
            this.clientList = clientList;
            this.iRepository = iRepository;

        }

        public override void Execute(object? parameter)
        {
            // This only runs if CanExecute() is true

            Client clientToDelete = (parameter as Client)!;

            iRepository.Delete(clientToDelete.Id);

            clientList.Clients.Remove(clientToDelete);
            clientList.SelectedClient = null;

        }

        public override bool CanExecute(object? parameter)
        {
            return parameter as Client is not null;
        }
    }
}
