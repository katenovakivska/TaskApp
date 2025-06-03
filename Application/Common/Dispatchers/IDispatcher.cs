using Application.Common.Interfaces;

namespace Application.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task<TResult> Send<TCommand, TResult>(TCommand command)
        where TCommand : ICommand<TResult>;

        Task<TResult> Query<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>;
    }
}
