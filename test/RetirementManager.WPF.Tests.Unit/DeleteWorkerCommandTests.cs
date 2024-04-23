namespace RetirementManager.Tests.Unit;

using FluentAssertions;
using NSubstitute;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using System.Windows.Input;

public class DeleteWorkerCommandTests
{
    private readonly IRepository<Worker> repository = Substitute.For<IRepository<Worker>>();

    private readonly WorkerList workerList;

    private readonly ICommand sut;

    public DeleteWorkerCommandTests()
    {
        repository.GetAll().Returns(new List<Worker>
        {
            new Worker
            {
                Id = 1,
                TownId = 1,
                Name = "John",
                Email = "john89@gmail.com",
                Mobil=321, BirthDate = new DateTime(85, 07, 23).ToString(),
                Notes = "Note"
            },
            new Worker
            {
                Id = 2,
                TownId = 2,
                Name = "Bob",
                Email = "bob239@gmail.com",
                Mobil=777, BirthDate = new DateTime(85, 06, 24).ToString(),
                Notes = "Note"
            },
        });

        workerList = new WorkerList(repository);
        sut = workerList.DeleteWorkerCommand;
    }

    [Fact]
    public void CanExecute_ShouldBeTrue_WhenSelectedWorkerIsNotNull()
    {
        // Arrange
        workerList.SelectedWorker = workerList.Workers[0];

        // Act

        // Assert
        sut.CanExecute(workerList.SelectedWorker).Should().BeTrue();
    }

    [Fact]
    public void CanExecute_ShouldBeFalse_WhenSelectedWorkerIsNull()
    {
        // Arrange
        workerList.SelectedWorker = null;

        // Act

        // Assert
        sut.CanExecute(workerList.SelectedWorker).Should().BeFalse();
    }

    [Fact]
    public void Execute_ShouldDeleteWorkerFromDatabase()
    {
        // Arrange
        Worker workerToDelete = workerList.Workers[0];
        repository.Delete(workerToDelete.Id).Returns(true);
        workerList.SelectedWorker = workerToDelete;

        // Act
        sut.Execute(workerList.SelectedWorker);

        // Assert
        repository.Received(1).Delete(Arg.Is(workerToDelete.Id));
    }

    [Fact]
    public void Execute_ShouldDeleteWorkerFromWorkerList()
    {
        // Arrange
        Worker workerToDelete = workerList.Workers[0];
        repository.Delete(workerToDelete.Id).Returns(true);
        workerList.SelectedWorker = workerToDelete;

        // Act
        sut.Execute(workerList.SelectedWorker);

        // Assert
        workerList.Workers.Should().NotContain(workerToDelete);
        workerList.SelectedWorker.Should().BeNull();
    }
}