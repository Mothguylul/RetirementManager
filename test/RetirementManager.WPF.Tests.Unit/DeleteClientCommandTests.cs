namespace RetirementManager.Tests.Unit;

using FluentAssertions;
using NSubstitute;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;
using RetirementManager.WPF.ViewModels;
using System.Windows.Input;

public class DeleteClientCommandTests
{
    private readonly IRepository<Client> repository = Substitute.For<IRepository<Client>>();

    private readonly ClientList clientList;

    private readonly ICommand sut;

    public DeleteClientCommandTests()
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

        clientList = new ClientList(repository);
        sut = clientList.DeleteClientCommand;
    }

    [Fact]
    public void CanExecute_ShouldBeTrue_WhenSelectedClientIsNotNull()
    {
        // Arrange
        clientList.SelectedClient = clientList.Clients[0];

        // Act

        // Assert
        sut.CanExecute(clientList.SelectedClient).Should().BeTrue();
    }

    [Fact]
    public void CanExecute_ShouldBeFalse_WhenSelectedClientIsNull()
    {
        // Arrange
        clientList.SelectedClient = null;

        // Act

        // Assert
        sut.CanExecute(clientList.SelectedClient).Should().BeFalse();
    }

    [Fact]
    public void Execute_ShouldDeleteClientFromDatabase()
    {
        // Arrange
        Client clientToDelete = clientList.Clients[0];
        repository.Delete(clientToDelete.Id).Returns(true);
        clientList.SelectedClient = clientToDelete;

        // Act
        sut.Execute(clientList.SelectedClient);

        // Assert
        repository.Received(1).Delete(Arg.Is(clientToDelete.Id));
    }

    [Fact]
    public void Execute_ShouldDeleteClientFromClientList()
    {
        // Arrange
        Client clientToDelete = clientList.Clients[0];
        repository.Delete(clientToDelete.Id).Returns(true);
        clientList.SelectedClient = clientToDelete;

        // Act
        sut.Execute(clientList.SelectedClient);

        // Assert
        clientList.Clients.Should().NotContain(clientToDelete);
        clientList.SelectedClient.Should().BeNull();
    }
}