using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementManager.Database
{
    public static class Data
    {
        public static IRepository<Worker> Workers { get; private set; } = null!;
        public static IRepository<Client> Clients { get; private set; } = null!;
        public static IRepository<Assignment> Assignments { get; private set; } = null!;

        public static void Initializing(IRepository<Worker> workerRepo, IRepository<Assignment> assignmentRepo, IRepository<Client> clientRepo)
        {
            Workers = workerRepo;
            Clients = clientRepo;
            Assignments = assignmentRepo; 
        }
    }
}
