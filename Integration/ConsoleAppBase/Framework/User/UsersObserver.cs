using System;
using System.Collections.Generic;
using System.Linq;
using Libraries.Utility.Patterns;

namespace ConsoleApp.Framework.User
{
    public class UsersObserver
    {
        public event EventHandler<CurrentUserChangedEventArgs> CurrentUserChangedEvent;

        private readonly IEnumerable<IUser> _allUsers;
        private readonly Notify<IUser> _user;

        public UsersObserver(IEnumerable<IUser> allUsers)
        {
            _allUsers = allUsers;
            _user = new Notify<IUser>(() => CurrentUserChangedEvent?.Invoke(this, new CurrentUserChangedEventArgs(User)));
            User = _allUsers.Single(u => u.Type == Users.Basic);
        }

        public IUser User
        {
            get { return _user.Value; }
            set { _user.Value = value; }
        }

        public IUser GetUserByName(string name)
        {
            return _allUsers.SingleOrDefault((u) => u.Name == name);
        }
    }
}
