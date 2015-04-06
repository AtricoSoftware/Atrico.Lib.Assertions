using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestIsTypeOf
    {
        [Test]
        public void TestTypeOfPass()
        {
            // Arrange
            const int actual = 1;
            var expected = typeof (int);

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().TypeOf(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestTypeOfFail()
        {
            // Arrange
            const int actual = 1;
            var expected = typeof (float);

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().TypeOf(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsTypeOfMessage()
        {
            // Arrange
            const int actual = 1;
            var expected = typeof (float);

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().TypeOf(expected)));

            // Assert
            var expectedMsg = string.Format("Is.TypeOf<{0}> failed. Actual:<{1}>", expected, actual.GetType());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestNotTypeOfPass()
        {
            // Arrange
            const int actual = 1;
            var expected = typeof (float);

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().TypeOf(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestNotTypeOfFail()
        {
            // Arrange
            const int actual = 1;
            var expected = typeof (int);

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().TypeOf(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNotTypeOfMessage()
        {
            // Arrange
            const int actual = 1;
            var expected = typeof (int);

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().TypeOf(expected)));

            // Assert
            var expectedMsg = string.Format("Is.Not.TypeOf<{0}> failed. Actual:<{1}>", expected, actual.GetType());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}