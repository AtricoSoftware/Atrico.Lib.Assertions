using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestIsFalse
    {
        [Test]
        public void TestIsFalsePass()
        {
            // Arrange
            const bool actual = false;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().False()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsFalseFail()
        {
            // Arrange
            const bool actual = true;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().False()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsFalseMessage()
        {
            // Arrange
            const bool actual = true;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().False()));

            // Assert
            var expectedMsg = string.Format("Is.False failed.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestIsNotFalsePass()
        {
            // Arrange
            const bool actual = true;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().False()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsNotFalseFail()
        {
            // Arrange
            const bool actual = false;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().False()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNotFalseMessage()
        {
            // Arrange
            const bool actual = false;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().False()));

            // Assert
            var expectedMsg = string.Format("Is.Not.False failed.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}