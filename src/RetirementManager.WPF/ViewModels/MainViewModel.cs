using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IRepository iRepository) 
        {
            WorkerList = new WorkerList(iRepository);

        }
        public WorkerList WorkerList { get; set; }

    }
}
