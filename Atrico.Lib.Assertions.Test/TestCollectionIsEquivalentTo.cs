using System.Collections.Generic;
using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestCollectionIsEquivalentTo
    {
        [Test]
        public void TestCollectionIsEquivalentToPassEqual()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionIsEquivalentToPassWrongOrder()
        {
            // Arrange
            var actual = new List<int> {1, 3, 2, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionIsEquivalentToFailMissingItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionIsEquivalentToFailExtraItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 4, 5};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionIsEquivalentToFailWrongItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 2, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionIsEquivalentToMessageMissingItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EquivalentTo failed. Expected:<[1,2,3,4]>, Actual:<[1,2,4]>: Count<-1>, Missing<[3]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionIsEquivalentToMessageExtraItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 4};
            var expected = new[] {1, 2, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EquivalentTo failed. Expected:<[1,2,4]>, Actual:<[1,2,3,4]>: Count<+1>, Extra<[3]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionIsEquivalentToMessageExtraAndMissingItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3};
            var expected = new[] {1, 2, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EquivalentTo failed. Expected:<[1,2,4]>, Actual:<[1,2,3]>: Missing<[4]>, Extra<[3]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionIsEquivalentToMessageExtraDuplicateItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 3};
            var expected = new[] {1, 2, 3};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EquivalentTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EquivalentTo failed. Expected:<[1,2,3]>, Actual:<[1,2,3,3]>: Count<+1>, Extra<[3]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}