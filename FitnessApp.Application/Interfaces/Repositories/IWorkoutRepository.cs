using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Interfaces.Repositories;

public interface IWorkoutRepository
{
    Task<List<Workout>> GetByFitnessProgramIdAsync(int fitnessProgramId);

    Task<Workout?> GetByIdAsync(int id);

    Task<Workout?> GetByIdForUserAsync(int id, string appUserId);

    Task AddAsync(Workout workout);

    void Update(Workout workout);

    void Delete(Workout workout);

    Task SaveChangesAsync();
}