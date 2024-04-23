using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IRepository<Worker> workerRepository, IRepository<Client> clientRepository)
        {
            WorkerList = new WorkerList(workerRepository);
            ClientList = new ClientList(clientRepository);
        }

        public WorkerList WorkerList { get; set; }
        public ClientList ClientList { get; set; }

    }
}
