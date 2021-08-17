using System;
using ConsoleApp.Framework.Commands;

namespace ConsoleApp.Framework.User
{
    public class AdminUser : IUser
    {
        public string Name => "admin";

        public string Password => "admin";

        public Users Type => Users.Admin;

        public bool AllowCommand(ICommand command) => true;
    }
}
