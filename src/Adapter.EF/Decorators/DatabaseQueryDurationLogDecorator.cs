using Core.Queries;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter.EF.Decorators
{
    public class DatabaseQueryDurationLogDecorator<TQuery, TResult>
        : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly ILogger<TQuery> _logger;
        private readonly IQueryHandler<TQuery, TResult> _decorated;

        public DatabaseQueryDurationLogDecorator(
            ILogger<TQuery> logger,
            IQueryHandler<TQuery, TResult> decorated)
        {
            _logger = logger;
            _decorated = decorated;
        }

        public async Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = await _decorated.HandleAsync(query, cancellationToken);

            stopwatch.Stop();
            _logger.LogInformation($"Estimated query operation: {stopwatch.Elapsed.TotalMilliseconds} miliseconds");

            return result;
        }
    }
}
