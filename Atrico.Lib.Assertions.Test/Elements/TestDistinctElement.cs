using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Assertions.Test._Helpers;
using Atrico.Lib.Testing.TestAttributes.NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test.Elements
{
    [TestFixture]
    public class TestDistinctElement
    {
        [Test]
        public void TestName()
        {
            // Arrange
            var collection = new[] {1, 5, 2, 3, 3, 4, 5, 1};

            var constraint = Value.Of(collection).Distinct().GetName();

            // Act
            var result = constraint.Name;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Distinct", result);
        }

        [Test]
        public void TestCheck()
        {
            // Arrange
            var collection = new[] {1, 5, 2, 3, 3, 4, 5, 1};
            IEnumerable<int> actual = null;
            var constraint = Value.Of(collection).Distinct().GetTestValue(val => actual = val);

            // Act
            constraint.Check();

            // Assert
            Debug.WriteLine(constraint.ErrorMessage);
            CollectionAssert.AreEquivalent(new List<int>(collection.Distinct()), new List<int>(actual));
        }

        [Test]
        public void TestErrorMessage()
        {
            // Arrange
            var collection = new[] {1, 5, 2, 3, 3, 4, 5, 1};
            IEnumerable<int> actual = null;
            var constraint = Value.Of(collection).Distinct().GetErrorMessageValue(val => actual = val);

            // Act
            var dummy = constraint.ErrorMessage;

            // Assert
            Debug.WriteLine(constraint.ErrorMessage);
            CollectionAssert.AreEquivalent(new List<int>(collection.Distinct()), new List<int>(actual));
        }
    }
}