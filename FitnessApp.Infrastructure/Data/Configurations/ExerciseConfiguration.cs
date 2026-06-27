using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Data.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.HasKey(exercise => exercise.Id);
        
        builder.Property(exercise => exercise.Name).IsRequired().HasMaxLength(150);
        
        builder.Property(exercise => exercise.Description).HasMaxLength(500);
        
        builder.Property(exercise => exercise.Instructions).HasMaxLength(2000);
        
        builder.Property(exercise => exercise.CreatedByAppUserId).HasMaxLength(450);

        builder.HasMany(exercise => exercise.WorkoutExercises)
            .WithOne(workoutExercise => workoutExercise.Exercise)
            .HasForeignKey(workoutExercise => workoutExercise.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}