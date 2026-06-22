using FitnessApp.Domain.Enums;

namespace FitnessApp.Domain.Entities;

public class WorkoutSession : BaseEntity
{
    public string AppUserId { get; set; } = string.Empty;
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = null;
    public DateTime StartedAtUtc { get; private set; } = DateTime.UtcNow;
    public DateTime? FinishedAtUtc { get; private set; }
    
    public WorkoutSessionStatus Status { get; private set; } = WorkoutSessionStatus.InProgress;
    
    public string? Notes { get; set; }

    public ICollection<SetLog> SetLogs { get; set; } = new List<SetLog>();

    public void Pause()
    {
        if (Status != WorkoutSessionStatus.InProgress)
        {
            throw new InvalidOperationException("Only in progress sessions can be paused.");
        }
        Status = WorkoutSessionStatus.Paused;
    }

    public void Resume()
    {
        if (Status != WorkoutSessionStatus.Paused)
        {
            throw new InvalidOperationException("Only paused sessions can be resumed.");
        }
        Status = WorkoutSessionStatus.InProgress;
    }

    public void Complete()
    {
        if (Status != WorkoutSessionStatus.InProgress)
        {
            throw new InvalidOperationException("Only in progress sessions can be completed.");
        }
        Status = WorkoutSessionStatus.Completed;
        FinishedAtUtc = DateTime.UtcNow;
    }
    
    public void Cancel()
    {
        if (Status == WorkoutSessionStatus.Completed)
        {
            throw new InvalidOperationException("Completed sessions cannot be cancelled.");
        }

        if (Status == WorkoutSessionStatus.Cancelled)
        {
            throw new InvalidOperationException("The WorkoutSession is already cancelled.");       
        }
        Status = WorkoutSessionStatus.Cancelled;
        FinishedAtUtc = DateTime.UtcNow;
    }
}