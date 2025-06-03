using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Dispatchers
{
    public class Dispatcher: IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResult> Send<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            return handler.Handle(command);
        }

        public Task<TResult> Query<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return handler.Handle(query);
        }
    }
}
