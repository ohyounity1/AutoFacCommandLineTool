using System;
using Libraries.Utility.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameworkUnitTests
{
    [TestClass]
    public class Notify
    {
        [TestMethod]
        public void TestValueTypeInit()
        {
            var changed = false;

            var notify = new Notify<int>(() => changed = true);
            Assert.IsFalse(changed);
        }

        [TestMethod]
        public void TestValueTypeChanged()
        {
            var changed = false;

            var notify = new Notify<int>(() => changed = true);
            notify.Value = 5;
            Assert.IsTrue(changed);
        }

        [TestMethod]
        public void TestReferenceTypeInit()
        {
            var changed = false;

            var notify = new Notify<string>(() => changed = true);
            Assert.IsFalse(changed);
        }

        [TestMethod]
        public void TestReferenceTypeChanged()
        {
            var changed = false;

            var notify = new Notify<string>(() => changed = true);
            notify.Value = "new";
            Assert.IsTrue(changed);
        }

        [TestMethod]
        public void TestReferenceTypeChangeToNull()
        {
            var changed = false;

            var notify = new Notify<string>(() => changed = true);
            notify.Value = "new";
            changed = false;
            notify.Value = null;
            Assert.IsTrue(changed);
        }
    }
}
