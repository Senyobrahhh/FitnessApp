using FitnessApp.Domain.Enums;

namespace FitnessApp.Domain.Entities;

public class FitnessProgram : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public FitnessGoal Goal { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public int DurationWeeks { get; set; }
    
    public string AppUserId { get; set; } = string.Empty;
    
    public bool IsGenerated { get; set; }

    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}