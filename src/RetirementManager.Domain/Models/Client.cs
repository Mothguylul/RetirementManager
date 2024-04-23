namespace RetirementManager.Domain.Models;

public class Client : ModelObject
{
    public string Name { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public string Contact { get; set; } = string.Empty;

    public string Age { get; set; } = string.Empty;

    public string InsuranceNumber { get; set; } = string.Empty;

    public string HealthInsurance { get; set; } = string.Empty;

    public string Doctor { get; set; } = string.Empty;

    public string NursingService { get; set; } = string.Empty;

    public bool IsEmployed { get; set; }

    public int LevelOfCare { get; set; }

    public bool HasDrivingLicense { get; set; }

    public int ContactOfAffiliations { get; set; }

    public string Denomination { get; set; } = string.Empty;

    public bool Single { get; set; }

    public float TimeDocumentation { get; set; }
}

