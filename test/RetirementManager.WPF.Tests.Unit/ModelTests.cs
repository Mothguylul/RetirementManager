namespace RetirementManager.Tests.Unit;

using FluentAssertions;
using NSubstitute;
using RetirementManager.Domain.Interfaces;
using RetirementManager.Domain.Models;

public class ModelTests
{

    [Fact]
    public void Worker_ShouldBeNewable()
    {
        // Arrange
        int newWorkerId = 1;
        string newWorkerName = "John";
        string newWorkerEmail = "john89@gmail.com";
        int newWorkerPhone = 5559993;
        string newWorkerBirthDate = "03/23/1980";
        string newWorkerNotes = "This is a worker.";

        // Act
        var freshWorker = new Worker();
        var initializedWorker = new Worker()
        {
            Id = newWorkerId,
            Name = newWorkerName,
            Email = newWorkerEmail,
            Mobil = newWorkerPhone,
            BirthDate = newWorkerBirthDate,
            Notes = newWorkerNotes,
        };

        // Assert
        freshWorker.Id.Should().Be(0);
        freshWorker.Name.Should().BeEquivalentTo(string.Empty);
        freshWorker.Email.Should().BeEquivalentTo(string.Empty);
        freshWorker.Mobil.Should().Be(0);
        freshWorker.BirthDate.Should().BeEquivalentTo(string.Empty);
        freshWorker.Notes.Should().BeEquivalentTo(string.Empty);

        initializedWorker.Id.Should().Be(newWorkerId);
        initializedWorker.Name.Should().BeEquivalentTo(newWorkerName);
        initializedWorker.Email.Should().BeEquivalentTo(newWorkerEmail);
        initializedWorker.Mobil.Should().Be(newWorkerPhone);
        initializedWorker.BirthDate.Should().BeEquivalentTo(newWorkerBirthDate);
        initializedWorker.Notes.Should().BeEquivalentTo(newWorkerNotes);
    }

    [Fact]
    public void Assignment_ShouldBeNewable()
    {
        // Arrange
        int newAssignmentId = 2;
        int newAssignmentWorkerId = 3;
        string newAssignmentStartDate = "04/05/2024";
        string newAssignmentEndDate = "04/07/2024";
        bool newAssignmentPaused = true;
        string newAssignmentNotes = "Needs to be done now!";

        // Act
        var freshAssignment = new Assignment();
        var initializedAssignment = new Assignment()
        {
            Id = newAssignmentId,
            WorkerId = newAssignmentWorkerId,
            StartDate = newAssignmentStartDate,
            EndDate = newAssignmentEndDate,
            Paused = newAssignmentPaused,
            Notes = newAssignmentNotes,
        };

        // Assert
        freshAssignment.Id.Should().Be(0);
        freshAssignment.WorkerId.Should().Be(0);
        freshAssignment.StartDate.Should().BeEquivalentTo(string.Empty);
        freshAssignment.EndDate.Should().BeEquivalentTo(string.Empty);
        freshAssignment.Paused.Should().BeFalse();
        freshAssignment.Notes.Should().BeEquivalentTo(string.Empty);

        initializedAssignment.Id.Should().Be(newAssignmentId);
        initializedAssignment.WorkerId.Should().Be(newAssignmentWorkerId);
        initializedAssignment.StartDate.Should().BeEquivalentTo(newAssignmentStartDate);
        initializedAssignment.EndDate.Should().BeEquivalentTo(newAssignmentEndDate);
        initializedAssignment.Paused.Should().BeTrue();
        initializedAssignment.Notes.Should().BeEquivalentTo(newAssignmentNotes);
    }

    [Fact]
    public void Client_ShouldBeNewable()
    {
        // Arrange
        int newClientId = 27;
        string newClientName = "Elvis";
        string newClientNotes = "He's a singer.";
        string newClientContact = "Lisa";
        string newClientAge = "56";
        string newClientInsuranceNumber = "IS-928-36765";
        string newClientHealthInsurance = "Geico";
        string newClientDoctor = "Dr. Feelgood";
        string newClientNursingService = "Nurses R' Us";
        bool newClientIsEmployed = true;
        int newClientLevelOfCare = 4;
        bool newClientHasDrivingLicense = true;
        int newClientAffiliations = 3;
        string newClientDenomination = "Lutheran";
        bool newClientSingle = true;
        float newClientTimeDoc = 1.2f;

        // Act
        var freshClient = new Client();
        var initializedClient = new Client()
        {
            Id = newClientId,
            Name = newClientName,
            Notes = newClientNotes,
            Contact = newClientContact,
            Age = newClientAge,
            InsuranceNumber = newClientInsuranceNumber,
            HealthInsurance = newClientHealthInsurance,
            Doctor = newClientDoctor,
            NursingService = newClientNursingService,
            IsEmployed = newClientIsEmployed,
            LevelOfCare = newClientLevelOfCare,
            HasDrivingLicense = newClientHasDrivingLicense,
            ContactOfAffiliations = newClientAffiliations,
            Denomination = newClientDenomination,
            Single = newClientSingle,
            TimeDocumentation = newClientTimeDoc,
        };

        // Assert
        freshClient.Id.Should().Be(0);
        freshClient.Name.Should().BeEquivalentTo(string.Empty);
        freshClient.Notes.Should().BeEquivalentTo(string.Empty);
        freshClient.Contact.Should().BeEquivalentTo(string.Empty);
        freshClient.Age.Should().BeEquivalentTo(string.Empty);
        freshClient.InsuranceNumber.Should().BeEquivalentTo(string.Empty);
        freshClient.HealthInsurance.Should().BeEquivalentTo(string.Empty);
        freshClient.Doctor.Should().BeEquivalentTo(string.Empty);
        freshClient.NursingService.Should().BeEquivalentTo(string.Empty);
        freshClient.IsEmployed.Should().BeFalse();
        freshClient.LevelOfCare.Should().Be(0);
        freshClient.HasDrivingLicense.Should().BeFalse();
        freshClient.ContactOfAffiliations.Should().Be(0);
        freshClient.Denomination.Should().BeEquivalentTo(string.Empty);
        freshClient.Single.Should().BeFalse();
        freshClient.TimeDocumentation.Should().Be(0);

        initializedClient.Id.Should().Be(newClientId);
        initializedClient.Name.Should().BeEquivalentTo(newClientName);
        initializedClient.Notes.Should().BeEquivalentTo(newClientNotes);
        initializedClient.Contact.Should().BeEquivalentTo(newClientContact);
        initializedClient.Age.Should().BeEquivalentTo(newClientAge);
        initializedClient.InsuranceNumber.Should().BeEquivalentTo(newClientInsuranceNumber);
        initializedClient.HealthInsurance.Should().BeEquivalentTo(newClientHealthInsurance);
        initializedClient.Doctor.Should().BeEquivalentTo(newClientDoctor);
        initializedClient.NursingService.Should().BeEquivalentTo(newClientNursingService);
        initializedClient.IsEmployed.Should().BeTrue();
        initializedClient.LevelOfCare.Should().Be(newClientLevelOfCare);
        initializedClient.HasDrivingLicense.Should().BeTrue();
        initializedClient.ContactOfAffiliations.Should().Be(newClientAffiliations);
        initializedClient.Denomination.Should().BeEquivalentTo(newClientDenomination);
        initializedClient.Single.Should().BeTrue();
        initializedClient.TimeDocumentation.Should().Be(newClientTimeDoc);
    }
}
