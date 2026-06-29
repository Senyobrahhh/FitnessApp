using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Interfaces.Repositories;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetByAppUserIdAsync(string appUserId);

    Task AddAsync(UserProfile userProfile);

    void Update(UserProfile userProfile);

    Task<bool> ExistsForUserAsync(string appUserId);

    Task SaveChangesAsync();
}