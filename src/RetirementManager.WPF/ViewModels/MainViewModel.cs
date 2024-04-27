using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RetirementManager.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Window _window;

        public MainViewModel(IRepository<Worker> workerRepository, IRepository<Client> clientRepository, Window clientwindow)
        {
            _window = clientwindow;

            WorkerList = new WorkerList(workerRepository);
            ClientList = new ClientList(clientRepository);
        }

        public WorkerList WorkerList { get; set; }
        public ClientList ClientList { get; set; }

    }
}
