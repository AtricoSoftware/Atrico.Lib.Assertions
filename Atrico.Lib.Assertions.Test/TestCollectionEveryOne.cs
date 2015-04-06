using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestCollectionEveryOne
    {
        [Test]
        public void TestCollectionEveryOneIsBetweenPass()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 1;
            const int upperLimit = 4;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).EveryOne().Is().Between(lowerLimit, upperLimit)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionEveryOneIsBetweenFail()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 2;
            const int upperLimit = 4;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).EveryOne().Is().Between(lowerLimit, upperLimit)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionEveryOneIsBetweenMessage()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 2;
            const int upperLimit = 3;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).EveryOne().Is().Between(lowerLimit, upperLimit)));

            // Assert
            var expectedMsg = string.Format("EveryOne.Is.Between({0} -> {1}) failed. Actual:<[*1*,2,3,*4*]>", lowerLimit,
                upperLimit);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionEveryOneIsNotBetweenPass()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 5;
            const int upperLimit = 6;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).EveryOne().Is().Not().Between(lowerLimit, upperLimit)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionEveryOneIsNotBetweenFail()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 1;
            const int upperLimit = 4;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).EveryOne().Is().Not().Between(lowerLimit, upperLimit)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionEveryOnetIsNotBetweenMessage()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int lowerLimit = 1;
            const int upperLimit = 4;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).EveryOne().Is().Not().Between(lowerLimit, upperLimit)));

            // Assert
            var expectedMsg = string.Format("EveryOne.Is.Not.Between({0} -> {1}) failed. Actual:<[*1*,*2*,*3*,*4*]>",
                lowerLimit, upperLimit);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}