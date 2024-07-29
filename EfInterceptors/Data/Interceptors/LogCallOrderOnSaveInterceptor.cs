using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfInterceptors.Data.Interceptors;

public class LogCallOrderOnSaveInterceptor(ILogger<LogCallOrderOnSaveInterceptor> logger)
    : SaveChangesInterceptor
{
    public override void SaveChangesCanceled(DbContextEventData eventData)
    {
        logger.LogInformation(nameof(SaveChangesCanceled));
        base.SaveChangesCanceled(eventData);
    }

    public override Task SaveChangesCanceledAsync(DbContextEventData eventData, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(SaveChangesCanceledAsync));
        return base.SaveChangesCanceledAsync(eventData, cancellationToken);
    }

    public override void SaveChangesFailed(DbContextErrorEventData eventData)
    {
        logger.LogInformation(nameof(SaveChangesFailed));
        base.SaveChangesFailed(eventData);
    }

    public override Task SaveChangesFailedAsync(DbContextErrorEventData eventData, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(SaveChangesFailedAsync));
        return base.SaveChangesFailedAsync(eventData, cancellationToken);
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        logger.LogInformation(nameof(SavedChanges));
        return base.SavedChanges(eventData, result);
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(SavedChangesAsync));
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        logger.LogInformation(nameof(SavingChanges));
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(SavingChangesAsync));

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult ThrowingConcurrencyException(ConcurrencyExceptionEventData eventData, InterceptionResult result)
    {
        logger.LogInformation(nameof(ThrowingConcurrencyException));
        return base.ThrowingConcurrencyException(eventData, result);
    }

    public override ValueTask<InterceptionResult> ThrowingConcurrencyExceptionAsync(ConcurrencyExceptionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(ThrowingConcurrencyExceptionAsync));
        return base.ThrowingConcurrencyExceptionAsync(eventData, result, cancellationToken);
    }
}