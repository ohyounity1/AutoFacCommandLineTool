namespace ConsoleApp.Framework.Commands
{
    public interface ICommand
    {
        void Execute(string[] args);
        string Description { get; }
        string Name { get; }
        bool BasicAllowed { get; }
    }
}
