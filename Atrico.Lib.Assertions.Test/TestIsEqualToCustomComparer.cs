using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestIsEqualToCustomComparer
    {
        [Test]
        public void TestEqualToPassPredicate()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected, (a, e) => a.Equals(((int) e)/2))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestEqualToFailPredicate()
        {
            // Arrange
            const int actual = 1;
            const int expected = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected, (a, e) => a.Equals(((int) e)/2))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }
    }
}