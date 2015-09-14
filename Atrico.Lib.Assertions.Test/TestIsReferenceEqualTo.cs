using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Tests
{
    [TestFixture]
    public class TestIsReferenceEqualTo
    {
        private class TestObject
        {
            public override int GetHashCode()
            {
                return 0;
            }

            public override bool Equals(object obj)
            {
                return true;
            }
        }

        [Test]
        public void TestReferenceEqualToPass()
        {
            // Arrange
            var actual = new TestObject();
            var expected = actual;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().ReferenceEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestReferenceEqualToFail()
        {
            // Arrange
            var actual = new TestObject();
            var expected = new TestObject();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().ReferenceEqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestReferenceEqualToMessage()
        {
            // Arrange
            var actual = new TestObject();
            var expected = new TestObject();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().ReferenceEqualTo(expected)));

            // Assert
            var expectedMsg = string.Format("Is.ReferenceEqualTo failed. Expected:<{0}>, Actual:<{1}>", expected, actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}