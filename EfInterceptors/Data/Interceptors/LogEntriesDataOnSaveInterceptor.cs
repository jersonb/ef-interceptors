using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Extensions;

namespace EfInterceptors.Data.Interceptors;

public class LogEntriesDataOnSaveInterceptor(ILogger<LogEntriesDataOnSaveInterceptor> logger)
    : SaveChangesInterceptor
{
    private readonly JsonSerializerOptions options = new() { WriteIndented = true };

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        LogEntries(eventData);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        LogEntries(eventData);
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private void LogEntries(DbContextEventData eventData)
    {
        var context = eventData.Context ?? throw new DbUpdateException();

        var entries = context.ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            var members = entry.Members.Select(member => new
            {
                metadata = member.Metadata.Name,
                member.IsModified,
                member.CurrentValue,
            });

            var value = new
            {
                state = entry.State.GetDisplayName(),
                entry.Entity,
                members
            };

            logger.LogInformation("Data: {@Value}", JsonSerializer.Serialize(value, options));
        }
    }
}