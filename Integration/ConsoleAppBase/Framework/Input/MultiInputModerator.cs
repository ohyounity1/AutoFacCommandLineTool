using System.Collections.Generic;

namespace ConsoleApp.Framework.Input
{
    public class MultiInputModerator : IInputModerator
    {
        private readonly IEnumerable<IInputModerator> _moderators;

        public MultiInputModerator(IEnumerable<IInputModerator> moderators)
        {
            _moderators = moderators;
        }

        public string Modify(string input)
        {
            string @finally = input;
            foreach(var moderator in _moderators)
            {
                @finally = moderator.Modify(@finally);
            }
            return @finally;
        }
    }
}
