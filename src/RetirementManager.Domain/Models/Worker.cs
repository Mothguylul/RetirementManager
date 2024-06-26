﻿namespace RetirementManager.Domain.Models;

public class Worker : ModelObject
{
    public string TownName { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string BirthDate { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public int Mobil { get; set; }
}

