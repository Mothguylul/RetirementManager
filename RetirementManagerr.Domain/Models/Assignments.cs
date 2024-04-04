namespace  RetirementManagerr.Domain;

public class Assignment
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }

        public string StartDate { get; set; } = string.Empty;

        public string EndDate { get; set; } = string.Empty;

        public bool Paused { get; set; } = false;

        public string Notes { get; set; } = string.Empty;
    }

