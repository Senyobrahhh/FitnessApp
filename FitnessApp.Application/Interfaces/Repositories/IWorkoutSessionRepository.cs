using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Interfaces.Repositories;

public interface IWorkoutSessionRepository
{
    Task<List<WorkoutSession>> GetHistoryForUserAsync(string appUserId);

    Task<WorkoutSession?> GetByIdForUserAsync(int id, string appUserId);

    Task AddAsync(WorkoutSession workoutSession);

    void Update(WorkoutSession workoutSession);

    Task SaveChangesAsync();
}