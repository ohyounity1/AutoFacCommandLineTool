using System;
using ConsoleApp.Framework.Console;
using ConsoleApp.Framework.Input;
using ConsoleApp.Framework.Prompt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CommandLineUnitTests
{
    [TestClass]
    public class InputManagerTests
    {
        [TestMethod]
        public void TestWritePrompt()
        {
            var mockedConsole = new Mock<IConsole>(MockBehavior.Strict);
            var mockedPrompt = new Mock<ICommandPrompt>(MockBehavior.Strict);
            mockedPrompt.Setup((c) => c.Prompt).Returns(() => ">");

            mockedConsole.Setup((c) => c.ReadLine()).Returns(() => "Dr. Dongle Blueberry Sr. Esq. III Attorney at Lawls");

            var wroteThis = string.Empty;

            mockedConsole.Setup((c) => c.Write(mockedPrompt.Object.Prompt)).Callback<string>((s) => wroteThis = s);

            var mockedDecorator = new Mock<IConsoleDecorator>(MockBehavior.Loose);
            var inputManager = new InputManager(mockedConsole.Object, 
                mockedPrompt.Object, 
                new BasicReadLineStrategy(mockedConsole.Object), 
                new LowerInputModerator(), 
                (c) => mockedDecorator.Object);

            var input = inputManager.ReadInput();
            Assert.AreEqual(">", wroteThis);
        }

        [TestMethod]
        public void TestModifyInput()
        {
            var mockedConsole = new Mock<IConsole>(MockBehavior.Strict);
            var mockedPrompt = new Mock<ICommandPrompt>(MockBehavior.Strict);
            mockedPrompt.Setup((c) => c.Prompt).Returns(() => ">");

            mockedConsole.Setup((c) => c.ReadLine()).Returns(() => "Dr. Dongle Blueberry Sr. Esq. III Attorney at Lawls");

            var wroteThis = string.Empty;

            mockedConsole.Setup((c) => c.Write(mockedPrompt.Object.Prompt));

            var mockedDecorator = new Mock<IConsoleDecorator>(MockBehavior.Loose);
            var inputManager = new InputManager(mockedConsole.Object,
                mockedPrompt.Object,
                new BasicReadLineStrategy(mockedConsole.Object),
                new LowerInputModerator(),
                (c) => mockedDecorator.Object);

            var input = inputManager.ReadInput();
            Assert.AreEqual("dr. dongle blueberry sr. esq. iii attorney at lawls", input);
        }
    }
}
