namespace FitnessApp.Domain.Entities;

public class WorkoutExercise : BaseEntity
{
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null;
    
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null;
    
    public int Order { get; set; }
    public int PlannedReps { get; set; }
    public int PlannedSets { get; set; }
    public string? Notes { get; set; }
    
    public ICollection<SetLog> SetLogs { get; set; } = new List<SetLog>();
}