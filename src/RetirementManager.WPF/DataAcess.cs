using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetirementManager.Database;
using RetirementManager.Domain.Interfaces;

namespace RetirementManager.WPF;

    public static class DataAccess
    {
        private static readonly IRepository Repo;

        static DataAccess()
        {
            Repo = new Repository();
        }

        public static IRepository Repository => Repo;
    }

