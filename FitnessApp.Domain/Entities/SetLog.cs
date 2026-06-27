namespace FitnessApp.Domain.Entities;

public class SetLog : BaseEntity
{
    public int WorkoutSessionId { get; set; }
    public WorkoutSession WorkoutSession { get; set; } = null;
    
    public int WorkoutExerciseId { get; set; }
    public WorkoutExercise WorkoutExercise { get; set; } = null;
    
    public int SetNumber { get; set; }
    public int Reps { get; set; }
    public decimal? WeightKg { get; set; }
    public string? Notes { get; set; }
}