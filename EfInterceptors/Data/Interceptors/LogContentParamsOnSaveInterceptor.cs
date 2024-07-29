using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfInterceptors.Data.Interceptors;

public class LogContentParamsOnSaveInterceptor(ILogger<LogContentParamsOnSaveInterceptor> logger)
    : SaveChangesInterceptor
{
    private readonly JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true };

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)

    {
        var context = eventData.Context ?? throw new DbUpdateException();
        var database = context.Database;
        var changeTracker = context.ChangeTracker;

        var data = new
        {
            eventData = new
            {
                eventData.EventId,
                eventData.EventIdCode,
                eventData.LogLevel,
            },
            database = new
            {
                database.ProviderName,
                database.CurrentTransaction,
                database.AutoSavepointsEnabled,
                database.AutoTransactionBehavior,
            },
            changeTracker.AutoDetectChangesEnabled,
        };
        logger.LogInformation("Result: {@Result} Data: {@Data}", result.HasResult, JsonSerializer.Serialize(data, jsonSerializerOptions));
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context ?? throw new DbUpdateException();
        var database = context.Database;
        var changeTracker = context.ChangeTracker;

        var data = new
        {
            eventData = new
            {
                eventData.EventId,
                eventData.EventIdCode,
                eventData.LogLevel,
            },
            database = new
            {
                database.ProviderName,
                database.CurrentTransaction,
                database.AutoSavepointsEnabled,
                database.AutoTransactionBehavior,
            },
            changeTracker.AutoDetectChangesEnabled,
        };

        logger.LogInformation("Result: {@Result} Data: {@Data}", result, JsonSerializer.Serialize(data, jsonSerializerOptions));

        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }
}