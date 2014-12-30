using System.Collections.Generic;
using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestAsCollectionIsEquivalentTo
	{
		[Test]
		public void TestAsCollectionIsEquivalentToPassEqual()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionIsEquivalentToPassWrongOrder()
		{
			// Arrange
			var actual = new List<int> {1, 3, 2, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionIsEquivalentToFailMissingItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestAsCollectionIsEquivalentToFailExtraItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4, 5};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestAsCollectionIsEquivalentToFailWrongItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 2, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestAsCollectionIsEquivalentToMessageMissingItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EquivalentTo failed. Expected:<[1,2,3,4]>, Actual:<[1,2,4]>: Missing<[3]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionIsEquivalentToMessageExtraItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4};
			var expected = new[] {1, 2, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EquivalentTo failed. Expected:<[1,2,4]>, Actual:<[1,2,3,4]>: Extra<[3]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionIsEquivalentToMessageExtraAndMissingItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3};
			var expected = new[] {1, 2, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EquivalentTo failed. Expected:<[1,2,4]>, Actual:<[1,2,3]>: Missing<[4]>, Extra<[3]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionIsEquivalentToMessageExtraDuplicateItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 3};
			var expected = new[] {1, 2, 3};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EquivalentTo failed. Expected:<[1,2,3]>, Actual:<[1,2,3,3]>: Extra<[3]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}
