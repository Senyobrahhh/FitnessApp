using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Data.Configurations;

public class FitnessProgramConfiguration : IEntityTypeConfiguration<FitnessProgram>
{
    public void Configure(EntityTypeBuilder<FitnessProgram> builder)
    {
        builder.HasKey(program => program.Id);
        
        builder.Property(program => program.Title).IsRequired().HasMaxLength(150);
        
        builder.Property(program => program.Description).HasMaxLength(1000);
        
        builder.Property(program => program.AppUserId).HasMaxLength(450).IsRequired();
        
        builder.HasMany(program => program.Workouts)
            .WithOne(workout => workout.FitnessProgram)
            .HasForeignKey(workout => workout.FitnessProgramId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}