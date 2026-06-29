using FitnessApp.Application.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using FitnessApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly ApplicationDbContext _context;

    public UserProfileRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<UserProfile?> GetByAppUserIdAsync(string appUserId)
    {
        return await _context.UserProfiles
            .FirstOrDefaultAsync(profile => profile.AppUserId == appUserId);
    }

    public async Task AddAsync(UserProfile userProfile)
    {
        await _context.UserProfiles.AddAsync(userProfile);
    }

    public void Update(UserProfile userProfile)
    {
        _context.UserProfiles.Update(userProfile);
    }

    public async Task<bool> ExistsForUserAsync(string appUserId)
    {
        return await _context.UserProfiles
            .AnyAsync(profile => profile.AppUserId == appUserId);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}