namespace FitnessApp.Domain.Entities;

public class Workout : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int WeekNumber { get; set; }
    public int DayNumber { get; set; }
    public bool IsRestDay { get; set; }
    
    public int FitnessProgramId { get; set; }
    public FitnessProgram FitnessProgram { get; set; } = null;
    
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    
    public ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
}