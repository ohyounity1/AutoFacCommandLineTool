namespace ConsoleApp.Framework.Prompt
{
    public class CustomizedCommandPrompt : ICommandPrompt
    {
        private readonly string _customizedString;

        public CustomizedCommandPrompt(string customizedString)
        {
            _customizedString = customizedString;
        }

        public string Prompt => _customizedString;
    }
}
