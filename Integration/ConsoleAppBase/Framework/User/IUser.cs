using ConsoleApp.Framework.Commands;

namespace ConsoleApp.Framework.User
{
    public interface IUser
    {
        bool AllowCommand(ICommand command);
        string Name { get; }
        string Password { get; }
        Users Type { get; }
    }
}
