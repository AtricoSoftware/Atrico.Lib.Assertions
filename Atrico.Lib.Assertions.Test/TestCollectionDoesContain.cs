using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Tests
{
    [TestFixture]
    public class TestCollectionDoesContain
    {
        [Test]
        public void TestCollectionDoesContainPass()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int expected = 3;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Contain(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionDoesContainFail()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int expected = 5;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Contain(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionDoesContainMessage()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int expected = 5;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Contain(expected)));

            // Assert
            var expectedMsg = string.Format("Does.Contain({0}) failed. Actual:<[1,2,3,4]>", expected);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionDoesNotContainPass()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int expected = 5;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Contain(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionDoesNotContainFail()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int expected = 3;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Contain(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionDoesNotContainMessage()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int expected = 3;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Contain(expected)));

            // Assert
            var expectedMsg = string.Format("Does.Not.Contain({0}) failed. Actual:<[1,2,3,4]>", expected);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}