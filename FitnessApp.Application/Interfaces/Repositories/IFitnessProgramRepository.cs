using FitnessApp.Domain.Entities;

namespace FitnessApp.Application.Interfaces.Repositories;

public interface IFitnessProgramRepository
{
    Task<List<FitnessProgram>> GetAllByUserIdAsync(string appUserId);

    Task<FitnessProgram?> GetByIdForUserAsync(int id, string appUserId);

    Task AddAsync(FitnessProgram fitnessProgram);

    void Delete(FitnessProgram fitnessProgram);

    Task SaveChangesAsync();
}