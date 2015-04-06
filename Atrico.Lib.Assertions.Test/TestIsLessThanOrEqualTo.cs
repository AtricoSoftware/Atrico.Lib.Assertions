using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestIsLessThanOrEqualTo
    {
        [Test]
        public void TestIsLessThanOrEqualToPassLess()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().LessThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsLessThanOrEqualToPassEqual()
        {
            // Arrange
            const int actual = 2;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().LessThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsLessThanOrEqualToFailMore()
        {
            // Arrange
            const int actual = 2;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().LessThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsLessThanOrEqualToMessage()
        {
            // Arrange
            const int actual = 2;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().LessThanOrEqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.LessThanOrEqualTo({0}) failed. Actual:<{1}>", expected, actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestIsNotLessThanOrEqualToFailLess()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().LessThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNotLessThanOrEqualToFailEqual()
        {
            // Arrange
            const int actual = 2;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().LessThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNotLessThanOrEqualToPassMore()
        {
            // Arrange
            const int actual = 2;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().LessThanOrEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsNotLessThanOrEqualToMessage()
        {
            // Arrange
            const int actual = 1;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().LessThanOrEqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.Not.LessThanOrEqualTo({0}) failed. Actual:<{1}>", expected, actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}