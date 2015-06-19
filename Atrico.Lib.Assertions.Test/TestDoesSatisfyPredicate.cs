using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestDoesSatisfyPredicate
    {
        [Test]
        public void TestDoesSatisfyPredicatePass()
        {
            // Arrange
            const int actual = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Satisfy().Predicate(a => a > 0)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestDoesSatisfyPredicateFail()
        {
            // Arrange
            const int actual = -1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Satisfy().Predicate(a => a > 0)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestDoesSatisfyPredicateMessage()
        {
            // Arrange
            const int actual = -1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Satisfy().Predicate(a => a > 0)));

            // Assert
            var expectedMsg = string.Format("Does.Satisfy.Predicate failed. Subject:<{0}>", actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestDoesNotSatisfyPredicatePass()
        {
            // Arrange
            const int actual = -1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Satisfy().Predicate(a => a > 0)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestDoesNotSatisfyPredicateFail()
        {
            // Arrange
            const int actual = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Satisfy().Predicate(a => a > 0)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestDoesNotSatisfyPredicateMessage()
        {
            // Arrange
            const int actual = 1;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Satisfy().Predicate(a => a > 0)));

            // Assert
            var expectedMsg = string.Format("Does.Not.Satisfy.Predicate failed. Subject:<{0}>", actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}