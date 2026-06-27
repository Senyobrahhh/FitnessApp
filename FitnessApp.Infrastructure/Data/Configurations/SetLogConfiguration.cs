using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Data.Configurations;

public class SetLogConfiguration : IEntityTypeConfiguration<SetLog>
{
    public void Configure(EntityTypeBuilder<SetLog> builder)
    {
        builder.HasKey(setLog => setLog.Id);
        
        builder.Property(setLog => setLog.WeightKg).HasPrecision(6, 2);

        builder.HasIndex(setLog => new
            {
                setLog.WorkoutSessionId,
                setLog.WorkoutExerciseId,
                setLog.SetNumber
            })
            .IsUnique();
    }
}