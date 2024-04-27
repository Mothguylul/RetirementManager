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
using System.Windows;
using System.Windows.Input;

namespace RetirementManager.WPF.ViewModels;

public class ClientList : ViewModelBase
{
    public ObservableCollection<Client> Clients { get; private set; }

    private Client? _selectedClient;

    private IRepository<Client> _repository;

    public ICommand DeleteClientCommand { get; set; }

    public ICommand OpenClientWindowCommand { get; set; }

    


    public Client? SelectedClient
    {
        get => _selectedClient;
        set
        {
            _selectedClient = value;
            OnPropertyChanged(nameof(SelectedClient));
        }
    }
    public ClientList(IRepository<Client> repository)
    {
        _repository = repository;

        Clients = new ObservableCollection<Client>();

        SaveClientCommand.ClientsUpdated += UpdateClientUI;

        foreach (Client client in repository.GetAll())
        {
            Clients.Add(client);
        }

        DeleteClientCommand = new DeleteClientCommand(this, repository);
        OpenClientWindowCommand = new OpenClientWindowCommand(repository);

    }

    private void UpdateClientUI()
    {
        Clients.Clear();

        foreach(Client client in _repository.GetAll())
        {
            Clients.Add(client);
        }
    }
}

