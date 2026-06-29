using FitnessApp.Application.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using FitnessApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _context;

    public ExerciseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Exercise>> GetAllAvailableForUserAsync(string appUserId)
    {
        return await _context.Exercises
            .Where(exercise =>
                exercise.CreatedByAppUserId == null ||
                exercise.CreatedByAppUserId == appUserId)
            .OrderBy(exercise => exercise.Name)
            .ToListAsync();
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await _context.Exercises
            .FirstOrDefaultAsync(exercise => exercise.Id == id);
    }

    public async Task<Exercise?> GetByIdForUserAsync(int id, string appUserId)
    {
        return await _context.Exercises
            .FirstOrDefaultAsync(exercise =>
                exercise.Id == id &&
                (exercise.CreatedByAppUserId == null ||
                 exercise.CreatedByAppUserId == appUserId));
    }
    
    public async Task AddAsync(Exercise exercise)
    {
        await _context.Exercises.AddAsync(exercise);
    }

    public void Update(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
    }

    public void Delete(Exercise exercise)
    {
        _context.Exercises.Remove(exercise);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}