
using System.Data;
using RetirementManager.Domain.Models;
using System.Data.SQLite;
using Dapper;
using RetirementManager.Domain.Interfaces;
using Dapper.Contrib.Extensions;

namespace RetirementManager.Database;

public class Repository<T> : IRepository<T> where T : ModelObject
{
    private readonly string connectionString = "Data Source=C:\\Code\\RetirementManager\\src\\RetirementManager.Database\\database.db";

    public IEnumerable<T> GetAll()
    {
        using (IDbConnection connection = new SQLiteConnection(connectionString))
        {
            string tableName = typeof(T).Name + "s";
            string sql = $"SELECT * FROM {tableName}";

            CommandDefinition command = new CommandDefinition(sql);
            return connection.Query<T>(command);
        }
    }


    public bool Create(T entity)
    {
        using (IDbConnection connection = new SQLiteConnection(connectionString))
        {
            return connection.Insert(entity) != 0;
        }
    }

    public bool Delete(int id)
    {
        using (IDbConnection connection = new SQLiteConnection(connectionString))
        {
            string tableName = typeof(T).Name + "s";
            string sql = $"DELETE FROM {tableName} WHERE Id = {id} ";

            CommandDefinition command = new CommandDefinition(sql);
            return connection.Execute(command) > 0;
        }
    }


    public bool Update(T entity)
    {
        using (IDbConnection connection = new SQLiteConnection(connectionString))
        {
            return connection.Update(entity);
        }
    }
}

