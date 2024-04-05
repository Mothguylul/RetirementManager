namespace RetirementManager.Domain.Models;

public class Worker
{
    public int Id { get; set; }

    public int TownId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string BirthDate { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public int Mobil { get; set; }
}

