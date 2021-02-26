using Core.Commands;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Decorators
{
    public class DeadlockRetryCommandHandlerDecorator<TCommand>
        : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _decorated;

        public DeadlockRetryCommandHandlerDecorator(ICommandHandler<TCommand> decorated)
        {
            _decorated = decorated;
        }

        public async Task Handle(TCommand command, CancellationToken cancellationToken)
        {
            await HandleWithRetry(command, 5, cancellationToken);
        }

        public async Task HandleWithRetry(TCommand command, int retries, CancellationToken cancellationToken)
        {
            try
            {
                await _decorated.Handle(command, cancellationToken);
            }
            catch (Exception ex)
            {
                if (retries <= 0 || !IsDeadlockException(ex))
                    throw;

                await Task.Delay(500, cancellationToken);
                await HandleWithRetry(command, retries - 1, cancellationToken);
            }
        }

        private bool IsDeadlockException(Exception ex) =>
            ex is DbException && ex.Message.Contains("deadlock") || (ex.InnerException != null && IsDeadlockException(ex.InnerException));
    }
}
