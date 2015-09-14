using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Tests
{
    [TestFixture]
    public class TestIsNull
    {
        private class TestObject
        {
        }

        [Test]
        public void TestIsNullPass()
        {
            // Arrange
            const object actual = null;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Null()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsNullFail()
        {
            // Arrange
            object actual = new TestObject();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Null()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNullMessage()
        {
            // Arrange
            object actual = new TestObject();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Null()));

            // Assert
            var expectedMsg = string.Format("Is.Null failed. Actual:<{0}>", actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestIsNotNullPass()
        {
            // Arrange
            object actual = new TestObject();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().Null()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsNotNullFail()
        {
            // Arrange
            const object actual = null;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().Null()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNotNullMessage()
        {
            // Arrange
            const object actual = null;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().Null()));

            // Assert
            var expectedMsg = string.Format("Is.Not.Null failed.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}