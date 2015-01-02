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
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
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
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
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
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
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
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestAsCollectionIsEqualToMessageMissingItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EqualTo failed. Expected:<[1,2,3,4]>, Actual:<[1,2,4]>: Missing<[3]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionIsEqualToMessageExtraItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4};
			var expected = new[] {1, 2, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EqualTo failed. Expected:<[1,2,4]>, Actual:<[1,2,3,4]>: Extra<[3]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionIsEqualToMessageExtraAndMissingItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3};
			var expected = new[] {1, 2, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EqualTo failed. Expected:<[1,2,4]>, Actual:<[1,2,3]>: Missing<[4]>, Extra<[3]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionIsEqualToMessageExtraDuplicateItem()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 3};
			var expected = new[] {1, 2, 3};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EqualTo failed. Expected:<[1,2,3]>, Actual:<[1,2,3,3]>: Extra<[3]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionIsEqualToMessageOneOutOfOrder()
		{
			// Arrange
			var actual = new List<int> {1, 2, 5, 3, 4};
			var expected = new[] {1, 2, 3, 4, 5};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EqualTo failed. Expected:<[1,2,3,4,5]>, Actual:<[1,2,5,3,4]>: OutOfOrder<[5]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionIsEqualToMessageTwoOutOfOrderAdjacent()
		{
			// Arrange
			var actual = new List<int> {1, 2, 4, 3, 5};
			var expected = new[] {1, 2, 3, 4, 5};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EqualTo failed. Expected:<[1,2,3,4,5]>, Actual:<[1,2,4,3,5]>: OutOfOrder<[3,4]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionIsEqualToMessageTwoOutOfOrderNonAdjacent()
		{
			// Arrange
			var actual = new List<int> {5, 2, 3, 4, 1};
			var expected = new[] {1, 2, 3, 4, 5};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Is.EqualTo failed. Expected:<[1,2,3,4,5]>, Actual:<[5,2,3,4,1]>: OutOfOrder<[1,5]>");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}
