using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RetirementManager.WPF.ViewModels;

public class ClientList : ViewModelBase
{
    public ObservableCollection<Client>? Clients { get; private set; }

    private Client? _selectedClient;

    public ICommand DeleteClientCommand { get; set; }


    public Client? SelectedClient
    {
        get => _selectedClient;
        set
        {
            _selectedClient = value;
            OnPropertyChanged(nameof(SelectedClient));
        }
    }
    public ClientList(IRepository irepository)
    {
        Clients = new ObservableCollection<Client>();

        foreach (Client client in irepository.GetClients())
        {
            Clients.Add(client);
        }

        DeleteClientCommand = new DeleteClientCommand(this, irepository);
    }

    public void ClientsRemove(Client client)
    {

    }
}

