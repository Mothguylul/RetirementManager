namespace RetirementManager.Tests.Unit;

using FluentAssertions;
using NSubstitute;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;

public class ClientListTests
{
    private readonly IRepository<Client> repository = Substitute.For<IRepository<Client>>();


    private readonly ClientList sut;

    public ClientListTests()
    {
        repository.GetAll().Returns(new List<Client>
        {
            new Client
            {
                Id = 1,
                Name = "John",
                Age = "30",
                Notes = "Test",
            },
            new Client
            {
                Id = 2,
                Name = "Bob",
                Age = "32",
                Notes = "Test 2",
            },
        });

        sut = new ClientList();
    }

    [Fact]
    public void ClientList_ObservableCollection_ShouldBeInitialized()
    {
        // Arrange

        // Act

        // Assert
        repository.Received(1).GetAll();
        sut.Clients.Should().NotBeNull();
    }

    [Fact]
    public void ClientList_ObservableCollection_ShouldContainClients()
    {
        // Arrange

        // Act

        // Assert
        sut.Clients?.Count.Should().Be(2);
        sut.Clients?[0].Name.Should().Be("John");
        sut.Clients?[1].Name.Should().Be("Bob");
    }

    [Fact]
    public void ClientList_ShouldRaisePropertyChanged_WhenSelectedClientChanged()
    {
        // Arrange
        var monitor = sut.Monitor();

        // Act
        sut.SelectedClient = new Client();

        // Assert
        monitor.Should().Raise(nameof(ClientList.PropertyChanged));
    }

    [Fact]
    public void ClientList_DeleteClientCommand_ShouldNotBeNull()
    {
        // Arrange

        // Act

        // Assert
        sut.DeleteClientCommand.Should().NotBeNull();
    }
}