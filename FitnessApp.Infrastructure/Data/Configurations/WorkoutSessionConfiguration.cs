using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Data.Configurations;

public class WorkoutSessionConfiguration : IEntityTypeConfiguration<WorkoutSession>
{
    public void Configure(EntityTypeBuilder<WorkoutSession> builder)
    {
        builder.HasKey(workoutSession => workoutSession.Id);
        
        builder.Property(workoutSession => workoutSession.AppUserId).IsRequired().HasMaxLength(450);
        
        builder.HasMany(workoutSession => workoutSession.SetLogs)
            .WithOne(setLog => setLog.WorkoutSession)
            .HasForeignKey(setLog => setLog.WorkoutSessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(workoutSession => workoutSession.AppUserId);

        builder.HasIndex(workoutSession => workoutSession.WorkoutId);
    }
}