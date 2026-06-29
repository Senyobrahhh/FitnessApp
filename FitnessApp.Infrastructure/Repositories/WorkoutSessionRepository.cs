using FitnessApp.Application.Interfaces.Repositories;
using FitnessApp.Domain.Entities;
using FitnessApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Repositories;

public class WorkoutSessionRepository : IWorkoutSessionRepository
{
    private readonly ApplicationDbContext _context;

    public WorkoutSessionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<WorkoutSession>> GetHistoryForUserAsync(
        string appUserId)
    {
        return await _context.WorkoutSessions
            .Where(session => session.AppUserId == appUserId)
            .Include(session => session.Workout)
            .Include(session => session.SetLogs)
            .ThenInclude(setLog => setLog.WorkoutExercise)
            .ThenInclude(workoutExercise => workoutExercise.Exercise)
            .OrderByDescending(session => session.StartedAtUtc)
            .ToListAsync();
    }

    public async Task<WorkoutSession?> GetByIdForUserAsync(
        int id,
        string appUserId)
    {
        return await _context.WorkoutSessions
            .Include(session => session.Workout)
            .Include(session => session.SetLogs)
            .ThenInclude(setLog => setLog.WorkoutExercise)
            .ThenInclude(workoutExercise => workoutExercise.Exercise)
            .FirstOrDefaultAsync(session =>
                session.Id == id &&
                session.AppUserId == appUserId);
    }
    
    public async Task AddAsync(WorkoutSession workoutSession)
    {
        await _context.WorkoutSessions.AddAsync(workoutSession);
    }

    public void Update(WorkoutSession workoutSession)
    {
        _context.WorkoutSessions.Update(workoutSession);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}