using FitnessApp.Application.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using FitnessApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Repositories;

public class FitnessProgramRepository : IFitnessProgramRepository
{
    private readonly ApplicationDbContext _context;

    public FitnessProgramRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<FitnessProgram>> GetAllByUserIdAsync(string appUserId)
    {
        return await _context.FitnessPrograms
            .Where(program => program.AppUserId == appUserId)
            .Include(program => program.Workouts)
            .OrderByDescending(program => program.CreatedAtUtc)
            .ToListAsync();
    }

    public async Task<FitnessProgram?> GetByIdForUserAsync(
        int id,
        string appUserId)
    {
        return await _context.FitnessPrograms
            .Include(program => program.Workouts)
            .ThenInclude(workout => workout.WorkoutExercises)
            .ThenInclude(workoutExercise => workoutExercise.Exercise)
            .FirstOrDefaultAsync(program =>
                program.Id == id &&
                program.AppUserId == appUserId);
    }
    
    public async Task AddAsync(FitnessProgram fitnessProgram)
    {
        await _context.FitnessPrograms.AddAsync(fitnessProgram);
    }

    public void Delete(FitnessProgram fitnessProgram)
    {
        _context.FitnessPrograms.Remove(fitnessProgram);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}