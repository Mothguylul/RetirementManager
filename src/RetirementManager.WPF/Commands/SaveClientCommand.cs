using RetirementManager.Database;
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

        private Window _clientwindow;

        public SaveClientCommand(Window clientwindow)
        {
            _clientwindow = clientwindow;

        }

        public override void Execute(object? parameter)
        {

            Client client = (parameter as Client)!;

            if (parameter is "Cancel")
            {
                _clientwindow.Close();
                ClientsUpdated?.Invoke();
                return;
            }

            if(client.Id == 0)
            {
                Data.Clients.Create(client);
            }
            else
            {
                Data.Clients.Update(client);
            }

            _clientwindow.Close();
            ClientsUpdated?.Invoke();
        }
    }
}
