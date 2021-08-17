namespace ConsoleApp.Framework.Input
{
    public class TrimInputModerator : IInputModerator
    {
        public string Modify(string input)
        {
            return input.Trim();
        }
    }
}
