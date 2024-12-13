using Microsoft.Extensions.DependencyInjection;

namespace Framework.Application
{
    public class CommandBus : ICommandBus
    {
        IServiceProvider serviceProvider;

        public CommandBus(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler=serviceProvider.GetService<ICommandHandler<TCommand>>();
            commandHandler.Handle(command);
        }
    }
}