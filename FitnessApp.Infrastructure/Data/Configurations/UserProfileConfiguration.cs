using FitnessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Infrastructure.Data.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(profile => profile.Id);
        
        builder.Property(profile => profile.AppUserId).IsRequired().HasMaxLength(450);
        
        builder.HasIndex(profile => profile.AppUserId).IsUnique();
        
        builder.Property(profile => profile.DisplayName).IsRequired().HasMaxLength(100);
        
        builder.Property(profile => profile.HeightCm).HasPrecision(5, 2);
        
        builder.Property(profile => profile.WeightKg).HasPrecision(5, 2);
        
        builder.Property(profile => profile.GoalWeightKg).HasPrecision(5, 2);
    }
}