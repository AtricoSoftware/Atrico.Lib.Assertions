﻿using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Tests
{
    [TestFixture]
    public class TestIsTrue
    {
        [Test]
        public void TestIsTruePass()
        {
            // Arrange
            const bool actual = true;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().True()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsTrueFail()
        {
            // Arrange
            const bool actual = false;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().True()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsTrueMessage()
        {
            // Arrange
            const bool actual = false;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().True()));

            // Assert
            var expectedMsg = string.Format("Is.True failed.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestIsNotTruePass()
        {
            // Arrange
            const bool actual = false;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().True()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestIsNotTrueFail()
        {
            // Arrange
            const bool actual = true;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().True()));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
        }

        [Test]
        public void TestIsNotTrueMessage()
        {
            // Arrange
            const bool actual = true;

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().Not().True()));

            // Assert
            var expectedMsg = string.Format("Is.Not.True failed.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }

        [Test]
        public void TestIsTrueNullableFalse()
        {
            // Arrange
            bool? actual = false;
            var constraint = Value.Of(actual).Is().True();

            // Act
            var result = constraint.Check();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
        }

        [Test]
        public void TestIsTrueNullableTrue()
        {
            // Arrange
            bool? actual = true;
            var constraint = Value.Of(actual).Is().True();

            // Act
            var result = constraint.Check();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
        }

        public void TestIsTrueNullableNull()
        {
            // Arrange
            bool? actual = null;
            var constraint = Value.Of(actual).Is().True();

            // Act
            var result = constraint.Check();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
        }

    }
}