
namespace RetirementManager.Domain.Interfaces;

using RetirementManager.Domain.Models;

public interface IRepository<T> where T : ModelObject
{
    IEnumerable<T> GetAll();

    bool Create(T entity);

    bool Update(T entity);

    bool Delete(int id);
}