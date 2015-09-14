using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Tests
{
    [TestFixture]
    public class TestIsEqualTo
    {
        [Test]
        public void TestEqualToPass()
        {
            // Arrange
            const int actual = 1;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestEqualToFail()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestEqualToMessage()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EqualTo failed. Expected:<{0} [{2}]>, Actual:<{1} [{2}]>", expected, actual, actual.GetType().Name);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestEqualToMessagePlus()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;
            const string message = "message";

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected), message));

            // Assert
            var expectedMsg = string.Format("Is.EqualTo failed. Expected:<{0} [{2}]>, Actual:<{1} [{2}]> ({3})", expected, actual, actual.GetType().Name, message);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestNotEqualToPass()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestNotEqualToFail()
        {
            // Arrange
            const int actual = 1;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestNotEqualToMessage()
        {
            // Arrange
            const int actual = 1;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.Not.EqualTo failed. Expected:<{0} [{2}]>, Actual:<{1} [{2}]>", expected, actual, actual.GetType().Name);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}
