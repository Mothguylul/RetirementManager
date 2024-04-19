﻿using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace RetirementManager.WPF.ViewModels
{
    public class EditableWorker : ViewModelBase
    {

        private Worker _worker;
        public Worker? Worker => _worker;

        private string _name { get; set; } = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                _worker.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _email { get; set; } = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                _worker.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _birthDate { get; set; } = string.Empty;
        public string BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                _worker.BirthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        private string _notes { get; set; } = string.Empty;
        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                _worker.Notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }

        private string _mobil { get; set; } = string.Empty;
        public string Mobil
        {
            get => _mobil;
            set
            {
                _mobil = value;
                if (int.TryParse(value, out int mobilNumber))
                {
                    _worker.Mobil = mobilNumber;
                }
                OnPropertyChanged(nameof(Mobil));
            }
        }


        public EditableWorker(Worker? worker)
        {
            if(worker is null)
            {
                _worker = new Worker();
            }
            else
            {
                _worker = worker;
                Name = worker.Name;
                Email = worker.Email;
                BirthDate = worker.BirthDate;
                Notes = worker.Notes;
                Mobil = worker.Mobil.ToString();
            }
        }
    }
}