using System.Collections.Generic;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Tests
{
    [TestFixture]
    public class TestCollectionIsEquivalentToCustomComparer
    {
        [Test]
        public void TestCollectionIsEquivalentToPassPredicate()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 4};
            var expected = new[] {2, 4, 6, 8};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected, (a, e) => a.Equals(e/2))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionIsEquivalentToFailPredicate()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected, (a, e) => a.Equals(e/2))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }
    }
}