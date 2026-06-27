using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Data.Configurations;

public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        builder.HasKey(workoutExercise => workoutExercise.Id);
        
        builder.Property(workoutExercise => workoutExercise.Notes).HasMaxLength(1000);

        builder.HasIndex(workoutExercise => new
            {
                workoutExercise.WorkoutId,
                workoutExercise.Order
            })
            .IsUnique();
        
        builder.HasMany(workoutExercise => workoutExercise.SetLogs)
            .WithOne(setLog => setLog.WorkoutExercise)
            .HasForeignKey(setLog => setLog.WorkoutExerciseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}