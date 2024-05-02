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

        private string _insuranceNumber { get; set; } = string.Empty;
        public string InsuranceNumber
        {
            get => _insuranceNumber;
            set
            {
                _insuranceNumber = value;
                _client.InsuranceNumber = value;
                OnPropertyChanged(nameof(InsuranceNumber));
            }
        }

        private string _healthInsurance { get; set; } = string.Empty;
        public string HealthInsurance
        {
            get => _healthInsurance;
            set
            {
                _healthInsurance = value;
                _client.HealthInsurance = value;
                OnPropertyChanged(nameof(HealthInsurance));
            }
        }

        private string _doctor { get; set; } = string.Empty;
        public string Doctor
        {
            get => _doctor;
            set
            {
                _doctor = value;
                _client.Doctor = value;
                OnPropertyChanged(nameof(Doctor));
            }
        }

        private string _nursingService { get; set; } = string.Empty;
        public string NursingService
        {
            get => _nursingService;
            set
            {
                _nursingService = value;
                _client.NursingService = value;
                OnPropertyChanged(nameof(NursingService));
            }
        }

        private bool _isEmployed { get; set; } 
        public bool IsEmployed
        {
            get => _isEmployed;
            set
            {
                _isEmployed = value;
                _client.IsEmployed = value;
                OnPropertyChanged(nameof(IsEmployed));
            }
        }

        private int _levelOfCare { get; set; }
        public int LevelOfCare
        {
            get => _levelOfCare;
            set
            {
                _levelOfCare = value;
                _client.LevelOfCare = value;
                OnPropertyChanged(nameof(LevelOfCare));
            }
        }

        private bool _hasDrivingLicense { get; set; }
        public bool HasDrivingLicense
        {
            get => _hasDrivingLicense;
            set
            {
                _hasDrivingLicense = value;
                _client.HasDrivingLicense = value;
                OnPropertyChanged(nameof(HasDrivingLicense));
            }
        }


        private int _contactOfAffiliations { get; set; }
        public int ContactOfAffiliations
        {
            get => _contactOfAffiliations;
            set
            {
                _contactOfAffiliations = value;
                _client.ContactOfAffiliations = value;
                OnPropertyChanged(nameof(ContactOfAffiliations));
            }
        }

        private string _denomination { get; set; } = string.Empty;
        public string Denomination
        {
            get => _denomination;
            set
            {
                _denomination = value;
                _client.Denomination = value;
                OnPropertyChanged(nameof(Denomination));
            }
        }

        private bool _single { get; set; } 
        public bool Single
        {
            get => _single;
            set
            {
                _single = value;
                _client.Single = value;
                OnPropertyChanged(nameof(Single));
            }
        }

        private float _timeDocumentation { get; set; }
        public float TimeDocumentation
        {
            get => _timeDocumentation;
            set
            {
                _timeDocumentation = value;
                _client.TimeDocumentation = value;
                OnPropertyChanged(nameof(TimeDocumentation));
            }
        }


        private Client _client;
        public Client Client => _client;

        public ICommand SaveClientCommand { get; set; }

        public EditableClient(Client? client, Window clientwindow )
        {  
            SaveClientCommand = new SaveClientCommand(clientwindow);

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
