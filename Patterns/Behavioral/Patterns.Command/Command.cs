namespace Patterns.Command
{
    public abstract class Command : ICommand
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}