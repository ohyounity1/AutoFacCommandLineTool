using System.Collections.Generic;
using ConsoleApp.Framework.User;

namespace ConsoleApp.Framework.Commands
{
    public interface ICommandFactory
    {
        IDictionary<string, ICommand> CreateCommands(IUser currentUser);
    }
}
