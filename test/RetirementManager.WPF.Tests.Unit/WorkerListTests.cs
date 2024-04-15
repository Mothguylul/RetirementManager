namespace RetirementManager.Tests.Unit;

using FluentAssertions;
using NSubstitute;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF;
using RetirementManager.WPF.ViewModels;

public class WorkerListTests
{
    private readonly IRepository repository = Substitute.For<IRepository>();

    private readonly WorkerList sut;

    public WorkerListTests()
    {
        repository.GetWorkers().Returns(new List<Worker>
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

        sut = new WorkerList(repository);
    }

    [Fact]
    public void WorkerList_ObservableCollection_ShouldBeInitialized()
    {
        // Arrange

        // Act

        // Assert
        repository.Received(1).GetWorkers();
        sut.Workers.Should().NotBeNull();
    }

    [Fact]
    public void WorkerList_ObservableCollection_ShouldContainWorkers()
    {
        // Arrange

        // Act

        // Assert
        sut.Workers.Count.Should().Be(2);
        sut.Workers[0].Name.Should().Be("John");
        sut.Workers[1].Name.Should().Be("Bob");
    }

    [Fact]
    public void WorkerList_ShouldRaisePropertyChanged_WhenSelectedWorkerChanged()
    {
        // Arrange
        var monitor = sut.Monitor();

        // Act
        sut.SelectedWorker = new Worker();

        // Assert
        monitor.Should().Raise(nameof(WorkerList.PropertyChanged));
    }

    [Fact]
    public void WorkerList_DeleteWorkerCommand_ShouldNotBeNull()
    {
        // Arrange

        // Act

        // Assert
        sut.DeleteWorkerCommand.Should().NotBeNull();
    }
}