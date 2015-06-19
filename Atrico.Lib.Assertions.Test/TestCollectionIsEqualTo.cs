using System.Collections.Generic;
using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestCollectionIsEqualTo
    {
        [Test]
        public void TestCollectionIsEqualToPassEqual()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionIsEqualToFailWrongOrder()
        {
            // Arrange
            var actual = new List<int> {1, 3, 2, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionIsEqualToFailMissingItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionIsEqualToFailExtraItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 4, 5};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionIsEqualToFailWrongItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 2, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionIsEqualToMessageMissingItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EqualTo failed. Expected:<[1,2,3,4]>, Actual:<[1,2,4]>: Count<-1>, Missing<[3]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionIsEqualToMessageExtraItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 4};
            var expected = new[] {1, 2, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EqualTo failed. Expected:<[1,2,4]>, Actual:<[1,2,3,4]>: Count<+1>, Extra<[3]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionIsEqualToMessageExtraAndMissingItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3};
            var expected = new[] {1, 2, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EqualTo failed. Expected:<[1,2,4]>, Actual:<[1,2,3]>: Missing<[4]>, Extra<[3]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionIsEqualToMessageExtraDuplicateItem()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 3};
            var expected = new[] {1, 2, 3};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EqualTo failed. Expected:<[1,2,3]>, Actual:<[1,2,3,3]>: Count<+1>, Extra<[3]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionIsEqualToMessageOneOutOfOrder()
        {
            // Arrange
            var actual = new List<int> {1, 2, 5, 3, 4};
            var expected = new[] {1, 2, 3, 4, 5};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EqualTo failed. Expected:<[1,2,3,4,5]>, Actual:<[1,2,5,3,4]>: OutOfOrder<[5]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionIsEqualToMessageTwoOutOfOrderAdjacent()
        {
            // Arrange
            var actual = new List<int> {1, 2, 4, 3, 5};
            var expected = new[] {1, 2, 3, 4, 5};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EqualTo failed. Expected:<[1,2,3,4,5]>, Actual:<[1,2,4,3,5]>: OutOfOrder<[3,4]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionIsEqualToMessageTwoOutOfOrderNonAdjacent()
        {
            // Arrange
            var actual = new List<int> {5, 2, 3, 4, 1};
            var expected = new[] {1, 2, 3, 4, 5};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.EqualTo failed. Expected:<[1,2,3,4,5]>, Actual:<[5,2,3,4,1]>: OutOfOrder<[1,5]>");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}