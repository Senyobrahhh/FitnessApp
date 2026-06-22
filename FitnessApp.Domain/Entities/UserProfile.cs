using System.ComponentModel.DataAnnotations;
using FitnessApp.Domain.Enums;

namespace FitnessApp.Domain.Entities;

public class UserProfile : BaseEntity
{
    public string AppUserId { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public BiologicalSex? BiologicalSex { get; set;}
    public decimal? HeightCm { get; set; }
    public decimal? WeightKg { get; set; }
    public decimal? GoalWeightKg { get; set; }
    public FitnessGoal Goal { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    
}