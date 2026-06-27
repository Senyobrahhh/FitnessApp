using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Data.Configurations;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.HasKey(workout => workout.Id);
        
        builder.Property(workout => workout.Title).IsRequired().HasMaxLength(150);
        
        builder.Property(workout => workout.Description).HasMaxLength(1000);
        
        builder.HasMany(workout => workout.WorkoutExercises)
            .WithOne(workoutExercise => workoutExercise.Workout)
            .HasForeignKey(workoutExercise => workoutExercise.WorkoutId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(workout => workout.WorkoutSessions)
            .WithOne(workoutSession => workoutSession.Workout)
            .HasForeignKey(workoutSession => workoutSession.WorkoutId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(workout => new
        {
            workout.FitnessProgramId,
            workout.WeekNumber,
            workout.DayNumber
        });
    }
}