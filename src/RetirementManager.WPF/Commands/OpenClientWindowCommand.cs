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
    public class OpenClientWindowCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            AddOrEditClient addoreditclient = new AddOrEditClient();

            Client? client = parameter as Client;
            addoreditclient.DataContext = new EditableClient(client, addoreditclient);
            addoreditclient.Show();

        }

        public override bool CanExecute(object? parameter)
        {
            return parameter is "Add" || parameter as Client is not null;
        }
    }
}
