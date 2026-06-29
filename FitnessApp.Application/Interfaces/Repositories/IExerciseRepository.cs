using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Interfaces.Repositories;

public interface IExerciseRepository
{
    Task<List<Exercise>> GetAllAvailableForUserAsync(string appUserId);

    Task<Exercise?> GetByIdAsync(int id);

    Task<Exercise?> GetByIdForUserAsync(int id, string appUserId);

    Task AddAsync(Exercise exercise);

    void Update(Exercise exercise);

    void Delete(Exercise exercise);

    Task SaveChangesAsync();
}