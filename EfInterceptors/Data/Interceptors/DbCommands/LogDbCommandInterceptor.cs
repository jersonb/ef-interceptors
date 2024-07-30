using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfInterceptors.Data.Interceptors.DbCommands;

public class LogDbCommandInterceptor(ILogger<LogDbCommandInterceptor> logger)
    : DbCommandInterceptor
{
    public override void CommandCanceled(DbCommand command, CommandEndEventData eventData)
    {
        logger.LogInformation(nameof(CommandCanceled));
        base.CommandCanceled(command, eventData);
    }

    public override Task CommandCanceledAsync(DbCommand command, CommandEndEventData eventData, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(CommandCanceledAsync));
        return base.CommandCanceledAsync(command, eventData, cancellationToken);
    }

    public override DbCommand CommandCreated(CommandEndEventData eventData, DbCommand result)
    {
        logger.LogInformation(nameof(CommandCreated));
        return base.CommandCreated(eventData, result);
    }

    public override InterceptionResult<DbCommand> CommandCreating(CommandCorrelatedEventData eventData, InterceptionResult<DbCommand> result)
    {
        logger.LogInformation(nameof(CommandCreating));
        return base.CommandCreating(eventData, result);
    }

    public override void CommandFailed(DbCommand command, CommandErrorEventData eventData)
    {
        logger.LogInformation(nameof(CommandFailed));
        base.CommandFailed(command, eventData);
    }

    public override Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(CommandFailedAsync));
        return base.CommandFailedAsync(command, eventData, cancellationToken);
    }

    public override DbCommand CommandInitialized(CommandEndEventData eventData, DbCommand result)
    {
        logger.LogInformation(nameof(CommandInitialized));
        return base.CommandInitialized(eventData, result);
    }

    public override InterceptionResult DataReaderClosing(DbCommand command, DataReaderClosingEventData eventData, InterceptionResult result)
    {
        logger.LogInformation(nameof(DataReaderClosing));
        return base.DataReaderClosing(command, eventData, result);
    }

    public override ValueTask<InterceptionResult> DataReaderClosingAsync(DbCommand command, DataReaderClosingEventData eventData, InterceptionResult result)
    {
        logger.LogInformation(nameof(DataReaderClosingAsync));
        return base.DataReaderClosingAsync(command, eventData, result);
    }

    public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
    {
        logger.LogInformation(nameof(DataReaderDisposing));
        return base.DataReaderDisposing(command, eventData, result);
    }

    public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
    {
        logger.LogInformation(nameof(NonQueryExecuted));
        return base.NonQueryExecuted(command, eventData, result);
    }

    public override ValueTask<int> NonQueryExecutedAsync(DbCommand command, CommandExecutedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(NonQueryExecutedAsync));
        return base.NonQueryExecutedAsync(command, eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
    {
        logger.LogInformation(nameof(NonQueryExecuting));
        return base.NonQueryExecuting(command, eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(NonQueryExecutingAsync));
        return base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
    }

    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        logger.LogInformation(nameof(ReaderExecuted));
        return base.ReaderExecuted(command, eventData, result);
    }

    public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(ReaderExecutedAsync));
        return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        logger.LogInformation(nameof(ReaderExecuting));
        return base.ReaderExecuting(command, eventData, result);
    }

    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(ReaderExecutingAsync));
        return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
    }

    public override object? ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object? result)
    {
        logger.LogInformation(nameof(ScalarExecuted));
        return base.ScalarExecuted(command, eventData, result);
    }

    public override ValueTask<object?> ScalarExecutedAsync(DbCommand command, CommandExecutedEventData eventData, object? result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(ScalarExecutedAsync));
        return base.ScalarExecutedAsync(command, eventData, result, cancellationToken);
    }

    public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
    {
        logger.LogInformation(nameof(ScalarExecuting));
        return base.ScalarExecuting(command, eventData, result);
    }

    public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(nameof(ScalarExecutingAsync));
        return base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
    }
}