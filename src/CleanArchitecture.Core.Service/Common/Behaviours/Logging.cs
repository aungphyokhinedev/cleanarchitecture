using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Core.Service;
public class Logging<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public Logging(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        
        _logger.LogInformation("CleanArchitecture Request: {Name} {@Request}",
            requestName, request);
    }
}