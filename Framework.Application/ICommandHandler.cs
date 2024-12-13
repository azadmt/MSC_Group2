namespace Framework.Application
{
    public interface ICommandHandler<TCommand>  where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}