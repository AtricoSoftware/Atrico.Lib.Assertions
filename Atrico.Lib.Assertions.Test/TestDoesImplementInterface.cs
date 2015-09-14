using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Tests
{
    [TestFixture]
    public class TestDoesImplementInterface
    {
        private interface INot
        {
        }

        private interface IBase
        {
        }

        private interface IDerived : IBase
        {
        }

        private class Base : IBase
        {
        }

        private class Derived : IDerived
        {
        }

        [Test]
        public void TestDoesImplementInterfaceSimplePass()
        {
            // Arrange
            var actual = new Base();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Implement().Interface(typeof (IBase))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestDoesImplementInterfaceDerivedPass()
        {
            // Arrange
            var actual = new Derived();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Implement().Interface(typeof (IBase))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestDoesImplementInterfaceFail()
        {
            // Arrange
            var actual = new Base();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Implement().Interface(typeof (INot))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestDoesImplementInterfaceMessage()
        {
            // Arrange
            var actual = new Base();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Implement().Interface(typeof (INot))));

            // Assert
            var expectedMsg = string.Format("Does.Implement.Interface<{0}> failed.", typeof (INot));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestDoesNotImplementInterfaceSimpleFail()
        {
            // Arrange
            var actual = new Base();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Implement().Interface(typeof (IBase))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestDoesNotImplementInterfaceDerivedFail()
        {
            // Arrange
            var actual = new Derived();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Implement().Interface(typeof (IBase))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestDoesNotImplementInterfacePass()
        {
            // Arrange
            var actual = new Base();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Implement().Interface(typeof (INot))));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestDoesNotImplementInterfaceMessage()
        {
            // Arrange
            var actual = new Base();

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Does().Not().Implement().Interface(typeof (IBase))));

            // Assert
            var expectedMsg = string.Format("Does.Not.Implement.Interface<{0}> failed.", typeof (IBase));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}