using System;

namespace ConsoleApp.Framework.User
{
    public class CurrentUserChangedEventArgs : EventArgs
    {
        public IUser CurrentUser { get; }

        public CurrentUserChangedEventArgs(IUser user)
        {
            CurrentUser = user;
        }
    }
}
