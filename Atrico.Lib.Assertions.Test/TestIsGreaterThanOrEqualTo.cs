using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Tests
{
    [TestFixture]
    public class TestIsGreaterThanOrEqualTo
    {
        [Test]
        public void TestIsGreaterThanOrEqualToPassMore()
        {
            // Arrange
            const int actual = 2;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().GreaterThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsGreaterThanOrEqualToPassEqual()
        {
            // Arrange
            const int actual = 2;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().GreaterThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsGreaterThanOrEqualToFailLess()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().GreaterThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsGreaterThanOrEqualToMessage()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().GreaterThanOrEqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.GreaterThanOrEqualTo({0}) failed. Actual:<{1}>", expected, actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestIsNotGreaterThanOrEqualToFailMore()
        {
            // Arrange
            const int actual = 2;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().GreaterThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNotGreaterThanOrEqualToFailEqual()
        {
            // Arrange
            const int actual = 2;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().GreaterThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNotGreaterThanOrEqualToPassLess()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().GreaterThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsNotGreaterThanOrEqualToMessage()
        {
            // Arrange
            const int actual = 2;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().GreaterThanOrEqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.Not.GreaterThanOrEqualTo({0}) failed. Actual:<{1}>", expected, actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}