
namespace RetirementManagerr.Domain.Interfaces;

using RetirementManagerr.Domain.Interfaces;

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
}

