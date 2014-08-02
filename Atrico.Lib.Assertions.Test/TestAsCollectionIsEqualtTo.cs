using System.Collections.Generic;
using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestAsCollectionIsEqualtTo
	{
		[Test]
		public void TestAsCollectionIsEqualToPassEqual()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionIsEqualToFailWrongOrder()
		{
			// Arrange
			var actual = new List<int> {1, 3, 2, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionIsEqualToFailMissingItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionIsEqualToFailExtraItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4, 5};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionIsEqualToFailWrongItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 2, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionIsEqualToMessage()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EqualTo failed. Expected:<[1,2,3,4]>, Actual:<[1,2,3]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}