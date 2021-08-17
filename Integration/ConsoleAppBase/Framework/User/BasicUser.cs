using ConsoleApp.Framework.Commands;

namespace ConsoleApp.Framework.User
{
    public class BasicUser : IUser
    {
        public string Name => "Operator";

        public string Password => "basic";

        public Users Type => Users.Basic;

        public bool AllowCommand(ICommand command) => command.BasicAllowed;
    }
}
