namespace  RetirementManager.Domain.Models;

public class Assignment : ModelObject
{
        public int WorkerId { get; set; }

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        public bool Paused { get; set; } = false;

        public string Notes { get; set; } = string.Empty;
        
        public int ClientID { get; set; }
    }

