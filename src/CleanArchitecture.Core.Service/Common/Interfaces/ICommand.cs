using MediatR;
namespace CleanArchitecture.Core.Service;

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
