using System;

namespace ConsoleApp.Framework.Prompt
{
    public class DateTimeStampPrompt : ICommandPrompt
    {
        public string Prompt => DateTime.Now.ToString() + "> ";
    }
}
