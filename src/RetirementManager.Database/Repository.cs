
using System.Data;
using RetirementManager.Domain.Models;
using System.Data.SQLite;
using Dapper;
using RetirementManager.Domain.Interfaces;

namespace RetirementManager.Database;

    public class Repository : IRepository
    {
        private readonly string connectionString = "Data Source=C:\\Code\\RetirementManager\\src\\RetirementManager.Database\\database.db";

        public IEnumerable<Assignment> GetAssignments()
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                string sql = "SELECT * FROM Assignments";
                CommandDefinition command = new CommandDefinition(sql);

                return connection.Query<Assignment>(command);
            }
        }

        public IEnumerable<Town> GetTowns()
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                string sql = "SELECT * FROM Towns";
                CommandDefinition command = new CommandDefinition(sql);

                return connection.Query<Town>(command);
            }
        }

        public IEnumerable<Worker> GetWorkers()
        {
            using (IDbConnection connect = new SQLiteConnection(connectionString))
            {
                string sql = "SELECT * FROM Workers";
                CommandDefinition command = new CommandDefinition(sql);

                return connect.Query<Worker>(command);
            }
        }

        public bool CreateAssignment(Assignment assignment)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                string sqlname = $"INSERT Into Assignments (WorkerId,EndDate,StartDate,Notes,Paused) VALUES('{assignment.WorkerId}', '{assignment.EndDate}', '{assignment.StartDate}', '{assignment.Notes}', '{assignment.Paused}')";
                CommandDefinition command = new CommandDefinition(sqlname);

                return connection.Execute(command) > 0;
            }
        }

        public bool DeleteAssignment(int workesId)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                string sqlname = $"DELETE FROM Assignments WHERE Id = '{workesId}'";
                CommandDefinition command = new CommandDefinition(sqlname);

                return connection.Execute(command) > 0;
            }
        }

        public bool TogglePause(Assignment assignment)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                string sqlname = $"UPDATE Assignments SET Paused = '{!assignment.Paused}' WHERE Id = {assignment.Id}";
                CommandDefinition command = new CommandDefinition(sqlname);

                return connection.Execute(command) > 0;
            }
        }

        public bool CreateNewTown(string newTown)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                string sqlname = $"INSERT Into Towns (Name) VALUES('{newTown}')";
                CommandDefinition command = new CommandDefinition(sqlname);

                return connection.Execute(command) > 0;
            }
        }

        public bool DeleteTown(int townId)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                string sqlname = $"DELETE FROM Towns WHERE Id = '{townId}'";
                CommandDefinition command = new CommandDefinition(sqlname);

                return connection.Execute(command) > 0;
            }
        }
    }

