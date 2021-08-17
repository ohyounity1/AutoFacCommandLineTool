namespace ConsoleApp.Framework.Input
{
    public class LowerInputModerator : IInputModerator
    {
        public string Modify(string input)
        {
            return input.ToLower();
        }
    }
}
