using System.Diagnostics;

namespace Framework.Application
{
    public class CommandHandlerLoggerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        ICommandHandler<TCommand> commandHandler;

        public CommandHandlerLoggerDecorator(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public void Handle(TCommand command)
        {
            //Log To anywhere
            Console.Write(command.ToString());
            commandHandler.Handle(command);
        }
    }
}