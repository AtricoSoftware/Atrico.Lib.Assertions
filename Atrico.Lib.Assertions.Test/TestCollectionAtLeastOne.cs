using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Tests
{
    [TestFixture]
    public class TestCollectionAtLeastOne
    {
        [Test]
        public void TestCollectionAtLeastOneIsBetweenPass()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 3;
            const int upperLimit = 4;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).AtLeastOne().Is().Between(lowerLimit, upperLimit)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionAtLeastOneIsBetweenFail()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 6;
            const int upperLimit = 7;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).AtLeastOne().Is().Between(lowerLimit, upperLimit)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionAtLeastOneIsBetweenMessage()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 6;
            const int upperLimit = 7;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).AtLeastOne().Is().Between(lowerLimit, upperLimit)));

            // Assert
            var expectedMsg = string.Format("AtLeastOne.Is.Between({0} -> {1}) failed. Actual:<[1,2,3,4]>", lowerLimit,
                upperLimit);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionAtLeastOneIsNotBetweenPass()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 2;
            const int upperLimit = 4;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).AtLeastOne().Is().Not().Between(lowerLimit, upperLimit)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionAtLeastOneIsNotBetweenFail()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 1;
            const int upperLimit = 4;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).AtLeastOne().Is().Not().Between(lowerLimit, upperLimit)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionAtLeastOnetIsNotBetweenMessage()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 1;
            const int upperLimit = 4;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).AtLeastOne().Is().Not().Between(lowerLimit, upperLimit)));

            // Assert
            var expectedMsg = string.Format("AtLeastOne.Is.Not.Between({0} -> {1}) failed. Actual:<[1,2,3,4]>",
                lowerLimit, upperLimit);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}