using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.ViewModels
{
    public class WorkerList : ViewModelBase
    {
        public ObservableCollection<Worker> Workers { get; private set; }

        public WorkerList()
        {
            Workers = new ObservableCollection<Worker>();

            foreach (Worker worker in DataAccess.Repository.GetWorkers())
            {
                Workers.Add(worker);
            }
        }
    }
}
