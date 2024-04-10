
namespace RetirementManager.Domain.Interfaces;

using RetirementManager.Domain.Models;

public interface IRepository
{
    IEnumerable<Town> GetTowns();

    IEnumerable<Worker> GetWorkers();

    IEnumerable<Assignment> GetAssignments();

    bool CreateAssignment(Assignment assignment);

    bool DeleteAssignment(int workersId);

    bool CreateNewTown(string newTown);

    bool DeleteTown(int townId);

    bool TogglePause(Assignment assignment);

    bool DeleteWorker(int workerId);
}

