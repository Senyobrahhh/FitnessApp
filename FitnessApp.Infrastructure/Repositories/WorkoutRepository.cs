using FitnessApp.Application.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using FitnessApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly ApplicationDbContext _context;

    public WorkoutRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Workout>> GetByFitnessProgramIdAsync(
        int fitnessProgramId)
    {
        return await _context.Workouts
            .Where(workout => workout.FitnessProgramId == fitnessProgramId)
            .Include(workout => workout.WorkoutExercises)
            .ThenInclude(workoutExercise => workoutExercise.Exercise)
            .OrderBy(workout => workout.WeekNumber)
            .ThenBy(workout => workout.DayNumber)
            .ToListAsync();
    }

    public async Task<Workout?> GetByIdAsync(int id)
    {
        return await _context.Workouts
            .Include(workout => workout.WorkoutExercises)
            .ThenInclude(workoutExercise => workoutExercise.Exercise)
            .FirstOrDefaultAsync(workout => workout.Id == id);
    }
    
    public async Task<Workout?> GetByIdForUserAsync(int id, string appUserId)
    {
        return await _context.Workouts
            .Include(workout => workout.FitnessProgram)
            .Include(workout => workout.WorkoutExercises)
            .ThenInclude(workoutExercise => workoutExercise.Exercise)
            .FirstOrDefaultAsync(workout =>
                workout.Id == id &&
                workout.FitnessProgram.AppUserId == appUserId);
    }

    public async Task AddAsync(Workout workout)
    {
        await _context.Workouts.AddAsync(workout);
    }

    public void Update(Workout workout)
    {
        _context.Workouts.Update(workout);
    }

    public void Delete(Workout workout)
    {
        _context.Workouts.Remove(workout);
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}