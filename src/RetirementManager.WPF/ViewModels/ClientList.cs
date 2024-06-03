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

    private List<Client> _allclients;

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

    private string? _searchText;
    public string? SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            OnPropertyChanged(nameof(SearchText));
            FilterClients();
        }
    }

    public ClientList()
    {

        Clients = new ObservableCollection<Client>();
        _allclients = new List<Client>();

        SaveClientCommand.ClientsUpdated += UpdateClientUI;

        foreach (Client client in Data.Clients.GetAll())
        {
            Clients.Add(client);
        }

        DeleteClientCommand = new DeleteClientCommand(this);
        OpenClientWindowCommand = new OpenClientWindowCommand();

    }

    private void UpdateClientUI()
    {
        Clients.Clear();

        foreach(Client client in Data.Clients.GetAll())
        {
            Clients.Add(client);
        }
    }

    private void FilterClients()
    {
        var filterclients = string.IsNullOrWhiteSpace(SearchText)
            ? _allclients
            : _allclients.Where(w => w.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();

        Clients.Clear();
        foreach (var client in filterclients)
        {
            Clients.Add(client);
        }
    }
}

