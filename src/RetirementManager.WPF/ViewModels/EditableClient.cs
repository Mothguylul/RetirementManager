using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RetirementManager.WPF.ViewModels
{
    public class EditableClient : ViewModelBase
    {
        private string _name = string.Empty;
        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                _client.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _notes { get; set; } = string.Empty;
        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                _client.Notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }

        private string _contact { get; set; } = string.Empty;
        public string Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                _client.Contact = value;
                OnPropertyChanged(nameof(Contact));
            }
        }

        private string _age { get; set; } = string.Empty;
        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                _client.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private  Client _client;
        public Client Client => _client;

        public ICommand SaveClientCommand { get; set; }

        public EditableClient(Client? client, IRepository<Client> repository, Window clientwindow )
        {
     
            SaveClientCommand = new SaveClientCommand(repository, clientwindow);

            if(client is null)
            {
                _client = new Client();
            }
            else
            {
                _client = client;   
                Name = client.Name;
                Age = client.Age;   
                Contact = client.Contact;
                Notes = client.Notes;   
            }
        }
    }
}
