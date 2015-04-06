using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestIsGreaterThan
    {
        [Test]
        public void TestIsGreaterThanPassMore()
        {
            // Arrange
            const int actual = 2;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().GreaterThan(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsGreaterThanFailEqual()
        {
            // Arrange
            const int actual = 2;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().GreaterThan(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsGreaterThanFailLess()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().GreaterThan(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsGreaterThanMessage()
        {
            // Arrange
            const int actual = 2;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().GreaterThan(expected)));

            // Assert
            var expectedMsg = string.Format("Is.GreaterThan({0}) failed. Actual:<{1}>", expected, actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestIsNotGreaterThanFailMore()
        {
            // Arrange
            const int actual = 2;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().GreaterThan(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNotGreaterThanPassEqual()
        {
            // Arrange
            const int actual = 2;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().GreaterThan(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsNotGreaterThanPassLess()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().GreaterThan(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsNotGreaterThanMessage()
        {
            // Arrange
            const int actual = 3;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().GreaterThan(expected)));

            // Assert
            var expectedMsg = string.Format("Is.Not.GreaterThan({0}) failed. Actual:<{1}>", expected, actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}