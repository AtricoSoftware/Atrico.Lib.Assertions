using System;
using System.Diagnostics;
using System.Threading;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Assertions.Test._Helpers;
using Atrico.Lib.Testing.NUnitAttributes;

namespace Atrico.Lib.Assertions.Test.Elements
{
    [TestFixture]
    public class TestWithinTimeoutElement
    {
        private readonly TimeSpan _timeout = TimeSpan.FromMilliseconds(1000);

        [Test]
        public void TestName()
        {
            // Arrange
            var value = new object();
            var constraint = Value.Of(value).WithinTimeout(_timeout).GetName();

            // Act
            var result = constraint.Name;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("WithinTimeout", result);
        }

        [Test]
        public void TestCheckValue()
        {
            // Arrange
            var value = new object();
            object actual = null;
            var constraint = Value.Of(value).WithinTimeout(_timeout).GetTestValue(val => actual = val);

            // Act
            constraint.Check();

            // Assert
            Debug.WriteLine(constraint.ErrorMessage);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSame(value, actual);
        }

        private static bool Delay(bool result, TimeSpan delay)
        {
            Thread.Sleep(delay);
            return result;
        }

        [Test]
        public void TestCheckWithinTimeout()
        {
            // Arrange
            var delay = _timeout - TimeSpan.FromMilliseconds(500);
            var constraintTrue = Value.Of(true).WithinTimeout(_timeout).ConstraintPredicate(val => Delay(val, delay));
            var constraintFalse = Value.Of(false).WithinTimeout(_timeout).ConstraintPredicate(val => Delay(val, delay));

            // Act
            var resultTrue = constraintTrue.Check();
            var resultFalse = constraintFalse.Check();

            // Assert
            Debug.WriteLine(constraintTrue.ErrorMessage);
            Debug.WriteLine(constraintFalse.ErrorMessage);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(resultTrue, "True");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(resultFalse, "False");
        }

        [Test]
        public void TestCheckNotWithinTimeout()
        {
            // Arrange
            var delay = _timeout + TimeSpan.FromMilliseconds(500);
            var constraintTrue = Value.Of(true).WithinTimeout(_timeout).ConstraintPredicate(val => Delay(val, delay));
            var constraintFalse = Value.Of(false).WithinTimeout(_timeout).ConstraintPredicate(val => Delay(val, delay));

            // Act
            var resultTrue = constraintTrue.Check();
            var resultFalse = constraintFalse.Check();

            // Assert
            Debug.WriteLine(constraintTrue.ErrorMessage);
            Debug.WriteLine(constraintFalse.ErrorMessage);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(resultTrue, "True");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(resultFalse, "False");
        }

        [Test]
        public void TestErrorMessage()
        {
            // Arrange
            var value = new object();
            object actual = null;
            var constraint = Value.Of(value).WithinTimeout(_timeout).GetErrorMessageValue(val => actual = val);

            // Act
            var dummy = constraint.ErrorMessage;

            // Assert
            Debug.WriteLine(constraint.ErrorMessage);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSame(value, actual);
        }
    }
}