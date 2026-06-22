using FitnessApp.Domain.Enums;

namespace FitnessApp.Domain.Entities;

public class Exercise : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Instructions { get; set; }
    public MuscleGroup PrimaryMuscleGroup { get; set; }
    public ExerciseType ExerciseType { get; set; }
    public EquipmentType EquipmentType { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    
    public string? CreatedByAppUserId { get; set; }
    
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    
}