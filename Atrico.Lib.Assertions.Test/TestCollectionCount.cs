using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestCollectionCount
    {
        [Test]
        public void TestCollectionCountEqualToPass()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = actual.Length;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionCountEqualToFail()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = actual.Length + 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionCountEqualToMessage()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = actual.Length + 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Is().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Count.Is.EqualTo failed. Expected:<{0} [{2}]>, Actual:<{1} [{2}]>", expected, actual.Length, expected.GetType().Name);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionCountNotEqualToPass()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = actual.Length + 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Is().Not().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionCountNotEqualToFail()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = actual.Length;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Is().Not().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionCountNotEqualToMessage()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = actual.Length;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Is().Not().EqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Count.Is.Not.EqualTo failed. Expected:<{0} [{2}]>, Actual:<{1} [{2}]>", expected, actual.Length, expected.GetType().Name);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionCountSatisfyPass()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = actual.Length;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Does().Satisfy().Predicate(a => a == expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionCountSatisfyFail()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = actual.Length + 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Does().Satisfy().Predicate(a => a == expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestCollectionCountSatisfyMessage()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = actual.Length + 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Does().Satisfy().Predicate(a => a == expected)));

            // Assert
            var expectedMsg = string.Format("Count.Does.Satisfy.Predicate failed. Subject:<{0}>", actual.Length);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestCollectionCountwithPredicate()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            const int expected = 2;
            var constraintTrue = Value.Of(actual).Count(i => i <= 2).Is().EqualTo(expected);
            var constraintFalse = Value.Of(actual).Count(i => i <= 2).Is().EqualTo(expected + 1);

            // Act
            var resultTrue = constraintTrue.Check();
            var resultFalse = constraintFalse.Check();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(resultTrue, "True");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(resultFalse, "False");
        }
    }
}
