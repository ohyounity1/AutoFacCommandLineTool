using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.UnitTests
{
    public static class AssertExt
    {
        public static void AssertThrows<T>(Action action)
        {
            try
            {
                action();
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(T));
                return;
            }
            throw new AssertFailedException("Exception of type: " + typeof(T) + " not thrown");
        }

        public static void AssertNoThrows<T>(Action action)
        {
            try
            {
                action();
            }
            catch (Exception)
            {
                throw new AssertFailedException("Exception of type: " + typeof(T) + "  thrown");
            }
            Assert.IsTrue(true);
        }
    }
}
