using Autofac;
using ConsoleApp.Framework.User;

using UserTypes = ConsoleApp.Framework.User.Users;

namespace Console.Config
{
    public class Users : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BasicUser>().As<IUser>().SingleInstance();
            builder.RegisterType<AdminUser>().As<IUser>().SingleInstance();

            builder.RegisterType<UsersObserver>().AsSelf().SingleInstance();
        }
    }
}
